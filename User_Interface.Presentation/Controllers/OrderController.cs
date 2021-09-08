using Data;
using Domain.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using User_Interface.Presentation.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace User_Interface.Presentation.Controllers
{
    [Authorize(Roles = "user")]
    public class OrderController : Controller
    {
        UnitOfWork UnitOfWork;
        private readonly ILogger<OrderController> _logger;
        private readonly UserManager<IdentityUser> _userManager;

        public OrderController(ILogger<OrderController> logger, UserManager<IdentityUser> userManager, UnitOfWork uow)
        {
            _logger = logger;
            _userManager = userManager;
            UnitOfWork = uow;
        }
        public IActionResult Orders()
        {
            
            var user = _userManager.GetUserId(HttpContext.User);
            User us = UnitOfWork.Users.Get(user);
            if (UnitOfWork.Orders.GetAll().Where(x => x.UserId == us.UserId) != null)
            {
                IEnumerable<Order> orders = UnitOfWork.Orders.GetAll().Where(x => x.UserId == us.UserId);
                return View(orders);
            }
            else
                return RedirectToAction("Products", "Home");
        }

        public IActionResult Index(Guid id)
        {
            Order order = UnitOfWork.Orders.Get(id);
            ViewBag.Id = order.OrderId;
            OrderViewModel ovm = new OrderViewModel { Address = order.Address, City = order.City, Comment = order.Comment, Date = order.Date, Name = order.Name, lines = order.lines, SumCost = order.SumCost };
            return View(ovm);
        }

        [HttpGet]
        public IActionResult CreateOrder(Guid? buy)
        {
            if (UnitOfWork.Users.Get(buy).Cart == null) return RedirectToAction("Products", "Home");
            else
            {
                User buyer = UnitOfWork.Users.Get(buy);
                var cart = buyer.Cart;
                OrderViewModel ovm = new OrderViewModel { cart = cart, Date = DateTime.Now, User = buyer };
                return View(ovm);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderViewModel ovm)
        {
            Order order = new Order { Name = ovm.Name, City = ovm.City, Address = ovm.Address, Comment = ovm.Comment, Date = ovm.Date, lines = (List<Cartline>)ovm.cart.Lines, UserId = ovm.User.UserId };
            UnitOfWork.ShoppingCarts.Delete(ovm.cart.ShoppingCartId);
            var user = UnitOfWork.Users.GetAll().Where(x => x.Cart.ShoppingCartId == ovm.cart.ShoppingCartId).FirstOrDefault();
            user.Cart = new ShoppingCart { Cartlines = new List<Cartline>() };
            UnitOfWork.Users.Update(user);
            UnitOfWork.Orders.Create(order);
            await UnitOfWork.Save();
            return View("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid? id)
        {
            IEnumerable<City> cit = UnitOfWork.Cities.GetAll();
            ViewBag.Cities = new SelectList(cit, "CityId", "city");
            Order order = UnitOfWork.Orders.Get(id);
            ViewBag.Id = order.OrderId;
            OrderViewModel ovm = new OrderViewModel { Address = order.Address, lines = order.lines, City = order.City, Comment = order.Comment, Name = order.Name };
            return View(ovm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OrderViewModel ovm, Guid id)
        {
            Order ord = UnitOfWork.Orders.Get(id);
            ord.Name = ovm.Name;
            ord.City = ovm.City;
            ord.Address = ovm.Address;
            ord.Date = ovm.Date;
            ord.lines = (List<Cartline>)ovm.lines;
            UnitOfWork.Orders.Update(ord);
            await UnitOfWork.Save();
            return View("Index");
        }

    }
}
