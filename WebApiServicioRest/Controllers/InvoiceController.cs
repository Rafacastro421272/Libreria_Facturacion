using Libreria_Facturacion.Domain;
using Libreria_Facturacion.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiServicioRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;


        public InvoiceController(IInvoiceService service)
        {
            _invoiceService = service;
        }

        // GET: api/<InvoiceController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Invoice> invoice = _invoiceService.GetInvoices();
                return Ok(invoice);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var invoice = _invoiceService.GetInvoice(id);
                return Ok(invoice);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public IActionResult Post(Invoice invoice)
        {
            try
            {
                if (invoice == null)
                {
                    return BadRequest();
                }
                var result = _invoiceService.SaveInvoice(invoice);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Invoice invoice)
        {
            try
            {
                if (invoice == null)
                    return BadRequest("La factura no puede ser nula.");

                if (invoice.Id != id)
                    return BadRequest("El ID de la factura no coincide con el ID de la URL.");

                var existingInvoice = _invoiceService.GetInvoice(id);

                if (existingInvoice == null)
                    return NotFound($"No se encontró una factura con ID {id}.");

                var result = _invoiceService.SaveInvoice(invoice);
                if (result)
                    return Ok(invoice);
                else
                    return StatusCode(500, "No se pudo actualizar el producto.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _invoiceService.DeleteInvoice(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
