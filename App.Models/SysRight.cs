//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace App.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SysRight
    {
        public SysRight()
        {
            this.SysRightOperate = new HashSet<SysRightOperate>();
        }
    
        public string Id { get; set; }
        public string ModuleId { get; set; }
        public string RoleId { get; set; }
        public bool Rightflag { get; set; }
    
        public virtual SysModule SysModule { get; set; }
        public virtual SysRole SysRole { get; set; }
        public virtual ICollection<SysRightOperate> SysRightOperate { get; set; }
    }
}
