using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using App.Models;
    using System.Linq;
    namespace App.MIS.IDAL
    {
        public interface IMIS_ArticleRepository
        {
            IQueryable<MIS_Article> GetList(AppDBContainer db);
            int Create(MIS_Article entity);
            int Delete(string id);
            void Delete(AppDBContainer db, string[] deleteCollection);
            int Edit(MIS_Article entity);
            MIS_Article GetById(string id);
            bool IsExist(string id);
        }
    }
