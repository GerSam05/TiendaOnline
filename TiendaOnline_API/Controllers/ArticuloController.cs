using Azure;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using TiendaOnline_API.Data;
using TiendaOnline_API.Models;

namespace TiendaOnline_API.Controllers
{
    [EnableCors("CorsRules")]
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
            var response = await funcion.MostrarArticulos();
            if (response.IsSuccess == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> Get(int id)
        {
            var funcion = new DataArticulo();
            var response = await funcion.ObtenerArticulo(id);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return StatusCode(StatusCodes.Status404NotFound, response);
            }
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> Post([FromBody] Articulo newArticulo)
        {
            var funcion = new DataArticulo();
            var response = await funcion.GuardarArticulo(newArticulo);
            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> Put(int id, [FromBody] Articulo articulo)
        {
            var funcion = new DataArticulo();
            articulo.Id = id;
            var response = await funcion.ObtenerArticulo(id);
            if (response.Result == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, response);
            }

            var response2 = await funcion.EditarArticulo(articulo);
            if (response2.StatusCode == HttpStatusCode.InternalServerError)
            {
                response2.Result = null;
                return StatusCode(StatusCodes.Status500InternalServerError, response2);
            }
            return Ok(response2);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> Delete(int id)
        {
            var funcion = new DataArticulo();
            var response = await funcion.ObtenerArticulo(id);
            if (response.Result == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, response);
            }

            var response2 = await funcion.EliminarArticulo(id);
            if (response2.StatusCode == HttpStatusCode.InternalServerError)
            {
                response2.Result = null;
                return StatusCode(StatusCodes.Status500InternalServerError, response2);
            }
            return Ok(response2);
        }
    }
}