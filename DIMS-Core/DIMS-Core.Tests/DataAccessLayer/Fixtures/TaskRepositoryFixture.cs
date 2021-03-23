using System;
using DIMS_Core.DataAccessLayer.Models;
using ThreadTask = System.Threading.Tasks.Task;
using DIMS_Core.DataAccessLayer.Repositories;

namespace DIMS_Core.Tests.DataAccessLayer.Fixtures
{
    public class TaskRepositoryFixture : BaseRepositoryFixture<TaskRepository>
    {
        public int UpdateTaskId { get; private set; }
        public int DeleteTaskId { get; set; }
        public int AddTaskId { get; private set; }

        protected override TaskRepository CreateRepository()
        {
            return new(Context);
        }

        protected override async void InitDatabase()
        {
            UpdateTaskId = (await Context.Tasks.AddAsync(new Task()
                                                         {
                                                             Name = "New Name",
                                                             Description = "New Description",
                                                             StartDate = DateTime.Now.AddDays(5),
                                                             DeadlineDate = DateTime.Now.AddDays(15)
                                                         })).Entity.TaskId;
            DeleteTaskId = (await Context.Tasks.AddAsync(new Task()
                                                         {
                                                             Name = "Deleted Name",
                                                             Description = "Delete Description",
                                                             StartDate = DateTime.Now.AddDays(9),
                                                             DeadlineDate = DateTime.Now.AddDays(19)
                                                         })).Entity.TaskId;
            AddTaskId = (await Context.Tasks.AddAsync(new Task()
                                                      {
                                                          Name = "Added Name",
                                                          Description = "Added Description",
                                                          StartDate = DateTime.Now.AddDays(1).Date,
                                                          DeadlineDate = DateTime.Now.AddDays(11).Date
                                                      })).Entity.TaskId;
            
            await Context.SaveChangesAsync();

        }
    }
}