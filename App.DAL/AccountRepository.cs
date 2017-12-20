using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;
using App.IDAL;

namespace App.DAL
{
    public class AccountRepository : IAccountRepository, IDisposable
    {
        public void Dispose()
        {

        }
        public SysUser Login(string userName, string pwd)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                SysUser user = db.SysUser.SingleOrDefault(x => x.UserName == userName && x.Password == pwd);
                return user;
            }
        }
    }
}
