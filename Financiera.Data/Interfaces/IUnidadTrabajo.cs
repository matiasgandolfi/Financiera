using Financiera.Data.Interfaces.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Data.Interfaces
{
    public interface IUnidadTrabajo : IDisposable
    {
        ICuentaRepositorio Cuenta { get; }

        Task Guardar();

    }
}
