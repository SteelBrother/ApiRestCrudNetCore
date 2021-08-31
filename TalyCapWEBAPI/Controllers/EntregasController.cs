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
    public class EntregasController : ControllerBase
    {
        IApplication<Entrega> _entrega;
        public EntregasController(IApplication<Entrega> entrega)
        {
            _entrega = entrega;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _entrega.GetAllAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entrega = await _entrega.GetByIdAsync(id);

            if (entrega != null)
            {
                return Ok(entrega);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Save(EntregaDTO entregaDTO)
        {
            var entrega = new Entrega()
            {
                
               FechaEntrega = entregaDTO.FechaEntrega,
               Descripcion = entregaDTO.Descripcion,
            };

            await _entrega.SaveAsync(entrega);
            return Ok(entrega);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, EntregaDTO entregaDTO)
        {
            if (id == 0 || entregaDTO == null) return NotFound();

            var tmp = _entrega.GetById(id);
            if (tmp != null)
            {
                tmp.FechaEntrega = entregaDTO.FechaEntrega;
                tmp.Descripcion = entregaDTO.Descripcion;
            }
            await _entrega.SaveAsync(tmp);
            return Ok(tmp);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();

            _entrega.DeleteAsync(id);
            return Ok();
        }
    }
}
