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

namespace App.BLL
{
    public class AccountBLL: IAccountBLL
    {
        [Dependency]
        public IAccountRepository repo { get; set; }
        public SysUser Login(string userName,string pwd)
        {
            return repo.Login(userName,pwd);
        }
    }
}
