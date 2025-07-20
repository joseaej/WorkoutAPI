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

        #region GETS
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
        #region Duration
        [HttpGet("grether_than_duration")]
        public async Task<ActionResult<List<WorkoutDto>>> GetAllWorkoutsGretherThanDuration(int duration)
        {
            var result = await _workoutService.GetAllWorkoutsGretterThanDuration(duration);
            if (result == null)
            {
                return NotFound();
            }
            List<WorkoutDto> list = result.Select(x => new WorkoutDto(x)).ToList();
            return list;
        }


        [HttpGet("equals_duration")]
        public async Task<ActionResult<List<WorkoutDto>>> GetAllWorkoutsEqualsDuration(int duration)
        {
            var result = await _workoutService.GetAllWorkoutsEqualsDuration(duration);
            if (result == null)
            {
                return NotFound();
            }
            List<WorkoutDto> list = result.Select(x => new WorkoutDto(x)).ToList();
            return list;
        }

        [HttpGet("less_than_duration")]
        public async Task<ActionResult<List<WorkoutDto>>> GetAllWorkoutsLessThanDuration(int duration)
        {
            var result = await _workoutService.GetAllWorkoutsLessThanDuration(duration);
            if (result == null)
            {
                return NotFound();
            }
            List<WorkoutDto> list = result.Select(x => new WorkoutDto(x)).ToList();
            return list;
        }
        #endregion
        #region Calories
        [HttpGet("grether_than_calories")]
        public async Task<ActionResult<List<WorkoutDto>>> GetAllWorkoutsGretherThanCalories(int calories)
        {
            var result = await _workoutService.GetAllWorkoutsGretterThanCalories(calories);
            if (result == null)
            {
                return NotFound();
            }
            List<WorkoutDto> list = result.Select(x => new WorkoutDto(x)).ToList();
            return list;
        }


        [HttpGet("equals_calories")]
        public async Task<ActionResult<List<WorkoutDto>>> GetAllWorkoutsEqualsCalories(int calories)
        {
            var result = await _workoutService.GetAllWorkoutsEqualsCalories(calories);
            if (result == null)
            {
                return NotFound();
            }
            List<WorkoutDto> list = result.Select(x => new WorkoutDto(x)).ToList();
            return list;
        }

        [HttpGet("less_than_calories")]
        public async Task<ActionResult<List<WorkoutDto>>> GetAllWorkoutsLessThanCalories(int calories)
        {
            var result = await _workoutService.GetAllWorkoutsLessThanCalories(calories);
            if (result == null)
            {
                return NotFound();
            }
            List<WorkoutDto> list = result.Select(x => new WorkoutDto(x)).ToList();
            return list;
        }
        #endregion

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
        #endregion
        #region POSTS
        [HttpPost("create_workout")]
        public async Task<ActionResult<WorkoutDto>> CreateWorkout(string Name, string Description,
            WorkoutType WorkoutType, WorkoutGoal Goal,
            Difficulty Difficulty, int TotalDuration,
            int EstimatedCalories, string VideoURL, string ImageURL)
        {
            Workout workout = new Workout(Name,Description,WorkoutType.ToString(),Goal.ToString(), Difficulty.ToString(), TotalDuration,EstimatedCalories,VideoURL,ImageURL);
            var result = await _workoutService.CreateWorkout(workout);
            if (result==null)
            {
                return BadRequest();
            }
            return new WorkoutDto(result);
        }
        #endregion
        #region PATCHS
        [HttpPatch("update_calories")]
        public async Task<ActionResult<WorkoutDto>> UpdateWorkoutCalories(string name,int calories)
        {
            var result = await _workoutService.UpdateWorkoutCalories(name, calories);
            if (result == null)
            {
                return NotFound();
            }
            return new WorkoutDto(result);
        }
        [HttpPatch("update_difficulty")]
        public async Task<ActionResult<WorkoutDto>> UpdateWorkoutDifficulty(string name, Difficulty difficulty)
        {
            var result = await _workoutService.UpdateWorkoutDifficulty(name, difficulty);
            if (result == null)
            {
                return NotFound();
            }
            return new WorkoutDto(result);
        }
        [HttpPatch("update_goal")]
        public async Task<ActionResult<WorkoutDto>> UpdateWorkoutGoal(string name, WorkoutGoal goal)
        {
            var result = await _workoutService.UpdateWorkoutGoal(name, goal);
            if (result == null)
            {
                return NotFound();
            }
            return new WorkoutDto(result);
        }
        [HttpPatch("update_duration")]
        public async Task<ActionResult<WorkoutDto>> UpdateWorkoutDuration(string name, int duration)
        {
            var result = await _workoutService.UpdateWorkoutDuration(name, duration);
            if (result == null)
            {
                return NotFound();
            }
            return new WorkoutDto(result);
        }
        [HttpPatch("update_name")]
        public async Task<ActionResult<WorkoutDto>> UpdateWorkoutName(string oldName, string newName)
        {
            var result = await _workoutService.UpdateWorkoutName(oldName, newName);
            if (result == null)
            {
                return NotFound();
            }
            return new WorkoutDto(result);
        }
        #endregion
        #region Deletes
        [HttpDelete("delete_by_name")]
        public async Task<ActionResult<WorkoutDto>> DeleteByName(string name)
        {
            var result = await _workoutService.DeleteWorkoutByName(name);
            if (result == null)
            {
                return Ok();
            }
            return new WorkoutDto(result);
        }
        #endregion

    }
}