﻿using System.Collections.Generic;
using App.Common;
using App.Models.MIS;
namespace App.MIS.IBLL
{
    public interface IMIS_ArticleBLL
    {
        List<MIS_ArticleModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, MIS_ArticleModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, MIS_ArticleModel model);
        MIS_ArticleModel GetById(string id);
        bool IsExist(string id);
    }
}
