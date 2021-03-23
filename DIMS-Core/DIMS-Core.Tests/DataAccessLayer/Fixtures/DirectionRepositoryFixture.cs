using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;

namespace DIMS_Core.Tests.DataAccessLayer.Fixtures
{
    public class DirectionRepositoryFixture : BaseRepositoryFixture<DirectionRepository>
    {
        public int UpdateDirectionId { get; set; }
        public int DeleteDirectionId { get; set; }

        public int AddDirectionId { get; set; }

        protected override DirectionRepository CreateRepository()
        {
            return new(Context);
        }

        protected override async void InitDatabase()
        {
            UpdateDirectionId = (await Context.Directions.AddAsync(new Direction()
                                                                   {
                                                                       Name = "New Name",
                                                                       Description = "New Description"
                                                                   })).Entity.DirectionId;
            DeleteDirectionId = (await Context.Directions.AddAsync(new Direction()
                                                                   {
                                                                       Name = "Deleted Name",
                                                                       Description = "Deleted Description"
                                                                   })).Entity.DirectionId;
            AddDirectionId = (await Context.Directions.AddAsync(new Direction()
                                                                  {
                                                                      Name = "Added Name",
                                                                      Description = "Added Description"
                                                                  })).Entity.DirectionId;
            await Context.SaveChangesAsync();
        }
    }
}