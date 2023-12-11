using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using inventory.Data;
using inventory.Model;
using AutoMapper;
using inventory.IService.Services;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;
        private readonly ApplicationDbContext _db;
        public ProductController(IProduct product, ApplicationDbContext db)
        {
            _product = product;
            _db=db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _product.GetAll());
        }

        // [HttpGet("{productId}")]
        // public async Task<IActionResult> Get(int? productId)
        // {
        //     if (productId==null || productId==0)
        //     {
        //         return BadRequest(new ErrorModelDto()
        //         {
        //             ErrorMessage="Invalid Id",
        //             StatusCode=StatusCodes.Status400BadRequest
        //         });
        //     }

        //     var product = await _product.Get(productId.Value);
        //     if (product==null)
        //     {
        //         return BadRequest(new ErrorModelDto()
        //         {
        //             ErrorMessage="Invalid Id",
        //             StatusCode=StatusCodes.Status404NotFound
        //         });
        //     }

        //     return Ok(product);
        // }
    }
}