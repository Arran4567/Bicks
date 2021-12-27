using Bicks.Data;
using Bicks.Data.DAL;
using Bicks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bicks.Areas.Sales.Data.DAL
{
    public class CustomerWorkUnit : IDisposable
    {
        private ApplicationDbContext _context;
        private GenericRepository<Product> productRepository;

        public CustomerWorkUnit(ApplicationDbContext context)
        {
            _context = context;
        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new GenericRepository<Product>(_context);
                }
                return productRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
