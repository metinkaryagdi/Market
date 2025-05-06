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
    public class UpdateCategoryHandlerTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UpdateCategoryHandler _handler;

        public UpdateCategoryHandlerTests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _mapperMock = new Mock<IMapper>();

            _handler = new UpdateCategoryHandler(_categoryRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Throw_Exception_When_Category_Not_Found()
        {
            // Arrange
            var command = new UpdateCategoryCommand
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = "Updated Category"
            };

            // Kategori repository'den null dönecek
            _categoryRepositoryMock
                .Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Category)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));
            Assert.Equal("Kategori bulunamadı.", exception.Message);
        }

        [Fact]
        public async Task Handle_Should_Update_Category_When_Category_Is_Found()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var command = new UpdateCategoryCommand
            {
                CategoryId = categoryId,
                CategoryName = "Updated Category"
            };

            var category = new Category
            {
                CategoryId = categoryId,
                CategoryName = "Old Category"
            };

            // Kategori repository'den mevcut kategori dönecek
            _categoryRepositoryMock
                .Setup(repo => repo.GetByIdAsync(categoryId))
                .ReturnsAsync(category);

            // Mapper'ın doğru şekilde çalıştığını doğruluyoruz
            _mapperMock
                .Setup(m => m.Map(command, category))
                .Verifiable();

            // UpdateAsync ve SaveChangesAsync metodlarının çalışmasını sağlıyoruz
            _categoryRepositoryMock
                .Setup(repo => repo.UpdateAsync(It.IsAny<Category>()))
                .Returns(Task.CompletedTask);
            _categoryRepositoryMock
                .Setup(repo => repo.SaveChangesAsync())
                .Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _categoryRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<Category>(c => c.CategoryId == categoryId && c.CategoryName == "Updated Category")), Times.Once);
            _categoryRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
            _mapperMock.Verify(m => m.Map(command, category), Times.Once);
            Assert.Equal(Unit.Value, result); // MediatR'da Unit.Value döner
        }
    }
}
