using ApiTMS.Data;
using ApiTMS.Model;

namespace ApiTMS.Repository
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<bool> ValidarCiudad(int id);
        Task<bool> ValidarEstado(int id);
        Task<bool> IdentificarCiudadDestino(int id);
        Task<bool> IdentificarCiudadOrigen(int id);
        Task<bool> IdentificarEstado(int id);
        Task<List<PedidoDto>> BuscarPorEstado(string estado);
        Task<List<PedidoDto>> BuscarPorCiudadOrigen(string ciudad);
        Task<List<PedidoDto>> BuscarPorCiudadDestino(string ciudad);
        Task<List<PedidoDto>> BuscarPorFecha(string fecha);
    }
}
