using Bookware.Models;

namespace Bookware.DbServices.Interfaces
{
    public interface IOrderService : IGenericService<Order>
    {
        IEnumerable<Order>? GetOrdersByIdAsync(int? id);
    }
}