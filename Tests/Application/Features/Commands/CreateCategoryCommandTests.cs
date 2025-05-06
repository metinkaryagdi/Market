//using Application.Features.Commands.CategoryCommands;
//using AutoMapper;
//using Domain.Entities;
//using Moq;
//using System.Threading.Tasks;
//using Xunit;

//namespace Tests.Application.Commands.CategoryCommands
//{
//    public class CreateCategoryCommandTests
//    {
//        private readonly Mock<IMapper> _mapperMock;

//        public CreateCategoryCommandTests()
//        {
//            _mapperMock = new Mock<IMapper>();
//        }

//        [Fact]
//        public void CreateCategoryCommand_Should_Map_To_Category()
//        {
//            // Arrange
//            var command = new CreateCategoryCommand
//            {
//                CategoryName = "Test Category"
//            };
//            var category = new Category
//            {
//                CategoryName = command.CategoryName
//            };

//            _mapperMock
//                .Setup(m => m.Map<Category>(command))
//                .Returns(category);

//            // Act
//            var mappedCategory = _mapperMock.Object.Map<Category>(command);

//            // Assert
//            Assert.Equal("Test Category", mappedCategory.CategoryName);
//        }
//    }
//}
