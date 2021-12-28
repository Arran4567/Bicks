using Bicks.Data;
using Bicks.Data.DAL;
using Bicks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Rotativa.AspNetCore;

namespace Bicks.Areas.Sales.Data.DAL
{
    public class SalesWorkUnit : IDisposable
    {
        private ApplicationDbContext _context;
        private SalesRepository saleRepository;
        private GenericRepository<Client> clientRepository;
        private GenericRepository<InvoiceItem> invoiceItemRepository;
        private GenericRepository<Product> productRepository;

        public SalesWorkUnit(ApplicationDbContext context)
        {
            _context = context;
        }

        public SalesRepository SaleRepository
        {
            get
            {
                if (saleRepository == null)
                {
                    saleRepository = new SalesRepository(_context);
                }
                return saleRepository;
            }
        }

        public GenericRepository<Client> ClientRepository
        {
            get
            {
                if (clientRepository == null)
                {
                    clientRepository = new GenericRepository<Client>(_context);
                }
                return clientRepository;
            }
        }

        public GenericRepository<InvoiceItem> InvoiceItemRepository
        {
            get
            {
                if (invoiceItemRepository == null)
                {
                    invoiceItemRepository = new GenericRepository<InvoiceItem>(_context);
                }
                return invoiceItemRepository;
            }
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

        public void GenerateExampleSale()
        {
            Client client = ClientRepository.GetByID(2);
            Product streakyBacon = ProductRepository.GetByID(1);
            streakyBacon.Category = _context.Categories.Find(1);
            Product blackPudding = ProductRepository.GetByID(2);
            blackPudding.Category = _context.Categories.Find(1);
            Product porkLoin = ProductRepository.GetByID(3);
            porkLoin.Category = _context.Categories.Find(2);
            InvoiceItem streakyBaconItem = new InvoiceItem()
            {
                Product = streakyBacon,
                NumCases = 35,
                TotalWeight = 27.24m
            };
            InvoiceItem blackPuddingItem = new InvoiceItem()
            {
                Product = blackPudding,
                NumCases = 35,
                TotalWeight = 10m
            };
            InvoiceItem porkLoinItem = new InvoiceItem()
            {
                Product = porkLoin,
                NumCases = 35,
                TotalWeight = 8.4m
            };
            List<InvoiceItem> invoiceItems = new List<InvoiceItem>
            {
                streakyBaconItem,
                blackPuddingItem,
                porkLoinItem
            };
            Sale sale = new Sale
            {
                SaleDateTime = DateTime.Now,
                SaleInvoiceItems = invoiceItems,
                Client = client
            };
            SaleRepository.Insert(sale);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public void DeleteSale(Sale sale)
        {
            foreach(InvoiceItem invoiceItem in sale.SaleInvoiceItems)
            {
                InvoiceItemRepository.Delete(invoiceItem);
            }
            SaleRepository.Delete(sale);
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
