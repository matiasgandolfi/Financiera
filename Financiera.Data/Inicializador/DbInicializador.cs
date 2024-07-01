﻿using Financiera.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Data.Inicializador
{
    public class DbInicializador : IdbInicializador
    {
        private readonly AplicacionDbContext _db;
        private readonly UserManager<UsuarioAplicacionModel> _userManager;
        private readonly RoleManager<RolAplicacionModel> _rolManager;

        public DbInicializador(AplicacionDbContext db, UserManager<UsuarioAplicacionModel> userManager,
            RoleManager<RolAplicacionModel> rolManager)
        {
            _db = db;
            _userManager = userManager;
            _rolManager = rolManager;
        }

        public void Inicializar()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate(); // Cuando se ejecuta por primera vez nuestra app y hay migraciones pendientes
                }
            }
            catch (Exception)
            {

                throw;
            }

            // Datos Iniciales
            // Crear Roles

            if (_db.Roles.Any(r => r.Name == "Admin")) return;

            _rolManager.CreateAsync(new RolAplicacionModel { Name = "Admin" }).GetAwaiter().GetResult();
            _rolManager.CreateAsync(new RolAplicacionModel { Name = "Agendador" }).GetAwaiter().GetResult();
            _rolManager.CreateAsync(new RolAplicacionModel { Name = "Gerente" }).GetAwaiter().GetResult();

            // Crear Usuario Administrador
            var usuario = new UsuarioAplicacionModel
            {
                UserName = "administrador",
                Email = "administrador@doctorapp.com",
                Apellido = "Piedra",
                Nombre = "Carlos"
            };
            _userManager.CreateAsync(usuario, "Admin123").GetAwaiter().GetResult();
            // Asignar el Rol Admin al usuario
            UsuarioAplicacionModel usuarioAdmin = _db.Usuarios.Where(u => u.UserName == "administrador").FirstOrDefault();
            _userManager.AddToRoleAsync(usuarioAdmin, "Admin").GetAwaiter().GetResult();




        }
    }
}
