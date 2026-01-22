using GymTrackerAPI.Contracts;
using GymTrackerAPI.Data;

namespace GymTrackerAPI.Repositories
{
    public class NutritionLogsRepository : GenericsRepository<NutritionLog>, INutritionLogsRepository
    {
        public NutritionLogsRepository(GymTrackerDbContext context) : base(context)
        {
        }
    }
}
