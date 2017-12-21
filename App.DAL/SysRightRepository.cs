using App.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models.Sys;
using App.Models;

namespace App.DAL
{
    public class SysRightRepository : ISysRightRepository, IDisposable
    {
        public void Dispose()
        {
            
        }

        public List<PermModel> GetPermission(string accountId, string controller)
        {
            using (AppDBContainer db=new AppDBContainer())
            {
                List<PermModel> rights = (from r in db.P_Sys_GetRightOperate(accountId, controller)
                                          select new PermModel
                                          {
                                              KeyCode = r.KeyCode,
                                              IsValid = r.IsValid
                                          }).ToList();
                return rights;

            }
        }
    }
}
