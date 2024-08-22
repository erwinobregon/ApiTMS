namespace ApiTMS.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Delete(int id);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Insert(TEntity entity);
        Task<List<TEntity>> GetList();
        Task<TEntity> GetById(int id);
    }
}
