﻿using App.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models.Sys;
using Microsoft.Practices.Unity;
using App.IDAL;
using App.Common;
using App.Models;
using App.BLL.Core;
using System.Transactions;
using System.Data.Common;

namespace App.BLL
{
    public class SysUserBLL : BaseBLL, ISysUserBLL
    {
        [Dependency]
        public ISysRightRepository repo { get; set; }

        [Dependency]
        public ISysUserRepository m_Rep { get; set; }

        public List<PermModel> GetPermission(string accountId, string controller)
        {
            return repo.GetPermission(accountId, controller);
        }

        public List<SysUserModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<SysUser> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(DB).Where(a => a.UserName.Contains(queryStr) || a.TrueName.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(DB);
            }
            pager.TotalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.Sort, pager.Order, pager.Page, pager.Rows);
            return CreateModelList(ref queryData);
        }
        private List<SysUserModel> CreateModelList(ref IQueryable<SysUser> queryData)
        {

            List<SysUserModel> modelList = (from r in queryData
                                            select new SysUserModel
                                            {
                                                Address = r.Address,
                                                Attach = r.Attach,
                                                Birthday = r.Birthday,
                                                Card = r.Card,
                                                City = r.City,
                                                CreatePerson = r.CreatePerson,
                                                CreateTime = r.CreateTime,
                                                Degree = r.Degree,
                                                DepId = r.DepId,
                                                EmailAddress = r.EmailAddress,
                                                Expertise = r.Expertise,
                                                Id = r.Id,
                                                JobState = r.JobState,
                                                JoinDate = r.JoinDate,
                                                Marital = r.Marital,
                                                MobileNumber = r.MobileNumber,
                                                Nationality = r.Nationality,
                                                Native = r.Native,
                                                OtherContact = r.OtherContact,
                                                Password = r.Password,
                                                PhoneNumber = r.PhoneNumber,
                                                Photo = r.Photo,
                                                Political = r.Political,
                                                PosId = r.PosId,
                                                Professional = r.Professional,
                                                Province = r.Province,
                                                QQ = r.QQ,
                                                School = r.School,
                                                Sex = r.Sex,
                                                State = r.State??false,
                                                TrueName = r.TrueName,
                                                UserName = r.UserName,
                                                Village = r.Village
                                            }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, SysUserModel model)
        {
            try
            {
                SysUser entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new SysUser();
                entity.Address = model.Address;
                entity.Attach = model.Attach;
                entity.Birthday = model.Birthday;
                entity.Card = model.Card;
                entity.City = model.City;
                entity.CreatePerson = model.CreatePerson;
                entity.CreateTime = model.CreateTime;
                entity.Degree = model.Degree;
                entity.DepId = model.DepId;
                entity.EmailAddress = model.EmailAddress;
                entity.Expertise = model.Expertise;
                entity.Id = model.Id;
                entity.JobState = model.JobState;
                entity.JoinDate = model.JoinDate;
                entity.Marital = model.Marital;
                entity.MobileNumber = model.MobileNumber;
                entity.Nationality = model.Nationality;
                entity.Native = model.Native;
                entity.OtherContact = model.OtherContact;
                entity.Password = model.Password;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Photo = model.Photo;
                entity.Political = model.Political;
                entity.PosId = model.PosId;
                entity.Professional = model.Professional;
                entity.Province = model.Province;
                entity.QQ = model.QQ;
                entity.School = model.School;
                entity.Sex = model.Sex;
                entity.State = model.State;
                entity.TrueName = model.TrueName;
                entity.UserName = model.UserName;
                entity.Village = model.Village;
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
                            //DbTransaction.Current.Rollback();
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
        public bool Edit(ref ValidationErrors errors, SysUserModel model)
        {
            try
            {
                SysUser entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Address = model.Address;
                entity.Attach = model.Attach;
                entity.Birthday = model.Birthday;
                entity.Card = model.Card;
                entity.City = model.City;
                entity.CreatePerson = model.CreatePerson;
                entity.CreateTime = model.CreateTime;
                entity.Degree = model.Degree;
                entity.DepId = model.DepId;
                entity.EmailAddress = model.EmailAddress;
                entity.Expertise = model.Expertise;
                entity.Id = model.Id;
                entity.JobState = model.JobState;
                entity.JoinDate = model.JoinDate;
                entity.Marital = model.Marital;
                entity.MobileNumber = model.MobileNumber;
                entity.Nationality = model.Nationality;
                entity.Native = model.Native;
                entity.OtherContact = model.OtherContact;
                entity.Password = model.Password;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Photo = model.Photo;
                entity.Political = model.Political;
                entity.PosId = model.PosId;
                entity.Professional = model.Professional;
                entity.Province = model.Province;
                entity.QQ = model.QQ;
                entity.School = model.School;
                entity.Sex = model.Sex;
                entity.State = model.State;
                entity.TrueName = model.TrueName;
                entity.UserName = model.UserName;
                entity.Village = model.Village;

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
            if (DB.SysUser.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public SysUserModel GetById(string id)
        {
            if (IsExist(id))
            {
                SysUser entity = m_Rep.GetById(id);
                SysUserModel model = new SysUserModel();
                model.Address = entity.Address;
                model.Attach = entity.Attach;
                model.Birthday = entity.Birthday;
                model.Card = entity.Card;
                model.City = entity.City;
                model.CreatePerson = entity.CreatePerson;
                model.CreateTime = entity.CreateTime;
                model.Degree = entity.Degree;
                model.DepId = entity.DepId;
                model.EmailAddress = entity.EmailAddress;
                model.Expertise = entity.Expertise;
                model.Id = entity.Id;
                model.JobState = entity.JobState;
                model.JoinDate = entity.JoinDate;
                model.Marital = entity.Marital;
                model.MobileNumber = entity.MobileNumber;
                model.Nationality = entity.Nationality;
                model.Native = entity.Native;
                model.OtherContact = entity.OtherContact;
                model.Password = entity.Password;
                model.PhoneNumber = entity.PhoneNumber;
                model.Photo = entity.Photo;
                model.Political = entity.Political;
                model.PosId = entity.PosId;
                model.Professional = entity.Professional;
                model.Province = entity.Province;
                model.QQ = entity.QQ;
                model.School = entity.School;
                model.Sex = entity.Sex;
                model.State = entity.State??false;
                model.TrueName = entity.TrueName;
                model.UserName = entity.UserName;
                model.Village = entity.Village;
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
