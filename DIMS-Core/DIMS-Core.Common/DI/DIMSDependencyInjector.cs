using System;
using System.Collections.Generic;
using System.Text;

namespace DIMS_Core.Common.DI
{
    class DIMSDependencyInjector : IDIMSDependencyInjector
    {
        public IServiceResolver ServiceResolver { get; set; }

        public DIMSDependencyInjector() : this(new ServiceResolver())
        {

        }

        public DIMSDependencyInjector(IServiceResolver resolver)
        {
            ServiceResolver = resolver;
        }

        public T GetInjectedInstance<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public object GetInjectedInstance(Type fromType)
        {
            throw new NotImplementedException();
        }
    }
}
