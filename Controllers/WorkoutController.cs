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


        [HttpPost("create_workout")]
        private async Task<ActionResult<WorkoutDto>> CreateWorkout(string Name, string Description,
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