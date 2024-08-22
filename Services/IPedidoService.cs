using ApiTMS.Data;
using ApiTMS.Model;

namespace ApiTMS.Services
{
    public interface IPedidoService: IService<Pedido>
    {
        Task<string> IdentificarDatosPedido(PedidoDto pedido);
        Task<string> ValidarPedido(PedidoDto pedido);
        Task<List<PedidoDto>> BuscarPorEstado(string estado);
        Task<List<PedidoDto>> BuscarPorCiudadOrigen(string ciudad);
        Task<List<PedidoDto>> BuscarPorCiudadDestino(string ciudad);
        Task<List<PedidoDto>> BuscarPorFecha(string fecha);
    }
}
