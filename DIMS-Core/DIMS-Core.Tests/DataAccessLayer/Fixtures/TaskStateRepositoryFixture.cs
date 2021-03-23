using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;

namespace DIMS_Core.Tests.DataAccessLayer.Fixtures
{
    public class TaskStateRepositoryFixture : BaseRepositoryFixture<TaskStateRepository>
    {
        public int UpdateStateId { get; private set; }
        public int DeleteStateId { get; private set; }
        public int AddStateId { get; private set; }

        protected override TaskStateRepository CreateRepository()
        {
            return new(Context);
        }

        protected override async void InitDatabase()
        {
            UpdateStateId = (await Context.TaskStates.AddAsync(new TaskState()
                                                               {
                                                                   StateName = "New Name"
                                                               })).Entity.StateId;
            DeleteStateId = (await Context.TaskStates.AddAsync(new TaskState()
                                                               {
                                                                   StateName = "Deleted Name"
                                                               })).Entity.StateId;
            AddStateId = (await Context.TaskStates.AddAsync(new TaskState()
                                                            {
                                                                StateName = "Added Name"
                                                            })).Entity.StateId;
            await Context.SaveChangesAsync();
        }
    }
}