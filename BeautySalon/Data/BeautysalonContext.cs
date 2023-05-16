using System;
using System.Collections.Generic;
using BeautySalon.Controllers;
using Microsoft.EntityFrameworkCore;
using BeautySalon.Data.Models;


namespace BeautySalon.Data.Models;

public partial class BeautysalonContext : DbContext
{
    public BeautysalonContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public BeautysalonContext(DbContextOptions<BeautysalonContext> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Position> Positions { get; set; }
   public virtual DbSet<EmployeesOnPosition> EmployeesOnPositions { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Serviceprovision> Serviceprovisions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clients_pkey");

            entity.ToTable("clients");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employees_pkey");

            entity.ToTable("employees");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Phone).HasColumnName("phone");
        });
        
        

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("positions_pkey");

            entity.ToTable("positions");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("schedules_pkey");

            entity.ToTable("schedules");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Empid).HasColumnName("empid");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasColumnName("status");

            entity.HasOne(d => d.Emp).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.Empid)
                .HasConstraintName("schedules_empid_fkey");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("services_pkey");

            entity.ToTable("services");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.About)
                .HasColumnType("character varying")
                .HasColumnName("about");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Posid).HasColumnName("posid");

            entity.HasOne(d => d.Pos).WithMany(p => p.Services)
                .HasForeignKey(d => d.Posid)
                .HasConstraintName("services_posid_fkey");
        });

        modelBuilder.Entity<Serviceprovision>(entity =>
        {
            entity.HasKey(e => e.Schid).HasName("pkserprov");

            entity.ToTable("serviceprovisions");

            entity.Property(e => e.Cliid).HasColumnName("cliid");
            entity.Property(e => e.Serid).HasColumnName("serid");
            entity.Property(e => e.Schid).HasColumnName("schid");

            entity.HasOne(d => d.Cli).WithMany(p => p.Serviceprovisions)
                .HasForeignKey(d => d.Cliid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkcliid");

            entity.HasOne(d => d.Sch).WithOne(p => p.Serviceprovision)
                .HasForeignKey<Serviceprovision>(d => d.Schid)
                .HasConstraintName("fkschid");

            entity.HasOne(d => d.Ser).WithMany(p => p.Serviceprovisions)
                .HasForeignKey(d => d.Serid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkserid");
            
            
        });

        modelBuilder.Entity<EmployeesOnPosition>(entity =>
        {
            entity.HasKey(e => new { e.Empid, e.Posid }).HasName("pkemppos");

            entity.ToTable("employeesonpositions");
            entity.Property(e => e.Posid).HasColumnName("posid");
            entity.Property(e => e.Empid).HasColumnName("empid");

            entity.HasOne(d=>d.Emp).WithMany(p=>p.EmployeesOnPositions)
                .HasForeignKey(d=>d.Empid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkempid");
            
            entity.HasOne(d=>d.Pos).WithMany(p=>p.EmployeesOnPositions)
                .HasForeignKey(d=>d.Posid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkposid");
        });
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    
}
