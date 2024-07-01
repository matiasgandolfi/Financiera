using Financiera.Data;
using Financiera.Models.Entidades;
using Financiera.Models.Models;
using Financiera.WebAPI.Controllers.Errores;
using Microsoft.AspNetCore.Mvc;

namespace Financiera.WebAPI.Controllers
{
    public class ErrorTestController : BaseApiController
    {
        private readonly AplicacionDbContext _db;

        public ErrorTestController(AplicacionDbContext db)
        {
            _db = db;
        }

        //[Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetNotAuthorize()
        {
            return "No Autorizado";
        }

        //[Authorize]
        [HttpGet("not-found")]
        public ActionResult<UsuarioAplicacionModel> GetNotFound()
        {
            var objeto = _db.Usuarios.Find(-1);
            if (objeto == null) return NotFound(new ApiErrorResponse(404));
            return objeto;
        }




        //[Authorize]
        [HttpGet("server-found")]
        public ActionResult<string> GetServerError()
        {
            var objeto = _db.Usuarios.Find(-1);
            var objetoString = objeto.ToString();
            return objetoString;
        }



        //[Authorize]
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest(new ApiErrorResponse(400));
        }
    }
}
