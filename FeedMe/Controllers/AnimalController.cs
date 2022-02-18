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
    public class AnimalController : Controller
    {
        AnimalManager animalManager = new AnimalManager(new EfAnimalDal());
        AnimalValidator validationRules = new AnimalValidator();
        // GET: Animal
        [Authorize]
        public ActionResult Index()
        {
            var animalValues = animalManager.GetList();
            return View(animalValues);
        }
        [HttpGet]
        public ActionResult AddAnimal()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAnimal(Animal animal)
        {
            ValidationResult results = validationRules.Validate(animal);
            if (results.IsValid)
            {
                animalManager.AnimalAdd(animal);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAnimal(int id)
        {
            var animalValues = animalManager.GetById(id);
            animalManager.AnimalDelete(animalValues);
            return View("Index");

        }
        [HttpGet]
        public ActionResult UpdateAnimal(int id)
        {
            var animalValue = animalManager.GetById(id);
            return View(animalValue);
        }
        [HttpPost]
        public ActionResult UpdateAnimal(Animal animal)
        {
            ValidationResult results = validationRules.Validate(animal);
            if (results.IsValid)
            {
                animalManager.AnimalUpdate(animal);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("Index");
        }
    }
}