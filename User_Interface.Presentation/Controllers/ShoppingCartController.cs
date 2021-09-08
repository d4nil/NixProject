using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Domain.Core;
using Data;
using System.Web;
using User_Interface.Presentation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace User_Interface.Presentation.Controllers
{

    [Authorize(Roles = "user")]
    public class ShoppingCartController : Controller
    {
        Context db;
        UnitOfWork UnitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly ILogger<ShoppingCartController> _logger;

        public ShoppingCartController(ILogger<ShoppingCartController> logger, Context context, UserManager<IdentityUser> userManager, UnitOfWork uow)
        {
            _logger = logger;
            db = context;
            _userManager = userManager;
            UnitOfWork = uow;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var us = UnitOfWork.Users.Get(user.Id);
            ShoppingCartViewModel scvm = new ShoppingCartViewModel { lines = us.Cart.Lines, TotalCostAllProducts = us.Cart.TotalCostAllProducts };
            return View(scvm);
        }

        [Authorize]
        public async Task<IActionResult> AddToCart(Guid? pid, Guid? BuyId)
        {
            Product product = UnitOfWork.Products.Get(pid);
            var user = UnitOfWork.Users.Get(BuyId);
            if (user.Cart != null) { 
            var cart = UnitOfWork.Users.Get(BuyId).Cart;
            cart.AddItem(product);
            cart.ComputeTotalCostAllProducts();
                UnitOfWork.ShoppingCarts.Update(cart);
                await UnitOfWork.Save();
            }
            else 
            {
                UnitOfWork.Users.Get(BuyId).Cart = new ShoppingCart {  Cartlines = new List<Cartline>()  };
                UnitOfWork.Users.Get(BuyId).Cart.AddItem(product);
                UnitOfWork.Users.Get(BuyId).Cart.ComputeTotalCostAllProducts();
                UnitOfWork.ShoppingCarts.Create(UnitOfWork.Users.Get(BuyId).Cart);
                user.Cart = UnitOfWork.Users.Get(BuyId).Cart;
                UnitOfWork.Users.Update(user);
                await UnitOfWork.Save();
            }
            return RedirectToAction("Products", "Home");
        }

        [Authorize]
        public IActionResult RemoveFromCart(Guid id, Guid? BuyerId)
        {
            Product product = UnitOfWork.Products.Get(id);
            UnitOfWork.Users.Get(BuyerId).Cart.RemoveLine(product);
            UnitOfWork.ShoppingCarts.Update(UnitOfWork.Users.Get(BuyerId).Cart);
            return RedirectToAction("Index");
        }


      
    }
}

