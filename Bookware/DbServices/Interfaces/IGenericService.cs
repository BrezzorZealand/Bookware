using Microsoft.EntityFrameworkCore.Metadata;

namespace Bookware.DbServices.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task Create(TEntity? entity);
        Task Delete(TEntity? entity);
        Task Update(TEntity? entity);
    }
}