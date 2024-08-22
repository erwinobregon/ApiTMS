using ApiTMS.Data;
using ApiTMS.Model;
using ApiTMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {

        private readonly IEstadoService estadoService;

        public EstadoController(IEstadoService estadoService)
        {
            this.estadoService = estadoService;
        }

        /// <summary>
        /// Obtiene el objeto estado por el Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> devuelve un objeto estado</returns>
        /// <response code="200">Retorna objeto estado</response>
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
            var estado = await estadoService.GetById((int)id);
            return Ok(estado);
        }

        /// <summary>
        /// Obtiene una lista de todos los objetos estado
        /// </summary>
        /// <returns>devuelve lista de objetos estado</returns>
        /// <response code="200">Retorna objeto estado</response>
        /// <response code="400">No encuentra lista de estados</response>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var listEstados = await estadoService.GetList();
            return Ok(listEstados);
        }

        /// <summary>
        /// Crea un objeto estado
        /// </summary>
        /// <param name="ciudadDto"></param>
        /// <returns>devuelve el objeto estado creado</returns>
        /// <response code="200">Retorna objeto estado</response>
        /// <response code="400">El objeto estado es invalido</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Create")]
        public async Task<IActionResult> Create(EstadoDto estadoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Estado area = new Estado
            {
                Descripcion = estadoDto.Descripcion,
            };

            area = await estadoService.Insert(area);
            return Ok(area);
        }

        /// <summary>
        /// Actualiza un objeto estado
        /// </summary>
        /// <param name="estadoDto"></param>
        /// <returns>devuelve el objeto estado actualizado</returns>
        /// <response code="200">Retorna objeto estado</response>
        /// <response code="400">El objeto estado es invalido</response>

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Update")]
        public async Task<IActionResult> Update(EstadoDto estadoDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Estado estado = new Estado
            {
                IdEstado = estadoDto.IdEstado,
                Descripcion = estadoDto.Descripcion,
            };
            estado = await estadoService.Update(estado);
            return Ok(estado);
        }
        /// <summary>
        /// Elimina un objeto estado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Retorna mensaje de confirmacion</response>
        /// <response code="400">El objeto estado es invalido o no existe</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var estado = await estadoService.GetById((int)id);

            if (estado == null)
                return BadRequest("Estado no existe");

            await estadoService.Delete(id.Value);
            return Ok("El estado se elimino");
        }

    }
}
