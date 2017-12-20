using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;
using App.Common;

namespace App.DAL
{
    public interface ISysLogBLL
    {
        List<SysLog> GetList(ref GridPager pager, string queryStr);
        SysLog GetById(string id);
        bool Delete(ref ValidationErrors errors,string id);
    }
}
