using ApiTMS.Data;
using ApiTMS.Repository;

namespace ApiTMS.Services
{
    public class CiudadService : Service<Ciudad>, ICiudadService
    {
        public CiudadService(ICiudadRepository repository) : base(repository)
        {
        }
    }
}
