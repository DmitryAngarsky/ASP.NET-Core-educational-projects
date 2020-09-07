using UnitTestApp.Models;
using Xunit;

namespace UnitTestApp.Tests
{

    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            // Организация
            // Arrange
            var p = new Product { Name = "Test", Price = 100M };

            // Действие
            // Act
            p.Name = "New Name";

            // Утверждение
            // Assert
            Assert.Equal("New Name", p.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {

            // Arrange
            var p = new Product { Name = "Test", Price = 100M };

            // Act
            p.Price = 200M;

            //Assert
            Assert.Equal(200M, p.Price);
        }
    }
}
