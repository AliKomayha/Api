using Microsoft.AspNetCore.Mvc;
using ProductAPIVS.Models;

namespace getPost.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
   

    private readonly Learn_DBContext _DBContext;

    public ProductController(Learn_DBContext dBContext)
    {
        this._DBContext=dBContext;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var product= this._DBContext.Products.ToList();
        return Ok(product);
    }
    
    [HttpGet("GetbyId/{ID}")]
    public IActionResult GetbyId(int ID)
    {
        var product= this._DBContext.Products.FirstOrDefault(o=>o.Id==ID);
        return Ok(product);
    }

    [HttpPost("Create")]
    public IActionResult Create ([FromBody] Product _product)
    {
        var product= this._DBContext.Products.FirstOrDefault(o=>o.Id==_product.Id);
        if(product!=null){
            product.Name=_product.Name;
            product.Price=_product.Price;
            this._DBContext.SaveChanges();
        }
        else{
            this._DBContext.Products.Add(_product);
            this._DBContext.SaveChanges();
        }
        return Ok(true);
    }
}
