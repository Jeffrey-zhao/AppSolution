using App.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Admin.Areas.MIS.Controllers
{
    public class ManageArticleController : BaseController
    {
        // GET: MIS/ManageArticle
        public ActionResult Index()
        {
            return View();
        }
    }
}