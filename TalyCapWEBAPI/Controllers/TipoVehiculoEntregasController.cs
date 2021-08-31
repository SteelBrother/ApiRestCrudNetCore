using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    public class TipoVehiculoEntregasController : ControllerBase
    {
        IApplication<TipoVehiculoEntrega> _tipoVehiculoEntrega;
        public TipoVehiculoEntregasController(IApplication<TipoVehiculoEntrega> TipoVehiculoEntrega)
        {
            _tipoVehiculoEntrega = TipoVehiculoEntrega;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _tipoVehiculoEntrega.GetAllAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tipoVehiculoEntrega = await _tipoVehiculoEntrega.GetByIdAsync(id);

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
        public async Task<IActionResult> Save(TipoVehiculoEntregaDTO tipoVehiculoEntregaDTO)
        {
            var tipoVehiculoEntrega = new TipoVehiculoEntrega()
            {
                Nombre = tipoVehiculoEntregaDTO.Nombre,
            };

            await _tipoVehiculoEntrega.SaveAsync(tipoVehiculoEntrega);
            return Ok(tipoVehiculoEntrega);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, TipoVehiculoEntregaDTO tipoVehiculoEntregaDTO)
        {
            if (id == 0 || tipoVehiculoEntregaDTO == null) return NotFound();

            var tmp = _tipoVehiculoEntrega.GetById(id);
            if (tmp != null)
            {
                tmp.Nombre = tipoVehiculoEntregaDTO.Nombre;
            }
            await _tipoVehiculoEntrega.SaveAsync(tmp);
            return Ok(tmp);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();

            _tipoVehiculoEntrega.DeleteAsync(id);
            return Ok();
        }
    }
}

