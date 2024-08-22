using ApiTMS.Data;
using ApiTMS.Model;
using ApiTMS.Repository;

namespace ApiTMS.Services
{
    public class PedidoService : Service<Pedido>, IPedidoService
    {
        private readonly IPedidoRepository repository;
        public PedidoService(IPedidoRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Valida si existen los datos que van hacer asociados al pedido: ciudad origen, ciudad destino, estado
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns>string</returns>
        public async Task<string> ValidarPedido(PedidoDto pedido)
        {
            string mensaje = string.Empty;
            try

            {
                if (!await repository.ValidarCiudad(pedido.IdCiudadOrigen))
                    mensaje = "No existe ciudad origen";

                else if (!await repository.ValidarCiudad(pedido.IdCiudadDestino))
                    mensaje = "No existe ciudad destino";

                else if (!await repository.ValidarEstado(pedido.IdEstado))
                    mensaje = "No existe estado";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;

            }
            return mensaje;
        }

        /// <summary>
        /// Valida si existen los datos que estan asociados al pedido: ciudad origen, ciudad destino, estado
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns>string</returns>
        public async Task<string> IdentificarDatosPedido(PedidoDto pedido)
        {
            string mensaje = string.Empty;
            try

            {
                if (!await repository.IdentificarCiudadOrigen(pedido.IdCiudadOrigen))
                    mensaje = "No existe ciudad origen";

                else if (!await repository.IdentificarCiudadDestino(pedido.IdCiudadDestino))
                    mensaje = "No existe ciudad destino";

                else if (!await repository.IdentificarEstado(pedido.IdEstado))
                    mensaje = "No existe estado";
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;

            }
            return mensaje;
        }
        /// <summary>
        /// Busca un pedido por el estado
        /// </summary>
        /// <param name="estado"></param>
        /// <returns>string</returns>
        public async Task<List<PedidoDto>> BuscarPorEstado(string estado)
        {
            return await repository.BuscarPorEstado(estado);
        }

        /// <summary>
        /// Busca un pedido por ciudad origen
        /// </summary>
        /// <param name="ciudad"></param>
        /// <returns>Lista pedido</returns>
        public async Task<List<PedidoDto>> BuscarPorCiudadOrigen(string ciudad)
        {
            return await repository.BuscarPorCiudadOrigen(ciudad);
        }

        /// <summary>
        /// Busca un pedido por cidudad destino
        /// </summary>
        /// <param name="ciudad"></param>
        /// <returns>Lista pedido</returns>
        public async Task<List<PedidoDto>> BuscarPorCiudadDestino(string ciudad)
        {
            return await repository.BuscarPorCiudadDestino(ciudad);
        }

        /// <summary>
        /// Busca un pedido por fecha
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public async Task<List<PedidoDto>> BuscarPorFecha(string fecha)
        {
            return await repository.BuscarPorFecha(fecha);
        }
    }
}
