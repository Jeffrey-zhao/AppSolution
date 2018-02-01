using System;
using System.Linq;
using App.MIS.IDAL;
using App.Models;
using System.Data;

namespace App.MIS.DAL
{
    public class MIS_ArticleRepository : IMIS_ArticleRepository, IDisposable
    {

        public IQueryable<MIS_Article> GetList(AppDBContainer db)
        {
            IQueryable<MIS_Article> list = db.MIS_Article.AsQueryable();
            return list;
        }

        public int Create(MIS_Article entity)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                db.MIS_Article.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                MIS_Article entity = db.MIS_Article.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.MIS_Article.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(AppDBContainer db, string[] deleteCollection)
        {
            IQueryable<MIS_Article> collection = from f in db.MIS_Article
                                                 where deleteCollection.Contains(f.Id)
                                                 select f;
            foreach (var deleteItem in collection)
            {
                db.MIS_Article.Remove(deleteItem);
            }
            db.SaveChanges();
        }

        public int Edit(MIS_Article entity)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                db.MIS_Article.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public MIS_Article GetById(string id)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                return db.MIS_Article.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                MIS_Article entity = GetById(id);
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
