using Microsoft.AspNetCore.Components;
using MyPlansServices.Interfaces;
using MyPlansLibrary.ApiResponses;
using MyPlansServices;

using MyPlansServices.Exceptions;
using System.Linq.Expressions;
using MyPlansLibrary.Models;

namespace MyPlans.Components.PlansComponents
{
    public partial class Pagination
    {
        [Inject]
        public IPlanServices PlanServices{ get; set; } 
        private bool _isBusy=false;
        private string _errorMessage = string.Empty;    
        private int _pageNumber= 1;
        private int _pageSize=10;
        private int _totalPages = 1;
        private string _query = string.Empty;
        private List<Plan> _plans = new();

        private async Task<Pagination<Plan>>GetPlansAsync(string query = "", int pageNumber = 1, int pageSize = 10)
        {
            _isBusy= true;
            try
            {
                var result = await PlanServices.GetPlansAsync(query, pageNumber, pageSize); 
                _plans = result.Value.Records.ToList();
                _pageNumber = result.Value.Page;
                _pageSize = result.Value.PageSize;
                _totalPages= result.Value.TotalPages;
                return result.Value;
            }
            catch (APIException ex) 
            {
                _errorMessage = ex.ApiErrorsResponses.Message;
            }
            
            catch (Exception ex)
            {
             _errorMessage = ex.Message; 
            }
            
            _isBusy = false;
            return null;
        }

    }
}
