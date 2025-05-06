using Application.Features.Handlers.CategoryHandlers;
using Application.Features.Queries.CategoryQueries;
using Application.Features.Results.CategoryResults;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Application.Features.Handlers.CategoryHandlerTests
{
    public class GetCategoryQueryHandlerTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly GetCategoryQueryHandler _handler;

        public GetCategoryQueryHandlerTests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _mapperMock = new Mock<IMapper>();

            _handler = new GetCategoryQueryHandler(_categoryRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Return_Category_List()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "Category 1" },
                new Category { CategoryId = Guid.NewGuid(), CategoryName = "Category 2" }
            };

            var categoryQueryResult = new List<GetCategoryQueryResult>
            {
                new GetCategoryQueryResult { CategoryId = categories[0].CategoryId, CategoryName = categories[0].CategoryName },
                new GetCategoryQueryResult { CategoryId = categories[1].CategoryId, CategoryName = categories[1].CategoryName }
            };

            _categoryRepositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(categories);

            _mapperMock
                .Setup(m => m.Map<IEnumerable<GetCategoryQueryResult>>(categories))
                .Returns(categoryQueryResult);

            // Act
            var result = await _handler.Handle(new GetCategoryQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(categories[0].CategoryId, result.First().CategoryId);
            Assert.Equal(categories[1].CategoryName, result.Last().CategoryName);
            _categoryRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            _mapperMock.Verify(m => m.Map<IEnumerable<GetCategoryQueryResult>>(categories), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_Return_Empty_List_When_No_Categories()
        {
            // Arrange
            var categories = new List<Category>();

            _categoryRepositoryMock
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(categories);

            _mapperMock
                .Setup(m => m.Map<IEnumerable<GetCategoryQueryResult>>(categories))
                .Returns(Enumerable.Empty<GetCategoryQueryResult>());

            // Act
            var result = await _handler.Handle(new GetCategoryQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            _categoryRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
            _mapperMock.Verify(m => m.Map<IEnumerable<GetCategoryQueryResult>>(categories), Times.Once);
        }
    }
}
