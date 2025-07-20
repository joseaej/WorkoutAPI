using Microsoft.AspNetCore.Mvc;
using WorkoutApi.Domain.DTOs;
using WorkoutApi.Domain.Models;
using WorkoutApi.Domain.Services;
namespace WorkoutApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MuscleController: Controller
    {
        private MuscleService _muscleService;
        public MuscleController(MuscleService service) => _muscleService = service;
        
        [HttpGet("all_muscles")]
        public async Task<ActionResult<List<MuscleDto>>> GetAllMuscles()
        {
            var result  = await _muscleService.GetAllMuscles();
            if (result == null)
            {
                return NotFound();
            }
            List<MuscleDto> muscles = result.Select(x => new MuscleDto(x)).ToList();
            return muscles;
        }

        [HttpGet("by_name")]
        public async Task<ActionResult<MuscleDto>> GetMuscleById(string name)
        {
            var result = await _muscleService.GetMuscleByName(name);
            if (result == null)
            {
                return NotFound();
            }
            return new MuscleDto(result);
        }

        [HttpPost("create_muscle")]
        public async Task<ActionResult<MuscleDto>> CreateMuscle(string name, string description)
        {
            Muscle muscle = new Muscle(name, description);
            var result = await _muscleService.CreateMuscle(muscle);
            if (result == null)
            {
                return BadRequest();
            }
            return new MuscleDto(result);
        }




        [HttpPatch("update_name")]
        public async Task<ActionResult<MuscleDto>> UpdateNameEquipment(string oldName, string newName)
        {
            var result = await _muscleService.UpdateNameMuscle(oldName, newName);
            if (result == null)
            {
                return NotFound();
            }
            return new MuscleDto(result);
        }

        [HttpPatch("update_description")]
        public async Task<ActionResult<MuscleDto>> UpdateDescriptionEquipment(string name, string newDescription)
        {
            var result = await _muscleService.UpdateDescriptionMuscle(name, newDescription);
            if (result == null)
            {
                return NotFound();
            }
            return new MuscleDto(result);
        }
    }
}
