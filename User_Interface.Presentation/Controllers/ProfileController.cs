using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;
using Data;
using User_Interface.Presentation.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace User_Interface.Presentation.Controllers
{
    [Authorize(Roles = "user")]
    public class ProfileController : Controller
    {
        UnitOfWork UnitOfWork;
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<IdentityUser> _userManager;


        public ProfileController(ILogger<AccountController> logger, UserManager<IdentityUser> userManager, UnitOfWork uow)
        {
            _logger = logger;
            _userManager = userManager;
            UnitOfWork = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Cities = new SelectList(UnitOfWork.Cities.GetAll(), "CityId", "city") ;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDataViewModel udvm)
        {
            var user = _userManager.GetUserId(HttpContext.User);
            if (UnitOfWork.Users.Get(user) == null) {
                User newuser = new User { IdentityId = user, UserProductsList = new UserProductsList { Products = new List<Product>() }, Cart = new ShoppingCart { Cartlines = new List<Cartline>() } };
            UnitOfWork.Users.Create(newuser);
            List<Phone> phones = new List<Phone> { new Phone { phone = udvm.Phone } };
            List<Email> emails = new List<Email> { new Email { email = udvm.Email } };
            UserData usd = new UserData { City = UnitOfWork.Cities.Get(udvm.City.CityId), Name = udvm.Name, Emails = emails, Phones = phones , UserId = newuser.UserId };
            UnitOfWork.UserDataList.Create(usd);
            await UnitOfWork.Save();
            }
            else
            {
                if (UnitOfWork.UserDataList.GetByUser(UnitOfWork.Users.Get(user).UserId) == null) {
                    List<Phone> phones = new List<Phone> { new Phone { phone = udvm.Phone } };
                    List<Email> emails = new List<Email> { new Email { email = udvm.Email } };
                    UserData usd = new UserData { City = udvm.City, Name = udvm.Name, Emails = emails, Phones = phones, UserId = UnitOfWork.Users.Get(user).UserId };
                    UnitOfWork.UserDataList.Create(usd);
                    await UnitOfWork.Save();
                    return RedirectToAction("Products", "Home");
                }
                else
                {
                    return RedirectToAction("MyAccount");
                }
            }
            return RedirectToAction("Products", "Home");
        }

        public IActionResult MyAccount()
        {
            var user =  _userManager.GetUserId(HttpContext.User);
            if (UnitOfWork.Users.Get(user) !=null)
            {
                UnitOfWork.Cities.GetAll().ToList();
                var usd = UnitOfWork.Users.Get(user);
                var userData = UnitOfWork.UserDataList.GetByUser(usd.UserId);
                UserDataViewModel udvm = new UserDataViewModel { Name = userData.Name, City = userData.City, Emails = userData.Emails, Phones = userData.Phones };
                ViewBag.Id = UnitOfWork.UserDataList.GetByUser(UnitOfWork.Users.Get(user).UserId).UserDataId;
                return View(udvm);
            }
            else
                return RedirectToAction("Register", "Account");
        }

        [HttpGet]
        public IActionResult Edit(Guid? id)
        {
            ViewBag.Cities = new SelectList(UnitOfWork.Cities.GetAll(), "CityId", "city");
            UserData data = UnitOfWork.UserDataList.Get(id);
            ViewBag.Id = data.UserDataId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserDataViewModel udvm, Guid? id)
        {
            UserData da = UnitOfWork.UserDataList.Get(id);
            da.Phones.Add(new Phone { phone = udvm.Phone });
            da.Emails.Add(new Email { email = udvm.Email });
            da.Name = udvm.Name;
            da.City = UnitOfWork.Cities.Get(udvm.City.CityId);
            UnitOfWork.UserDataList.Update(da);
            await UnitOfWork .Save();
            return RedirectToAction("MyAccount");

        }
    }
}
