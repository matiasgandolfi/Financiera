using Financiera.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Data.Interfaces.IRepositorio
{
    public interface ICuentaRepositorio : IRepositorioGenerico<Cuenta>
    {
        void Actualizar(Cuenta cuenta);

    }
}
