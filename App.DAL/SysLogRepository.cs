using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;
using App.IDAL;
using System.Data.Objects;
namespace App.DAL
{
    public class SysLogRepository : ISysLogRepository, IDisposable
    {
        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="db">数据库</param>
        /// <returns>集合</returns>
        public IQueryable<SysLog> GetList(AppDBContainer db)
        {
            IQueryable<SysLog> list = db.SysLog.AsQueryable();
            return list;
        }
        /// <summary>
        /// 创建一个对象
        /// </summary>
        /// <param name="db">数据库</param>
        /// <param name="entity">实体</param>
        public int Create(SysLog entity)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                //db.SysLogs.AddObject(entity);
                db.SysLog.Add(entity);
                return db.SaveChanges();
            }

        }

        /// <summary>
        /// 删除对象集合
        /// </summary>
        /// <param name="db">数据库</param>
        /// <param name="deleteCollection">集合</param>
        public int Delete(AppDBContainer db, string id)
        {
            IQueryable<SysLog> collection = from f in db.SysLog
                                            where f.Id==id
                                            select f;
            
            foreach (var deleteItem in collection)
            {
                //db.SysLogs.DeleteObject(deleteItem);
                db.SysLog.Remove(deleteItem);
            }
            return db.SaveChanges();
        }
        /// <summary>
        /// 根据ID获取一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysLog GetById(string id)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                return db.SysLog.SingleOrDefault(a => a.Id == id);
            }
        }


        public void Dispose()
        {

        }
    }
}
