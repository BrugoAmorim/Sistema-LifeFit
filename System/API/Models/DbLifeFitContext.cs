using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models;

public partial class DbLifeFitContext : DbContext
{
    public DbLifeFitContext()
    {
    }

    public DbLifeFitContext(DbContextOptions<DbLifeFitContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbDiaSemana> TbDiaSemanas { get; set; }

    public virtual DbSet<TbExercicio> TbExercicios { get; set; }

    public virtual DbSet<TbRotinaTreino> TbRotinaTreinos { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
    
        if(!optionsBuilder.IsConfigured)
        {
            string connectionMySql = "host=localhost;user=root;password=12345;database=dbLifeFit";
            optionsBuilder.UseMySql(connectionMySql, Microsoft.EntityFrameworkCore.ServerVersion.AutoDetect(connectionMySql));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<TbDiaSemana>(entity =>
        {
            entity.HasKey(e => e.IdDiaSemana).HasName("PRIMARY");

            entity.ToTable("tb_dia_semana");

            entity.Property(e => e.IdDiaSemana).HasColumnName("id_dia_semana");
            entity.Property(e => e.DsDiaSemana)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("ds_dia_semana");
        });

        modelBuilder.Entity<TbExercicio>(entity =>
        {
            entity.HasKey(e => e.IdExercicio).HasName("PRIMARY");

            entity.ToTable("tb_exercicio");

            entity.HasIndex(e => e.IdDiaSemana, "id_dia_semana");

            entity.HasIndex(e => e.IdRotina, "id_rotina");

            entity.Property(e => e.IdExercicio).HasColumnName("id_exercicio");
            entity.Property(e => e.DsCargaAquecimento)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("ds_carga_aquecimento");
            entity.Property(e => e.DsCargaMaxima)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("ds_carga_maxima");
            entity.Property(e => e.DsExercicio)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("ds_exercicio");
            entity.Property(e => e.DsSeriesERepeticoes)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("ds_series_e_repeticoes");
            entity.Property(e => e.DsTempoDescanso)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("ds_tempo_descanso");
            entity.Property(e => e.IdDiaSemana).HasColumnName("id_dia_semana");
            entity.Property(e => e.IdRotina).HasColumnName("id_rotina");

            entity.HasOne(d => d.IdDiaSemanaNavigation).WithMany(p => p.TbExercicios)
                .HasForeignKey(d => d.IdDiaSemana)
                .HasConstraintName("tb_exercicio_ibfk_1");

            entity.HasOne(d => d.IdRotinaNavigation).WithMany(p => p.TbExercicios)
                .HasForeignKey(d => d.IdRotina)
                .HasConstraintName("tb_exercicio_ibfk_2");
        });

        modelBuilder.Entity<TbRotinaTreino>(entity =>
        {
            entity.HasKey(e => e.IdRotina).HasName("PRIMARY");

            entity.ToTable("tb_rotina_treino");

            entity.HasIndex(e => e.IdUsuario, "id_usuario");

            entity.Property(e => e.IdRotina).HasColumnName("id_rotina");
            entity.Property(e => e.DsNomeRotina)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("ds_nome_rotina");
            entity.Property(e => e.DsTempoDuracao)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("ds_tempo_duracao");
            entity.Property(e => e.DtRotinaCriada)
                .HasColumnType("datetime")
                .HasColumnName("dt_rotina_criada");
            entity.Property(e => e.IdUsuario).IsRequired(false)
            .HasColumnName("id_usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.TbRotinaTreinos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("tb_rotina_treino_ibfk_1");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("tb_usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.DsEmail)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("ds_email");
            entity.Property(e => e.DsNome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("ds_nome");
            entity.Property(e => e.DsSenha)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnName("ds_senha");
            entity.Property(e => e.DtContaAtualizada)
                .HasColumnType("datetime")
                .HasColumnName("dt_conta_atualizada");
            entity.Property(e => e.DtContaCriada)
                .HasColumnType("datetime")
                .HasColumnName("dt_conta_criada");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
