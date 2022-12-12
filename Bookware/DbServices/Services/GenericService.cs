using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookware.DbServices.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly BookwareDbContext context;

        public GenericService(BookwareDbContext context)
        {
            this.context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>().AsNoTracking();
        }

        ///// <summary>
        ///// Gets all entities of type T from the database that match the filter.
        ///// </summary>
        ///// <param name="filter">The string to filter (can be NULL)</param>
        ///// <param name="propertyName">Name of the Property the filter will filter </param>
        ///// <returns>A list of objects that match the filter</returns>
        //public IQueryable<TEntity> GetAllFilter(string? filter)
        //{
        //    return context.Set<TEntity>()
        //        .Where(t => t.GetType()
        //                     .GetProperty(propertyName!)
        //                     .ToString()
        //                     .StartsWith(filter!));

        //}

        //public TEntity GetById(int id)
        //{
        //    return context.Set<TEntity>().Find(x => x.Id == id);
        //}

        public async Task Create(TEntity? entity)
        {
            if (entity is not null)
            {
                await context.Set<TEntity>().AddAsync(entity);
            }
            await context.SaveChangesAsync();
        }

        public async Task Update(TEntity? entity)
        {
            if (entity is not null)
            {
                context.Set<TEntity>().Update(entity);
            }
            await context.SaveChangesAsync();
        }

        public async Task Delete(TEntity? entity)
        {
            if (entity is not null)
            {
                context.Set<TEntity>().Remove(entity);
            }
            await context.SaveChangesAsync();
        }
    }
}
