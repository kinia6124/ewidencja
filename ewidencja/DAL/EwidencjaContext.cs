using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ewidencja.Models;

namespace ewidencja.DAL
{
    public class EwidencjaContext : DbContext
    {
        public EwidencjaContext() : base("EwidencjaContext")
        { }

        public DbSet<Adresy> Adresies { get; set; }
        public DbSet<Obywatel> Obywatels { get; set; }
        public DbSet<Uwagi> Uwagis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}