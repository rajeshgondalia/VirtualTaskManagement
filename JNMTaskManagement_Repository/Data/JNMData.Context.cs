﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JNMTaskManagement_Repository.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class JNM_TaskManagementEntities : DbContext
    {
        public JNM_TaskManagementEntities()
            : base("name=JNM_TaskManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ApiCallLog> ApiCallLogs { get; set; }
        public virtual DbSet<FrequencyTypeMaster> FrequencyTypeMasters { get; set; }
        public virtual DbSet<LoginLogDetail> LoginLogDetails { get; set; }
        public virtual DbSet<PriorityMaster> PriorityMasters { get; set; }
        public virtual DbSet<TaskPokeDetail> TaskPokeDetails { get; set; }
        public virtual DbSet<AlertDay1Master> AlertDay1Master { get; set; }
        public virtual DbSet<AlertDay2Master> AlertDay2Master { get; set; }
        public virtual DbSet<AlertDayMaster> AlertDayMasters { get; set; }
        public virtual DbSet<TaskDetail> TaskDetails { get; set; }
    }
}
