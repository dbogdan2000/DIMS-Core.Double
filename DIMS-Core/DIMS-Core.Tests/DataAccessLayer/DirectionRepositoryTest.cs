using System;
using System.Collections.Generic;
using System.Linq;
using DIMS_Core.Common.Exceptions;
using DIMS_Core.DataAccessLayer.Models;
using ThreadTask = System.Threading.Tasks.Task;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.DataAccessLayer.Fixtures;
using DIMS_Core.Tests.DataAccessLayer.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DIMS_Core.Tests.DataAccessLayer
{
    public class DirectionRepositoryTest : IDisposable
    {
        private readonly DirectionRepositoryFixture _fixture;

        public DirectionRepositoryTest()
        {
            //Arrange
            _fixture = new DirectionRepositoryFixture();
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
            var result = await _fixture.Repository.GetById(_fixture.AddDirectionId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_fixture.AddDirectionId, result.DirectionId);
            Assert.Equal("Added Name", result.Name);
            Assert.Equal("Added Description", result.Description);
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
            var newDirection = new Direction()
                               {
                                   Name = "New Name",
                                   Description = "New Description"
                               };
            //Act
            var result = await _fixture.Repository.Create(newDirection);

            await _fixture.Context.SaveChangesAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(newDirection.DirectionId, result.DirectionId);
            Assert.Equal(newDirection.Name, result.Name);
            Assert.Equal(newDirection.Description, result.Description);
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
            var updatedDirection = await _fixture.Context.Directions.FindAsync(_fixture.UpdateDirectionId);
            updatedDirection.Name = updatedName;
            updatedDirection.Description = updatedDescription;

            //Act
            var result = _fixture.Repository.Update(updatedDirection);
            await _fixture.Context.SaveChangesAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_fixture.UpdateDirectionId, result.DirectionId);
            Assert.Equal(updatedName, result.Name);
            Assert.Equal(updatedDescription, result.Description);
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
             await _fixture.Repository.Delete(_fixture.DeleteDirectionId);
             await _fixture.Context.SaveChangesAsync();

            //Assert
            Assert.DoesNotContain(await _fixture.Context.Directions.FindAsync(_fixture.DeleteDirectionId), _fixture.Repository.GetAll());
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