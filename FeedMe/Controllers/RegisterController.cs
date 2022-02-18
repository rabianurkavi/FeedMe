using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedMe.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        IAuthService _authService = new AuthManager(new AdminManager(new EfAdminDal()), new AnimalLoverManager(new EfAnimalLoverDal()));
        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AdminForLoginDto adminForLoginDto)
        {
            _authService.AdminRegister(adminForLoginDto.AdminUserName, adminForLoginDto.AdminMail, adminForLoginDto.AdminPassword);
            return RedirectToAction("Index", "Animal");
        }
    }
}