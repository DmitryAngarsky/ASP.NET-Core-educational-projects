using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UnitTestApp.Controllers;
using UnitTestApp.Models;
using Xunit;

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
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepository
            {
                Products = products
            };

            // Действие
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Утверждение
            Assert.Equal(controller.Repository.Products, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }

    class PropertyOnceFakeRepository : IRepository
    {
        public int PropertyCounter { get; set; } = 0;

        public IEnumerable<Product> Products
        {
            get
            {
                PropertyCounter++;
                return new[] { new Product { Name = "P1", Price = 100 } };
            }
        }

        public void AddProduct(Product p)
        {

        }

        public void RepositoryPropertyCalledOnce()
        {
            var repo = new PropertyOnceFakeRepository();
            var controller = new HomeController { Repository = repo };

            var result = controller.Index();

            Assert.Equal(1, repo.PropertyCounter);
        }
    }
}
