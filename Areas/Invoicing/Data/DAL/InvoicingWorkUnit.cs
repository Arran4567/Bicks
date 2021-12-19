using Bicks.Data;
using Bicks.Data.DAL;
using Bicks.Models;
using Bicks.Areas.Invoicing.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Rotativa.AspNetCore;

namespace Bicks.Areas.Invoicing.Data.DAL
{
    public class InvoicingWorkUnit : IDisposable
    {
        private ApplicationDbContext _context;
        private GenericRepository<Product> productRepository;

        public GenericRepository<Product> ProductRepository
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

        public InvoicingWorkUnit(ApplicationDbContext context)
        {
            _context = context;
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

        public ViewAsPdf GenerateExampleInvoice()
        {
            SalesInvoiceViewModel salesInvoiceViewModel = new SalesInvoiceViewModel();
            ViewAsPdf viewAsPdf = new ViewAsPdf("SalesInvoiceTemplate", salesInvoiceViewModel);
            return viewAsPdf;
        }

        //Example
        //public IEnumerable<Job> GetUnassignedJobs()
        //{
        //     return JobRepository.Get(j => j.JobStatus.ID == (int)Enums.JobStatuses.JobCreated, q => q.OrderBy(j => j.DueWhen));
        //}
    }
}
