using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedMe.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());
        // GET: Gallery
        public ActionResult Index()
        {
            var imageValues = imageFileManager.GetList();
            return View(imageValues);
        }
        public ActionResult AdminLayoutIndex()
        {
            var imageValues = imageFileManager.GetList();
            return View(imageValues);
        }
    }
}