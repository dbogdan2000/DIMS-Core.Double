using DIMS_Core.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DIMS_Core.BusinessLayer.Interfaces
{
    public interface IDirectionService
    {
        Task<DirectionModel> Create(DirectionModel direction);
        Task<DirectionModel> GetById(int id);
        Task<IEnumerable<DirectionModel>> GetAll();

        Task<DirectionModel> Update(DirectionModel direction);

        Task Delete(int id);
    }
}
