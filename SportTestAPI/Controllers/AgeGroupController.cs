using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportTestAPI.DataModels;
using SportTestAPI.Dto;
using SportTestAPI.ImplementRepo;
using Swashbuckle.AspNetCore.Annotations;

namespace SportTestAPI.Controllers
{
    /// <summary>
    /// AgeGroup API- pART OF Sports API
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "SportsAPI")] // Group under SportsAPI
    [SwaggerTag("SportsTestAPI")] // Add this tag in Swagger UI
    public class AgeGroupController : ControllerBase
    {
        private readonly IAgeGroupRepository _AgeGroupRepository;

        public AgeGroupController(IAgeGroupRepository ageGroupRepository)
        {
            _AgeGroupRepository = ageGroupRepository;
        }
       

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgeGroupResponseDto>>> GetAgeGroup()
        {
            return Ok(await _AgeGroupRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AgeGroupResponseDto>> GetAgeGroup(int id)
        {
            return Ok(await _AgeGroupRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAgeGroup(AgeGroupRequestDto AgeGroupDto)
        {
            var createdAgeGroup = await _AgeGroupRepository.CreateAsync(AgeGroupDto);
            if(createdAgeGroup==null||createdAgeGroup.AgeGroupID==0)
            {
                return BadRequest("Failed to create Age Group");
            }
            return CreatedAtAction(nameof(GetAgeGroup), new { id = createdAgeGroup.AgeGroupID }, createdAgeGroup);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAgeGroup(int id, AgeGroupRequestDto AgeGroupDto)
        {
            await _AgeGroupRepository.UpdateAsync(id, AgeGroupDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgeGroup(int id)
        {
            await _AgeGroupRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
