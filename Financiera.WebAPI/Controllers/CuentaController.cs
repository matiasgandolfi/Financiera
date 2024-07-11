using Financiera.Logic.Servicios.Interfaces;
using Financiera.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Financiera.WebAPI.Controllers
{
    //[Authorize(Roles ="Admin,Agendador")]
    public class CuentaController : BaseApiController
    {
        private readonly ICuentaServicio _cuentaServicio;
        private ApiResponse _response;

        public CuentaController(ICuentaServicio cuentaServicio, ApiResponse response)
        {
            _cuentaServicio = cuentaServicio;
            _response = new();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _response.Resultado = await _cuentaServicio.GetAll();
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex) 
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }

        //[HttpGet("ListadoActivos")]
        //public async Task<IActionResult> GetActivos()
        //{
        //    try
        //    {
        //        _response.Resultado = await _cuentaServicio.ObtenerActivos();
        //        _response.IsExitoso = true;
        //        _response.StatusCode = HttpStatusCode.OK;
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsExitoso = false;
        //        _response.Mensaje = ex.Message;
        //        _response.StatusCode = HttpStatusCode.BadRequest;
        //    }
        //    return Ok(_response);
        //}




        [HttpPost]
        public async Task<IActionResult> Create(CuentaDto modelDto)
        {
            try
            {
                await _cuentaServicio.Create(modelDto);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }


        [HttpPut]
        public async Task<IActionResult> Editar(CuentaDto modelDto)
        {
            try
            {
                await _cuentaServicio.Update(modelDto);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _cuentaServicio.Delete(id);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }
    }
}
