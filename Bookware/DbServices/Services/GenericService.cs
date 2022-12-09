using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookware.DbServices.Services
{
    public class GenericService<T>  /*IGenericService<T> where T : class*/
    {
        private readonly BookwareDbContext context;
        private readonly DbSet<T> dbSet;

        public GenericService(BookwareDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll<T>()
        {
            return await dbSet
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Gets all entities of type T from the database that match the filter.
        /// </summary>
        /// <param name="filter">The string to filter (can be NULL)</param>
        /// <param name="propertyName">Name of the Property the filter will filter </param>
        /// <returns>A list of objects that match the filter</returns>
        public async Task<IEnumerable<T>> GetAllFilter<T>(string? filter, string? propertyName)
        {
            return await dbSet
                .Where(t => t
                            .GetType()
                            .GetProperty(propertyName!)
                            .ToString()
                            .StartsWith(filter!))
                .ToListAsync();

        }

        public async Task<T> GetById<T>(int id)
        {
            T? entity = await dbSet.FindAsync(id);
            return entity!;
        }

        public async Task Create<T>(T entity)
        {
            if (entity is not null)
            {
                await dbSet.AddAsync(entity);
            }
            await context.SaveChangesAsync();
        }

        public async Task Update<T>(T entity)
        {
            if (entity is not null)
            {
                dbSet.Update(entity);
            }
            await context.SaveChangesAsync();
        }

        public async Task Delete<T>(T entity)
        {
            if (entity is not null)
            {
                dbSet.Remove(entity);
            }
            await context.SaveChangesAsync();
        }
    }
}
