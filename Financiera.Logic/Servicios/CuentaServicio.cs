using AutoMapper;
using Financiera.Data.Interfaces;
using Financiera.Data.Repositorio;
using Financiera.Logic.Servicios.Interfaces;
using Financiera.Models.DTOs;
using Financiera.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Financiera.Logic.Servicios
{
    public class CuentaServicio : ICuentaServicio
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IMapper _mapper;

        public CuentaServicio(IUnidadTrabajo unidadTrabajo, IMapper mapper)
        {
            _unidadTrabajo = unidadTrabajo;
            _mapper = mapper;
        }

        public async Task<CuentaDto> Create(CuentaDto cuentaDto)
        {
            try
            {
                Cuenta cuenta = new Cuenta
                {
                    CuentaId = cuentaDto.CuentaId,
                    UsuarioId = cuentaDto.UsuarioId,
                    NumeroCuenta = cuentaDto.NumeroCuenta,
                    Saldo = cuentaDto.Saldo,
                    Estado = cuentaDto.Estado == 1 ? true : false,
                    FechaCreación = DateTime.Now
                };
                await _unidadTrabajo.Cuenta.Create(cuenta);
                await _unidadTrabajo.Guardar();
                if(cuenta.CuentaId== 0)
                {
                    throw new TaskCanceledException("La cuenta no se pudo crear");
                };
                return _mapper.Map<CuentaDto>(cuenta);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Update(CuentaDto cuentaDto)
        {
            try
            {
                var cuentaDb = await _unidadTrabajo.Cuenta.GetFirst(e => e.CuentaId == cuentaDto.CuentaId);
                if (cuentaDb == null)
                    throw new TaskCanceledException("La Cuenta no existe");

                cuentaDb.CuentaId = cuentaDb.CuentaId;
                cuentaDb.UsuarioId = cuentaDb.UsuarioId;
                cuentaDb.NumeroCuenta = cuentaDb.NumeroCuenta;
                cuentaDb.Saldo = cuentaDb.Saldo;
                cuentaDb.Estado = cuentaDb.Estado;
                _unidadTrabajo.Cuenta.Update(cuentaDb);
                await _unidadTrabajo.Guardar();


            }
            catch (Exception ex)
            {
                throw; 
            }
        }
    


        public async Task<IEnumerable<CuentaDto>> GetAll()
        {
            try
            {
                var lista = await _unidadTrabajo.Cuenta.GetAll(
                                    orderBy: e => e.OrderBy(e => e.CuentaId));
                return _mapper.Map<IEnumerable<CuentaDto>>(lista);
            }
            catch (Exception)
            {

                throw;
            }
        }
    

        public async Task Delete(int id)
        {
            try
            {
                var especialidadDb = await _unidadTrabajo.Cuenta.GetFirst(e => e.CuentaId == id);
                if (especialidadDb == null)
                    throw new TaskCanceledException("La Cuenta no existe");
                _unidadTrabajo.Cuenta.Delete(especialidadDb);
                await _unidadTrabajo.Guardar();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
