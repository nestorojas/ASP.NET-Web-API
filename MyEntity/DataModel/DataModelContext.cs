using Microsoft.EntityFrameworkCore;
using MyEntity.DataModel.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEntity.DataModel
{
    public partial class DataModelContext : DbContext
    {
        public DataModelContext(DbContextOptions<DataModelContext> options)
            : base(options)
        { }

        public virtual DbSet<Blog> Blog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Blog>().HasKey(c => new { c.Id });
        }
    }
}
