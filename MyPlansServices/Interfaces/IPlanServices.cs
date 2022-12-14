using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPlansLibrary.ApiResponses;
using MyPlansLibrary.Models;

namespace MyPlansServices.Interfaces
{
    public interface IPlanServices
    {
        Task<ApiResponses<Pagination<Plan>>> GetPlansAsync(string query = null , int pageNumber = 1, int pageSize = 10);

        Task<ApiResponses<PlanDetails>> GetByIdAsync(string id);
        Task<ApiResponses<PlanDetails>> CreateAsync(PlanDetails model, FormFile coverFile);
        Task<ApiResponses<PlanDetails>> EditAsync(PlanDetails model, FormFile coverFile);

        Task DeleteAsync(string id);

    }
}
