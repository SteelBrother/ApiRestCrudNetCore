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
    public class RegistrosController : ControllerBase
    {
        IApplication<Registro> _registro;
        public RegistrosController(IApplication<Registro> Registro)
        {
            _registro = Registro;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _registro.GetAllAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var registro = await _registro.GetByIdAsync(id);

            if (registro != null)
            {
                return Ok(registro);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Save(RegistroDTO registroDTO)
        {
            var registro = new Registro()
            {
                FechaRegistro = registroDTO.FechaRegistro
            };

            await _registro.SaveAsync(registro);
            return Ok(registro);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, RegistroDTO registroDTO)
        {
            if (id == 0 || registroDTO == null) return NotFound();

            var tmp = _registro.GetById(id);
            if (tmp != null)
            {
                tmp.FechaRegistro = registroDTO.FechaRegistro;
            }
            await _registro.SaveAsync(tmp);
            return Ok(tmp);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();

            _registro.DeleteAsync(id);
            return Ok();
        }
    }
}
