using Financiera.Data.Interfaces;
using Financiera.Data.Interfaces.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Data.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly AplicacionDbContext _db;
        public ICuentaRepositorio Cuenta { get; private set; }

        public UnidadTrabajo(AplicacionDbContext db)
        {
            _db = db;
            Cuenta = new CuentaRepositorio(db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }


    }
}
