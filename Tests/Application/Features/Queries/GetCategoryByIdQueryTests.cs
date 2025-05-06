//using Application.Features.Handlers.CategoryHandlers;
//using Application.Features.Queries.CategoryQueries;
//using Application.Features.Results.CategoryResults;
//using Domain.Interfaces;
//using Moq;
//using System;
//using System.Threading;
//using System.Threading.Tasks;
//using Xunit;

//namespace Tests.Application.Queries.CategoryQueries
//{
//    public class GetCategoryByIdQueryTests
//    {
//        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;

//        public GetCategoryByIdQueryTests()
//        {
//            _categoryRepositoryMock = new Mock<ICategoryRepository>();
//        }

//        [Fact]
//        public async Task Handle_Should_Return_Category_By_Id()
//        {
//            // Arrange
//            var categoryId = Guid.NewGuid(); // Generate a new Guid
//            var query = new GetCategoryByIdQuery { CategoryId = categoryId }; // Pass the Guid
//            var category = new GetCategoryQueryResult
//            {
//                CategoryId = categoryId,  // Use Guid here
//                CategoryName = "Test Kategori"
//            };
//            _categoryRepositoryMock.Setup(repo => repo.GetByIdAsync(categoryId)).ReturnsAsync(category);

//            var handler = new GetCategoryByIdQueryHandler(_categoryRepositoryMock.Object);

//            // Act
//            var result = await handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.Equal(categoryId, result.CategoryId);
//            Assert.Equal("Test Kategori", result.CategoryName);
//        }
//    }
//}
