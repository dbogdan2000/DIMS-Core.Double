using System;
using System.Collections.Generic;
using System.Text;

namespace DIMS_Core.Common.DI
{
    class ServiceResolver : IServiceResolver
    {
        private Dictionary<Type, object> _store;
        private Dictionary<Type, Type> _bindings;

        public IDIMSDependencyInjector DIMSInjector { get; set; }
        public ServiceResolver()
        {
            DIMSInjector = new DIMSDependencyInjector();
            _store = new Dictionary<Type, object>();
            _bindings = new Dictionary<Type, Type>();
        }

        public ServiceResolver(IDIMSDependencyInjector injector)
        {
            DIMSInjector = injector;
            _store = new Dictionary<Type, object>();
            _bindings = new Dictionary<Type, Type>();
        }

        public void Register<TFrom, TTo>()
        {
            _bindings.Add(typeof(TFrom), typeof(TTo));
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type fromType)
        {
            throw new NotImplementedException();
        }
    }
}
