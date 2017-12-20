using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL
{
    public class BaseBLL
    {
        public AppDBContainer DB
        {
            get
            {
                return new AppDBContainer();
            }
        }
    }
}
