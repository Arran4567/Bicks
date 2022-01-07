﻿using Bicks.Models;
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
            foreach(Product product in products)
            {
                context.Products.Where(p => p.ID == product.ID).First().CasesInStock += product.CasesInStock;
            }
        }
    }
}
