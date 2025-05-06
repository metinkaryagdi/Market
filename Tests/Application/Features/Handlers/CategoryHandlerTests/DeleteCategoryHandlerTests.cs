using Application.Features.Commands.CategoryCommands;
using Application.Features.Handlers.CategoryHandlers;
using Application.Features.Queries.CategoryQueries;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Application.Features.Handlers.CategoryHandlerTests
{
    public class DeleteCategoryHandlerTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly DeleteCategoryHandler _handler;

        public DeleteCategoryHandlerTests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _handler = new DeleteCategoryHandler(_categoryRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Return_False_When_Category_Not_Found()
        {
            // Arrange
            var command = new DeleteCategoryCommand(Guid.NewGuid());

            // Kategori repository'den null dönecek
            _categoryRepositoryMock
                .Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Category)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);  // Kategori bulunamadığı için false döndürmeli
        }

        [Fact]
        public async Task Handle_Should_Return_True_When_Category_Is_Deleted()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var command = new DeleteCategoryCommand(categoryId);
            var category = new Category { CategoryId = categoryId, CategoryName = "Test Category" };

            // Kategori repository'den mevcut kategori dönecek
            _categoryRepositoryMock
                .Setup(repo => repo.GetByIdAsync(categoryId))
                .ReturnsAsync(category);

            _categoryRepositoryMock
                .Setup(repo => repo.DeleteAsync(category))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _categoryRepositoryMock.Verify(repo => repo.DeleteAsync(It.Is<Category>(c => c.CategoryId == categoryId)), Times.Once);
            Assert.True(result);  // Kategori başarıyla silindiği için true döndürmeli
        }
    }
}
