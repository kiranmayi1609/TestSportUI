using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportTestAPI.Dto;
using SportTestAPI.ImplementRepo;

namespace SportTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class CourtController : ControllerBase
    {
        private readonly ICourtRepository _courtRepository;

        public CourtController(ICourtRepository courtRepository)
        {
            _courtRepository = courtRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourtResponseDto>>> GetCourts()
        {
            return Ok(await _courtRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourtResponseDto>> GetCourt(int id)
        {
            return Ok(await _courtRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateCourt(CourtRequestDto courtDto)
        {
            var createdCourt = await _courtRepository.CreateAsync(courtDto);
            return CreatedAtAction(nameof(GetCourt), new { id = createdCourt.CourtID }, createdCourt);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourt(int id, CourtRequestDto courtDto)
        {
            await _courtRepository.UpdateAsync(id, courtDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourt(int id)
        {
            await _courtRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
