using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedMe.Controllers.WriterPanelController
{
    public class WriterPanelController : Controller
    {
        AnimalManager animalManager = new AnimalManager(new EfAnimalDal());
        // GET: WriterPanel
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        FeedMeContext feedMeContext = new FeedMeContext();
        AnimalLoverManager animalLoverManager = new AnimalLoverManager(new EfAnimalLoverDal());
        // GET: WriterPanel
        [HttpGet]
        public ActionResult AnimalLoverProfile(int id = 0)
        {
            string p = (string)Session["AnimalLoverMail"];
            id = feedMeContext.AnimalLovers.Where(x => x.AnimalLoverMail == p).Select(y => y.AnimalLoverId).FirstOrDefault();
            var writervalue = animalLoverManager.GetById(id);
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult AnimalLoverProfile(AnimalLover animalLover)
        {
            AnimalLoverValidator animalLoverValidator = new AnimalLoverValidator();
            ValidationResult results = animalLoverValidator.Validate(animalLover);
            if (results.IsValid)
            {
                animalLoverManager.AnimalLoverUpdate(animalLover);
                return RedirectToAction("AllHeading", "WriterPanel");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();

        }
        public ActionResult GetByIdHeading(int id)
        {
            var list = headingManager.GetListByAnimalLoverId(id);
            return View(list);
        }
        public ActionResult MyHeading(string p)
        {

            p = (string)Session["AnimalLoverMail"];
            var writerIdInfo = feedMeContext.AnimalLovers.Where(x => x.AnimalLoverMail == p).Select(y => y.AnimalLoverId).FirstOrDefault();
            var headingValues = headingManager.GetListByAnimalLoverId(writerIdInfo);
            return View(headingValues);
        }
        public ActionResult AllHeading(int p = 1)
        {
            var headings = headingManager.GetList().ToPagedList(p, 4);
            return View(headings);
        }
    }
}