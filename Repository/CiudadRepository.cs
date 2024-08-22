using ApiTMS.Data;

namespace ApiTMS.Repository
{
    public class CiudadRepository : Repository<Ciudad>, ICiudadRepository
    {
        public CiudadRepository(DBTMSContext TMSContext) : base(TMSContext)
        {
        }
    }
}
