//using Domain.Entities;
//using Domain.Interfaces;
//using Infrastructure.Repositories;
//using Moq;
//using Xunit;

//namespace Tests.Infrastructure.Repositories
//{
//    public class CategoryRepositoryTests
//    {
//        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;

//        public CategoryRepositoryTests()
//        {
//            _categoryRepositoryMock = new Mock<ICategoryRepository>();
//        }

//        [Fact]
//        public void AddAsync_Should_Add_Category()
//        {
//            // Arrange
//            var category = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Test Kategori" };

//            // Act
//            _categoryRepositoryMock.Object.AddAsync(category);

//            // Assert
//            _categoryRepositoryMock.Verify(repo => repo.AddAsync(It.Is<Category>(c => c.CategoryName == "Test Kategori")), Times.Once);
//        }
//    }
//}
