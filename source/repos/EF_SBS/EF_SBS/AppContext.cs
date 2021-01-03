using EF_SBS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_SBS
{
    public class AppContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public AppContext()
        {
            Console.WriteLine("Start delete DB...");
            Database.EnsureDeleted();
            Console.WriteLine("Start creating DB...");
            Database.EnsureCreated();
            Console.WriteLine("DB created.");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SBS_sdb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Doctor model
            modelBuilder.Entity<Doctor>().HasKey(p => p.Id);
            modelBuilder.Entity<Doctor>().Property(d => d.HiredDate).IsRequired();
            modelBuilder.Entity<Doctor>()
                .Property(p => p.FName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Doctor>()
                .Property(p => p.LName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Doctor>()
                .HasMany(p => p.Visits)
                .WithOne(vs => vs.Doctor)
                .OnDelete(DeleteBehavior.SetNull);

            // Prescription model
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Visit)
                .WithOne(p => p.Prescription)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Prescription>()
                .Property(p => p.Cure).HasMaxLength(50)
                .IsRequired(false);
            modelBuilder.Entity<Prescription>()
                .Property(p => p.Comment).HasMaxLength(50)
                .IsRequired(false);
            modelBuilder.Entity<Prescription>()
                .Property(p => p.IsActive).IsRequired();

            // Department model
            modelBuilder.Entity<Department>()
                .Property(p => p.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Doctors)
                .WithOne(docs => docs.Department)
                .OnDelete(DeleteBehavior.SetNull);

            // Area model
            modelBuilder.Entity<Area>()
                .Property(p => p.RoomNumber)
                .IsRequired();
            modelBuilder.Entity<Area>()
                .Property(p => p.Name)
                .HasMaxLength(50);
            modelBuilder.Entity<Area>()
                .HasOne(p => p.Doctor)
                .WithOne(a => a.Area)
                .OnDelete(DeleteBehavior.SetNull);

            // Patient model
            modelBuilder.Entity<Patient>()
                .HasOne(pt => pt.Area)
                .WithMany(ar => ar.Patients)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Patient>()
                .Property(p => p.FName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Patient>()
                .Property(p => p.LName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Patient>()
                .Property(p => p.BDate).IsRequired();
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Visits)
                .WithOne(vs => vs.Patient)
                .OnDelete(DeleteBehavior.Cascade);

            // Address model
            modelBuilder.Entity<Address>()
                .HasOne(p => p.Patient)
                .WithOne(k => k.Address)
                .OnDelete(DeleteBehavior.Cascade);

            // Visit model
            modelBuilder.Entity<Visit>().Property(p => p.Description)
                .HasMaxLength(150).IsRequired();
            modelBuilder.Entity<Visit>().Property(p => p.Date)
                .IsRequired();
            modelBuilder.Entity<Visit>()
                .Property(p => p.DoctorId).IsRequired(false);
        }
    }
}
