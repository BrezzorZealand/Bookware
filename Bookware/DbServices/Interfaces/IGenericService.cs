namespace Bookware.DbServices.Interfaces
{
    public interface IGenericService
    {
        Task Create<T>(T entity);
        Task Delete<T>(T entity);
        Task<IEnumerable<T>> GetAll<T>();
        Task<IEnumerable<T>> GetAllFilter<T>(string? filter, string? propertyName);
        Task<T> GetById<T>(int id);
        Task Update<T>(T entity);
    }
}