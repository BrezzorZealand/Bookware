using Bookware.Models;

namespace Bookware.DbServices.Interfaces
{
    public interface IClassService
    {
        Task AddClassAsync(Class? klasse); 
        Task <IEnumerable<Class?>> GetClassAsync();
        Task <Class?> GetClassByIdAsync(int id);
        Task <Class?> GetClassDataByIdAsync(int id);
        Task UpdateClassAsync(Class? klasse);
        Task DeleteClassAsync(Class? klasse);
        Task AddBook(ClassBook? classBook);
        Task RemoveBook(ClassBook? classBook);
        Task<IEnumerable<ClassBook?>> GetClassBooksByIdAsync(int id);
        Task<ClassBook?> GetClassBookByIdAsync(int Cid, int Bid);
    }
}
