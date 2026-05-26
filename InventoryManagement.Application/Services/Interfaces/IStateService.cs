using InventoryManagement.Domain.Models.Dto;

namespace InventoryManagement.Application.Services.Interfaces
{
    public interface IStateService
    {
        ResultOperation<List<StateManagementDto>> GetStates();
        ResultOperation<StateManagementDto> GetStateById(int id);
        ResultOperation<bool> CreateState(StateManagementDto state);
        ResultOperation<bool> UpdateState(int id, StateManagementDto state);
        ResultOperation<bool> DeleteState(int id);
    }
}