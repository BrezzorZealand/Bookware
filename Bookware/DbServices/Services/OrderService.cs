using Bookware.DbServices.Interfaces;
using Bookware.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookware.DbServices.Services
{
    public class OrderService : GenericService<Order>, IOrderService
    {
        public OrderService(BookwareDbContext context) : base(context)
        {
        }

        public IEnumerable<Order>? GetOrdersByIdAsync(int? id)
        {
            return GetAll()
                .Where(order => order.CbId == id)
                .Include(order => order.Cb)
                .ThenInclude(classBook => classBook.Class)
                .Include(order => order.Cb)
                .ThenInclude(classBook => classBook.Book)
                .AsNoTracking();
        }
    }
}
