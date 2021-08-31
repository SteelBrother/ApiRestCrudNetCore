using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalyCap.Application;
using TalyCap.Entities;
using TalyCapWEBAPI.DTOs;

namespace TalyCapWEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class VehiculoEntregasController : ControllerBase
    {
        IApplication<VehiculoEntrega> _vehiculoEntrega;
        public VehiculoEntregasController(IApplication<VehiculoEntrega> TipoVehiculoEntrega)
        {
            _vehiculoEntrega = TipoVehiculoEntrega;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _vehiculoEntrega.GetAllAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tipoVehiculoEntrega = await _vehiculoEntrega.GetByIdAsync(id);

            if (tipoVehiculoEntrega != null)
            {
                return Ok(tipoVehiculoEntrega);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Save(VehiculoEntregaDTO vehiculoEntregaDTO)
        {
            var vehiculoEntrega = new VehiculoEntrega()
            {
                Matricula = vehiculoEntregaDTO.Matricula,
                NombreConductor = vehiculoEntregaDTO.NombreConductor,
                IdTipoVehiculoEntrega = vehiculoEntregaDTO.IdTipoVehiculoEntrega,
            };

            await _vehiculoEntrega.SaveAsync(vehiculoEntrega);
            return Ok(vehiculoEntrega);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, VehiculoEntregaDTO vehiculoEntregaDTO)
        {
            if (id == 0 || vehiculoEntregaDTO == null) return NotFound();

            var tmp = _vehiculoEntrega.GetById(id);
            if (tmp != null)
            {
                tmp.Matricula = vehiculoEntregaDTO.Matricula;
                tmp.NombreConductor = vehiculoEntregaDTO.NombreConductor;
                tmp.IdTipoVehiculoEntrega = vehiculoEntregaDTO.IdTipoVehiculoEntrega;
            }
            await _vehiculoEntrega.SaveAsync(tmp);
            return Ok(tmp);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();

            _vehiculoEntrega.DeleteAsync(id);
            return Ok();
        }
    }
}
