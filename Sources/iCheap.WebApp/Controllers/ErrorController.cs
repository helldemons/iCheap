﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iCheap.WebApp.Controllers
{
    public class ErrorController : BaseController
    {
        // GET: Error
        public ActionResult NotFound()
        {
            return View();
        }
    }
}