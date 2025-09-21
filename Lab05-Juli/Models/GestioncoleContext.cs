﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Lab05_Juli.Models;

public partial class GestioncoleContext : DbContext
{
    public GestioncoleContext()
    {
    }

    public GestioncoleContext(DbContextOptions<GestioncoleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistencia> Asistencias { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Evaluacione> Evaluaciones { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    public virtual DbSet<Matricula> Matriculas { get; set; }

    public virtual DbSet<Profesore> Profesores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=gestioncole;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Asistencia>(entity =>
        {
            entity.HasKey(e => e.IdAsistencia).HasName("PRIMARY");

            entity.ToTable("asistencias");

            entity.HasIndex(e => e.IdCurso, "fk_asistencia_curso");

            entity.HasIndex(e => e.IdEstudiante, "fk_asistencia_estudiante");

            entity.Property(e => e.IdAsistencia)
                .HasColumnType("int(11)")
                .HasColumnName("id_asistencia");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdCurso)
                .HasColumnType("int(11)")
                .HasColumnName("id_curso");
            entity.Property(e => e.IdEstudiante)
                .HasColumnType("int(11)")
                .HasColumnName("id_estudiante");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("fk_asistencia_curso");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("fk_asistencia_estudiante");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("PRIMARY");

            entity.ToTable("cursos");

            entity.Property(e => e.IdCurso)
                .HasColumnType("int(11)")
                .HasColumnName("id_curso");
            entity.Property(e => e.Creditos)
                .HasColumnType("int(11)")
                .HasColumnName("creditos");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante).HasName("PRIMARY");

            entity.ToTable("estudiantes");

            entity.Property(e => e.IdEstudiante)
                .HasColumnType("int(11)")
                .HasColumnName("id_estudiante");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Edad)
                .HasColumnType("int(11)")
                .HasColumnName("edad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Evaluacione>(entity =>
        {
            entity.HasKey(e => e.IdEvaluacion).HasName("PRIMARY");

            entity.ToTable("evaluaciones");

            entity.HasIndex(e => e.IdCurso, "fk_eval_curso");

            entity.HasIndex(e => e.IdEstudiante, "fk_eval_estudiante");

            entity.Property(e => e.IdEvaluacion)
                .HasColumnType("int(11)")
                .HasColumnName("id_evaluacion");
            entity.Property(e => e.Calificacion)
                .HasPrecision(5, 2)
                .HasColumnName("calificacion");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdCurso)
                .HasColumnType("int(11)")
                .HasColumnName("id_curso");
            entity.Property(e => e.IdEstudiante)
                .HasColumnType("int(11)")
                .HasColumnName("id_estudiante");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.Evaluaciones)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("fk_eval_curso");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Evaluaciones)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("fk_eval_estudiante");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.IdMateria).HasName("PRIMARY");

            entity.ToTable("materias");

            entity.HasIndex(e => e.IdCurso, "fk_materia_curso");

            entity.Property(e => e.IdMateria)
                .HasColumnType("int(11)")
                .HasColumnName("id_materia");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.IdCurso)
                .HasColumnType("int(11)")
                .HasColumnName("id_curso");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.Materia)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("fk_materia_curso");
        });

        modelBuilder.Entity<Matricula>(entity =>
        {
            entity.HasKey(e => e.IdMatricula).HasName("PRIMARY");

            entity.ToTable("matriculas");

            entity.HasIndex(e => e.IdCurso, "fk_matricula_curso");

            entity.HasIndex(e => e.IdEstudiante, "fk_matricula_estudiante");

            entity.Property(e => e.IdMatricula)
                .HasColumnType("int(11)")
                .HasColumnName("id_matricula");
            entity.Property(e => e.IdCurso)
                .HasColumnType("int(11)")
                .HasColumnName("id_curso");
            entity.Property(e => e.IdEstudiante)
                .HasColumnType("int(11)")
                .HasColumnName("id_estudiante");
            entity.Property(e => e.Semestre)
                .HasMaxLength(20)
                .HasColumnName("semestre");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("fk_matricula_curso");

            entity.HasOne(d => d.IdEstudianteNavigation).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("fk_matricula_estudiante");
        });

        modelBuilder.Entity<Profesore>(entity =>
        {
            entity.HasKey(e => e.IdProfesor).HasName("PRIMARY");

            entity.ToTable("profesores");

            entity.Property(e => e.IdProfesor)
                .HasColumnType("int(11)")
                .HasColumnName("id_profesor");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(100)
                .HasColumnName("especialidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
