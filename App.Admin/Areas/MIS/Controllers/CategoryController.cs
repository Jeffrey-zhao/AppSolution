using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using App.Common;
using App.IBLL;
using App.Models.Sys;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;
using App.Admin.Core;
using App.Models.MIS;
using App.MIS.IBLL;
using App.Admin.Controllers;

namespace App.Admin.Areas.MIS.Controllers
{
    public class CategoryController : BaseController
    {
        [Dependency]
        public IMIS_Article_CategoryBLL m_BLL { get; set; }
        ValidationErrors errors = new ValidationErrors();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<MIS_Article_CategoryModel> list = m_BLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.TotalRows,
                rows = (from r in list
                        select new MIS_Article_CategoryModel()
                        {

                            Id = r.Id,
                            ChannelId = r.ChannelId,
                            Name = r.Name,
                            ParentId = r.ParentId,
                            Sort = r.Sort,
                            ImgUrl = r.ImgUrl,
                            BodyContent = r.BodyContent,
                            CreateTime = r.CreateTime,
                            Enable = r.Enable

                        }).ToArray()

            };

            return Json(json);
        }

        #region 创建
        [SupportFilter]
        public ActionResult Create()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Create(MIS_Article_CategoryModel model)
        {
            model.Id = ResultHelper.NewId;
            model.CreateTime = ResultHelper.NowTime;
            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Create(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",ChannelId" + model.Name, "成功", "创建", "App");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",ChannelId" + model.Name + "," + ErrorCol, "失败", "创建", "App");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail));
            }
        }
        #endregion

        #region 修改
        [SupportFilter]
        public ActionResult Edit(string id)
        {
            ViewBag.Perm = GetPermission();
            MIS_Article_CategoryModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(MIS_Article_CategoryModel model)
        {
            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",ChannelId" + model.Name, "成功", "修改", "App");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",ChannelId" + model.Name + "," + ErrorCol, "失败", "修改", "App");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.EditFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.EditFail));
            }
        }
        #endregion

        #region 详细
        [SupportFilter]
        public ActionResult Details(string id)
        {
            ViewBag.Perm = GetPermission();
            MIS_Article_CategoryModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        #endregion

        #region 删除
        [HttpPost]
        [SupportFilter]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (m_BLL.Delete(ref errors, id))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id, "成功", "删除", "App");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + id + "," + ErrorCol, "失败", "删除", "App");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail));
            }


        }
        #endregion
        #region 导出到PDF EXCEL WORD
        public ActionResult Reporting(string type = "PDF", string queryStr = "", int rows = 0, int page = 1)
        {
            //选择了导出全部
            if (rows == 0 && page == 0)
            {
                rows = 9999999;
                page = 1;
            }
            GridPager pager = new GridPager()
            {
                Rows = rows,
                Page = page,
                Sort = "Id",
                Order = "desc"
            };
            List<MIS_Article_CategoryModel> ds = m_BLL.GetList(ref pager, queryStr);
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Reports/MIS_Article_CategoryReport.rdlc");
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", ds);
            localReport.DataSources.Add(reportDataSource);
            string reportType = type;
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =
                "<DeviceInfo>" +
                "<OutPutFormat>" + type + "</OutPutFormat>" +
                "<PageWidth>11in</PageWidth>" +
                "<PageHeight>11in</PageHeight>" +
                "<MarginTop>0.5in</MarginTop>" +
                "<MarginLeft>1in</MarginLeft>" +
                "<MarginRight>1in</MarginRight>" +
                "<MarginBottom>0.5in</MarginBottom>" +
                "</DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = localReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings
                );
            return File(renderedBytes, mimeType);
        }
        #endregion
    }
}
