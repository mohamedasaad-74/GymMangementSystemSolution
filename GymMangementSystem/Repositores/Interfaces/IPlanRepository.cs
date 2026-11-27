using GymMangementSystem.Entities;

namespace GymMangementSystem.Repositores.Interfaces
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> GetAllAsync(CancellationToken Ct = default);
        Task<Plan?>GetPlanByIdAsync(int id,CancellationToken ct= default);

        Task<int> UpdateAsync(CancellationToken ct);
    }
}
