using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UnitTestApp.Controllers;
using UnitTestApp.Models;
using Xunit;
using Moq;

namespace UnitTestApp.Test
{
    public class HomeControllerTest
    {
        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; set; }

            public void AddProduct(Product p)
            {

            }
        }

        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelComplete(Product[] products)
        {
            // Организация
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            var controller = new HomeController { Repository = mock.Object };

            // Действие
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Утверждение
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            // Организация
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products)
                .Returns(new[] { new Product { Name = "P1", Price = 100 } });

            var controller = new HomeController { Repository = mock.Object };

            // Действие
            var result = controller.Index();

            // Утверждение
            mock.Verify(m => m.Products, Times.Once);
        }
    }
}
