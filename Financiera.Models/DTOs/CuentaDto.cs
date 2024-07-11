using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Models.DTOs
{
    public class CuentaDto
    {
        public int CuentaId { get; set; }
        public int UsuarioId { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal Saldo { get; set; }
        public int Estado { get; set; }
    }
}
