using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestordePacientes.Core.Domain.Entities;

namespace GestordePacientes.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<Labtest> Labtests { get; set; }
        public DbSet<Labresult> labresults { get; set; }
        public DbSet<Clinic> Clinics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region UserTables
            modelBuilder.Entity<User>(tb => 
           {
                tb.HasKey(col => col.IdUser);
               tb.Property(col => col.IdUser)
                   .UseIdentityColumn()
                   .ValueGeneratedOnAdd();

               tb.Property(col => col.Name).HasMaxLength(50);
               tb.Property(col => col.Email).HasMaxLength(50);
               tb.Property(col => col.UserName).HasMaxLength(50);
               tb.Property(col => col.Password).HasMaxLength(50);
               tb.Property(col => col.Rol).HasMaxLength(50);

           });

            modelBuilder.Entity<User>().ToTable("Usuario");
            #endregion

            #region ClinicTables
            modelBuilder.Entity<Clinic>(tb =>
            {
                tb.HasKey(col => col.IdClinic);  
                tb.Property(col => col.Name).HasMaxLength(100);
                tb.Property(col => col.Address).HasMaxLength(200);
                tb.Property(col => col.PhoneNumber).HasMaxLength(15);
            });

            modelBuilder.Entity<Clinic>().ToTable("Clinicas");
            #endregion
        }
    }
}
