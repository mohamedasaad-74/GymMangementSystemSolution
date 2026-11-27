using GymMangementSystem.Context;
using GymMangementSystem.Entities;
using GymMangementSystem.Repositores.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GymMangementSystem.Repositores.Classes
{
    public class MemberShipRepository : IMemberShipRepository
    {
        private readonly GymDbContext _dbContext;

        public MemberShipRepository(GymDbContext dbContext)
        {
          
_dbContext = dbContext;
        }
        public async Task<bool> AnyAsync(Expression<Func<MemberShip, bool>> predicate, CancellationToken ct = default)
        {
            return await _dbContext.MemberShips.AnyAsync(predicate , ct);
        }
    }
}
