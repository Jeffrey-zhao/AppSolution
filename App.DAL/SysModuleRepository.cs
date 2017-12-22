using App.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;

namespace App.DAL
{
    public class SysModuleRepository : IDisposable, ISysModuleRepository
    {
        public IQueryable<SysModule> GetList(AppDBContainer db)
        {
            IQueryable<SysModule> list = db.SysModule.AsQueryable();
            return list;
        }

        public IQueryable<SysModule> GetModuleBySystem(AppDBContainer db, string parentId)
        {
            return db.SysModule.Where(a => a.ParentId == parentId).AsQueryable();
        }

        public int Create(SysModule entity)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                db.SysModule.Add(entity);
                return db.SaveChanges();
            }
        }

        public void Delete(AppDBContainer db, string id)
        {
            SysModule entity = db.SysModule.SingleOrDefault(a => a.Id == id);
            if (entity != null)
            {

                //删除SysRight表数据
                var sr = db.SysRight.AsQueryable().Where(a => a.ModuleId == id);
                foreach (var o in sr)
                {
                    //删除SysRightOperate表数据
                    var sro = db.SysRightOperate.AsQueryable().Where(a => a.RightId == o.Id);
                    foreach (var o2 in sro)
                    {
                        db.SysRightOperate.Remove(o2);
                    }
                    db.SysRight.Remove(o);
                }
                //删除SysModuleOperate数据
                var smo = db.SysModuleOperate.AsQueryable().Where(a => a.ModuleId == id);
                foreach (var o3 in smo)
                {
                    db.SysModuleOperate.Remove(o3);
                }
                db.SysModule.Remove(entity);
                db.SaveChanges();
            }
        }

        public int Edit(SysModule entity)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                db.SysModule.Attach(entity);
                db.Entry<SysModule>(entity).State = System.Data.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public SysModule GetById(string id)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                return db.SysModule.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                SysModule entity = GetById(id);
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
