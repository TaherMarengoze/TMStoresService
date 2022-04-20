using Contracts;
using EntitiesCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public ProductController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var result = _repository.Product.FindAll();
                return Ok(result.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}"/*, Name = "GetProduct"*/)]
        public IActionResult GetProduct(int id)
        {
            try
            {
                var result = _repository.Product.FindByCondition(p => p.Id == id);

                if (result == null || !result.Any())
                {
                    return NotFound($"Product with id = { id } not found");
                }

                return Ok(result.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (product is null)
            {
                return BadRequest("Product object is null");
            }

            _repository.Product.Create(product);
            _repository.Save();

            //return Ok("Product added.");
            return CreatedAtRoute("GetProduct", new { product.Id }, product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Product product)
        {
            try
            {
                if (product is null)
                    return BadRequest("Product object is null");

                if (id != product.Id)
                    return BadRequest("Product ID mismatch");

                //var prod = _repository.Product.GetById(id);
                
                if (_repository.Product.GetById(id) == null)
                    return NotFound($"Product with ID = { id } not found");

                _repository.Product.Update(product);
                _repository.Save();

                //return NoContent();
                return StatusCode(200, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                var prod = _repository.Product.GetById(id);
                if (prod == null)
                {
                    return NotFound($"Product with ID = { id } was not found");
                }

                _repository.Product.Delete(prod);
                _repository.Save();

                return Ok("Product deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}