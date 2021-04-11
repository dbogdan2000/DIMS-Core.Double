using DIMS_Core.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.BusinessLayer.Interfaces
{
    public interface IReadOnlyService<TModel> : IDisposable 
        where TModel : class
    {
        Task<IEnumerable<TModel>> GetAll();
    }
}
