using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiTMS.Data
{
    public partial class DBTMSContext : DbContext
    {
        public DBTMSContext()
        {
        }

        public DBTMSContext(DbContextOptions<DBTMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudad> Ciudads { get; set; } = null!;
        public virtual DbSet<Estado> Estados { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.IdCiudad);

                entity.ToTable("Ciudad");

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado);

                entity.ToTable("Estado");

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido);

                entity.ToTable("Pedido");

                entity.Property(e => e.Descripcion).HasMaxLength(200);

                entity.Property(e => e.DireccionDestino).HasMaxLength(100);

                entity.Property(e => e.DireccionOrigen).HasMaxLength(100);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.IdCiudadDestinoNavigation)
                    .WithMany(p => p.PedidoIdCiudadDestinoNavigations)
                    .HasForeignKey(d => d.IdCiudadDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_CiudadDestino");

                entity.HasOne(d => d.IdCiudadOrigenNavigation)
                    .WithMany(p => p.PedidoIdCiudadOrigenNavigations)
                    .HasForeignKey(d => d.IdCiudadOrigen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_CiudadOrigen");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_Estado");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
