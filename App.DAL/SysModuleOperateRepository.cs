using App.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;

namespace App.DAL
{
    public class SysModuleOperateRepository : IDisposable, ISysModuleOperateRepository
    {
        public IQueryable<SysModuleOperate> GetList(AppDBContainer db)
        {
            IQueryable<SysModuleOperate> list = db.SysModuleOperate.AsQueryable();
            return list;
        }

        public int Create(SysModuleOperate entity)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                db.SysModuleOperate.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                SysModuleOperate entity = db.SysModuleOperate.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.SysModuleOperate.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public SysModuleOperate GetById(string id)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                return db.SysModuleOperate.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                SysModuleOperate entity = GetById(id);
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
