using Application.Features.Commands.CategoryCommands;
using Application.Features.Handlers.CategoryHandlers;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Application.Features.Handlers.CategoryHandlerTests
{
    public class CreateCategoryCommandHandlerTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CreateCategoryCommandHandler _handler;

        public CreateCategoryCommandHandlerTests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _mapperMock = new Mock<IMapper>();

            _handler = new CreateCategoryCommandHandler(
                _categoryRepositoryMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task Handle_Should_Add_Category_And_Return_Unit()
        {
            // Arrange
            var command = new CreateCategoryCommand
            {
                CategoryName = "Test Category"
            };

            var mappedCategory = new Category
            {
                CategoryName = command.CategoryName,
                CategoryId = Guid.NewGuid() // ID'yi burada test için ayarlıyoruz
            };

            _mapperMock
                .Setup(m => m.Map<Category>(command))
                .Returns(mappedCategory);

            _categoryRepositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<Category>()))
                .Returns(Task.CompletedTask);

            _categoryRepositoryMock
                .Setup(repo => repo.SaveChangesAsync())
                .Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mapperMock.Verify(m => m.Map<Category>(command), Times.Once);
            _categoryRepositoryMock.Verify(repo => repo.AddAsync(It.Is<Category>(c => c.CategoryName == "Test Category")), Times.Once);
            _categoryRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);

            Assert.Equal(Unit.Value, result);
        }

        [Fact]
        public async Task Handle_Should_Throw_Exception_When_Error_Occurs()
        {
            // Arrange
            var command = new CreateCategoryCommand
            {
                CategoryName = "Test Category"
            };

            _mapperMock
                .Setup(m => m.Map<Category>(command))
                .Throws(new Exception("Mapping failed"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(async () => await _handler.Handle(command, CancellationToken.None));
        }
    }
}
