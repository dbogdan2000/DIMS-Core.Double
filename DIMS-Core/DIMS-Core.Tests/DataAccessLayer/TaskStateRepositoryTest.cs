using System;
using DIMS_Core.Common.Exceptions;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.Tests.DataAccessLayer.Fixtures;
using Microsoft.EntityFrameworkCore;
using Xunit;
using ThreadTask = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.DataAccessLayer
{
    public class TaskStateRepositoryTest : IDisposable
    {
        private readonly TaskStateRepositoryFixture _fixture;

        public TaskStateRepositoryTest()
        {
            //Arrange
            _fixture = new TaskStateRepositoryFixture();
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
            var result = await _fixture.Repository.GetById(_fixture.AddStateId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_fixture.AddStateId, result.StateId);
            Assert.Equal("Added Name", result.StateName);
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
            var newTaskState = new TaskState()
                               {
                                   StateName = "New Name"
                               };
            //Act
            var result = await _fixture.Repository.Create(newTaskState);

            await _fixture.Context.SaveChangesAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(newTaskState.StateId, result.StateId);
            Assert.Equal(newTaskState.StateName, result.StateName);
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
            var updatedStateName = "Updated Name";
            var updatedTaskState = await _fixture.Context.TaskStates.FindAsync(_fixture.UpdateStateId);
            updatedTaskState.StateName = updatedStateName;

            //Act
            var result = _fixture.Repository.Update(updatedTaskState);
            await _fixture.Context.SaveChangesAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_fixture.UpdateStateId, result.StateId);
            Assert.Equal(updatedStateName, result.StateName);
        }
        
        [Fact]
        public async ThreadTask Update_IncorrectData_Fail()
        {
            //Act, Assert
            Assert.Throws<ArgumentNullException>(() => _fixture.Repository.Update(null));
        }

        [Fact]
        public async ThreadTask Delete_OK()
        {
            //Act
             await _fixture.Repository.Delete(_fixture.DeleteStateId);
             await _fixture.Context.SaveChangesAsync();

            //Assert
            Assert.DoesNotContain(await _fixture.Context.TaskStates.FindAsync(_fixture.DeleteStateId),  _fixture.Repository.GetAll());
        }
        
        [Fact]
        public async ThreadTask Delete_IncorrectData_Fail()
        {
            //Act, Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _fixture.Repository.Delete(5));
        }
        

        public void Dispose()
        {
            _fixture.Dispose();
        }
    }
}