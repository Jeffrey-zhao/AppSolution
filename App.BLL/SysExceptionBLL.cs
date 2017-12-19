using App.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Common;
using App.Models;
using Microsoft.Practices.Unity;
using App.IDAL;
using App.IBLL;

namespace App.BLL
{
    public class SysExceptionBLL : ISysExceptionBLL
    {
        [Dependency]
        public ISysExceptionRepository ExceptionRepository { get; set; }


        public List<SysException> GetList(ref GridPager pager, string queryStr)
        {
            AppDBContainer db = new AppDBContainer();
            List<SysException> query = null;
            IQueryable<SysException> list = ExceptionRepository.GetList(db);
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                list = list.Where(a => a.Message.Contains(queryStr));
                pager.TotalRows = list.Count();
            }
            else
            {
                pager.TotalRows = list.Count();
            }

            if (pager.Order == "desc")
            {
                query = list.OrderByDescending(c => c.CreateTime).Skip((pager.Page - 1) * pager.Rows).Take(pager.Rows).ToList();
            }
            else
            {
                query = list.OrderBy(c => c.CreateTime).Skip((pager.Page - 1) * pager.Rows).Take(pager.Rows).ToList();
            }


            return query;
        }
        public SysException GetById(string id)
        {
            return ExceptionRepository.GetById(id);
        }

        public bool Delete(string id)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    AppDBContainer db = new AppDBContainer();
                    if (ExceptionRepository.Delete(db, id) == 1)
                    {
                        return true;
                    }else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
