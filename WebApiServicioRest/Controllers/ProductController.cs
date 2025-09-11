using Libreria_Facturacion.Domain;
using Libreria_Facturacion.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiServicioRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Product> products = _productService.GetProducts();
                return Ok(products);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var product = _productService.GetProduct(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post(Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }
                return Ok(_productService.Save(product));
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            try
            {
                if (product == null)
                    return BadRequest("El producto no puede ser nulo.");

                if (product.Id != id)
                    return BadRequest("El ID del producto no coincide con el ID de la URL.");

                var existingProduct = _productService.GetProduct(id);

                if (existingProduct == null)
                    return NotFound($"No se encontró un producto con ID {id}.");

                var result = _productService.Save(product);
                if (result)
                    return Ok(product);
                else
                    return StatusCode(500, "No se pudo actualizar el producto.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _productService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
