using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    private List<Product> GetProducts() 
    {
        List<Product> products = new List<Product>();
        products.Add(new Product {Id = 101,Name ="Bike",Description = "Details about Bike",Price = 234563});
        products.Add(new Product { Id = 102, Name = "AC", Description = "Details about AC", Price = 14563 });
        products.Add(new Product { Id = 103, Name = "Car", Description = "Details about Car", Price = 134563 });
        products.Add(new Product { Id = 104, Name = "Cycle", Description = "Details about Cycle", Price = 4563 });

        return products;
    }
    private List<Student> GetStudents()
    {
        List<Student> Students = new List<Student>();
        Students.Add(new Student { Id = 101, Name = "Bala", Number = 23456 });
        Students.Add(new Student { Id = 102, Name = "Ranga", Number = 43211 });
        Students.Add(new Student { Id = 103, Name = "Sai", Number = 54211 });
        return Students;
    }

    public ViewResult ShowProducts()
    {
        List<Product> product = GetProducts();
        ViewBag.Products = product;
        return View();
    }

    public ViewResult DisplayProducts()
    {
        List<Product> products = GetProducts();
        return View(products);
    }
    

    public ViewResult ShowLists()
    {
        CommonClass common = new CommonClass();
        common.Students = GetStudents();
        common.Products = GetProducts();
        return View(common);
    }

}
