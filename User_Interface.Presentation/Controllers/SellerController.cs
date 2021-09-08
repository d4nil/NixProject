using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User_Interface.Presentation.Models;
using Data;
using Domain.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace User_Interface.Presentation.Controllers
{
    [Authorize(Roles = "user")]
    public class SellerController : Controller
    {
        UnitOfWork UnitOfWork;
        private readonly ILogger<SellerController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public SellerController(ILogger<SellerController> logger, UserManager<IdentityUser> userManager, UnitOfWork uow)
        {
            _logger = logger;
            _userManager = userManager;
            UnitOfWork = uow;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product prod)
        {
            if(UnitOfWork.Users.Get(prod.UserId).UserProductsList.Products == null)
            {
                UserProductsList upl = new UserProductsList { Products = new List<Product>() };
                UnitOfWork.Users.Get(prod.UserId).UserProductsList = upl;
                UnitOfWork.Users.Update(UnitOfWork.Users.Get(prod.UserId));
                

            }
            prod.Category = UnitOfWork.Categories.Get(prod.Category.CategoryId);
            prod.Subcategory = UnitOfWork.Categories.Get(prod.Subcategory.CategoryId);
            prod.Producer = UnitOfWork.Producers.Get(prod.Producer.ProducerId);
            UnitOfWork.Users.Get(prod.UserId).AddProduct(prod);
            UnitOfWork.Products.Create(prod);
            UnitOfWork.Users.Update(UnitOfWork.Users.Get(prod.UserId));
            await UnitOfWork.Save();
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            var user = _userManager.GetUserId(HttpContext.User);
            if (UnitOfWork.Users.Get(user) != null)
            {
                ViewBag.Categories = new SelectList(UnitOfWork.Categories.GetAll().ToList().Where(x=>x.ParentCategory == null), "CategoryId", "Name");
                ViewBag.SubCategories = new SelectList(UnitOfWork.Categories.GetAll().ToList().Where(x => x.ParentCategory != null), "CategoryId", "Name");
                ViewBag.Producers = new SelectList(UnitOfWork.Producers.GetAll(), "ProducerId", "Name");
                ViewBag.Id = UnitOfWork.Users.Get(user).UserId;
                return View();
            }
            return RedirectToAction("Register", "Account");

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductList()
        {

            var user =  _userManager.GetUserId(HttpContext.User);
            var usd = UnitOfWork.Users.Get(user);
            var userpro = usd.UserData;
            ProductsViewModel pvm = new ProductsViewModel { Products = UnitOfWork.Products.GetAll().Where(x=>x.UserId == usd.UserId), UserId = UnitOfWork.Users.Get(user).UserId };
            return View(pvm);
        }

        [HttpGet]
        public IActionResult EditProduct(Guid? id)
        {

            var product = UnitOfWork.Products.Get(id);
            ViewBag.Categories = new SelectList(UnitOfWork.Categories.GetAll().Where(x => x.ParentCategory == null), "CategoryId", "Name");
            ViewBag.SubCategories = new SelectList(UnitOfWork.Categories.GetAll().Where(x => x.ParentCategory != null), "CategoryId", "Name");
            ViewBag.Producers = new SelectList(UnitOfWork.Categories.GetAll(), "ProducerId", "Name");
            ProductViewModel pvm = new ProductViewModel ();
            ViewBag.SelId = product.UserId;
            return View(pvm);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductViewModel pvm)
        {
            Product prod = UnitOfWork.Products.GetByUser(pvm.BuyerId);
            prod.Category = pvm.Category;
            prod.ProductDescription = pvm.ProductDescription;
            prod.Producer = pvm.Producer;
            prod.Cost = pvm.Cost;
            prod.PName = pvm.PName;
            prod.Condition = prod.Condition;
            UnitOfWork.Products.Update(prod);
            await UnitOfWork.Save();
            return View("ProductList");
        }

        public IActionResult Delete(Guid? id)
        {
            UnitOfWork.Products.Delete(id);
            return View("ProductList");
        }
    }
}
