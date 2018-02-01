using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using App.Models;
using App.Common;
using System.Transactions;
using App.Models.MIS;
using App.MIS.IBLL;
using App.MIS.IDAL;
using App.BLL.Core;
using App.BLL;

namespace App.MIS.BLL
{
    public class MIS_Article_CategoryBLL : BaseBLL, IMIS_Article_CategoryBLL
    {
        [Dependency]
        public IMIS_Article_CategoryRepository m_Rep { get; set; }

        public List<MIS_Article_CategoryModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<MIS_Article_Category> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(DB).Where(a => a.Name.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(DB);
            }
            pager.TotalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.Sort, pager.Order, pager.Page, pager.Rows);
            return CreateModelList(ref queryData);
        }
        private List<MIS_Article_CategoryModel> CreateModelList(ref IQueryable<MIS_Article_Category> queryData)
        {

            List<MIS_Article_CategoryModel> modelList = (from r in queryData
                                                         select new MIS_Article_CategoryModel
                                                         {
                                                             BodyContent = r.BodyContent,
                                                             ChannelId = r.ChannelId,
                                                             CreateTime = r.CreateTime,
                                                             Enable = r.Enable,
                                                             Id = r.Id,
                                                             ImgUrl = r.ImgUrl,
                                                             Name = r.Name,
                                                             ParentId = r.ParentId,
                                                             Sort = r.Sort??0
                                                         }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, MIS_Article_CategoryModel model)
        {
            try
            {
                MIS_Article_Category entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new MIS_Article_Category();
                entity.BodyContent = model.BodyContent;
                entity.ChannelId = model.ChannelId;
                entity.CreateTime = model.CreateTime;
                entity.Enable = model.Enable;
                entity.Id = model.Id;
                entity.ImgUrl = model.ImgUrl;
                entity.Name = model.Name;
                entity.ParentId = model.ParentId;
                entity.Sort = model.Sort;
                if (m_Rep.Create(entity) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.InsertFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        public bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        public bool Delete(ref ValidationErrors errors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        m_Rep.Delete(DB, deleteCollection);
                        if (DB.SaveChanges() == deleteCollection.Length)
                        {
                            transactionScope.Complete();
                            return true;
                        }
                        else
                        {
                            Transaction.Current.Rollback();
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }
        public bool Edit(ref ValidationErrors errors, MIS_Article_CategoryModel model)
        {
            try
            {
                MIS_Article_Category entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.BodyContent = model.BodyContent;
                entity.ChannelId = model.ChannelId;
                entity.CreateTime = model.CreateTime;
                entity.Enable = model.Enable;
                entity.Id = model.Id;
                entity.ImgUrl = model.ImgUrl;
                entity.Name = model.Name;
                entity.ParentId = model.ParentId;
                entity.Sort = model.Sort;

                if (m_Rep.Edit(entity) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.EditFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        public bool IsExists(string id)
        {
            if (DB.MIS_Article_Category.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public MIS_Article_CategoryModel GetById(string id)
        {
            if (IsExist(id))
            {
                MIS_Article_Category entity = m_Rep.GetById(id);
                MIS_Article_CategoryModel model = new MIS_Article_CategoryModel();
                model.BodyContent = entity.BodyContent;
                model.ChannelId = entity.ChannelId;
                model.CreateTime = entity.CreateTime;
                model.Enable = entity.Enable;
                model.Id = entity.Id;
                model.ImgUrl = entity.ImgUrl;
                model.Name = entity.Name;
                model.ParentId = entity.ParentId;
                model.Sort = entity.Sort??0;
                return model;
            }
            else
            {
                return null;
            }
        }

        public bool IsExist(string id)
        {
            return m_Rep.IsExist(id);
        }
    }
}
