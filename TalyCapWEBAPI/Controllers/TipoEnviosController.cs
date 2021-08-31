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
    public class TipoEnviosController : ControllerBase
    {
        IApplication<TipoEnvio> _tipoEnvio;
        public TipoEnviosController(IApplication<TipoEnvio> TipoEnvio)
        {
            _tipoEnvio = TipoEnvio;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _tipoEnvio.GetAllAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tipoEnvio = await _tipoEnvio.GetByIdAsync(id);

            if (tipoEnvio != null)
            {
                return Ok(tipoEnvio);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Save(TipoEnvioDTO tipoEnvioDTO)
        {
            var tipoEnvio = new TipoEnvio()
            {
                Nombre = tipoEnvioDTO.Nombre,
            };

            await _tipoEnvio.SaveAsync(tipoEnvio);
            return Ok(tipoEnvio);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, TipoEnvioDTO tipoEnvioDTO)
        {
            if (id == 0 || tipoEnvioDTO == null) return NotFound();

            var tmp = _tipoEnvio.GetById(id);
            if (tmp != null)
            {
                tmp.Nombre = tipoEnvioDTO.Nombre;
            }
            await _tipoEnvio.SaveAsync(tmp);
            return Ok(tmp);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();

            _tipoEnvio.DeleteAsync(id);
            return Ok();
        }
    }
}
