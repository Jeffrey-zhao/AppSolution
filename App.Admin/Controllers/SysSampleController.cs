using App.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.BLL;
using App.Models;
using App.Models.Sys;
using Microsoft.Practices.Unity;

namespace App.Admin.Controllers
{
    public class SysSampleController : Controller
    {
        // GET: SysSample
        [Dependency]
        public ISysSampleBLL m_BLL { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetList(int page = 1, int rows = 10, string sort = "Id", string order = "desc")
        {
            int total = 0;
            IEnumerable<SysSampleModel> list = m_BLL.GetList(page, rows, sort, order, ref total);
            var json = new
            {
                total = list.Count(),
                rows = (from r in list
                        select new SysSampleModel
                        {
                            Id = r.Id,
                            Name = r.Name,
                            Age = r.Age,
                            Bir = r.Bir,
                            Photo = r.Photo,
                            Note = r.Note,
                            CreateTime = r.CreateTime,
                        }).ToArray()
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}