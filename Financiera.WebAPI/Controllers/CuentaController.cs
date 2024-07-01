using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Financiera.WebAPI.Controllers
{
    [Authorize(Roles ="Admin,Agendador")]
    public class CuentaController : BaseApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hola");
        }
    }
}
