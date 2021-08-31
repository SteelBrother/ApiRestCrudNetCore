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
    public class ClientesController : ControllerBase
    {
        IApplication<Cliente> _cliente;
        public ClientesController(IApplication<Cliente> Cliente)
        {
            _cliente = Cliente;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _cliente.GetAllAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _cliente.GetByIdAsync(id);

            if (cliente != null)
            {
                return Ok(cliente);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Save(ClienteDTO clienteDTO)
        {
            var user = new Cliente()
            {
                Nombre = clienteDTO.Nombre,
                Apellidos = clienteDTO.Apellidos
            };

            await _cliente.SaveAsync(user);
            return Ok(user);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, ClienteDTO clienteDTO)
        {
            if (id == 0 || clienteDTO == null) return NotFound();

            var tmp = _cliente.GetById(id);
            if (tmp != null)
            {
                tmp.Nombre = clienteDTO.Nombre;
                tmp.Apellidos = clienteDTO.Apellidos;
            }
            await _cliente.SaveAsync(tmp);
            return Ok(tmp);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();

            _cliente.DeleteAsync(id);
            return Ok();
        }
    }
}
