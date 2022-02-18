using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FeedMe.Controllers
{
    
    [AllowAnonymous]
    public class LoginController : Controller
    {
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new AnimalLoverManager(new EfAnimalLoverDal()));
        AdminManager _adminManager = new AdminManager(new EfAdminDal());
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(AdminForLoginDto adminForLoginDto)
        {

            if (authService.AdminLogin(adminForLoginDto))
            {
                FormsAuthentication.SetAuthCookie(adminForLoginDto.AdminMail, false);
                Session["AdminMail"] = adminForLoginDto.AdminMail;
                var session = Session["AdminMail"];
                ViewBag.a = session;
                return RedirectToAction("Index", "Animal");
            }
            else
            {
                ViewData["Hata"] = "Kullanıcı adı veya parola yanlış lütfen tekrar deneyin.";
                return RedirectToAction("AdminLogin");
            }

        }
        public ActionResult AdminLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin", "Login");
        }
        [HttpGet]
        public ActionResult AnimalLoverLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AnimalLoverLogin(AnimalLover animalLover)
        {
            var Value = authService.AnimalLoverLogin(animalLover.AnimalLoverMail, animalLover.AnimalLoverPassword);
            if (Value != null)
            {
                FormsAuthentication.SetAuthCookie(Value.AnimalLoverMail, false);
                Session["AnimalLoverMail"] = Value.AnimalLoverMail;
                return RedirectToAction("MyHeading", "WriterPanel");
            }
            else
            {
                ViewData["Hata"] = "Kullanıcı adı veya parola yanlış lütfen tekrar deneyin.";
                return RedirectToAction("AnimalLoverLogin");

            }
        }
        public ActionResult AnimalLoverLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AnimalLoverLogin", "Login");
        }

    }
}