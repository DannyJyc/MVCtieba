﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace student.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MvctbEntities1 : DbContext
    {
        public MvctbEntities1()
            : base("name=MvctbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Ba> Bas { get; set; }
        public virtual DbSet<hf> hfs { get; set; }
        public virtual DbSet<Tie> Ties { get; set; }
        public virtual DbSet<TieContent> TieContents { get; set; }
    }
}
