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
            User User = UnitOfWork.Users.Get(prod.UserId);
            User.AddProduct(prod);
            UnitOfWork.Products.Create(prod);
            UnitOfWork.Users.Update(User);
            await UnitOfWork.Save();
            return View("ProductList");
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (UnitOfWork.Users.Get(user.Id) != null)
            {
                User olduser = UnitOfWork.Users.Get(user.Id);
                ViewBag.Categories = new SelectList(UnitOfWork.Categories.GetAll().Where(x=>x.ParentCategory == null), "CategoryId", "Name");
                ViewBag.SubCategories = new SelectList(UnitOfWork.Categories.GetAll().Where(x => x.ParentCategory != null), "CategoryId", "Name");
                ViewBag.Producers = new SelectList(UnitOfWork.Producers.GetAll(), "ProducerId", "Name");
                ViewBag.Id = olduser.UserId;
                return View();
            }
            return RedirectToAction("Register", "Account");

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ProductList()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            User User = UnitOfWork.Users.Get(user.Id);
            IEnumerable<Product> products =  UnitOfWork.Products.GetAll().Where(x=>x.UserId == User.UserId);
            ProductsViewModel pvm = new ProductsViewModel { Products = products, UserId = User.UserId };
            return View(pvm);
        }

        [HttpGet]
        public IActionResult EditProduct(Guid? id)
        {

            Product product = UnitOfWork.Products.Get(id);
            ViewBag.Categories = new SelectList(UnitOfWork.Categories.GetAll().Where(x => x.ParentCategory == null), "CategoryId", "Name");
            ViewBag.SubCategories = new SelectList(UnitOfWork.Categories.GetAll().Where(x => x.ParentCategory != null), "CategoryId", "Name");
            ViewBag.Producers = new SelectList(UnitOfWork.Categories.GetAll(), "ProducerId", "Name");
            ProductViewModel pvm = new ProductViewModel { Category = product.Category, Condition = product.Condition, Cost = product.Cost, PName = product.PName, Producer = product.Producer, ProductDescription = product.ProductDescription};
            ViewBag.SelId = product.UserId;
            return View(pvm);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductViewModel pvm,Guid selid)
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
