using Microsoft.AspNetCore.Mvc;
using WorkoutApi.Domain.DTOs;
using WorkoutApi.Domain.Models;
using WorkoutApi.Domain.Services;

namespace WorkoutApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutMusclesController:Controller
    {
        private readonly WorkoutMusclesServices _workoutMusclesService;
        public WorkoutMusclesController(WorkoutMusclesServices service) => _workoutMusclesService = service;

        [HttpGet("all_muscles_for_workout")]
        public async Task<ActionResult<List<MuscleDto>>> GetAllMusclesForWorkout(string workoutName)
        {
            var result = await _workoutMusclesService.GetAllMusclesForWorkout(workoutName);
            if (result == null)
            {
                return NotFound();
            }
            List<MuscleDto> listMuscles = result.Select(x => new MuscleDto(x)).ToList();
            return listMuscles;
        }
        [HttpGet("all_workout_for_muscle")]
        public async Task<ActionResult<List<WorkoutDto>>> GetAllWorkoutsForMuscle(string muscleName)
        {
            var result = await _workoutMusclesService.GetAllWorkoutsForMuscle(muscleName);
            if (result == null)
            {
                return NotFound();
            }
            List<WorkoutDto> listWorkouts = result.Select(x => new WorkoutDto(x)).ToList();
            return listWorkouts;
        }
        [HttpPost()]
        public async Task<ActionResult<List<WorkoutMusclesDto>>> CreateMusclesForWorkout(string workoutName, List<string> muscleNames) {
            List<WorkoutMuscles> listWorkoutMuscles = await _workoutMusclesService.CreateMusclesForWorkout(workoutName, muscleNames);
            List<WorkoutMusclesDto> result = listWorkoutMuscles.Select(x=>new WorkoutMusclesDto(x)).ToList();
            return result;
        }

        [HttpDelete()]
        public async Task<ActionResult<List<WorkoutMusclesDto>>> DeleteAMuscleForWorkout(string workoutName, string muscleName)
        {
            bool? isMuscleWorkoutDeleted = await _workoutMusclesService.DeleteAMuscleForWorkout(workoutName, muscleName);
            if (isMuscleWorkoutDeleted == null)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
