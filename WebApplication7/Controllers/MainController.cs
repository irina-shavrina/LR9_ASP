using ASP.NET.Views.Main;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;


public class MainController : Controller
{
    [Route("")]
    public IActionResult Index()
    {
        return RedirectToAction("AddProduct", "Main");
    }

    [HttpGet]
    [Route("AddProduct")]
    public IActionResult AddProduct()
    {
        return View();
    }

    [HttpPost]
    [Route("AddProduct")]
    public IActionResult AddProductPut(string name, string price)
    {
        bool result = false;
        try
        {
            Product product = new Product(name, decimal.Parse(price, CultureInfo.InvariantCulture), DateTime.Now);
            result = ProductRepository.AddProduct(product);
        }
        catch { }
        TempData["Status"] = result;
        return View("AddProduct");
    }

    [HttpGet]
    [HttpPost]
    [Route("ProductView")]
    public IActionResult ProductView()
    {
        ProductViewModel model;
       
            model = new ProductViewModel {  Products = ProductRepository.GetProductList() };
        
 
        return View(model);
    }

    [HttpGet]
    [Route("Map")]
    public IActionResult MapGet()
    {
        return View();
    }

    [HttpPost]
    [Route("Map")]
    public IActionResult MapPost(string lat, string lng)
    {
        var model = new MapPostModel
        {
            Lat = lat,
            Lng = lng
        };

        return View(model);
    }
}