using ApiTMS.Data;
using ApiTMS.Repository;

namespace ApiTMS.Services
{
    public class EstadoService : Service<Estado>, IEstadoService
    {
        public EstadoService(IEstadoRepository repository) : base(repository)
        {
        }
    }
}
