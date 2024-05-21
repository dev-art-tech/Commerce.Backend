using ASD.Commerce.Domain.Contracts.Services;
using ASD.Commerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ASD.Host.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategorySrvc _categorySrvc;
        public CategoryController(ICategorySrvc categorySrvc) { 
            _categorySrvc = categorySrvc;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _categorySrvc.GetAllAsync());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _categorySrvc.GetByIdAsync(id));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            if (category == null)
            {
                ModelState.AddModelError(nameof(Category), "Category is required.");
                return BadRequest(ModelState);
            }
            else
            {
                if (string.IsNullOrEmpty(category.Name))
                {
                    ModelState.AddModelError(nameof(Category.Name), $"{nameof(Category.Name)} is required.");
                }
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _categorySrvc.AddAsync(category);

            return Created();
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Category category)
        {
            if (id != category?.Id)
            {
                ModelState.AddModelError(nameof(id), "Invalid id");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _categorySrvc.Update(category);
            return Ok();
        }

        // DELETE api/<CategoryController>/5
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

            await _categorySrvc.Remove(new Category { Id = id });

            return Ok();
        }
    }
}
