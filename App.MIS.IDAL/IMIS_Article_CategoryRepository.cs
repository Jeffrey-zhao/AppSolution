using App.Models;
using System.Linq;
namespace App.MIS.IDAL
{
    public interface IMIS_Article_CategoryRepository
    {
        IQueryable<MIS_Article_Category> GetList(AppDBContainer db);
        int Create(MIS_Article_Category entity);
        int Delete(string id);
        void Delete(AppDBContainer db, string[] deleteCollection);
        int Edit(MIS_Article_Category entity);
        MIS_Article_Category GetById(string id);
        bool IsExist(string id);
    }
}
