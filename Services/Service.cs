using ApiTMS.Repository;

namespace ApiTMS.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private IRepository<TEntity> repository;

        public Service(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }
        public async Task Delete(int id)
        {
            await repository.Delete(id);
        }

        public async Task<TEntity> GetById(int id)
        {
            return await repository.GetById(id);
        }

        public async Task<List<TEntity>> GetList()
        {
            return await repository.GetList();
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            return await repository.Insert(entity);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await repository.Update(entity);
        }
    }
}
