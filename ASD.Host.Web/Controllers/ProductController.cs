using ASD.Commerce.Domain.Contracts.Services;
using ASD.Commerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ASD.Host.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductSrvc _productSrvc;
        public ProductController(IProductSrvc productSrvc) { 
            _productSrvc = productSrvc;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productSrvc.GetAllAsync());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _productSrvc.GetByIdAsync(id));
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product Product)
        {
            if (Product == null)
            {
                ModelState.AddModelError(nameof(Product), "Product is required.");
                return BadRequest(ModelState);
            }
            else
            {
                if (string.IsNullOrEmpty(Product.Name))
                {
                    ModelState.AddModelError(nameof(Product.Name), $"{nameof(Product.Name)} is required.");
                }
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _productSrvc.AddAsync(Product);

            return Created();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product Product)
        {
            if (id != Product?.Id)
            {
                ModelState.AddModelError(nameof(id), "Invalid id");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _productSrvc.Update(Product);
            return Ok();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                ModelState.AddModelError(nameof(id), "Invalid id");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _productSrvc.Remove(new Product { Id = id });

            return Ok();
        }
    }
}
