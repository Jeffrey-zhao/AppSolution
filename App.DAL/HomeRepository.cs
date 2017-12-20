﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;
using App.IDAL;

namespace App.DAL
{
    public class HomeRepository : IHomeRepository, IDisposable
    {
        public List<SysModule> GetMenuByPersonId(string moduleId)
        {
            using (AppDBContainer db = new AppDBContainer())
            {
                var menus =
                (
                    from m in db.SysModule
                    where m.ParentId == moduleId
                    where m.Id != "0"
                    select m
                          ).Distinct().OrderBy(a => a.Sort).ToList();
                return menus;
            }
        }


        public void Dispose()
        {

        }

    }
}
