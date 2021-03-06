﻿using System;
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
    public class MIS_ArticleBLL : BaseBLL, IMIS_ArticleBLL
    {
        [Dependency]
        public IMIS_ArticleRepository m_Rep { get; set; }

        public List<MIS_ArticleModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<MIS_Article> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(DB).Where(a => a.Title.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(DB);
            }
            pager.TotalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.Sort, pager.Order, pager.Page, pager.Rows);
            return CreateModelList(ref queryData);
        }
        private List<MIS_ArticleModel> CreateModelList(ref IQueryable<MIS_Article> queryData)
        {

            List<MIS_ArticleModel> modelList = (from r in queryData
                                                select new MIS_ArticleModel
                                                {
                                                    BodyContent = r.BodyContent,
                                                    CategoryId = r.CategoryId,
                                                    ChannelId = r.ChannelId,
                                                    CheckDateTime = r.CheckDateTime,
                                                    Checker = r.Checker,
                                                    CheckFlag = r.CheckFlag,
                                                    Click = r.Click??0,
                                                    Creater = r.Creater,
                                                    CreateTime = r.CreateTime,
                                                    Id = r.Id,
                                                    ImgUrl = r.ImgUrl,
                                                    Sort = r.Sort??0,
                                                    Title = r.Title
                                                }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, MIS_ArticleModel model)
        {
            try
            {
                MIS_Article entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new MIS_Article();
                entity.BodyContent = model.BodyContent;
                entity.CategoryId = model.CategoryId;
                entity.ChannelId = model.ChannelId;
                entity.CheckDateTime = model.CheckDateTime;
                entity.Checker = model.Checker;
                entity.CheckFlag = model.CheckFlag;
                entity.Click = model.Click;
                entity.Creater = model.Creater;
                entity.CreateTime = model.CreateTime;
                entity.Id = model.Id;
                entity.ImgUrl = model.ImgUrl;
                entity.Sort = model.Sort;
                entity.Title = model.Title;
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
        public bool Edit(ref ValidationErrors errors, MIS_ArticleModel model)
        {
            try
            {
                MIS_Article entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.BodyContent = model.BodyContent;
                entity.CategoryId = model.CategoryId;
                entity.ChannelId = model.ChannelId;
                entity.CheckDateTime = model.CheckDateTime;
                entity.Checker = model.Checker;
                entity.CheckFlag = model.CheckFlag;
                entity.Click = model.Click;
                entity.Creater = model.Creater;
                entity.CreateTime = model.CreateTime;
                entity.Id = model.Id;
                entity.ImgUrl = model.ImgUrl;
                entity.Sort = model.Sort;
                entity.Title = model.Title;

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
            if (DB.MIS_Article.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public MIS_ArticleModel GetById(string id)
        {
            if (IsExist(id))
            {
                MIS_Article entity = m_Rep.GetById(id);
                MIS_ArticleModel model = new MIS_ArticleModel();
                model.BodyContent = entity.BodyContent;
                model.CategoryId = entity.CategoryId;
                model.ChannelId = entity.ChannelId;
                model.CheckDateTime = entity.CheckDateTime;
                model.Checker = entity.Checker;
                model.CheckFlag = entity.CheckFlag;
                model.Click = entity.Click??0;
                model.Creater = entity.Creater;
                model.CreateTime = entity.CreateTime;
                model.Id = entity.Id;
                model.ImgUrl = entity.ImgUrl;
                model.Sort = entity.Sort??0;
                model.Title = entity.Title;
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
