using System;

namespace DIMS_Core.Common.DI
{
    interface IDIMSDependencyInjector
    {
        T GetInjectedInstance<T>() where T : class;
        object GetInjectedInstance(Type fromType);
        IServiceResolver ServiceResolver { get; set; }
    }
}
