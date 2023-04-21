using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.Data.Models;

public partial class BeautysalonContext : DbContext
{
    public BeautysalonContext()
    {
    }

    public BeautysalonContext(DbContextOptions<BeautysalonContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Serviceprovision> Serviceprovisions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("attendances_pkey");

            entity.ToTable("attendances");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Clientid).HasColumnName("clientid");

            entity.HasOne(d => d.Client).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.Clientid)
                .HasConstraintName("attendances_clientid_fkey");
        });

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

            entity.HasMany(d => d.Pos).WithMany(p => p.Emps)
                .UsingEntity<Dictionary<string, object>>(
                    "Employeesonposition",
                    r => r.HasOne<Position>().WithMany()
                        .HasForeignKey("Posid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fkposid"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("Empid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fkempid"),
                    j =>
                    {
                        j.HasKey("Empid", "Posid").HasName("pkemponposid");
                        j.ToTable("employeesonpositions");
                        j.IndexerProperty<long>("Empid").HasColumnName("empid");
                        j.IndexerProperty<long>("Posid").HasColumnName("posid");
                    });
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
            entity.HasKey(e => new { e.Attid, e.Serid }).HasName("pkserprov");

            entity.ToTable("serviceprovisions");

            entity.Property(e => e.Attid).HasColumnName("attid");
            entity.Property(e => e.Serid).HasColumnName("serid");
            entity.Property(e => e.Schid).HasColumnName("schid");

            entity.HasOne(d => d.Att).WithMany(p => p.Serviceprovisions)
                .HasForeignKey(d => d.Attid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkattid");

            entity.HasOne(d => d.Sch).WithMany(p => p.Serviceprovisions)
                .HasForeignKey(d => d.Schid)
                .HasConstraintName("fkschid");

            entity.HasOne(d => d.Ser).WithMany(p => p.Serviceprovisions)
                .HasForeignKey(d => d.Serid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fkserid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
