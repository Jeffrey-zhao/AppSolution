using App.Models;
using System.Linq;
namespace App.IDAL
{
    public interface ISysUserRepository
    {
        IQueryable<SysUser> GetList(AppDBContainer db);
        int Create(SysUser entity);
        int Delete(string id);
        void Delete(AppDBContainer db, string[] deleteCollection);
        int Edit(SysUser entity);
        SysUser GetById(string id);
        bool IsExist(string id);
        IQueryable<P_Sys_GetRoleByUserId_Result> GetRoleByUserId(AppDBContainer db, string userId);
        void UpdateSysRoleSysUser(string userId, string[] roleIds);
    }
}
