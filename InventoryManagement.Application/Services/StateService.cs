using InventoryManagement.Application.Services.Interfaces;
using InventoryManagement.Domain.Models;
using InventoryManagement.Domain.Models.Dto;
using InventoryManagement.Infrastructure.Repositories;
using Microsoft.Extensions.Options;

namespace InventoryManagement.Application.Services
{
    public class StateService : _Service, IStateService
    {
        public StateService(IOptions<ConnectionStrings> connectionStrings) : base(connectionStrings.Value.ConnetionGenerico)
        {

        }

        public ResultOperation<List<StateManagementDto>> GetStates()
        {
            return WrapExecuteTrans<ResultOperation<List<StateManagementDto>>, StateRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<List<StateManagementDto>>();

                try
                {
                    var states = repo.GetStates();

                    rst.Result = states;
                    rst.stateOperation = true;
                }
                catch (Exception ex)
                {
                    rst.RollBack = true;
                    rst.stateOperation = false;
                    rst.MessageExceptionTechnical = ex.Message + Environment.NewLine + ex.StackTrace;
                }

                return rst;
            });
        }

        public ResultOperation<StateManagementDto> GetStateById(int id)
        {
            return WrapExecuteTrans<ResultOperation<StateManagementDto>, StateRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<StateManagementDto>();

                try
                {
                    var state = repo.GetStateById(id);
                    rst.Result = state;
                    rst.stateOperation = true;
                }
                catch (Exception ex)
                {
                    rst.RollBack = true;
                    rst.stateOperation = false;
                    rst.MessageExceptionTechnical = ex.Message + Environment.NewLine + ex.StackTrace;
                }

                return rst;
            });
        }

        public ResultOperation<bool> CreateState(StateManagementDto state)
        {
            return WrapExecuteTrans<ResultOperation<bool>, StateRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<bool>();

                try
                {
                    rst.Result = repo.CreateState(state);
                    rst.stateOperation = true;
                }
                catch (Exception ex)
                {
                    rst.RollBack = true;
                    rst.stateOperation = false;
                    rst.MessageExceptionTechnical = ex.Message + Environment.NewLine + ex.StackTrace;
                }

                return rst;
            });
        }

        public ResultOperation<bool> UpdateState(int id, StateManagementDto state)
        {
            return WrapExecuteTrans<ResultOperation<bool>, StateRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<bool>();

                try
                {
                    rst.Result = repo.UpdateState(id, state);
                    rst.stateOperation = true;
                }
                catch (Exception ex)
                {
                    rst.RollBack = true;
                    rst.stateOperation = false;
                    rst.MessageExceptionTechnical = ex.Message + Environment.NewLine + ex.StackTrace;
                }

                return rst;
            });
        }

        public ResultOperation<bool> DeleteState(int id)
        {
            return WrapExecuteTrans<ResultOperation<bool>, StateRepository>((repo, uow) =>
            {
                var rst = new ResultOperation<bool>();

                try
                {
                    rst.Result = repo.DeleteState(id);
                    rst.stateOperation = true;
                }
                catch (Exception ex)
                {
                    rst.RollBack = true;
                    rst.stateOperation = false;
                    rst.MessageExceptionTechnical = ex.Message + Environment.NewLine + ex.StackTrace;
                }

                return rst;
            });
        }
    }
}
