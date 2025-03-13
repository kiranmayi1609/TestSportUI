using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportTestAPI.Dto;
using SportTestAPI.ImplementRepo;

namespace SportTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CoachController : ControllerBase
    {
        private readonly ICoachRepository _coachRepository;
        public CoachController(ICoachRepository coachRepository)
        {
            _coachRepository = coachRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoachResponseDto>>> GetCoaches()
        {
            return Ok(await _coachRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CoachResponseDto>> GetCoach(int id)
        {
            return Ok(await _coachRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateCoach(CoachRequestDto coachDto)
        {
            var createdCoach = await _coachRepository.CreateAsync(coachDto);
            return CreatedAtAction(nameof(GetCoach), new { id = createdCoach.CoachID }, createdCoach);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoach(int id, CoachRequestDto coachDto)
        {
            await _coachRepository.UpdateAsync(id, coachDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoach(int id)
        {
            await _coachRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
