using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeviceManager.Infrastructure
{
    public class DeviceManagerDbContext(DbContextOptions<DeviceManagerDbContext> options) : DbContext(options)
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureCliente(modelBuilder.Entity<Cliente>());
            ConfigureDispositivo(modelBuilder.Entity<Dispositivo>());
            ConfigureEvento(modelBuilder.Entity<Evento>());

            base.OnModelCreating(modelBuilder);
        }

        private static void ConfigureCliente(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(c => c.Email)
                .IsUnique();

            builder.Property(c => c.Telefone)
                .IsRequired(false)
                .HasMaxLength(15);

            builder.Property(c => c.Status)
                .HasDefaultValue(true);

            builder.HasMany(c => c.Dispositivos)
                .WithOne(d => d.Cliente)
                .HasForeignKey(d => d.ClienteId);
        }

        private static void ConfigureDispositivo(EntityTypeBuilder<Dispositivo> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Serial)
                .IsRequired();

            builder.HasIndex(d => d.Serial)
                .IsUnique();

            builder.Property(d => d.IMEI)
                .IsRequired()
                .HasMaxLength(15);

            builder.HasIndex(d => d.IMEI)
                .IsUnique();

            builder.Property(d => d.DataAtivacao)
                .IsRequired(false);

            builder.HasMany(d => d.Eventos)
                .WithOne(e => e.Dispositivo)
                .HasForeignKey(e => e.DispositivoId);
        }

        private static void ConfigureEvento(EntityTypeBuilder<Evento> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Tipo)
                .IsRequired();

            builder.Property(e => e.DataHora)
                .IsRequired();

            builder.HasOne(e => e.Dispositivo)
                .WithMany(d => d.Eventos)
                .HasForeignKey(e => e.DispositivoId);
        }
    }
}