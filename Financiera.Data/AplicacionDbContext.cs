using Financiera.Models.Entidades;
using Financiera.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Financiera.Data
{
    public class AplicacionDbContext : IdentityDbContext<UsuarioAplicacionModel, RolAplicacionModel, int, IdentityUserClaim<int>
                                                         , RolUsuarioAplicacionModel, IdentityUserLogin<int>, IdentityRoleClaim<int>
                                                         , IdentityUserToken<int>>
    {
        public AplicacionDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UsuarioAplicacionModel> Usuarios { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
