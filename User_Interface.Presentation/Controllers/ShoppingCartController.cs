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
            User us = UnitOfWork.Users.Get(user.Id);
            ShoppingCart cart = UnitOfWork.ShoppingCarts.GetByUser(us.UserId);
            ShoppingCartViewModel scvm = new ShoppingCartViewModel { lines = cart.Lines, TotalCostAllProducts = cart.TotalCostAllProducts };
            return View(scvm);
        }

        [Authorize]
        public async Task<IActionResult> AddToCart(Guid? pid, Guid BuyId)
        {
            Product product = UnitOfWork.Products.Get(pid);
            if(UnitOfWork.ShoppingCarts.GetByUser(BuyId) != null) { 
            ShoppingCart cart = UnitOfWork.ShoppingCarts.GetByUser(BuyId);
            cart.AddItem(product);
            cart.ComputeTotalCostAllProducts();
                UnitOfWork.ShoppingCarts.Update(cart);
                await UnitOfWork.Save();
            }
            else 
            {
                ShoppingCart cart = new ShoppingCart { BuyerId = BuyId };
                cart.AddItem(product);
                cart.ComputeTotalCostAllProducts();
                UnitOfWork.ShoppingCarts.Create(cart);
                await UnitOfWork.Save();
            }
            return RedirectToAction("Products", "Home");
        }

        [Authorize]
        public IActionResult RemoveFromCart(Guid id, Guid BuyerId)
        {
            Product product = UnitOfWork.Products.Get(id);
            ShoppingCart cart = UnitOfWork.ShoppingCarts.GetByUser(BuyerId);
            cart.RemoveLine(product);
            UnitOfWork.ShoppingCarts.Update(cart);
            return RedirectToAction("Index");
        }


      
    }
}

