using App.Common;
using App.IBLL;
using App.IDAL;
using App.Models;
using App.Models.Sys;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BLL
{
    public class SysRightBLL:BaseBLL, ISysRightBLL
    {
        [Dependency]
        public ISysRightRepository m_RightRepo { get; set; }
        public bool UpdateRight(ref ValidationErrors errors, SysRightOperateModel model)
        {
            int flag=m_RightRepo.UpdateRight(model);
            if (flag == 1)
            {
                errors.Add(Suggestion.UpdateSucceed);
                return true;
            }
            else
            {
                errors.Add(Suggestion.UpdateFail);
                return false;
            }
        }
        //按选择的角色及模块加载模块的权限项
        public List<P_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId)
        {
            return m_RightRepo.GetRightByRoleAndModule(roleId, moduleId);
        }
    }
}
