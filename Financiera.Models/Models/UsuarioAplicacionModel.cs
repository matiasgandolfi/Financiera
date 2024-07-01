using Financiera.Models.Entidades;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Models.Models
{
    public class UsuarioAplicacionModel : IdentityUser<int>
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public ICollection<Cuenta> Cuentas { get; set; }

        public ICollection<RolUsuarioAplicacionModel> RolUsuarios { get; set; }
    }
}
