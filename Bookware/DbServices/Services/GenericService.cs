using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookware.DbServices.Services
{
    public class GenericService
    {
        private readonly BookwareDbContext context;

        public GenericService(BookwareDbContext context)
        {
            this.context = context;
        }

        public async Task<List<T>> GetAll<T>() where T : class
        {
            return await context.Set<T>()
                .ToListAsync();
        }

        /// <summary>
        /// Gets all entities of type T from the database that match the filter.
        /// </summary>
        /// <param name="filter">The string to filter (can be NULL)</param>
        /// <param name="propertyName">Name of the Property the filter will filter </param>
        /// <returns>A list of objects that match the filter</returns>
        public async Task<List<T>> GetAllFilter<T>(string? filter, string? propertyName) where T : class
        {
            return await context.Set<T>()
                .Where(t => t
                            .GetType()
                            .GetProperty(propertyName!)
                            .ToString()
                            .StartsWith(filter!))
                .ToListAsync();

        }

        public async Task<T> GetById<T>(int id) where T : class
        {
            T? entity = await context!.Set<T>()
                                 .FindAsync(id);

            return entity!;
        }

        public async Task Create<T>(T entity) where T : class
        {
            if (entity is not null)
            {
                await context.Set<T>().AddAsync(entity);
            }
            await context.SaveChangesAsync();
        }

        public async Task Update<T>(T entity) where T : class
        {
            if (entity is not null)
            {
                context.Set<T>().Update(entity);
            }
            await context.SaveChangesAsync();
        }

        public async Task Delete<T>(T entity) where T : class
        {
            if (entity is not null)
            {
                context.Set<T>().Remove(entity);
            }
            await context.SaveChangesAsync();
        }
    }
}
