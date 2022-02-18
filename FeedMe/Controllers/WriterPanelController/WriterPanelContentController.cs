using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedMe.Controllers.WriterPanelController
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        FeedMeContext feedMeContext = new FeedMeContext();
        // GET: WriterPanelContent
        public ActionResult MyContent(string p)
        {

            p = (string)Session["AnimalLoverMail"];
            var animalLoverIdInfo = feedMeContext.AnimalLovers.Where(x => x.AnimalLoverMail == p).Select(y => y.AnimalLoverId).FirstOrDefault();
            var contentValues = contentManager.GetListByAnimalLover(animalLoverIdInfo);
            return View(contentValues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["AnimalLoverMail"];
            var animalLoverIdInfo = feedMeContext.AnimalLovers.Where(x => x.AnimalLoverMail == mail).Select(y => y.AnimalLoverId).FirstOrDefault();
            var contentValues = contentManager.GetListByAnimalLover(animalLoverIdInfo);
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.AnimalLoverId = animalLoverIdInfo;
            content.ContentStatus = true;
            contentManager.ContentAdd(content);
            return RedirectToAction("MyContent");
        }
        
    }
}