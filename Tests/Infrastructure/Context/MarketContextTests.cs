//using Microsoft.EntityFrameworkCore;
//using Persistance.Context;
//using Xunit;

//namespace Tests.Infrastructure.Context
//{
//    public class MarketContextTests
//    {
//        private readonly MarketContext _context;

//        public MarketContextTests()
//        {
//            var options = new DbContextOptionsBuilder<MarketContext>()
//                .UseInMemoryDatabase("TestDatabase")
//                .Options;

//            _context = new MarketContext(options);
//        }

//        [Fact]
//        public void MarketContext_Should_Initialize_With_Correct_Options()
//        {
//            // Arrange & Act
//            var context = _context;

//            // Assert
//            Assert.NotNull(context);
//        }
//    }
//}
