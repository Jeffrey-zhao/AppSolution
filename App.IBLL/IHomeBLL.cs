﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;

namespace App.DAL
{
    public interface IHomeBLL
    {
        List<SysModule> GetMenuByPersonId(string personId,string moduleId);
    }
}
