using System;
using System.Linq;
using App.IDAL;
using App.Models;
using System.Data;

namespace App.DAL
{
    public class SysUserRepository : ISysUserRepository, IDisposable
    {

        public IQueryable<SysUser> GetList(AppDBContainer db)
        {
            IQueryable<SysUser> list = db.SysUser.AsQueryable();
            return list;
        }

        public int Create(SysUser entity)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                db.SysUser.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                SysUser entity = db.SysUser.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.SysUser.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(AppDBContainer db, string[] deleteCollection)
        {
            IQueryable<SysUser> collection = from f in db.SysUser
                                             where deleteCollection.Contains(f.Id)
                                             select f;
            foreach (var deleteItem in collection)
            {
                db.SysUser.Remove(deleteItem);
            }
            db.SaveChanges();
        }

        public int Edit(SysUser entity)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                db.SysUser.Attach(entity);
                db.Entry(entity).State=EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public SysUser GetById(string id)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                return db.SysUser.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                SysUser entity = GetById(id);
                if (entity != null)
                    return true;
                return false;
            }
        }
        public void Dispose()
        {

        }
    }
}
