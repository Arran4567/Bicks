using Bicks.Data;
using Bicks.Data.DAL;
using Bicks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Rotativa.AspNetCore;

namespace Bicks.Areas.ProductManagement.Data.DAL
{
    public class ProductManagementWorkUnit : IDisposable
    {
        private ApplicationDbContext _context;
        private ProductRepository productRepository;
        private GenericRepository<Category> categoryRepository;
        private GenericRepository<SubCategory> subCategoryRepository;

        public ProductManagementWorkUnit(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(_context);
                }
                return productRepository;
            }
        }

        public GenericRepository<Category> CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new GenericRepository<Category>(_context);
                }
                return categoryRepository;
            }
        }

        public GenericRepository<SubCategory> SubCategoryRepository
        {
            get
            {
                if (subCategoryRepository == null)
                {
                    subCategoryRepository = new GenericRepository<SubCategory>(_context);
                }
                return subCategoryRepository;
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

        //Example
        //public IEnumerable<Job> GetUnassignedJobs()
        //{
        //     return JobRepository.Get(j => j.JobStatus.ID == (int)Enums.JobStatuses.JobCreated, q => q.OrderBy(j => j.DueWhen));
        //}
    }
}
