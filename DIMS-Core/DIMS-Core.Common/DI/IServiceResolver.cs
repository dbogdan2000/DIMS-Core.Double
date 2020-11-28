using System;
using System.Collections.Generic;
using System.Text;

namespace DIMS_Core.Common.DI
{
    interface IServiceResolver
    {
        void Register<TFrom, TTo>();
        T Resolve<T>();
        object Resolve(Type fromType);
    }
}
