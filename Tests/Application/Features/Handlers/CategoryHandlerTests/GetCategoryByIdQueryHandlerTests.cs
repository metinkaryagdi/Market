using Application.Features.Handlers.CategoryHandlers;
using Application.Features.Queries.CategoryQueries;
using Application.Features.Results.CategoryResults;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Application.Features.Handlers.CategoryHandlerTests
{
    public class GetCategoryByIdQueryHandlerTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetCategoryByIdQueryHandler _handler;

        public GetCategoryByIdQueryHandlerTests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _mapperMock = new Mock<IMapper>();

            _handler = new GetCategoryByIdQueryHandler(_categoryRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Throw_Exception_When_Category_Not_Found()
        {
            // Arrange
            var command = new GetCategoryByIdQuery(Guid.NewGuid());

            // Kategori repository'den null dönecek
            _categoryRepositoryMock
                .Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Category)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));
            Assert.Equal("Kategori bulunamadı.", exception.Message);
        }

        [Fact]
        public async Task Handle_Should_Return_Category_When_Category_Is_Found()
        {
            // Arrange
            var categoryId = Guid.NewGuid();
            var command = new GetCategoryByIdQuery(categoryId);

            var category = new Category
            {
                CategoryId = categoryId,
                CategoryName = "Test Category"
            };

            var expectedResult = new GetCategoryByIdQueryResult
            {
                CategoryId = categoryId,
                CategoryName = "Test Category"
            };

            // Kategori repository'den mevcut kategori dönecek
            _categoryRepositoryMock
                .Setup(repo => repo.GetByIdAsync(categoryId))
                .ReturnsAsync(category);

            // Mapper'ın doğru şekilde çalıştığını doğruluyoruz
            _mapperMock
                .Setup(m => m.Map<GetCategoryByIdQueryResult>(category))
                .Returns(expectedResult);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(expectedResult.CategoryId, result.CategoryId);
            Assert.Equal(expectedResult.CategoryName, result.CategoryName);
            _categoryRepositoryMock.Verify(repo => repo.GetByIdAsync(categoryId), Times.Once);
            _mapperMock.Verify(m => m.Map<GetCategoryByIdQueryResult>(category), Times.Once);
        }
    }
}
