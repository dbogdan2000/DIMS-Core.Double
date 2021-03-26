using System;
using DIMS_Core.Common.Exceptions;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.Tests.DataAccessLayer.Fixtures;
using Microsoft.EntityFrameworkCore;
using Xunit;
using ThreadTask = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.DataAccessLayer
{
    
    public class TaskRepositoryTest : IDisposable
    {
        private readonly TaskRepositoryFixture _fixture;

        public TaskRepositoryTest()
        {
            //Arrange
            _fixture = new TaskRepositoryFixture();
        }
        
        [Fact]
        public async ThreadTask GetAll_OK()
        {
            //Act
            var result = _fixture.Repository.GetAll();

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(3, await result.CountAsync());
            
        }

        [Fact]
        public async ThreadTask GetById_OK()
        {

            //Act
            var result = await _fixture.Repository.GetById(_fixture.AddTaskId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_fixture.AddTaskId, result.TaskId);
            Assert.Equal("Added Name", result.Name);
            Assert.Equal("Added Description", result.Description);
            Assert.Equal(DateTime.Now.AddDays(1).Date, result.StartDate);
            Assert.Equal(DateTime.Now.AddDays(11).Date, result.DeadlineDate);
        }

        [Fact]
        public async ThreadTask GetById_IncorrectData_Fail()
        {
            //Act, Assert
            await Assert.ThrowsAsync<EntityNotExistException>(() => _fixture.Repository.GetById(5));
        }

        [Fact]
        public async ThreadTask Create_OK()
        {
            //Arrange
            var newTask = new Task
                          {
                              Name = "Created Name",
                              Description = "Created Description",
                              StartDate = DateTime.Now.AddDays(2)
                                                  .Date,
                              DeadlineDate = DateTime.Now.AddDays(12)
                                                     .Date
                          };

            //Act
            var result = await _fixture.Repository.Create(newTask);

            await _fixture.Context.SaveChangesAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(newTask.TaskId, result.TaskId);
            Assert.Equal(newTask.Name, result.Name);
            Assert.Equal(newTask.StartDate, result.StartDate);
            Assert.Equal(newTask.DeadlineDate, result.DeadlineDate);
        }
        
        [Fact]
        public async ThreadTask Create_IncorrectData_Fail()
        {
            //Act, Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _fixture.Repository.Create(null));
        }

        [Fact]
        public async ThreadTask Update_OK()
        {
            //Arrange
            var updatedName = "Updated Name";
            var updatedDescription = "Updated Description";
            var updatedStartDate = DateTime.Now.AddDays(3).Date;
            var updatedDeadlineDate = DateTime.Now.AddDays(13).Date;
            var updatedTask = await _fixture.Context.Tasks.FindAsync(_fixture.UpdateTaskId);
            updatedTask.Name = updatedName;
            updatedTask.Description = updatedDescription;
            updatedTask.StartDate = updatedStartDate;
            updatedTask.DeadlineDate = updatedDeadlineDate;
            
            //Act
            var result = _fixture.Repository.Update(updatedTask);
            await _fixture.Context.SaveChangesAsync();
            
            //Assert
            Assert.NotNull(result);
            Assert.Equal(_fixture.UpdateTaskId, result.TaskId);
            Assert.Equal(updatedName, result.Name);
            Assert.Equal(updatedDescription, result.Description);
            Assert.Equal(updatedStartDate,result.StartDate);
            Assert.Equal(updatedDeadlineDate, result.DeadlineDate);
        }
        
        [Fact]
        public async ThreadTask Update_IncorrectData_Fail()
        {
            //Act, Assert
            Assert.Throws<ArgumentNullException>(() => _fixture.Repository.Update(null));
        }

        public void Dispose()
        {
            _fixture.Dispose();
        }
    }
}