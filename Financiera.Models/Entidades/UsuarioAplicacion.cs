﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Models.Entidades
{
    public class UsuarioAplicacion : IdentityUser<int>
    {
        public string Apellidos { get; set; }
        public string Nombre { get; set; }
        public ICollection<RolUsuarioAplicacion> RolUsuarios { get; set; }

    }
}
