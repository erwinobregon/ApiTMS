using ApiTMS.Data;
using ApiTMS.Model;

namespace ApiTMS.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        private readonly DBTMSContext _TMSContext;
        public PedidoRepository(DBTMSContext TMSContext) : base(TMSContext)
        {
            _TMSContext = TMSContext;
        }
        /// <summary>
        /// Busca un pedido por la ciudad destino
        /// </summary>
        /// <param name="ciudad"></param>
        /// <returns>Lista pedido</returns>
        public Task<List<PedidoDto>> BuscarPorCiudadDestino(string ciudad)
        {
            List<PedidoDto> listaPedido = new List<PedidoDto>();
            try
            {
                var bd = _TMSContext;
                listaPedido = (from pedidos in bd.Pedidos
                               join estados in bd.Estados
                               on pedidos.IdEstado equals estados.IdEstado
                               join ciudadOrigen in bd.Ciudads
                               on pedidos.IdCiudadOrigen equals ciudadOrigen.IdCiudad
                               join ciudadDestino in bd.Ciudads
                               on pedidos.IdCiudadDestino equals ciudadDestino.IdCiudad
                               where ciudadDestino.Descripcion.Contains(ciudad)
                               select new PedidoDto
                               {
                                   IdPedido = pedidos.IdPedido,
                                   Descripcion = pedidos.Descripcion,
                                   Estado = estados.Descripcion,
                                   CiudadDestino = ciudadDestino.Descripcion,
                                   CiudadOrigen = ciudadOrigen.Descripcion,
                                   Fecha = pedidos.Fecha
                               }).ToList();


            }
            catch (Exception ex)
            {
                throw;
            }
            return Task.FromResult(listaPedido);
        }
        /// <summary>
        /// Busca un pedido por la ciudad origen
        /// </summary>
        /// <param name="ciudad"></param>
        /// <returns>Lista pedido</returns>
        public Task<List<PedidoDto>> BuscarPorCiudadOrigen(string ciudad)
        {
            List<PedidoDto> listaPedido = new List<PedidoDto>();
            try
            {
                var bd = _TMSContext;
                listaPedido = (from pedidos in bd.Pedidos
                               join estados in bd.Estados
                               on pedidos.IdEstado equals estados.IdEstado
                               join ciudadOrigen in bd.Ciudads
                               on pedidos.IdCiudadOrigen equals ciudadOrigen.IdCiudad
                               join ciudadDestino in bd.Ciudads
                              on pedidos.IdCiudadDestino equals ciudadDestino.IdCiudad
                               where ciudadOrigen.Descripcion.Contains(ciudad)
                               select new PedidoDto
                               {
                                   IdPedido = pedidos.IdPedido,
                                   Descripcion = pedidos.Descripcion,
                                   Estado = estados.Descripcion,
                                   CiudadDestino = ciudadDestino.Descripcion,
                                   CiudadOrigen = ciudadOrigen.Descripcion,
                                   Fecha = pedidos.Fecha
                               }).ToList();


            }
            catch (Exception ex)
            {
                throw;
            }
            return Task.FromResult(listaPedido);
        }
        /// <summary>
        /// Busca un pedido por la ciudad origen
        /// </summary>
        /// <param name="estado"></param>
        /// <returns>Lista pedido</returns>
        public Task<List<PedidoDto>> BuscarPorEstado(string estado)
        {
            List<PedidoDto> listaPedido = new List<PedidoDto>();
            try
            {
                var bd = _TMSContext;
                listaPedido = (from pedidos in bd.Pedidos
                               join estados in bd.Estados
                               on pedidos.IdEstado equals estados.IdEstado
                               join ciudadOrigen in bd.Ciudads
                               on pedidos.IdCiudadOrigen equals ciudadOrigen.IdCiudad
                               join ciudadDestino in bd.Ciudads
                               on pedidos.IdCiudadOrigen equals ciudadDestino.IdCiudad
                               where estados.Descripcion.Contains(estado)
                               select new PedidoDto
                               {
                                   IdPedido = pedidos.IdPedido,
                                   Descripcion = pedidos.Descripcion,
                                   Estado = estados.Descripcion,
                                   CiudadDestino = ciudadDestino.Descripcion,
                                   CiudadOrigen = ciudadOrigen.Descripcion,
                                   Fecha = pedidos.Fecha
                               }).ToList();


            }
            catch (Exception ex)
            {
                throw;
            }
            return Task.FromResult(listaPedido);
        }

        /// <summary>
        /// Busca un pedido por la ciudad origen 
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns>Lista pedidos</returns>
        public Task<List<PedidoDto>> BuscarPorFecha(string fecha)
        {

            List<PedidoDto> listaPedido = new List<PedidoDto>();
            try
            {
                var bd = _TMSContext;
                listaPedido = (from pedidos in bd.Pedidos
                               join estados in bd.Estados
                               on pedidos.IdEstado equals estados.IdEstado
                               join ciudadOrigen in bd.Ciudads
                               on pedidos.IdCiudadOrigen equals ciudadOrigen.IdCiudad
                               join ciudadDestino in bd.Ciudads
                               on pedidos.IdCiudadOrigen equals ciudadDestino.IdCiudad
                               where pedidos.Fecha.Date.CompareTo(Convert.ToDateTime(fecha)) == 0
                               select new PedidoDto
                               {
                                   IdPedido = pedidos.IdPedido,
                                   Descripcion = pedidos.Descripcion,
                                   Estado = estados.Descripcion,
                                   CiudadDestino = ciudadDestino.Descripcion,
                                   CiudadOrigen = ciudadOrigen.Descripcion,
                                   Fecha = pedidos.Fecha
                               }).ToList();


            }
            catch (Exception ex)
            {
                throw;
            }
            return Task.FromResult(listaPedido);
        }
        /// <summary>
        /// Identifica si la ciudad destino esta asociada al pedido
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public Task<bool> IdentificarCiudadDestino(int id)
        {
            bool rpta = true;
            try
            {
                var bd = _TMSContext;
                int count = bd.Pedidos.Where(x => x.IdCiudadDestino == id).Count();
                if (count == 0)
                    rpta = false;

            }
            catch (Exception ex)
            {

                rpta = false;
            }

            return Task.FromResult(rpta);
        }

        /// <summary>
        ///  Identifica si la ciudad origen esta asociada al pedido
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public Task<bool> IdentificarCiudadOrigen(int id)
        {
            bool rpta = true;
            try
            {
                var bd = _TMSContext;
                int count = bd.Pedidos.Where(x => x.IdCiudadOrigen == id).Count();
                if (count == 0)
                    rpta = false;

            }
            catch (Exception ex)
            {

                rpta = false;
            }

            return Task.FromResult(rpta);
        }

        /// <summary>
        ///  Identifica si el estado esta asociado al pedido
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public Task<bool> IdentificarEstado(int id)
        {
            bool rpta = true;
            try
            {
                var bd = _TMSContext;
                int count = bd.Estados.Where(x => x.IdEstado == id).Count();
                if (count == 0)
                    rpta = false;

            }
            catch (Exception ex)
            {

                rpta = false;
            }

            return Task.FromResult(rpta);
        }
        /// <summary>
        ///  Valida si la ciudad esta creada
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public Task<bool> ValidarCiudad(int id)
        {
            bool rpta = true;
            try
            {
                var bd = _TMSContext;
                int count = bd.Ciudads.Where(x => x.IdCiudad == id).Count();
                if (count == 0)
                    rpta = false;

            }
            catch (Exception ex)
            {

                rpta = false;
            }

            return Task.FromResult(rpta);

        }

        /// <summary>
        ///  Valida si el estado esta creado
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public Task<bool> ValidarEstado(int id)
        {
            bool rpta = true;
            try
            {
                var bd = _TMSContext;
                int count = bd.Estados.Where(x => x.IdEstado == id).Count();
                if (count == 0)
                    rpta = false;

            }
            catch (Exception)
            {

                rpta = false;
            }

            return Task.FromResult(rpta);
        }


    }
}
