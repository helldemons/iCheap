using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iCheap.WebApp.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Origin()
        {
            return View();
        }

        public ActionResult Brand()
        {
            return View();
        }

        public ActionResult Category()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }

        public ActionResult BlogCategory()
        {
            return View();
        }
    }
}