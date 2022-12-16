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
