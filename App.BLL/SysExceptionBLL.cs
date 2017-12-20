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
using App.BLL.Core;

namespace App.BLL
{
    public class SysExceptionBLL :BaseBLL, ISysExceptionBLL
    {
        [Dependency]
        public ISysExceptionRepository ExceptionRepository { get; set; }


        public List<SysException> GetList(ref GridPager pager, string queryStr)
        {
            List<SysException> query = null;
            IQueryable<SysException> list = ExceptionRepository.GetList(DB);
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

        public bool Delete(ref ValidationErrors errors,string id)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(id))
                {
                    if (ExceptionRepository.Delete(DB, id) == 1)
                    {
                        return true;
                    }else
                    {
                        errors.Add("删除失败");
                        return false;
                    }
                }
                else
                {
                    errors.Add("主键为空");
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
    }

}
