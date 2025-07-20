using Supabase.Postgrest;
using WorkoutApi.Domain.Models;
using WorkoutApi.Utils;

namespace WorkoutApi.Domain.Services
{
    public class WorkoutService
    {
        private readonly SupabaseClientService _supabase;
        public WorkoutService(SupabaseClientService supabase) => _supabase = supabase;

        #region Name
        public async Task<Workout?> GetWorkoutByName(string name)
        {
            var result = await _supabase.Client.From<Workout>().Filter(x=>x.Name, Constants.Operator.ILike, name).Get();
            return result.Models.FirstOrDefault();
        }
        #endregion
        #region Type
        public async Task<List<Workout>?> GetAllWorkoutsByType(WorkoutType type)
        {
            var result = await _supabase.Client.From<Workout>().Filter(x => x.WorkoutType.ToString(), Constants.Operator.ILike, type.ToString()).Get();
            return result.Models;
        }
        #endregion
        #region Duration

        public async Task<List<Workout>?> GetAllWorkoutsGretterThanDuration(int duration)
        {
            var result = await _supabase.Client.From<Workout>().Filter(x => x.TotalDuration, Constants.Operator.GreaterThanOrEqual, duration).Get();
            return result.Models;
        }

        public async Task<List<Workout>?> GetAllWorkoutsEqualsDuration(int duration)
        {
            var result = await _supabase.Client.From<Workout>().Filter(x => x.TotalDuration, Constants.Operator.Equals, duration).Get();
            return result.Models;
        }
        public async Task<List<Workout>?> GetAllWorkoutsLessThanDuration(int duration)
        {
            var result = await _supabase.Client.From<Workout>().Filter(x => x.TotalDuration, Constants.Operator.LessThanOrEqual, duration).Get();
            return result.Models;
        }
        #endregion
        #region Calories

        public async Task<List<Workout>?> GetAllWorkoutsGretterThanCalories(int calories)
        {
            var result = await _supabase.Client.From<Workout>().Filter(x => x.EstimatedCalories, Constants.Operator.GreaterThanOrEqual, calories).Get();
            return result.Models;
        }

        public async Task<List<Workout>?> GetAllWorkoutsEqualsCalories(int calories)
        {
            var result = await _supabase.Client.From<Workout>().Filter(x => x.EstimatedCalories, Constants.Operator.Equals, calories).Get();
            return result.Models;
        }
        public async Task<List<Workout>?> GetAllWorkoutsLessThanCalories(int calories)
        {
            var result = await _supabase.Client.From<Workout>().Filter(x => x.EstimatedCalories, Constants.Operator.LessThanOrEqual, calories).Get();
            return result.Models;
        }
        #endregion
        #region Difficulty
        public async Task<List<Workout>?> GetAllWorkoutsByDifficulty(Difficulty difficulty)
        {
            var result = await _supabase.Client.From<Workout>().Filter(x => x.Difficulty.ToString(), Constants.Operator.ILike, difficulty.ToString()).Get();
            return result.Models;
        }
        #endregion
        #region Goals
        public async Task<List<Workout>?> GetAllWorkoutsByGoal(WorkoutGoal goal)
        {
            var result = await _supabase.Client.From<Workout>().Filter(x => x.Goal.ToString(), Constants.Operator.ILike, goal.ToString()).Get();
            return result.Models;
        }
        #endregion
        #region Create&Update
        public async Task<Workout> CreateWorkout(Workout workout)
        {
            var result = await _supabase.Client.From<Workout>().Insert(workout);
            return result.Models.First();
        }
        #region Updates
        public async Task<Workout> UpdateWorkoutName(string oldName,string newName)
        {
            var result = await _supabase.Client.From<Workout>().Filter(x => x.Name, Constants.Operator.ILike, oldName).Set(x => x.Name, newName).Update();
            return result.Models.First();
        }
        public async Task<Workout> UpdateWorkoutType(string name, WorkoutType type)
        {
            var result = await _supabase.Client.From<Workout>().Filter(x => x.Name, Constants.Operator.ILike, name).Set(x => x.WorkoutType, type.ToString()).Update();
            return result.Models.First();
        }
        public async Task<Workout> UpdateWorkoutGoal(string name, WorkoutGoal goal)
        {
            var result = await _supabase.Client.From<Workout>().Filter(x => x.Name, Constants.Operator.ILike, name).Set(x => x.Goal, goal.ToString()).Update();
            return result.Models.First();
        }
        public async Task<Workout?> UpdateWorkoutDifficulty(string name, Difficulty difficulty)
        {
            var result = await _supabase.Client
                .From<Workout>()
                .Filter(x => x.Name, Constants.Operator.ILike, name)
                .Set(x => x.Difficulty, difficulty.ToString())
                .Update();

            return result.Models.FirstOrDefault();
        }

        public async Task<Workout?> UpdateWorkoutCalories(string name, int estimatedCalories)
        {
            var result = await _supabase.Client.From<Workout>().Filter(x => x.Name, Constants.Operator.ILike, name).Set(x => x.EstimatedCalories, estimatedCalories).Update();
            return result.Models.FirstOrDefault();
        }
        public async Task<Workout> UpdateWorkoutDuration(string name, int durartion)
        {
            var result = await _supabase.Client.From<Workout>().Filter(x => x.Name, Constants.Operator.ILike, name).Set(x => x.TotalDuration, durartion).Update();
            return result.Models.First();
        }
        #endregion
        #endregion
        #region Deletes
        public async Task<Workout?> DeleteWorkoutByName(string name)
        {
            await _supabase.Client.From<Workout>().Filter(x=>x.Name,Constants.Operator.ILike,name).Delete();
            var result = await GetWorkoutByName(name);
            return result;
        }
        #endregion
    }
}
