﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AppDBContainer : DbContext
    {
        public AppDBContainer()
            : base("name=AppDBContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
            base.OnModelCreating(modelBuilder);
        }
    
        public DbSet<SysSample> SysSamples { get; set; }
        public DbSet<SysModule> SysModules { get; set; }
    }
}
