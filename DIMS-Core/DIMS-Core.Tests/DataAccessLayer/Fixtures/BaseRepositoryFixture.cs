using System;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.DataAccessLayer.Infrastructure;

namespace DIMS_Core.Tests.DataAccessLayer.Fixtures
{
    public abstract class BaseRepositoryFixture<TRepository> : IDisposable
    {
        private TRepository _repository;

        public DIMSCoreContext Context { get; }
        

        protected BaseRepositoryFixture()
        {
            Context = ContextCreator.CreateContext();
            
            InitDatabase();
        }

        public TRepository Repository => _repository ??= CreateRepository();
        
        public void Dispose()
        {
            Context.Dispose();
        }

        protected abstract TRepository CreateRepository();
        protected abstract void InitDatabase();
        
      
    }
}