using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_WFM.Models;

namespace Task_WFM.Models
{
    public class WFMdbContext : DbContext
    {

        #region Constructor
        public WFMdbContext(DbContextOptions options) : base(options)
        {

        }
        #endregion

        public DbSet<Skills> Skills { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Skillmaps> Skillmaps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureModels(modelBuilder);
        }

        private static void ConfigureModels(ModelBuilder modelBuilder)
        {
            #region Entity: Skills
            modelBuilder.Entity<Skills>().ToTable("Skills");
            modelBuilder.Entity<Skills>().Property(x => x.skillname).IsRequired().HasMaxLength(30).HasColumnType("varchar");
            #endregion

            #region Entity: Employees
            modelBuilder.Entity<Employees>().ToTable("Employees");
            modelBuilder.Entity<Employees>().Property(x => x.employee_name).IsRequired().HasMaxLength(50).HasColumnType("varchar");
            modelBuilder.Entity<Employees>().Property(x => x.status).IsRequired().HasMaxLength(50).HasColumnType("varchar");
            modelBuilder.Entity<Employees>().Property(x => x.manager).HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Employees>().Property(x => x.wfm_manager).HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Employees>().Property(x => x.email).HasColumnType("varchar").HasMaxLength(100);
            modelBuilder.Entity<Employees>().Property(x => x.lockstatus).HasMaxLength(30).HasColumnType("varchar");
            modelBuilder.Entity<Employees>().Property(x => x.experience).HasColumnType("decimal(5,0)");
            #endregion

            #region Entity: Skillmaps
            modelBuilder.Entity<Skillmaps>().ToTable("Skillmaps");
            modelBuilder.Entity<Skillmaps>().HasKey(c => new { c.employee_id, c.skillid });
            modelBuilder.Entity<Skillmaps>().HasOne(a => a.employees).WithMany(b => b.skillmaps).HasForeignKey(c => c.employee_id);
            modelBuilder.Entity<Skillmaps>().HasOne(a => a.skills).WithMany(b => b.skillmaps).HasForeignKey(c => c.skillid);
            #endregion
        }
    }
}
