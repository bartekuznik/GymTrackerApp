using GymTrackerAPI.Contracts;
using GymTrackerAPI.Data;

namespace GymTrackerAPI.Repositories
{
    public class WaterLogsRepository : GenericsRepository<WaterLog>, IWaterLogsRepository
    {
        public WaterLogsRepository(GymTrackerDbContext context) : base(context)
        {
        }
    }
}
