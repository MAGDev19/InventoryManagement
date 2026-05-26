using InventoryManagement.Domain.Models.Dto;

namespace InventoryManagement.Infrastructure.Repositories.Interfaces
{
    public interface IStateRepository
    {
        List<StateManagementDto> GetStates();
        StateManagementDto GetStateById(int id);
        bool CreateState(StateManagementDto state);
        bool UpdateState(int id, StateManagementDto state);
        bool DeleteState(int id);
    }
}
