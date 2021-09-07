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
            ViewBag.Cities = new SelectList(UnitOfWork.Cities.GetAll(), "CityId", "city");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDataViewModel udvm)
        {
            var user = _userManager.GetUserId(HttpContext.User);
            User newuser = new User { IdentityId = user };
            UnitOfWork.Users.Create(newuser);
            List<Phone> phones = new List<Phone> { new Phone { phone = udvm.Phone } };
            List<Email> emails = new List<Email> { new Email { email = udvm.Email } };
            City city = new City { city = udvm.City.city };
            UserData usd = new UserData { City = city, Name = udvm.Name, Emails = emails, Phones = phones , UserId = newuser.UserId };
            UnitOfWork.UserDataList.Create(usd);
            await UnitOfWork.Save();
            return RedirectToAction("Products", "Home");
        }

        public IActionResult MyAccount()
        {
            var user =  _userManager.GetUserId(HttpContext.User);
            if (UnitOfWork.Users.Get(user) !=null)
            {
                User olduser = UnitOfWork.Users.Get(user);
                if(UnitOfWork.UserDataList.GetByUser(olduser.UserId) == null) { return RedirectToAction("Create"); }
                UserData data = UnitOfWork.UserDataList.GetByUser(olduser.UserId);
                UserDataViewModel udvm = new UserDataViewModel { Name = data.Name, City = data.City, Emails = data.Emails, Phones = data.Phones };
                ViewBag.Id = data.UserDataId;
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
            da.City = udvm.City;
            UnitOfWork.UserDataList.Update(da);
            await UnitOfWork .Save();
            return RedirectToAction("MyAccount");

        }
    }
}
