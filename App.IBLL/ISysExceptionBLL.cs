using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;
using App.Common;

namespace App.DAL
{
    public interface ISysExceptionBLL
    {
        List<SysException> GetList(ref GridPager pager, string queryStr);
        SysException GetById(string id);
        bool Delete(string id);
    }
}
