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
    public class ProductosController : ControllerBase
    {
        IApplication<Producto> _producto;
        public ProductosController(IApplication<Producto> Producto)
        {
            _producto = Producto;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _producto.GetAllAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _producto.GetByIdAsync(id);

            if (producto != null)
            {
                return Ok(producto);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Save(ProductoDTO productoDTO)
        {
            var producto = new Producto()
            {
                PrecioEnvio = productoDTO.PrecioEnvio,
                DescripcionProducto = productoDTO.DescripcionProducto,
                IdEntrega = productoDTO.Entrega,
                IdRegistro = productoDTO.Registro,
                IdTipoEnvio = productoDTO.TipoEnvio,
            };

            await _producto.SaveAsync(producto);
            return Ok(producto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, ProductoDTO productoDTO)
        {
            if (id == 0 || productoDTO == null) return NotFound();

            var tmp = _producto.GetById(id);
            if (tmp != null)
            {
                tmp.PrecioEnvio = productoDTO.PrecioEnvio;
                tmp.DescripcionProducto = productoDTO.DescripcionProducto;
                tmp.IdEntrega = productoDTO.Entrega;
                tmp.IdRegistro = productoDTO.Registro;
                tmp.IdTipoEnvio = productoDTO.TipoEnvio;
            }
            await _producto.SaveAsync(tmp);
            return Ok(tmp);

        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();

            _producto.DeleteAsync(id);
            return Ok();
        }
    }
}
