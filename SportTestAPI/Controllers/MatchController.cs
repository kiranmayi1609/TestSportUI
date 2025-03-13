using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportTestAPI.Dto;
using SportTestAPI.ImplementRepo;

namespace SportTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class MatchController : ControllerBase
    {
        private readonly IMatchRepository _matchRepository;

        public MatchController(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatchResponseDto>>> GetMatches()
        {
            return Ok(await _matchRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MatchResponseDto>> GetMatch(int id)
        {
            return Ok(await _matchRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateMatch(MatchRequestDto matchDto)
        {
            var createdMatch = await _matchRepository.CreateAsync(matchDto);
            return CreatedAtAction(nameof(GetMatch), new { id = createdMatch.MatchID }, createdMatch);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMatch(int id, MatchRequestDto matchDto)
        {
            await _matchRepository.UpdateAsync(id, matchDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatch(int id)
        {
            await _matchRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
