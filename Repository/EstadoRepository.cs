using ApiTMS.Data;

namespace ApiTMS.Repository
{
    public class EstadoRepository : Repository<Estado>, IEstadoRepository
    {
        public EstadoRepository(DBTMSContext TMSContext) : base(TMSContext)
        {
        }
    }
}
