using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportTestAPI.Dto;
using SportTestAPI.ImplementRepo;

namespace SportTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class TrainingSessionController : ControllerBase
    {
        private readonly ITrainingSessionRepository _trainingSessionRepository;

        public TrainingSessionController(ITrainingSessionRepository trainingSessionRepository)
        {
            _trainingSessionRepository = trainingSessionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingSessionResponseDto>>> GetTrainingSessions()
        {
            return Ok(await _trainingSessionRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainingSessionResponseDto>> GetTrainingSession(int id)
        {
            return Ok(await _trainingSessionRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateTrainingSession(TrainingSessionRequestDto trainingSessionDto)
        {
            var createdTrainingSession = await _trainingSessionRepository.CreateAsync(trainingSessionDto);
            return CreatedAtAction(nameof(GetTrainingSession), new { id = createdTrainingSession.SessionID }, createdTrainingSession);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainingSession(int id, TrainingSessionRequestDto trainingSessionDto)
        {
            await _trainingSessionRepository.UpdateAsync(id, trainingSessionDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingSession(int id)
        {
            await _trainingSessionRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}

