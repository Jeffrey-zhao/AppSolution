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
    public class SysExceptionRepository : ISysExceptionRepository, IDisposable
    {
        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="db">数据库</param>
        /// <returns>集合</returns>
        public IQueryable<SysException> GetList(AppDBContainer db)
        {
            IQueryable<SysException> list = db.SysExceptions.AsQueryable();
            return list;
        }
        /// <summary>
        /// 创建一个对象
        /// </summary>
        /// <param name="db">数据库</param>
        /// <param name="entity">实体</param>
        public int Create(SysException entity)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                //db.SysExceptions.AddObject(entity);
                db.SysExceptions.Add(entity);
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
            SysException entity = db.SysExceptions.SingleOrDefault(x => x.Id == id);
            db.SysExceptions.Remove(entity);
            return db.SaveChanges();
        }
        /// <summary>
        /// 根据ID获取一个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SysException GetById(string id)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                return db.SysExceptions.SingleOrDefault(a => a.Id == id);
            }
        }


        public void Dispose()
        {

        }
    }
}
