using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.IDAL
{
    public interface ISysRoleRepository
    {

        IQueryable<SysRole> GetList(AppDBContainer db);
        int Create(SysRole entity);
        int Delete(string id);
        int Edit(SysRole entity);
        SysRole GetById(string id);
        bool IsExist(string id);
        IQueryable<SysUser> GetRefSysUser(AppDBContainer db, string id);
        IQueryable<P_Sys_GetUserByRoleId_Result> GetUserByRoleId(AppDBContainer db, string roleId);
        void UpdateSysRoleSysUser(string roleId, string[] userIds);
    }
}
