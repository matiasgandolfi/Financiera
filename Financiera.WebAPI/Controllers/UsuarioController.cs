using Financiera.Data.Interfaces;
using Financiera.Models.DTOs;
using Financiera.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Financiera.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UserManager<UsuarioAplicacionModel> _userManager;
        private readonly ITokenServicio _tokenServicio;
        private ApiResponse _response;
        private readonly RoleManager<RolAplicacionModel> _rolManager;

        public UsuarioController(UserManager<UsuarioAplicacionModel> userManager, ITokenServicio tokenServicio,
            RoleManager<RolAplicacionModel> rolManager)
        {
            _userManager = userManager;
            _tokenServicio = tokenServicio;
            _response = new();
            _rolManager = rolManager;
        }

        [Authorize(Policy = "AdminRol")]
        [HttpGet("ListadoRoles")]
        public IActionResult GetRoles()
        {
            var roles = _rolManager.Roles.Select(r => new { NombreRol = r.Name }).ToList();
            _response.Resultado = roles;
            _response.IsExitoso = true;
            _response.StatusCode = HttpStatusCode.OK;

            return Ok(_response);
        }

        private async Task<bool> UsuarioExiste(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }



        [Authorize(Policy = "AdminRol")]
        [HttpPost("registro")] //POST: api/usuario/registro
        public async Task<ActionResult<UsuarioDto>> Registro(RegistroDto registroDto)
        {
            if (await UsuarioExiste(registroDto.Username)) { return BadRequest("UserName ya esta Registrado"); }

            var usuario = new UsuarioAplicacionModel
            {
                UserName = registroDto.Username.ToLower(),
                Email = registroDto.Email,
                Apellido = registroDto.Apellido,
                Nombre = registroDto.Nombre
            };

            var resultado = await _userManager.CreateAsync(usuario, registroDto.Password);
            if (!resultado.Succeeded) return BadRequest(resultado.Errors);

            var rolResultado = await _userManager.AddToRoleAsync(usuario, registroDto.Rol);
            if (!rolResultado.Succeeded) return BadRequest("Error al Agregar el Rol al Usuario");

            return new UsuarioDto
            {
                UserName = usuario.UserName,
                Token = await _tokenServicio.CrearToken(usuario)
            };

        }

        [HttpPost("login")] //POST: api/usuario/registro
        public async Task<ActionResult<UsuarioDto>> Login(LoginDto loginDto)
        {
            var usuario = await _userManager.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.UserName);
            if (usuario == null) { return Unauthorized("Usuario no autorizado"); }

            var resultado = await _userManager.CheckPasswordAsync(usuario, loginDto.Password);

            if (!resultado) return Unauthorized("Password no valido");

            return new UsuarioDto
            {
                UserName = usuario.UserName,
                Token = await _tokenServicio.CrearToken(usuario)
            };
        }
    }
}
