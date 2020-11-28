using System;
using System.Collections.Generic;
using System.Text;

namespace DIMS_Core.Common.DI
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Constructor | AttributeTargets.Class)]
    public class InjectAttribute : Attribute
    {
    }
}
