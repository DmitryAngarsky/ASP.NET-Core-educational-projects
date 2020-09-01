using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            List<string> results = new List<string>();

            foreach(Product p in Product.GetProducts()){
                
                string name = p?.Name ?? "<No name>";
                decimal? price = p?.Price ?? 0;
                string releatedName = p?.Releated?.Name ?? "<None>";
                results.Add(string.Format("Name: {0} Price: {1} Releated: {2}", name, price, releatedName));
            }

            return View(results);
        }
    }
}
