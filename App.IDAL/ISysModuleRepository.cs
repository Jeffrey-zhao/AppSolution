using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.IDAL
{
    public interface ISysModuleRepository
    {
        IQueryable<SysModule> GetList(AppDBContainer db);
        IQueryable<SysModule> GetModuleBySystem(AppDBContainer db, string parentId);
        int Create(SysModule entity);
        void Delete(AppDBContainer db, string id);
        int Edit(SysModule entity);
        SysModule GetById(string id);
        bool IsExist(string id);
    }
}
