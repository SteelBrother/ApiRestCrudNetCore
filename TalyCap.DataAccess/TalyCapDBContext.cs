using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TalyCap.Entities;

#nullable disable

namespace TalyCap.DataAccess
{
    public partial class TalyCapDBContext : DbContext
    {
        public TalyCapDBContext()
        {
        }

        public TalyCapDBContext(DbContextOptions<TalyCapDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Entrega> Entregas { get; set; }
        public virtual DbSet<LugarEntrega> LugarEntregas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Registro> Registros { get; set; }
        public virtual DbSet<TipoEnvio> TipoEnvios { get; set; }
        public virtual DbSet<TipoLugarEntrega> TipoLugarEntregas { get; set; }
        public virtual DbSet<TipoVehiculoEntrega> TipoVehiculoEntregas { get; set; }
        public virtual DbSet<VehiculoEntrega> VehiculoEntregas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\;Database=TalyCapDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Entrega>(entity =>
            {
                entity.ToTable("Entrega");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FechaEntrega).HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.IdSitioEntrega).HasColumnName("Id_SitioEntrega");

                entity.Property(e => e.IdVehiculoEntrega).HasColumnName("Id_VehiculoEntrega");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entrega_Cliente");

                entity.HasOne(d => d.IdSitioEntregaNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdSitioEntrega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entrega_LugarEntrega");

                entity.HasOne(d => d.IdVehiculoEntregaNavigation)
                    .WithMany(p => p.Entregas)
                    .HasForeignKey(d => d.IdVehiculoEntrega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Entrega_VehiculoEntrega");
            });

            modelBuilder.Entity<LugarEntrega>(entity =>
            {
                entity.ToTable("LugarEntrega");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Direccion)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.IdTipoLugarEntrega).HasColumnName("Id_TipoLugarEntrega");

                entity.HasOne(d => d.IdTipoLugarEntregaNavigation)
                    .WithMany(p => p.LugarEntregas)
                    .HasForeignKey(d => d.IdTipoLugarEntrega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LugarEntrega_TipoLugarEntrega");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DescripcionProducto)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.IdEntrega).HasColumnName("Id_Entrega");

                entity.Property(e => e.IdRegistro).HasColumnName("Id_Registro");

                entity.Property(e => e.IdTipoEnvio).HasColumnName("Id_TipoEnvio");

                entity.HasOne(d => d.IdEntregaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdEntrega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Entrega");

                entity.HasOne(d => d.IdRegistroNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdRegistro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Registro");

                entity.HasOne(d => d.IdTipoEnvioNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdTipoEnvio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_TipoEnvio");
            });

            modelBuilder.Entity<Registro>(entity =>
            {
                entity.ToTable("Registro");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            });

            modelBuilder.Entity<TipoEnvio>(entity =>
            {
                entity.ToTable("TipoEnvio");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TipoLugarEntrega>(entity =>
            {
                entity.ToTable("TipoLugarEntrega");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TipoVehiculoEntrega>(entity =>
            {
                entity.ToTable("TipoVehiculoEntrega");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<VehiculoEntrega>(entity =>
            {
                entity.ToTable("VehiculoEntrega");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdTipoVehiculoEntrega).HasColumnName("Id_TipoVehiculoEntrega");

                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.NombreConductor)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdTipoVehiculoEntregaNavigation)
                    .WithMany(p => p.VehiculoEntregas)
                    .HasForeignKey(d => d.IdTipoVehiculoEntrega)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VehiculoEntrega_TipoVehiculoEntrega");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
