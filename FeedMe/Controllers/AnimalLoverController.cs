using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedMe.Controllers
{
    public class AnimalLoverController : Controller
    {
        AnimalLoverManager animalLoverManager = new AnimalLoverManager(new EfAnimalLoverDal());
        AnimalLoverValidator animalLoverValidator = new AnimalLoverValidator();
        // GET: AnimalLover
        public ActionResult Index()
        {
            var AnimalValues = animalLoverManager.GetList();
            return View(AnimalValues);
        }
        [HttpGet]
        public ActionResult AddAnimalLover()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddAnimalLover(AnimalLover animalLover)
        {

            ValidationResult results = animalLoverValidator.Validate(animalLover);
            if (results.IsValid)
            {
                animalLoverManager.AnimalLoverAdd(animalLover);
                return RedirectToAction("Index");
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
        public ActionResult DeleteAnimalLover(int id)
        {
            var animalLoverValues = animalLoverManager.GetById(id);
            animalLoverManager.AnimalLoverDelete(animalLoverValues);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAnimalLover(int id)
        {
            var animalLoverValue = animalLoverManager.GetById(id);
            return View(animalLoverValue);
        }
        [HttpPost]
        public ActionResult UpdateAnimalLover(AnimalLover animalLover)
        {
            ValidationResult results = animalLoverValidator.Validate(animalLover);
            if (results.IsValid)
            {
                animalLoverManager.AnimalLoverUpdate(animalLover);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View("Index");
        }
    }
}