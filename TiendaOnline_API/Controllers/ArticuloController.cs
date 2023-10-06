using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using TiendaOnline_API.Data;
using TiendaOnline_API.Models;

namespace TiendaOnline_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAll()
        {
            var funcion = new DataArticulo();
            var result = await funcion.MostrarArticulos();
            if (result.IsExitoso == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> Get(int id)
        {
            var funcion = new DataArticulo();
            var result = await funcion.ObtenerArticulo(id);
            if (result.StatusCode == HttpStatusCode.NotFound)
            {
                return StatusCode(StatusCodes.Status404NotFound, result);
            }
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> Post([FromBody] Articulo newArticulo)
        {
            var funcion = new DataArticulo();
            var result = await funcion.GuardarArticulo(newArticulo);
            if (result.StatusCode == HttpStatusCode.InternalServerError)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }

            return StatusCode(StatusCodes.Status201Created, result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> Put(int id, [FromBody] Articulo articulo)
        {
            var funcion = new DataArticulo();
            articulo.Id = id;
            var result = await funcion.ObtenerArticulo(id);
            if (result.Resultado == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, result);
            }

            var result2 = await funcion.EditarArticulo(articulo);
            if (result2.StatusCode == HttpStatusCode.InternalServerError)
            {
                result2.Resultado = null;
                return StatusCode(StatusCodes.Status500InternalServerError, result2);
            }
            return Ok(result2);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> Delete(int id)
        {
            var funcion = new DataArticulo();
            var result = await funcion.ObtenerArticulo(id);
            if (result.Resultado == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, result);
            }

            var result2 = await funcion.EliminarArticulo(id);
            if (result2.StatusCode == HttpStatusCode.InternalServerError)
            {
                result2.Resultado = null;
                return StatusCode(StatusCodes.Status500InternalServerError, result2);
            }
            return Ok(result2);
        }
    }
}