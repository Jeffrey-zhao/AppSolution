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
using App.Admin.Core;

namespace App.Admin.Controllers
{
    public class SysSampleController : BaseController
    {
        // GET: SysSample
        [Dependency]
        public ISysSampleBLL m_BLL { get; set; }
        //index get
        public ActionResult Index()
        {
            return View();
        }
        [SupportFilter(ActionName ="Index")]
        //index post
        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr = "")
        {
            IEnumerable<SysSampleModel> list = m_BLL.GetList(ref pager, queryStr);
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
        [SupportFilter]
        //create get
        public ActionResult Create()
        {
            return View();
        }

        //create post
        [HttpPost]
        public JsonResult Create(SysSampleModel model)
        {
            ValidationErrors errors = new ValidationErrors();
            if (m_BLL.Create(ref errors, model))
            {
                LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name, "成功", "创建", "样例程序");
                return Json(JsonHandler.CreateMessage(1, "插入成功"), JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name + "," + ErrorCol, "失败", "创建", "样例程序");
                return Json(JsonHandler.CreateMessage(0, "插入失败" + "\n" + ErrorCol), JsonRequestBehavior.AllowGet);
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
            ValidationErrors errors = new ValidationErrors();
            if (m_BLL.Edit(ref errors,model))
            {
                LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name, "成功", "编辑", "样例程序");
                return Json(JsonHandler.CreateMessage(1, "编辑成功"), JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog("虚拟用户", "Id:" + model.Id + ",Name:" + model.Name + "," + ErrorCol, "失败", "编辑", "样例程序");
                return Json(JsonHandler.CreateMessage(0, "编辑失败" + "\n" + ErrorCol), JsonRequestBehavior.AllowGet);
            }
        }

        //delete 
        public JsonResult Delete(string id)
        {
            ValidationErrors errors = new ValidationErrors();
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (m_BLL.Delete(ref errors,id))
                {
                    LogHandler.WriteServiceLog("虚拟用户", "Id:" + id + ",", "成功", "删除", "样例程序");
                    return Json(JsonHandler.CreateMessage(1, "删除成功"), JsonRequestBehavior.AllowGet);
                }
                else
                {

                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog("虚拟用户", "Id:" + id + "," + ErrorCol, "失败", "删除", "样例程序");
                    return Json(JsonHandler.CreateMessage(0, "删除失败" + "\n" + ErrorCol), JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog("虚拟用户", "Id:" + id + "," + ErrorCol, "失败", "删除", "样例程序");
                return Json(JsonHandler.CreateMessage(0, "删除失败" + "\n" + ErrorCol), JsonRequestBehavior.AllowGet);
            }
        }

        //details get
        public ActionResult Details(string id)
        {
            SysSampleModel entity = m_BLL.GetById(id);
            return View(entity);
        }
        [SupportFilter]
        public ActionResult Test()
        {
            return View();
        }
    }
}