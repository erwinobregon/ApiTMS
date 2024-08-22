using ApiTMS.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiTMS.Repository
{

        public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
        {
            private readonly DBTMSContext TMSContext;

            public Repository(DBTMSContext TMSContext)
            {
                this.TMSContext = TMSContext;
            }


        /// <summary>
        /// /Eliminación Generica de un registro 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
            public async Task Delete(int id)
            {
                var entity = await GetById(id);
                if (entity == null)
                {
                    throw new Exception("The entity is null");
                }

                TMSContext.Set<TEntity>().Remove(entity);
                await TMSContext.SaveChangesAsync();
            }

        /// <summary>
        /// Insercion Generica de un Registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
            public async Task<TEntity> GetById(int id)
            {
                return await TMSContext.Set<TEntity>().FindAsync(id);
            }

            public async Task<List<TEntity>> GetList()
            {
                return await TMSContext.Set<TEntity>().ToListAsync();
            }

        /// <summary>
        /// Insercion Generica de un Registro
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

            public async Task<TEntity> Insert(TEntity entity)
            {
                await TMSContext.Set<TEntity>().AddAsync(entity);
                await TMSContext.SaveChangesAsync();
                return entity;
            }

        /// <summary>
        /// Actualizacion Generica de un Registro
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
            public async Task<TEntity> Update(TEntity entity)
            {
                TMSContext.Set<TEntity>().Update(entity);
                await TMSContext.SaveChangesAsync();
                return entity;
            }
        }
    
}
