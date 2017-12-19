using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.IDAL
{
    public interface ISysExceptionRepository
    {
        int Create(SysException entity);

        int Delete(AppDBContainer db, string id);

        IQueryable<SysException> GetList(AppDBContainer db);

        SysException GetById(string id);
    }
}
