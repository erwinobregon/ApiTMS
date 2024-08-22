using Microsoft.AspNetCore.Mvc;
using ApiTMS.Services;
using ApiTMS.Model;
using ApiTMS.Data;

namespace ApiTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly ICiudadService ciudadService;

        public CiudadController(ICiudadService ciudadService)
        {
            this.ciudadService = ciudadService;
        }

        /// <summary>
        /// Obtiene el objeto ciudad por el Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> devuelve un objeto ciudad</returns>
        /// <response code="200">Retorna objeto ciudad</response>
        /// <response code="400">El Id es null</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ciudad = await ciudadService.GetById((int)id);
            return Ok(ciudad);
        }

        /// <summary>
        /// Obtiene una lista de todos los objetos ciudad
        /// </summary>
        /// <returns>devuelve lista de objetos ciudad</returns>
        /// <response code="200">Retorna objeto ciudad</response>
        /// <response code="400">No encuentra lista de ciudades</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var listCiudades = await ciudadService.GetList();
            return Ok(listCiudades);
        }

        /// <summary>
        /// Crea un objeto ciudad
        /// </summary>
        /// <param name="ciudadDto"></param>
        /// <returns>devuelve el objeto ciudad creado</returns>
        /// <response code="200">Retorna objeto ciudad</response>
        /// <response code="400">El objeto ciudad es invalido</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Create")]
        public async Task<IActionResult> Create(CiudadDto ciudadDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Ciudad ciudad = new Ciudad
            {
                Descripcion = ciudadDto.Descripcion,
            };

            ciudad = await ciudadService.Insert(ciudad);
            return Ok(ciudad);
        }

        /// <summary>
        /// Actualiza un objeto ciudad
        /// </summary>
        /// <param name="ciudadDto"></param>
        /// <returns>devuelve el objeto ciudad actualizado</returns>
        /// <response code="200">Retorna objeto ciudad</response>
        /// <response code="400">El objeto ciudad es invalido</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Update")]
        public async Task<IActionResult> Update(CiudadDto ciudadDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Ciudad ciudad = new Ciudad
            {
                IdCiudad= ciudadDto.IdCiudad,
                Descripcion = ciudadDto.Descripcion
            };
            ciudad = await ciudadService.Update(ciudad);
            return Ok(ciudad);
        }

        /// <summary>
        /// Elimina un objeto ciudad
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Retorna mensaje de confirmacion</response>
        /// <response code="400">El objeto ciudad es invalido o no existe</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var ciudad = await ciudadService.GetById((int)id);

            if (ciudad == null)
                return BadRequest("Ciudad No existe");

            await ciudadService.Delete(id.Value);

            return Ok("La ciudad se elimino");
        }

    }
}
