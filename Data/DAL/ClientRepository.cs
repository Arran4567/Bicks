using Bicks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bicks.Data.DAL
{
    public class ClientRepository : GenericRepository<Client>
    {
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IOrderedEnumerable<ProductOption> GetProductOptions(int id)
        {
            IQueryable<Client> query = dbSet;
            Client client = query.Where(c => c.ID == id).FirstOrDefault();
            return client.ProductOptions.OrderByDescending(po => po.NumTimesPurchased);
        }
    }
}
