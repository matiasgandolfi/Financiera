using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Models.Entidades
{
    public class Transaccion
    {
        public int TransaccionId { get; set; }
        public int CuentaId { get; set; }
        public decimal Monto { get; set; }
        public string TipoTransaccion { get; set; }
        public DateTime FechaTransaccion { get; set; }

        public Cuenta Cuenta { get; set; }
    }
}
