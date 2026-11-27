using GymMangementSystem.Context;
using GymMangementSystem.Entities;
using GymMangementSystem.Repositores.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymMangementSystem.Repositores.Classes
{
    public class PlanRepository : IPlanRepository
    {
        private GymDbContext _dbContext;
        public PlanRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Plan>> GetAllAsync(CancellationToken Ct = default)
        {
            return await _dbContext.Plans.AsNoTracking().ToListAsync(Ct);
        }

        public async Task<Plan?> GetPlanByIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbContext.Plans.FindAsync([id], cancellationToken: ct);
        }

        public async Task<int> UpdateAsync(CancellationToken ct)
        {
            try
            {
                return await _dbContext.SaveChangesAsync(ct);
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
        }
    }
}
