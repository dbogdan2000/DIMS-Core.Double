using System;
using System.Collections.Generic;
using System.Linq;
using DIMS_Core.DataAccessLayer.Models;
using ThreadTask = System.Threading.Tasks.Task;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.DataAccessLayer.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace DIMS_Core.Tests.DataAccessLayer
{
    public class DirectionRepositoryTest
    {
        [Fact]
        public async ThreadTask GetAll_OK()
        {
            //Arrange
            await using var context = ContextCreator.CreateContext();
            var dbSet = context.Set<Direction>();
            var directionRepository = new DirectionRepository(context);
            List<Direction> directions = new List<Direction>()
                                         {
                                             new()
                                             {
                                                 Name = "Name1",
                                                 Description = "Description1",
                                             },
                                             new()
                                             {
                                                 Name = "Name2",
                                                 Description = "Description2",
                                             },
                                             new()
                                             {
                                                 Name = "Name3",
                                                 Description = "Description3",
                                             },
                                             new()
                                             {
                                                 Name = "Name4",
                                                 Description = "Description4",
                                             }
                                         };
            await dbSet.AddRangeAsync(directions);
            await context.SaveChangesAsync();

            //Act
            var result = directionRepository.GetAll();

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(directions.Count, await result.CountAsync());
            Assert.All(result, direction => directions.Any(d => direction.DirectionId == d.DirectionId));
        }

        [Fact]
        public async ThreadTask GetById_OK()
        {
            //Arrange
            await using var context = ContextCreator.CreateContext();
            var dbSet = context.Set<Direction>();
            var directionRepository = new DirectionRepository(context);
            var direction = new Direction()
                            {
                                Name = "Name1",
                                Description = "Description1"
                            };
            await dbSet.AddAsync(direction);
            await context.SaveChangesAsync();

            //Act
            var result = await directionRepository.GetById(1);

            //Assert
            Assert.Equal(result, direction);
        }
        
        [Fact]
        public async ThreadTask GetById_IncorrectData_Fail()
        {
            //Arrange
            await using var context = ContextCreator.CreateContext();
            var dbSet = context.Set<Direction>();
            var directionRepository = new DirectionRepository(context);
            var direction = new Direction()
                            {
                                Name = "Name1",
                                Description = "Description1"
                            };
            await dbSet.AddAsync(direction);
            await context.SaveChangesAsync();

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => directionRepository.GetById(2));
        }

        [Fact]
        public async ThreadTask Create_OK()
        {
            //Arrange
            await using var context = ContextCreator.CreateContext();
            var dbSet = context.Set<Direction>();
            var directionRepository = new DirectionRepository(context);
            List<Direction> directions = new List<Direction>()
                               {
                                   new()
                                   {
                                       Name = "Name1",
                                       Description = "Description1",
                                   },
                                   new()
                                   {
                                       Name = "Name2",
                                       Description = "Description2",
                                   },
                                   new()
                                   {
                                       Name = "Name3",
                                       Description = "Description3",
                                   },

                               };
            await dbSet.AddRangeAsync(directions);
            await context.SaveChangesAsync();
            var direction = new Direction()
                       {
                           Name = "Name4",
                           Description = "Description4",
                       };

            //Act
            var entity = await directionRepository.Create(direction);
            await context.SaveChangesAsync();
            var result = directionRepository.GetAll();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(await result.CountAsync(), directions.Count + 1);
            Assert.Equal(entity.DirectionId, direction.DirectionId);
            Assert.Equal(entity.Name, direction.Name);
        }
        
        [Fact]
        public async ThreadTask Create_IncorrectData_Fail()
        {
            //Arrange
            await using var context = ContextCreator.CreateContext();
            var dbSet = context.Set<Direction>();
            var directionRepository = new DirectionRepository(context);
            List<Direction> directions = new List<Direction>()
                                         {
                                             new()
                                             {
                                                 Name = "Name1",
                                                 Description = "Description1",
                                             },
                                             new()
                                             {
                                                 Name = "Name2",
                                                 Description = "Description2",
                                             },
                                             new()
                                             {
                                                 Name = "Name3",
                                                 Description = "Description3",
                                             },

                                         };
            await dbSet.AddRangeAsync(directions);
            await context.SaveChangesAsync();
            var direction = new Direction()
                            {
                                Name = "Name4",
                                Description = "Description4",
                            };

            //Act
            await Assert.ThrowsAsync<ArgumentNullException>(() => directionRepository.Create(null));
        }

        [Fact]
        public async ThreadTask Update_OK()
        {
            //Arrange
            await using var context = ContextCreator.CreateContext();
            var dbSet = context.Set<Direction>();
            var directionRepository = new DirectionRepository(context);
            List<Direction> directions = new List<Direction>()
                               {
                                   new()
                                   {
                                       Name = "Name1",
                                       Description = "Description1",
                                   },
                                   new()
                                   {
                                       Name = "Name2",
                                       Description = "Description2",
                                   }
                               };
            await dbSet.AddRangeAsync(directions);
            await context.SaveChangesAsync();
            var newName = "UpdatedName";
            var newDescription = "UpdatedDescription";
            var newDirection = await dbSet.FirstAsync();
            newDirection.Name = newName;
            newDirection.Description = newDescription;

            //Act
            directionRepository.Update(newDirection);
            await context.SaveChangesAsync();
            var result = directionRepository.GetAll();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(await result.CountAsync(), directions.Count);
            Assert.Equal(newName,
                         result.First()
                               .Name);
            Assert.Equal(newDescription,
                         result.First()
                               .Description);
        }
        
        [Fact]
        public async ThreadTask Update_IncorrectData_Fail()
        {
            //Arrange
            await using var context = ContextCreator.CreateContext();
            var dbSet = context.Set<Direction>();
            var directionRepository = new DirectionRepository(context);
            List<Direction> directions = new List<Direction>()
                                         {
                                             new()
                                             {
                                                 Name = "Name1",
                                                 Description = "Description1",
                                             },
                                             new()
                                             {
                                                 Name = "Name2",
                                                 Description = "Description2",
                                             }
                                         };
            await dbSet.AddRangeAsync(directions);
            await context.SaveChangesAsync();
            var newName = "UpdatedName";
            var newDescription = "UpdatedDescription";
            var newDirection = await dbSet.FirstAsync();
            newDirection.Name = newName;
            newDirection.Description = newDescription;

            //Act, Assert
            Assert.Throws<ArgumentNullException>(() => directionRepository.Update(null));
        }

        [Fact]
        public async ThreadTask Delete_OK()
        {
            //Arrange
            await using var context = ContextCreator.CreateContext();
            var dbSet = context.Set<Direction>();
            var directionRepository = new DirectionRepository(context);
            List<Direction> directions = new List<Direction>()
                                         {
                                             new()
                                             {
                                                 Name = "Name1",
                                                 Description = "Description1",
                                             },
                                             new()
                                             {
                                                 Name = "Name2",
                                                 Description = "Description2",
                                             }
                                         };
            await dbSet.AddRangeAsync(directions);
            await context.SaveChangesAsync();
            var direction = directions.First();

            //Act
            await directionRepository.Delete(direction.DirectionId);
            await context.SaveChangesAsync();
            var result = directionRepository.GetAll();

            //Assert
            Assert.Equal(await result.CountAsync(), directions.Count - 1);
            Assert.DoesNotContain(direction, dbSet);
        }
        
        [Fact]
        public async ThreadTask Delete_IncorrectData_Fail()
        {
            //Arrange
            await using var context = ContextCreator.CreateContext();
            var dbSet = context.Set<Direction>();
            var directionRepository = new DirectionRepository(context);
            List<Direction> directions = new List<Direction>()
                                         {
                                             new()
                                             {
                                                 Name = "Name1",
                                                 Description = "Description1",
                                             },
                                             new()
                                             {
                                                 Name = "Name2",
                                                 Description = "Description2",
                                             }
                                         };
            await dbSet.AddRangeAsync(directions);
            await context.SaveChangesAsync();
            var direction = directions.First();

            //Act, Assert
            await Assert.ThrowsAsync<ArgumentException>(() => directionRepository.Delete(5));
        }
    }
}