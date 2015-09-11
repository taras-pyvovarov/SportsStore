using System.Collections.Generic;
using SportsStore.Domain.Abstract;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private readonly EFDbContext _context = new EFDbContext();

        public IEnumerable<Entities.Product> Products
        {
            get
            {
                return _context.Products;
            }
        }
    }
}
