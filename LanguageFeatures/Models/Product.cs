using System;

namespace LanguageFeatures.Models
{
    public class Product
    {
        public Product(bool stock = true)
        {
            InStock = stock;
        }

        public string Name { get; set; }
        public string Category { get; set; } = "Watersports";
        public decimal? Price { get; set; }
        public Product Releated { get; set; }
        public bool InStock { get; }
        public bool NameBeginWithS => Name?[0] == 'S';

        public static Product[] GetProducts()
        {
            Product kayak = new Product
            {
                Name = "Kayak",
                Category = "Water Craft",
                Price = 250M
            };

            Product lifejacket = new Product
            {
                Name = "Lifejacket",
                Price = 48.95M
            };

            kayak.Releated = lifejacket;

            return new Product[] { kayak, lifejacket, null };
        }
    }
}
