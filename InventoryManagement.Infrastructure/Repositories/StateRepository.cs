using Dapper;
using InventoryManagement.Domain.Models.Dto;
using InventoryManagement.Infrastructure.Repositories._UnitOfWork;
using InventoryManagement.Infrastructure.Repositories.Interfaces;

namespace InventoryManagement.Infrastructure.Repositories
{
    public class StateRepository : Repository, IStateRepository
    {
        public StateRepository() { }
        public StateRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public List<StateManagementDto> GetStates()
        {
            var response = GetDataListOfProcedure<StateManagementDto>("sp_GetStates");
            return response;
        }

        public StateManagementDto GetStateById(int id)
        {
            var prms = new DynamicParameters();
            prms.Add("@IdState", id);

            var result = GetDataListOfProcedure<StateManagementDto>("sp_GetStateById", prms)
                         .FirstOrDefault();
            return result;
        }

        public bool CreateState(StateManagementDto state)
        {
            var prms = new DynamicParameters();
            prms.Add("@NameState", state.NameState);

            var response = Execute<int>("sp_PostState", prms) == 1 ? true : false;
            return response;
        }

        public bool UpdateState(int id, StateManagementDto state)
        {
            var prms = new DynamicParameters();
            prms.Add("@IdState", id);
            prms.Add("@NameState", state.NameState);

            var response = Execute<int>("sp_UpdateState", prms) == 1 ? true : false;
            return response;
        }

        public bool DeleteState(int id)
        {
            var prms = new DynamicParameters();
            prms.Add("@IdState", id);

            var response = Execute<int>("sp_DeleteState", prms) == 1 ? true : false;
            return response;
        }
    }
}
