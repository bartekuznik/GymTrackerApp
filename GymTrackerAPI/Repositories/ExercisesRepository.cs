using GymTrackerAPI.Contracts;
using GymTrackerAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace GymTrackerAPI.Repositories
{
    public class ExercisesRepository : GenericsRepository<Exercise>,IExercisesRepository
    {
        public ExercisesRepository(GymTrackerDbContext context) : base(context) 
        {
        }

       
    }
}
