using Bicks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bicks.Data.DAL
{
    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void UpdateStock(List<Product> products)
        {
            foreach (Product product in products)
            {
                UpdateProductStock(product.ID, product.CasesInStock);
            }
        }
        public void UpdateProductStock(int id, int stockChange)
        {
            Product product = dbSet.Find(id);
            product.CasesInStock = product.CasesInStock + stockChange > 0 ? product.CasesInStock + stockChange : 0;
        }
    }
}
