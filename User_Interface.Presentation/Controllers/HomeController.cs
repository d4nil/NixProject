using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using User_Interface.Presentation.Models;
using Data;
using Domain.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace User_Interface.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork UnitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, UnitOfWork unw)
        {
            _logger = logger;
            _userManager = userManager;
            UnitOfWork = unw;
        }
        
        [Authorize]
        public async Task<IActionResult> Products(Guid? id, Guid? category, string name, int page = 1)
        {
            IEnumerable<Product> products = UnitOfWork.Products.GetAll();
            ProductsViewModel productsView = new ProductsViewModel();
            var user =  _userManager.GetUserId(HttpContext.User);
            if(UnitOfWork.Users.Get(user) == null)
            {
                User newuser = new User { IdentityId = user };
                productsView.BuyerId = newuser.UserId;
                UnitOfWork.Users.Create(newuser);
                await UnitOfWork.Save();
                
            }
            else 
            {
                productsView.BuyerId = UnitOfWork.Users.Get(user).UserId;

            }

            if (category != null)
            {
                products =  products.Where(p => p.Category.CategoryId == category);
            }
            if (!String.IsNullOrEmpty(name))
            {
                products = products.Where(p => p.PName.Contains(name));
            }

            List<Category> categories = UnitOfWork.Categories.GetAll().ToList();
            categories.Insert(0, new Category { Name = "Все"});
            ViewBag.Categories = new SelectList(categories, "CategoryId", "Name");
            int pageSize = 8;
            var count =  products.Count();
            var items =  products.Skip((page - 1) * pageSize).Take(pageSize);
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            productsView.PageViewModel = pageViewModel;
            productsView.Products = products;
            productsView.Users = UnitOfWork.Users.GetAll();
            return View(productsView);
        }

        [Authorize(Roles = "user")]
        public IActionResult ShowProduct(Guid id, Guid buyerid)
        {
            
                Product prod = UnitOfWork.Products.Get(id);
                ViewBag.ProdId = prod.ProductId;
                User sell = UnitOfWork.Users.Get(buyerid);
                ProductViewModel pvm = new ProductViewModel {PName = prod.PName, Category = prod.Category, Condition = prod.Condition, Cost = prod.Cost, Producer = prod.Producer, ProductDescription = prod.ProductDescription,Username = sell.UserData.Name, SubCategory = prod.Subcategory, BuyerId = buyerid};
                return View(pvm);
            

        }

        public IActionResult Index()
        {
            return View(UnitOfWork.Categories.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
