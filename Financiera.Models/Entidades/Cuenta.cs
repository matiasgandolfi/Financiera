using Financiera.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Models.Entidades
{
    public class Cuenta
    {
        [Key]
        public int CuentaId { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal Saldo { get; set; }
        public DateTime FechaCreación { get; set; }
        public bool Estado { get; set; }

        public UsuarioAplicacionModel Usuario { get; set; }
        public ICollection<Transaccion> Transacciones { get; set; }

    }
}
