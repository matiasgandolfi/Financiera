using Financiera.Data.Interfaces.IRepositorio;
using Financiera.Models.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Data.Repositorio
{
    public class CuentaRepositorio : Repositorio<Cuenta>, ICuentaRepositorio
    {
        private readonly AplicacionDbContext _db;
        public CuentaRepositorio(AplicacionDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Cuenta cuenta)
        {
            var cuentaDb = _db.Cuentas.FirstOrDefault(e => e.CuentaId == cuenta.CuentaId);
            if(cuentaDb != null)
            {
                cuentaDb.NumeroCuenta = cuenta.NumeroCuenta;
                cuentaDb.Saldo = cuenta.Saldo;
                _db.SaveChanges();
            }

        }
    }
}
