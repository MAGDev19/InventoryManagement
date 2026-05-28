using InventoryManagement.Application.Services.Interfaces;
using InventoryManagement.Domain.Models;
using InventoryManagement.Infrastructure.Repositories;
using Microsoft.Extensions.Options;
using InventoryManagement.Domain.Models.Dto;

namespace InventoryManagement.Application.Services
{
    public class InventoryReportService : _Service, IInventoryReportService
    {
        public InventoryReportService(IOptions<ConnectionStrings> connectionStrings) : base(connectionStrings.Value.ConnetionGenerico)
        {

        }

        public ResultOperation<InventorySummaryDto>GetInventorySummary()
        {
            var result = WrapExecuteTrans < ResultOperation<InventorySummaryDto>, InventoryReportRepository > ((repo, uow) =>
                {
                    var rst = new ResultOperation<InventorySummaryDto>();

                    try
                    {
                        rst.Result =
                            repo.GetInventorySummary();

                        rst.stateOperation = true;
                    }
                    catch (Exception ex)
                    {
                        rst.RollBack = true;

                        rst.stateOperation = false;

                        rst.MessageExceptionTechnical =
                            ex.Message
                            + Environment.NewLine
                            + ex.StackTrace;
                    }

                    return rst;
                });

            return result;
        }
    }
}