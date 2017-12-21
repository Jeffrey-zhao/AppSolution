using App.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Common;
using App.Models;
using Microsoft.Practices.Unity;
using App.IDAL;
using App.IBLL;

namespace App.BLL
{
    public class HomeBLL: IHomeBLL
    {
        [Dependency]
        public IHomeRepository repo { get; set; }

        public List<SysModule> GetMenuByPersonId(string personId,string moduleId)
        {
            return repo.GetMenuByPersonId(personId,moduleId);
        }
    }
}
