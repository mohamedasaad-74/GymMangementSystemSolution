using GymMangementSystem.Entities;
using System.Linq.Expressions;

namespace GymMangementSystem.Repositores.Interfaces
{
    public interface IMemberShipRepository
    {
        Task<bool> AnyAsync(Expression<Func<MemberShip,bool>>predicate,CancellationToken ct =default);
    }
}
