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
    public class GateController : Controller
    {
        // GET: Gate
        GateManager gateManager = new GateManager(new EfGateDal());
        NeighborhoodManager neighborhoodManager = new NeighborhoodManager(new EfNeighborhoodDal());
        [HttpGet]
        public ActionResult GateAdd()
        {
            List<SelectListItem> valueNeighborhood = (from x in neighborhoodManager.GetList()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.NeighborhoodName,
                                                          Value = x.NeighborhoodId.ToString()
                                                      }).ToList();
            ViewBag.vnn = valueNeighborhood;

            return View();
        }
        [HttpPost]
        public ActionResult GateAdd(Gate gate)
        {
            GateValidator gateValidator = new GateValidator();
            ValidationResult results = gateValidator.Validate(gate);
            if (results.IsValid)
            {

                gateManager.GateAdd(gate);
                return RedirectToAction("GetListCoordinate", "Gate");
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
        public ActionResult GetListCoordinate()
        {
            var coordinate = gateManager.GetList().Select(x => x.GateCoordinate);
            string value = "";
            foreach (var item in coordinate)
            {
                value += item + ";";
            }
            ViewBag.ci = value;

            return View();
        }
        public ActionResult GetListCoordinateAdmin()
        {
            var coordinate = gateManager.GetList().Select(x => x.GateCoordinate);
            string value = "";
            foreach (var item in coordinate)
            {
                value += item + ";";
            }
            ViewBag.ci = value;

            return View();
        }
        public ActionResult GetListAdmin()
        {
            var gateValues = gateManager.GetList();

            return View(gateValues);
        }
        //public ActionResult GetByIdAdmin()
        //{

        //}
        public ActionResult GetList()
        {
            var gateValues = gateManager.GetList();

            return View(gateValues);
        }
        public ActionResult GetById(int id)
        {
            var cordinateid = gateManager.GetById(id);
            ViewBag.ci = cordinateid.GateCoordinate;
            return View();
        }
        public ActionResult GetByIdAdmin(int id)
        {
            var cordinateid = gateManager.GetById(id);
            ViewBag.ci = cordinateid.GateCoordinate;
            return View();
        }

        [HttpGet]
        public ActionResult GateEdit(int id)
        {
            List<SelectListItem> valueNeighborhood = (from x in neighborhoodManager.GetList()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.NeighborhoodName,
                                                          Value = x.NeighborhoodId.ToString()
                                                      }).ToList();
            ViewBag.vnn = valueNeighborhood;
            var gateValue = gateManager.GetById(id);
            return View(gateValue);
        }
        [HttpPost]
        public ActionResult GateEdit(Gate gate)
        {
            gateManager.GateUpdate(gate);
            return RedirectToAction("GetListAdmin");
        }
        public ActionResult GateDelete(int id)
        {
            var deleteValue = gateManager.GetById(id);
            gateManager.GateDelete(deleteValue);
            return RedirectToAction("GateGetList");
        }
        [HttpGet]
        public ActionResult GateAddAdmin()
        {
            List<SelectListItem> valueNeighborhood = (from x in neighborhoodManager.GetList()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.NeighborhoodName,
                                                          Value = x.NeighborhoodId.ToString()
                                                      }).ToList();
            ViewBag.vnn = valueNeighborhood;

            return View();
        }
        [HttpPost]
        public ActionResult GateAddAdmin(Gate gate)
        {
            GateValidator gateValidator = new GateValidator();
            ValidationResult results = gateValidator.Validate(gate);
            if (results.IsValid)
            {

                gateManager.GateAdd(gate);
                return RedirectToAction("GetListCoordinateAdmin", "Gate");
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
    }
}