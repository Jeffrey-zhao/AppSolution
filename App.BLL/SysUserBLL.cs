using App.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models.Sys;
using Microsoft.Practices.Unity;
using App.IDAL;

namespace App.BLL
{
    public class SysUserBLL : BaseBLL, ISysUserBLL
    {
        [Dependency]
        public ISysRightRepository repo { get; set; }
        public List<PermModel> GetPermission(string accountId, string controller)
        {
            return repo.GetPermission(accountId, controller);
        }
    }
}
