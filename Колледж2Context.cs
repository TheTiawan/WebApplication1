﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1;

public partial class Колледж2Context : DbContext
{
    public Колледж2Context()
    {
    }

    public Колледж2Context(DbContextOptions<Колледж2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Дисциплины> Дисциплиныs { get; set; }

    public virtual DbSet<Преподаватели> Преподавателиs { get; set; }

    public virtual DbSet<УчебнаяНагрузка> УчебнаяНагрузкаs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress; Database=Колледж2; User=исп-41; Password=1234567890; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Дисциплины>(entity =>
        {
            entity.HasKey(e => e.КодДисциплины);

            entity.ToTable("Дисциплины");

            entity.Property(e => e.КодДисциплины).ValueGeneratedNever();
        });

        modelBuilder.Entity<Преподаватели>(entity =>
        {
            entity.HasKey(e => e.ТабельныйНомер);

            entity.ToTable("Преподаватели");

            entity.Property(e => e.ТабельныйНомер).ValueGeneratedNever();
        });

        modelBuilder.Entity<УчебнаяНагрузка>(entity =>
        {
            entity.HasKey(e => new { e.Преподаватель, e.Дисциплина, e.Группа, e.Семестр });

            entity.ToTable("УчебнаяНагрузка");

            entity.HasOne(d => d.ДисциплинаNavigation).WithMany(p => p.УчебнаяНагрузкаs)
                .HasForeignKey(d => d.Дисциплина)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_УчебнаяНагрузка_Дисциплины");

            entity.HasOne(d => d.ПреподавательNavigation).WithMany(p => p.УчебнаяНагрузкаs)
                .HasForeignKey(d => d.Преподаватель)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_УчебнаяНагрузка_Преподаватели");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
