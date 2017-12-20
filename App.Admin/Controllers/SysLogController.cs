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
    public class SysLogController : Controller
    {
        [Dependency]
        public ISysLogBLL logBLL { get; set; }
        // GET: SysLog
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<SysLog> list = logBLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.TotalRows,
                rows = (from r in list
                        select new SysLogModel()
                        {

                            Id = r.Id,
                            Operator = r.Operator,
                            Message = r.Message,
                            Result = r.Result,
                            Type = r.Type,
                            Module = r.Module,
                            CreateTime = r.CreateTime

                        }).ToArray()

            };

            return Json(json);
        }

        #region 详细

        public ActionResult Details(string id)
        {

            SysLog entity = logBLL.GetById(id);
            SysLogModel info = new SysLogModel()
            {
                Id = entity.Id,
                Operator = entity.Operator,
                Message = entity.Message,
                Result = entity.Result,
                Type = entity.Type,
                Module = entity.Module,
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
            if (id!=null)
            {
                if (logBLL.Delete(ref errors,id))
                {
                    LogHandler.WriteServiceLog("虚拟用户", "Id:" + id + ",", "成功", "删除", "日志程序");
                    return Json(JsonHandler.CreateMessage(1, "删除成功"), JsonRequestBehavior.AllowGet);
                }
                else
                {

                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog("虚拟用户", "Id:" + id + "," + ErrorCol, "失败", "删除", "日志程序");
                    return Json(JsonHandler.CreateMessage(0, "删除失败" + "\n" + ErrorCol), JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog("虚拟用户", "Id:" + id + "," + ErrorCol, "失败", "删除", "日志程序");
                return Json(JsonHandler.CreateMessage(0, "删除失败" + "\n" + ErrorCol), JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

    }
}