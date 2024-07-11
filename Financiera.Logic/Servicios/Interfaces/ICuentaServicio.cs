using Financiera.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Logic.Servicios.Interfaces
{
    public interface ICuentaServicio
    {
        Task<IEnumerable<CuentaDto>> GetAll();
        Task<CuentaDto> Create(CuentaDto cuenta);
        Task Update(CuentaDto cuenta);
        Task Delete(int id);
    }
}
