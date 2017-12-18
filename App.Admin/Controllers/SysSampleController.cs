using App.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.BLL;
using App.Common;
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
        //index get
        public ActionResult Index()
        {
            return View();
        }
        //index post
        [HttpPost]
        public JsonResult GetList(GridPager pager,string queryStr="")
        {
            //if (string.IsNullOrWhiteSpace(queryStr))
            //{
            //    queryStr = "";
            //}
            IEnumerable<SysSampleModel> list = m_BLL.GetList(ref pager,queryStr);
            var json = new
            {
                total = pager.TotalRows,
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

        //create get
        public ActionResult Create()
        {
            return View();
        }

        //create post
        [HttpPost]
        public JsonResult Create(SysSampleModel model)
        {
            if (m_BLL.Create(model))
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

        //edit get
        public ActionResult Edit(string id)
        {
            SysSampleModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        //edit post
        [HttpPost]
        public JsonResult Edit(SysSampleModel model)
        {
            if (m_BLL.Edit(model))
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

        //delete post
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (m_BLL.Delete(id))
                {
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    return Json(0, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

        //details get
        public ActionResult Details(string id)
        {
            SysSampleModel entity = m_BLL.GetById(id);
            return View(entity);
        }
    }
}