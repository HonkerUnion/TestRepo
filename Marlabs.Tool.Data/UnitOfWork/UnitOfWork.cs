using Marlabs.Tool.Data.GenericRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marlabs.Tool.Data.UnitOfWork
{
    /// <summary>
    /// Unit of Work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        #region Private member variables...

        private HonkerUnionEntities _context = null;
        private GenericRepository<Product> _productRepository;
        private GenericRepository<USERINFORMATION> _userInformationRepository;
        #endregion

        public UnitOfWork()
        {
            _context = new HonkerUnionEntities();
        }


        /// <summary>
        /// Get/Set Property for Product repository.
        /// </summary>
        public GenericRepository<Product> ProductRepository
        {
            get
            {
                if (this._productRepository == null)
                    this._productRepository = new GenericRepository<Product>(_context);
                return _productRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for User Information repository.
        /// </summary>
        public GenericRepository<USERINFORMATION> UserInformationRepository
        {
            get
            {
                if (this._userInformationRepository == null)
                    this._userInformationRepository = new GenericRepository<USERINFORMATION>(_context);
                return _userInformationRepository;
            }
        }

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                // log the exception
                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable.

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}