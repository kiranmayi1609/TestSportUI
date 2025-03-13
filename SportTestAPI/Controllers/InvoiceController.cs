using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportTestAPI.Dto;
using SportTestAPI.ImplementRepo;

namespace SportTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceResponseDto>>> GetInvoices()
        {
            return Ok(await _invoiceRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceResponseDto>> GetInvoice(int id)
        {
            return Ok(await _invoiceRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateInvoice(InvoiceRequestDto invoiceDto)
        {
            var createdInvoice = await _invoiceRepository.CreateAsync(invoiceDto);
            return CreatedAtAction(nameof(GetInvoice), new { id = createdInvoice.InvoiceID }, createdInvoice);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInvoice(int id, InvoiceRequestDto invoiceDto)
        {
            await _invoiceRepository.UpdateAsync(id, invoiceDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            await _invoiceRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
