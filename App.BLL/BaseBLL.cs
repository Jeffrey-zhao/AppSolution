using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL
{
    public class BaseBLL:IDisposable
    {
        public AppDBContainer DB
        {
            get
            {
                return new AppDBContainer();
            }
        }

        public void Dispose()
        {
            
        }
    }
}
