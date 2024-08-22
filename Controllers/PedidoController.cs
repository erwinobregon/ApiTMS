using ApiTMS.Data;
using ApiTMS.Model;
using ApiTMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            this.pedidoService = pedidoService;
        }

        /// <summary>
        /// Obtiene el objeto pedido por el Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> devuelve un objeto pedido</returns>
        /// <response code="200">Retorna objeto pedido</response>
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
            var pedido = await pedidoService.GetById((int)id);
            return Ok(pedido);
        }

        /// <summary>
        /// Busca un pedido por el estado
        /// </summary>
        /// <param name="estado"></param>
        /// <returns>devuelve lista de objetos pedido</returns>
        /// <response code="200">Retorna objeto pedido</response>
        /// <response code="400">El Id es null or el pedido no existe</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("BuscarPorEstado/{estado}")]
        public async Task<IActionResult> BuscarPorEstado(string estado)
        {
            if (estado == null)
            {
                return NotFound();
            }
            var pedidos = await pedidoService.BuscarPorEstado(estado);


            if (estado == null)
            {
                return NotFound($"No se encontraron pedidos por el estado de envio {estado}");
            }

            return Ok(pedidos);

        }

        /// <summary>
        /// Busca un pedido por la ciudad origen
        /// </summary>
        /// <param name="ciudad"></param>
        /// <returns>devuelve lista de objetos pedido</returns>
        /// <response code="200">Retorna objeto pedido</response>
        /// <response code="400">El Id es null or la pedido no existe</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("BuscarPorOrigen/{ciudad}")]
        public async Task<IActionResult> BuscarPorOrigen(string ciudad)
        {
            if (ciudad == null)
            {
                return NotFound();
            }
            var pedidos = await pedidoService.BuscarPorCiudadOrigen(ciudad);


            if (ciudad == null)
            {
                return NotFound($"No se encontraron pedidos por la ciudad origen {ciudad}");
            }

            return Ok(pedidos);

        }

        /// <summary>
        /// Busca un pedido por la ciudad destino
        /// </summary>
        /// <param name="ciudad"></param>
        /// <returns>devuelve lista de objetos pedido</returns>
        /// <response code="200">Retorna objeto pedido</response>
        /// <response code="400">El Id es null or la pedido no existe</response>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("BuscarPorDestino/{ciudad}")]
        public async Task<IActionResult> BuscarPorDestino(string ciudad)
        {
            if (ciudad == null)
            {
                return NotFound();
            }
            var pedidos = await pedidoService.BuscarPorCiudadDestino(ciudad);


            if (ciudad == null)
            {
                return NotFound($"No se encontraron pedidos por la ciudad destino {ciudad}");
            }

            return Ok(pedidos);

        }
        /// <summary>
        /// Busca un pedido por la fecha
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        /// <response code="200">Retorna objeto pedido</response>
        /// <response code="400">El Id es null or la pedido no existe</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("BuscarPorFecha/{fecha}")]
        public async Task<IActionResult> BuscarPorFecha(string fecha)
        {
            if (fecha == null)
            {
                return NotFound();
            }
            var pedidos = await pedidoService.BuscarPorFecha(fecha);


            if (fecha == null)
            {
                return NotFound($"No se encontraron pedidos por la fecha {fecha}");
            }

            return Ok(pedidos);

        }

        /// <summary>
        /// Obtiene una lista de todos los objetos pedido
        /// </summary>
        /// <returns>devuelve lista de objetos pedido</returns>
        /// <response code="200">Retorna objeto pedido</response>
        /// <response code="400">No encuentra lista de pedidos</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var listPedidos = await pedidoService.GetList();
            if (listPedidos == null)
                return NotFound("No se han encontrado pedidos");

            return Ok(listPedidos);
        }

        /// <summary>
        /// Crea un objeto pedido
        /// </summary>
        /// <param name="pedidoDto"></param>
        /// <returns>devuelve el objeto pedido creado</returns>
        /// <response code="200">Retorna objeto pedido</response>
        /// <response code="400">El objeto pedido es invalido</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Create")]
        public async Task<IActionResult> Create(PedidoDto pedidoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            string mensaje = await pedidoService.ValidarPedido(pedidoDto);

            if (mensaje != string.Empty)
            {
                return BadRequest(mensaje);
            }

            Pedido pedido = new Pedido
            {
                IdEstado = pedidoDto.IdEstado,
                Descripcion = pedidoDto.Descripcion,
                IdCiudadOrigen = pedidoDto.IdCiudadOrigen,
                DireccionOrigen = pedidoDto.DireccionOrigen,
                IdCiudadDestino = pedidoDto.IdCiudadDestino,
                DireccionDestino = pedidoDto.DireccionDestino,
                Fecha = DateTime.Now,
            };

            pedido = await pedidoService.Insert(pedido);

            return Ok(pedido);
        }

        /// <summary>
        /// Actualiza un objeto pedido
        /// </summary>
        /// <param name="pedidoDto"></param>
        /// <returns>devuelve el objeto pedido actualizado</returns>
        /// <response code="200">Retorna objeto pedido</response>
        /// <response code="400">El objeto pedido es invalido o no se encuentra</response>

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Update")]
        public async Task<IActionResult> Update(PedidoDto pedidoDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var pedidoSearch = await pedidoService.GetById(pedidoDto.IdPedido);

            if (pedidoSearch == null)
            {
                return NotFound($"No se encuentra el numero de pedido  {pedidoDto.IdPedido}");
            }

            string mensaje = await pedidoService.IdentificarDatosPedido(pedidoDto);

            if (mensaje != string.Empty)
            {
                return BadRequest(mensaje);
            }


            Pedido pedido = new Pedido
            {
                IdPedido = pedidoDto.IdPedido,
                IdEstado = pedidoDto.IdEstado,
                Descripcion = pedidoDto.Descripcion,
                IdCiudadOrigen = pedidoDto.IdCiudadOrigen,
                DireccionOrigen = pedidoDto.DireccionOrigen,
                IdCiudadDestino = pedidoDto.IdCiudadDestino,
                DireccionDestino = pedidoDto.DireccionDestino,
                Fecha = DateTime.Now,
            };
            pedido = await pedidoService.Update(pedido);
            return Ok(pedido);
        }

        /// <summary>
        /// Elimina un objeto pedido
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string</returns>
        /// <response code="200">Retorna mensaje de confirmacion</response>
        /// <response code="400">El objeto pedido es invalido o no existe</response>

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var pedido = await pedidoService.GetById((int)id);

            if (pedido == null)
                return BadRequest($"No existe numero de pedido {id}");

            await pedidoService.Delete(id.Value);
            return Ok("El pedido se elimino");
        }
    }
}
