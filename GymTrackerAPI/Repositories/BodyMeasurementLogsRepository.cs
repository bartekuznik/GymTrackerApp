using GymTrackerAPI.Contracts;
using GymTrackerAPI.Data;

namespace GymTrackerAPI.Repositories
{
    public class BodyMeasurementLogsRepository : GenericsRepository<BodyMeasurementLog>, IBodyMeasurementLogsRepository
    {
        private readonly GymTrackerDbContext _context;

        public BodyMeasurementLogsRepository(GymTrackerDbContext context) : base(context)
        {
            _context = context;
        }
    
    }
}
