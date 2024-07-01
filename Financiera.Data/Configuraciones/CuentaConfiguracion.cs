using Financiera.Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Data.Configuraciones
{
    public class CuentaConfiguracion : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            // Configuración de la clave primaria
            builder.HasKey(c => c.CuentaId);

            // Configuración de propiedades
            builder.Property(c => c.NumeroCuenta)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.Saldo)
                .HasColumnType("decimal(18,2)")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(c => c.FechaCreación)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            // Configuración de la relación con Usuario
            builder.HasOne(c => c.Usuario)
                .WithMany(u => u.Cuentas)
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración de la relación con Transacciones
            builder.HasMany(c => c.Transacciones)
                .WithOne(t => t.Cuenta)
                .HasForeignKey(t => t.CuentaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Opcional: Nombre de la tabla en la base de datos
            builder.ToTable("Cuentas");
        }
    }
}
