using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedMe.Controllers
{
   
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        AnimalManager animalManager = new AnimalManager(new EfAnimalDal());
        AnimalLoverManager animalLoverManager = new AnimalLoverManager(new EfAnimalLoverDal());
        // GET: Heading
        [Authorize]
        public ActionResult Index(int p = 1)
        {
            var headingValues = headingManager.GetList().ToPagedList(p, 4);
            return View(headingValues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            //Dropdown List
            List<SelectListItem> valueAnimal = (from x in animalManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.AnimalName,
                                                    Value = x.AnimalId.ToString()
                                                }).ToList();
            List<SelectListItem> valueWriter = (from x in animalLoverManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.AnimalLoverName + " " + x.AnimalLoverSurName,
                                                    Value = x.AnimalLoverId.ToString()
                                                }).ToList();
            ViewBag.vlc = valueAnimal;
            ViewBag.vlw = valueWriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.HeadingStatus = true;
            headingManager.HeadingAdd(heading);
            return View("Index");
        }
        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> valueAnimal = (from x in animalManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.AnimalName,
                                                    Value = x.AnimalId.ToString()
                                                }).ToList();
            var headingValues = headingManager.GetById(id);
            ViewBag.vlc = valueAnimal;
            return View(headingValues);
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetById(id);
            headingValue.HeadingStatus = false;
            headingManager.HeadingDelete(headingValue);
            return RedirectToAction("index");
        }
    }
}