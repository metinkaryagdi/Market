//using Domain.Entities;
//using Domain.Interfaces;
//using Moq;
//using Xunit;

//namespace Tests.Domain.Interfaces
//{
//    public class ICategoryRepositoryTests
//    {
//        private readonly Mock<ICategoryRepository> _repositoryMock;

//        public ICategoryRepositoryTests()
//        {
//            _repositoryMock = new Mock<ICategoryRepository>();
//        }

//        [Fact]
//        public void AddAsync_Should_Call_Add_Method()
//        {
//            // Arrange
//            var category = new Category { CategoryId = Guid.NewGuid(), CategoryName = "Test Kategori" };

//            // Act
//            _repositoryMock.Object.AddAsync(category);

//            // Assert
//            _repositoryMock.Verify(r => r.AddAsync(It.IsAny<Category>()), Times.Once);
//        }
//    }
//}
