using Microsoft.AspNetCore.Mvc;
using WorkoutApi.Domain.DTOs;
using WorkoutApi.Domain.Models;
using WorkoutApi.Domain.Services;


namespace WorkoutApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : Controller
    {
        private readonly WorkoutService _workoutService;
        public WorkoutController(WorkoutService service)=>_workoutService = service;


        [HttpGet("by_name")]
        public async Task<ActionResult<WorkoutDto>> GetWorkoutByName(string name)
        {
            var result = await _workoutService.GetWorkoutByName(name);
            if (result == null)
            {
                return BadRequest();
            }
            return new WorkoutDto(result);
        }

        [HttpGet("by_type")]
        public async Task<ActionResult<List<WorkoutDto>>> GetAllWorkoutsByType (WorkoutType type)
        {
            var result = await _workoutService.GetAllWorkoutsByType(type);
            if (result == null)
            {
                return NotFound();
            }
            List<WorkoutDto> list = result.Select(x=> new WorkoutDto(x)).ToList();
            return list;
        }

        [HttpGet("by_goal")]
        public async Task<ActionResult<List<WorkoutDto>>> GetAllWorkoutsByGoal(WorkoutGoal goal)
        {
            var result = await _workoutService.GetAllWorkoutsByGoal(goal);
            if (result == null)
            {
                return NotFound();
            }
            List<WorkoutDto> list = result.Select(x => new WorkoutDto(x)).ToList();
            return list;
        }
        [HttpGet("by_difficulty")]
        public async Task<ActionResult<List<WorkoutDto>>> GetAllWorkoutsByDifficulty(Difficulty difficulty)
        {
            var result = await _workoutService.GetAllWorkoutsByDifficulty(difficulty);
            if (result == null)
            {
                return NotFound();
            }
            List<WorkoutDto> list = result.Select(x => new WorkoutDto(x)).ToList();
            return list;
        }

        [HttpPost("create_workout")]
        public async Task<ActionResult<WorkoutDto>> CreateWorkout(string Name, string Description,
            WorkoutType WorkoutType, WorkoutGoal Goal,
            Difficulty Difficulty, int TotalDuration,
            int EstimatedCalories, string VideoURL, string ImageURL)
        {
            Workout workout = new Workout(Name,Description,WorkoutType,Goal,Difficulty,TotalDuration,EstimatedCalories,VideoURL,ImageURL);
            var result = await _workoutService.CreateWorkout(workout);
            if (result==null)
            {
                return BadRequest();
            }
            return new WorkoutDto(result);
        }
    }
}