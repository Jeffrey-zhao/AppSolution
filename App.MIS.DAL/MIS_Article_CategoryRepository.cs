using System;
using System.Linq;
using App.MIS.IDAL;
using App.Models;
using System.Data;

namespace App.MIS.DAL
{
    public class MIS_Article_CategoryRepository : IMIS_Article_CategoryRepository, IDisposable
    {

        public IQueryable<MIS_Article_Category> GetList(AppDBContainer db)
        {
            IQueryable<MIS_Article_Category> list = db.MIS_Article_Category.AsQueryable();
            return list;
        }

        public int Create(MIS_Article_Category entity)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                db.MIS_Article_Category.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                MIS_Article_Category entity = db.MIS_Article_Category.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.MIS_Article_Category.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(AppDBContainer db, string[] deleteCollection)
        {
            IQueryable<MIS_Article_Category> collection = from f in db.MIS_Article_Category
                                                          where deleteCollection.Contains(f.Id)
                                                          select f;
            foreach (var deleteItem in collection)
            {
                db.MIS_Article_Category.Remove(deleteItem);
            }
            db.SaveChanges();
        }

        public int Edit(MIS_Article_Category entity)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                db.MIS_Article_Category.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public MIS_Article_Category GetById(string id)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                return db.MIS_Article_Category.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                MIS_Article_Category entity = GetById(id);
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
