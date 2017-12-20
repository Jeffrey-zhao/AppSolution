using App.DAL;
using App.IBLL;
using App.IDAL;
using App.Models;
using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Common;
using App.Models.Sys;
using Microsoft.Practices.Unity;
using App.BLL.Core;

namespace App.BLL
{
    public class SysSampleBLL : BaseBLL, ISysSampleBLL
    {
        [Dependency]
        public ISysSampleRepository Rep { get; set; }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pager">JQgrid分页</param>
        /// <param name="queryStr">搜索条件</param>
        /// <returns>列表</returns>
        public List<SysSampleModel> GetList(ref GridPager pager,string queryStr)
        {
            IQueryable<SysSample> queryData=Rep.GetList(DB);
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = queryData.Where(x => x.Name.Contains(queryStr) || x.Note.Contains(queryStr));
                pager.TotalRows = queryData.Count();
            }
            else
            {
                pager.TotalRows = queryData.Count();
            }            
            //排序
            if (pager.Order == "desc")
            {
                switch (pager.Sort)
                {
                    case "Id":
                        queryData = queryData.OrderByDescending(c => c.Id);
                        break;
                    case "Name":
                        queryData = queryData.OrderByDescending(c => c.Name);
                        break;
                    default:
                        queryData = queryData.OrderByDescending(c => c.CreateTime);
                        break;
                }
            }
            else
            {

                switch (pager.Sort)
                {
                    case "Id":
                        queryData = queryData.OrderBy(c => c.Id);
                        break;
                    case "Name":
                        queryData = queryData.OrderBy(c => c.Name);
                        break;
                    default:
                        queryData = queryData.OrderBy(c => c.CreateTime);
                        break;
                }
            }

            return CreateModelList(ref queryData,ref pager);
        }

        private List<SysSampleModel> CreateModelList(ref IQueryable<SysSample> queryData,ref GridPager pager)
        {
            pager.TotalRows = queryData.Count();
            if (pager.TotalPages > 0)
            {
                if (pager.Page <= 1)
                {
                    queryData = queryData.Take(pager.Rows);
                }
                else
                {
                    queryData = queryData.Skip((pager.Page - 1) * pager.Rows).Take(pager.Rows);
                }
            }
            List<SysSampleModel> modelList = (from r in queryData
                                              select new SysSampleModel
                                              {
                                                  Id = r.Id,
                                                  Name = r.Name,
                                                  Age = r.Age,
                                                  Bir = r.Bir,
                                                  Photo = r.Photo,
                                                  Note = r.Note,
                                                  CreateTime = r.CreateTime,

                                              }).ToList();

            return modelList;

        }

        /// <summary>
        /// 创建一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool Create(ref ValidationErrors errors,SysSampleModel model)
        {
            try
            {
                SysSample entity = Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add("主键重复");
                    return false;
                }

                entity = new SysSample();
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Age = model.Age;
                entity.Bir = model.Bir;
                entity.Photo = model.Photo;
                entity.Note = model.Note;
                entity.CreateTime = model.CreateTime;

                if (Rep.Create(entity) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add("插入失败");
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add("插入异常");
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="id">id</param>
        /// <returns>是否成功</returns>
        public bool Delete(ref ValidationErrors errors ,string id)
        {
            try
            {
                if (Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add("删除失败");
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add("删除异常");
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="errors">持久的错误信息</param>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool Edit(ref ValidationErrors errors,SysSampleModel model)
        {
            try
            {
                SysSample entity = Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add("主键不存在");
                    return false;
                }
                entity.Name = model.Name;
                entity.Age = model.Age;
                entity.Bir = model.Bir;
                entity.Photo = model.Photo;
                entity.Note = model.Note;

                if (Rep.Edit(entity) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add("编辑失败");
                    return false;
                }

            }
            catch (Exception ex)
            {
                errors.Add("编辑异常");
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }
        /// <summary>
        /// 判断是否存在实体
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns>是否存在</returns>
        public bool IsExists(string id)
        {
            if (DB.SysSample.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 根据ID获得一个实体
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>实体</returns>
        public SysSampleModel GetById(string id)
        {
            if (IsExist(id))
            {
                SysSample entity = Rep.GetById(id);
                SysSampleModel model = new SysSampleModel();
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.Age = entity.Age;
                model.Bir = entity.Bir;
                model.Photo = entity.Photo;
                model.Note = entity.Note;
                model.CreateTime = entity.CreateTime;

                return model;
            }
            else
            {
                return new SysSampleModel();
            }
        }

        /// <summary>
        /// 判断一个实体是否存在
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>是否存在 true or false</returns>
        public bool IsExist(string id)
        {
            return Rep.IsExist(id);
        }
    }
}
