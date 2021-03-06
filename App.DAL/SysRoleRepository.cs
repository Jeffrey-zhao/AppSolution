﻿using App.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;

namespace App.DAL
{
    public class SysRoleRepository : IDisposable, ISysRoleRepository
    {
        public IQueryable<SysRole> GetList(AppDBContainer db)
        {
            IQueryable<SysRole> list = db.SysRole.AsQueryable();
            return list;
        }

        public int Create(SysRole entity)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                db.SysRole.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                SysRole entity = db.SysRole.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.SysRole.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public int Edit(SysRole entity)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                db.SysRole.Attach(entity);
                db.Entry<SysRole>(entity).State= System.Data.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public SysRole GetById(string id)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                return db.SysRole.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                SysRole entity = GetById(id);
                if (entity != null)
                    return true;
                return false;
            }
        }

        public void Dispose()
        {

        }
        public IQueryable<SysUser> GetRefSysUser(AppDBContainer db, string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return from m in db.SysRole
                       from f in m.SysUser
                       where m.Id == id
                       select f;
            }
            return null;
        }
        public IQueryable<P_Sys_GetUserByRoleId_Result> GetUserByRoleId(AppDBContainer db, string roleId)
        {
            return db.P_Sys_GetUserByRoleId(roleId).AsQueryable();
        }

        public void UpdateSysRoleSysUser(string roleId, string[] userIds)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                db.P_Sys_DeleteSysRoleSysUserByRoleId(roleId);
                foreach (string userid in userIds)
                {
                    if (!string.IsNullOrWhiteSpace(userid))
                    {
                        db.P_Sys_UpdateSysRoleSysUser(roleId, userid);
                    }
                }
                db.SaveChanges();
            }
        }

    }
}
