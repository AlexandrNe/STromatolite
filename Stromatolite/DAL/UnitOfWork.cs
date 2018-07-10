using Stromatolite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Stromatolite.DAL
{
    public class UnitOfWork: IDisposable
    {
        private StromatoliteModel context = new StromatoliteModel();
        
        private GenericRepository<Currency> currencyRepository;
        private GenericRepository<Offer> offerRepository;
        private GenericRepository<Product> productRepository;
        private GenericRepository<Unit> unitRepository;

        /****************************************************************************************************************************************/


        public GenericRepository<Currency> CurrencyRepository
        {
            get
            {
                if (this.currencyRepository == null)
                {
                    this.currencyRepository = new GenericRepository<Currency>(context);
                }
                return currencyRepository;
            }
        }


        public GenericRepository<Offer> OfferRepository
        {
            get
            {
                if (this.offerRepository == null)
                {
                    this.offerRepository = new GenericRepository<Offer>(context);
                }
                return offerRepository;
            }
        }


        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<Product>(context);
                }
                return productRepository;
            }
        }


        public GenericRepository<Unit> UnitRepository
        {
            get
            {
                if (this.unitRepository == null)
                {
                    this.unitRepository = new GenericRepository<Unit>(context);
                }
                return unitRepository;
            }
        }




        /*******************************************************************************************************************************************/
        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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