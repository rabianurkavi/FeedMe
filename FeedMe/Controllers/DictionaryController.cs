using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedMe.Controllers
{
    public class DictionaryController : Controller
    {
        // GET: Dictionary
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            var headinglist = headingManager.GetList();
            return View(headinglist);
        }
        public PartialViewResult Index(int id = 1)
        {
            var contentList = contentManager.GetListHeadingById(id);
            return PartialView(contentList);
        }
        
        

    }
}