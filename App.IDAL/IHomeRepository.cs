﻿using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.IDAL
{
    public interface IHomeRepository
    {
        List<SysModule> GetMenuByPersonId(string moduleId);
    }
}
