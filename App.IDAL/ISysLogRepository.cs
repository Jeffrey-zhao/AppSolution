using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.IDAL
{
    public interface ISysLogRepository
    {
        int Create(SysLog entity);

        int Delete(AppDBContainer db, string id);

        IQueryable<SysLog> GetList(AppDBContainer db);

        SysLog GetById(string id);
    }
}
