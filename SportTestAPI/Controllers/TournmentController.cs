using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportTestAPI.Dto;
using SportTestAPI.ImplementRepo;

namespace SportTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TournmentController : ControllerBase
    {
         private readonly ITournmentRepository _tournmentRepository;

        public TournmentController(ITournmentRepository tournmentRepository)
        {
            _tournmentRepository = tournmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentResponseDto>>> GetTournaments()
        {
            return Ok(await _tournmentRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentResponseDto>> GetTournament(int id)
        {
            return Ok(await _tournmentRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateTournament(TournamentRequestDto tournmentDto)
        {
            var createdTournament = await _tournmentRepository.CreateAsync(tournmentDto);
            return CreatedAtAction(nameof(GetTournament), new { id = createdTournament.TournamentID }, createdTournament);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTournament(int id, TournamentRequestDto tournmentDto)
        {
            await _tournmentRepository.UpdateAsync(id, tournmentDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament(int id)
        {
            await _tournmentRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
