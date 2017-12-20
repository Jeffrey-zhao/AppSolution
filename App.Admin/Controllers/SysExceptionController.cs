using App.Admin.Core;
using App.Common;
using App.DAL;
using App.Models;
using App.Models.Sys;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Admin.Controllers
{
    public class SysExceptionController : BaseController
    {
        [Dependency]
        public ISysExceptionBLL exceptionBLL { get; set; }
        // GET: SysException
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<SysException> list = exceptionBLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.TotalRows,
                rows = (from r in list
                        select new SysException()
                        {
                            Id = r.Id,
                            HelpLink = r.HelpLink,
                            Message = r.Message,
                            Source = r.Source,
                            StackTrace = r.StackTrace,
                            TargetSite = r.TargetSite,
                            Data = r.Data,
                            CreateTime = r.CreateTime
                        }).ToArray()

            };
            return Json(json);
        }

        #region 详细

        public ActionResult Details(string id)
        {

            SysException entity = exceptionBLL.GetById(id);
            SysExceptionModel info = new SysExceptionModel()
            {
                Id = entity.Id,
                HelpLink = entity.HelpLink,
                Message = entity.Message,
                Source = entity.Source,
                StackTrace = entity.StackTrace,
                TargetSite = entity.TargetSite,
                Data = entity.Data,
                CreateTime = entity.CreateTime,
            };
            return View(info);
        }

        #endregion

        #region 删除
        [HttpPost]
        public JsonResult Delete(string id)
        {
            ValidationErrors errors = new ValidationErrors();
            if (id != null)
            {
                if (exceptionBLL.Delete(ref errors, id))
                {
                    LogHandler.WriteServiceLog("虚拟用户", "Id:" + id + ",", "成功", "删除", "异常程序");
                    return Json(JsonHandler.CreateMessage(1, "删除成功"), JsonRequestBehavior.AllowGet);
                }
                else
                {

                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog("虚拟用户", "Id:" + id + "," + ErrorCol, "失败", "删除", "异常程序");
                    return Json(JsonHandler.CreateMessage(0, "删除失败" + "\n" + ErrorCol), JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog("虚拟用户", "Id:" + id + "," + ErrorCol, "失败", "删除", "异常程序");
                return Json(JsonHandler.CreateMessage(0, "删除失败" + "\n" + ErrorCol), JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        public ActionResult Error()
        {
            BaseException ex = new BaseException();
            return View(ex);
        }
    }
}