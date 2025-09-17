using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi_Entity_Framework.Data.Models;
using WebApi_Entity_Framework.Data.RepositoryEF;
using WebApi_Entity_Framework.Dto;
using WebApi_Entity_Framework.Service;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_Entity_Framework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }               

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _service.GetAllAsync();
                var productsDto = products.Select(ArticuloDto.FromEntity).ToList();
                return Ok(productsDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno!");
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var articulo = await _service.GetByIdAsync(id);
                if (articulo != null)
                {
                    var productDto = ArticuloDto.FromEntity(articulo);
                    return Ok(productDto);
                }
                else
                {
                    return StatusCode(404, "Articulo no encontrado!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno!");
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ArticuloDto articuloDto)
        {
            try
            {
                var articulo = ArticuloDto.ToEntity(articuloDto);
                if (IsValid(articulo))
                {
                    await _service.CreateAsync(articulo);
                    return Ok("Articulo agregado correctamente!");
                }
                else
                {
                    return BadRequest("Los datos no son válidos o incompletos!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno!");
            }
        }

        private bool IsValid(Articulo articulo)
        {
            return !string.IsNullOrWhiteSpace(articulo.Nombre);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ArticuloDto articuloDto)
        {
            try
            {
                var articulo = ArticuloDto.ToEntity(articuloDto);
                if (id != 0 && id == articulo.IdArticulo && IsValid(articulo))
                {
                    await _service.UpdateAsync(id, articulo);
                    return Ok("Articulo modificado!");
                }
                else
                {
                    return NotFound("Articulo no encontrado!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno!");
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    await _service.DeleteAsync(id);
                    return Ok("Articulo eliminado!");
                }
                else
                {
                    return NotFound("Articulo no válido!");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Ha ocurrido un error interno!");
            }
        }
    }
}
