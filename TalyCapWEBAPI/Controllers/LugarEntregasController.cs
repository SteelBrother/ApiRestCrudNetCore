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
    public class LugarEntregasController : ControllerBase
    {
        IApplication<LugarEntrega> _lugarEntrega;
        public LugarEntregasController(IApplication<LugarEntrega> lugarEntrega)
        {
            _lugarEntrega = lugarEntrega;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _lugarEntrega.GetAllAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var lugarEntrega = await _lugarEntrega.GetByIdAsync(id);

            if (lugarEntrega != null)
            {
                return Ok(lugarEntrega);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Save(LugarEntregaDTO lugarEntregaDTO)
        {
            var lugarEntrega = new LugarEntrega()
            {
                Direccion = lugarEntregaDTO.Direccion,
                IdTipoLugarEntrega = lugarEntregaDTO.IdTipoLugarEntrega,
            };

            await _lugarEntrega.SaveAsync(lugarEntrega);
            return Ok(lugarEntrega);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, LugarEntregaDTO lugarEntregaDTO)
        {
            if (id == 0 || lugarEntregaDTO == null) return NotFound();

            var tmp = _lugarEntrega.GetById(id);
            if (tmp != null)
            {
                tmp.Direccion = lugarEntregaDTO.Direccion;
                tmp.IdTipoLugarEntrega = lugarEntregaDTO.IdTipoLugarEntrega;
            }
            await _lugarEntrega.SaveAsync(tmp);
            return Ok(tmp);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();

            _lugarEntrega.DeleteAsync(id);
            return Ok();
        }
    }
}
