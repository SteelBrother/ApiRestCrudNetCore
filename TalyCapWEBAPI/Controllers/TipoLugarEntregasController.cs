using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    public class TipoLugarEntregasController : ControllerBase
    {
        IApplication<TipoLugarEntrega> _tipoLugarEntrega;
        public TipoLugarEntregasController(IApplication<TipoLugarEntrega> TipoLugarEntrega)
        {
            _tipoLugarEntrega = TipoLugarEntrega;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _tipoLugarEntrega.GetAllAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tipoLugarEntrega = await _tipoLugarEntrega.GetByIdAsync(id);

            if (tipoLugarEntrega != null)
            {
                return Ok(tipoLugarEntrega);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Save(TipoLugarEntregaDTO tipoLugarEntregaDTO)
        {
            var tipoLugarEntrega = new TipoLugarEntrega()
            {
                Nombre = tipoLugarEntregaDTO.Nombre,
            };

            await _tipoLugarEntrega.SaveAsync(tipoLugarEntrega);
            return Ok(tipoLugarEntrega);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, TipoLugarEntregaDTO tipoLugarEntregaDTO)
        {
            if (id == 0 || tipoLugarEntregaDTO == null) return NotFound();

            var tmp = _tipoLugarEntrega.GetById(id);
            if (tmp != null)
            {
                tmp.Nombre = tipoLugarEntregaDTO.Nombre;
            }
            await _tipoLugarEntrega.SaveAsync(tmp);
            return Ok(tmp);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();

            _tipoLugarEntrega.DeleteAsync(id);
            return Ok();
        }
    }
}
