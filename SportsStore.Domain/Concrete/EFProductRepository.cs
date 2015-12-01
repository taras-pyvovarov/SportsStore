using System.Collections.Generic;
using System.Linq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private readonly EFDbContext _context = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get
            {
                return _context.Products;
            }
        }

        public EFProductRepository()
        {
            var productsCount = Products.Count();
            if (productsCount == 0)
            {
                AddNewProduct("Kayak", "A boat for one person", "Watersports", 275);
                AddNewProduct("Lifejacket", "Protective and fashionable", "Watersports", 48.95M);
                AddNewProduct("Soccer Ball", "FIFA-approved size and weight", "Soccer", 19.50M);
                AddNewProduct("Corner Flags", "Give your playing field a professional touch", "Soccer", 34.95M);
                AddNewProduct("Stadium", "Flat-packed 35,000-seat stadium", "Soccer", 79500);
                AddNewProduct("Thinking Cap", "Improve your brain efficiency by 75%", "Chess", 16);
                AddNewProduct("Unsteady Chair", "Secretly give your opponent a disadvantage", "Chess", 29.95M);
                AddNewProduct("Human Chess Board", "A fun game for the family", "Chess", 75);
                AddNewProduct("Bling-Bling-Bling", "Gold-plated, diamond-studded King", "Chess", 1200);
            }
        }

        private void AddNewProduct(string name, string description, string category, decimal price)
        {
            Product p = new Product();
            p.Name = name;
            p.Description = description;
            p.Category = category;
            p.Price = price;
            _context.Products.Add(p);
            _context.SaveChanges();
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
                _context.Products.Add(product);
            else
            {
                Product dbEntry = _context.Products.Find(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }

                _context.SaveChanges();
            }
        }
    }
}
