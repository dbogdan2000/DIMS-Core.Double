using System;
using System.Collections.Generic;
using System.Linq;
using DIMS_Core.DataAccessLayer.Models;
using ThreadTask = System.Threading.Tasks.Task;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.DataAccessLayer.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DIMS_Core.Tests
{
    public class TaskRepositoryTest
    {
        [Fact]
        public async ThreadTask GetAll_OK()
        {
            //Arrange
            await using var context = ContextCreator.CreateContext();
            var dbSet = context.Set<Task>();
            var taskRepository = new TaskRepository(context);
            List<Task> tasks = new List<Task>()
                               {
                                   new()
                                   {
                                       Name = "Name1",
                                       Description = "Description1",
                                       StartDate = DateTime.Now.AddDays(1),
                                       DeadlineDate = DateTime.Now.AddDays(11)
                                   },
                                   new()
                                   {
                                       Name = "Name2",
                                       Description = "Description2",
                                       StartDate = DateTime.Now.AddDays(2),
                                       DeadlineDate = DateTime.Now.AddDays(12)
                                   },
                                   new()
                                   {
                                       Name = "Name3",
                                       Description = "Description3",
                                       StartDate = DateTime.Now.AddDays(3),
                                       DeadlineDate = DateTime.Now.AddDays(13)
                                   },
                                   new()
                                   {
                                       Name = "Name4",
                                       Description = "Description4",
                                       StartDate = DateTime.Now.AddDays(4),
                                       DeadlineDate = DateTime.Now.AddDays(14)
                                   },
                                   new()
                                   {
                                       Name = "Name5",
                                       Description = "Description5",
                                       StartDate = DateTime.Now.AddDays(5),
                                       DeadlineDate = DateTime.Now.AddDays(15)
                                   }
                               };
            await dbSet.AddRangeAsync(tasks);
            await context.SaveChangesAsync();

            //Act
            var result = taskRepository.GetAll();

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(tasks.Count, await result.CountAsync());
            Assert.All(result, task => tasks.Any(t => task.TaskId == t.TaskId));
        }

        [Fact]
        public async ThreadTask GetById_OK()
        {
            //Arrange
            await using var context = ContextCreator.CreateContext();
            var dbSet = context.Set<Task>();
            var taskRepository = new TaskRepository(context);
            var task = new Task()
                       {
                           Name = "Name1",
                           Description = "Description1",
                           StartDate = DateTime.Now.AddDays(1),
                           DeadlineDate = DateTime.Now.AddDays(11)
                       };
            await dbSet.AddAsync(task);
            await context.SaveChangesAsync();

            //Act
            var result = await taskRepository.GetById(1);

            //Assert
            Assert.Equal(result, task);
        }

        [Fact]
        public async ThreadTask GetById_IncorrectData_Fail()
        {
            //Arrange
            await using var context = ContextCreator.CreateContext();
            var dbSet = context.Set<Task>();
            var taskRepository = new TaskRepository(context);
            var task = new Task()
                       {
                           Name = "Name1",
                           Description = "Description1",
                           StartDate = DateTime.Now.AddDays(1),
                           DeadlineDate = DateTime.Now.AddDays(11)
                       };
            await dbSet.AddAsync(task);
            await context.SaveChangesAsync();

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => taskRepository.GetById(2));
        }

        [Fact]
        public async ThreadTask Create_OK()
        {
            //Arrange
            await using var context = ContextCreator.CreateContext();
            var dbSet = context.Set<Task>();
            var taskRepository = new TaskRepository(context);
            List<Task> tasks = new List<Task>()
                               {
                                   new()
                                   {
                                       Name = "Name1",
                                       Description = "Description1",
                                       StartDate = DateTime.Now.AddDays(1),
                                       DeadlineDate = DateTime.Now.AddDays(11)
                                   },
                                   new()
                                   {
                                       Name = "Name2",
                                       Description = "Description2",
                                       StartDate = DateTime.Now.AddDays(2),
                                       DeadlineDate = DateTime.Now.AddDays(12)
                                   },
                                   new()
                                   {
                                       Name = "Name3",
                                       Description = "Description3",
                                       StartDate = DateTime.Now.AddDays(3),
                                       DeadlineDate = DateTime.Now.AddDays(13)
                                   },

                               };
            await dbSet.AddRangeAsync(tasks);
            await context.SaveChangesAsync();
            var task = new Task()
                       {
                           Name = "Name4",
                           Description = "Description4",
                           StartDate = DateTime.Now.AddDays(4),
                           DeadlineDate = DateTime.Now.AddDays(14)
                       };

            //Act
            var entity =  await taskRepository.Create(task);
            await context.SaveChangesAsync();
            var result = taskRepository.GetAll();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(await result.CountAsync(), tasks.Count + 1);
            Assert.Equal(entity.TaskId, task.TaskId);
            Assert.Equal(entity.Name, task.Name);
            Assert.Equal(entity.StartDate, task.StartDate);
            Assert.Equal(entity.DeadlineDate, task.DeadlineDate);
        }
        
        [Fact]
        public async ThreadTask Create_IncorrectData_Fail()
        {
            //Arrange
            await using var context = ContextCreator.CreateContext();
            var dbSet = context.Set<Task>();
            var taskRepository = new TaskRepository(context);
            List<Task> tasks = new List<Task>()
                               {
                                   new()
                                   {
                                       Name = "Name1",
                                       Description = "Description1",
                                       StartDate = DateTime.Now.AddDays(1),
                                       DeadlineDate = DateTime.Now.AddDays(11)
                                   },
                                   new()
                                   {
                                       Name = "Name2",
                                       Description = "Description2",
                                       StartDate = DateTime.Now.AddDays(2),
                                       DeadlineDate = DateTime.Now.AddDays(12)
                                   },
                                   new()
                                   {
                                       Name = "Name3",
                                       Description = "Description3",
                                       StartDate = DateTime.Now.AddDays(3),
                                       DeadlineDate = DateTime.Now.AddDays(13)
                                   },

                               };
            await dbSet.AddRangeAsync(tasks);
            await context.SaveChangesAsync();
            var task = new Task()
                       {
                           Name = "Name4",
                           Description = "Description4",
                           StartDate = DateTime.Now.AddDays(4),
                           DeadlineDate = DateTime.Now.AddDays(14)
                       };

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => taskRepository.Create(null));
        }

        [Fact]
        public async ThreadTask Update_OK()
        {
            //Arrange
            await using var context = ContextCreator.CreateContext();
            var dbSet = context.Set<Task>();
            var taskRepository = new TaskRepository(context);
            List<Task> tasks = new List<Task>()
                               {
                                   new()
                                   {
                                       Name = "Name1",
                                       Description = "Description1",
                                       StartDate = DateTime.Now.AddDays(1),
                                       DeadlineDate = DateTime.Now.AddDays(11)
                                   },
                                   new()
                                   {
                                       Name = "Name2",
                                       Description = "Description2",
                                       StartDate = DateTime.Now.AddDays(2),
                                       DeadlineDate = DateTime.Now.AddDays(12)
                                   }
                               };
            await dbSet.AddRangeAsync(tasks);
            await context.SaveChangesAsync();
            var newName = "UpdatedName";
            var newDescription = "UpdatedDescription";
            var newStartDate = DateTime.Now.AddDays(5);
            var newDeadlineDate = DateTime.Now.AddDays(15);
            var newTask = await dbSet.FirstAsync();
            newTask.Name = newName;
            newTask.Description = newDescription;
            newTask.StartDate = newStartDate;
            newTask.DeadlineDate = newDeadlineDate;
            
            //Act
            taskRepository.Update(newTask);
            await context.SaveChangesAsync();
            var result = taskRepository.GetAll();
            
            //Assert
            Assert.NotNull(result);
            Assert.Equal(await result.CountAsync(), tasks.Count);
            Assert.Equal(newName, result.First().Name);
            Assert.Equal(newDescription, result.First().Description);
            Assert.Equal(newStartDate,result.First().StartDate);
            Assert.Equal(newDeadlineDate, result.First().DeadlineDate);
        }
        
         [Fact]
        public async ThreadTask Update_IncorrectData_Fail()
        {
            //Arrange
            await using var context = ContextCreator.CreateContext();
            var dbSet = context.Set<Task>();
            var taskRepository = new TaskRepository(context);
            List<Task> tasks = new List<Task>()
                               {
                                   new()
                                   {
                                       Name = "Name1",
                                       Description = "Description1",
                                       StartDate = DateTime.Now.AddDays(1),
                                       DeadlineDate = DateTime.Now.AddDays(11)
                                   },
                                   new()
                                   {
                                       Name = "Name2",
                                       Description = "Description2",
                                       StartDate = DateTime.Now.AddDays(2),
                                       DeadlineDate = DateTime.Now.AddDays(12)
                                   }
                               };
            await dbSet.AddRangeAsync(tasks);
            await context.SaveChangesAsync();
            var newName = "UpdatedName";
            var newDescription = "UpdatedDescription";
            var newStartDate = DateTime.Now.AddDays(5);
            var newDeadlineDate = DateTime.Now.AddDays(15);
            var newTask = await dbSet.FirstAsync();
            newTask.Name = newName;
            newTask.Description = newDescription;
            newTask.StartDate = newStartDate;
            newTask.DeadlineDate = newDeadlineDate;
            
            //Act, Assert
            Assert.Throws<ArgumentNullException>(() => taskRepository.Update(null));
        }

        [Fact]
        public async ThreadTask Delete_OK()
        {
            //Arrange
            await using var context = ContextCreator.CreateContext();
            var dbSet = context.Set<Task>();
            var taskRepository = new TaskRepository(context);
            var task = new Task()
                       {
                           Name = "Name1",
                           Description = "Description1",
                           StartDate = DateTime.Now.AddDays(1),
                           DeadlineDate = DateTime.Now.AddDays(11)
                       };
            await dbSet.AddAsync(task);
            await context.SaveChangesAsync();
           
            
            //Act
            await taskRepository.Delete(task.TaskId);
            await context.SaveChangesAsync();
            
            //Assert
            Assert.DoesNotContain(task, dbSet);
        }
    }
}