using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ewidencja.Models;
/// <summary>
/// kontekt bazy danych
/// </summary>
namespace ewidencja.DAL
{/// <summary>
/// klasa definijąca kontekst bazy danych i jej tabel
/// </summary>
    public class EwidencjaContext : DbContext
    {
        public EwidencjaContext() : base("EwidencjaContext")
        { }

        public DbSet<Adresy> Adresies { get; set; }
        public DbSet<Obywatel> Obywatels { get; set; }
        public DbSet<Uwagi> Uwagis { get; set; }
        /// <summary>
        /// metoda tworząca model bazy
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}