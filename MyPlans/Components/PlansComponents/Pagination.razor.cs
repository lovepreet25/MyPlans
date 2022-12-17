using Microsoft.AspNetCore.Components;
using MyPlansServices.Interfaces;
using MyPlansLibrary.ApiResponses;
using MyPlansServices;

using MyPlansServices.Exceptions;
using System.Linq.Expressions;
using MyPlansLibrary.Models;
using MudBlazor;

namespace MyPlans.Components.PlansComponents
{
    public partial class Pagination
    {
        [Inject]
        public NavigationManager Navigation { get; set;}


        [Inject]
        public IPlanServices PlanServices{ get; set; }
        [Inject]
        public IDialogService DialogService { get; set; }
        
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
        
        private bool _isCardsViewEnabled = true;
        private void SetCardView()
        {
            _isCardsViewEnabled = true;
        }
        private void SetTableView()
        { _isCardsViewEnabled = false; }
        private void EditPlan(Plan plan)
        {
            Navigation.NavigateTo($"plans/form/{plan.Id}");
        }
        private async Task DeletePlanAsync(Plan plan)
        {
            var parameters = new DialogParameters();
            parameters.Add("ContentText", "Do you really want to remove the  Plan '{plan.Title}'? ");
            parameters.Add("ButtonText", "Delete");
            parameters.Add("Color", Color.Error);

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

            var dialogresult = DialogService.Show<ConfirmDialog>("Delete", parameters, options);
            var confirmResult = await dialogresult.Result;
            if (!confirmResult.Cancelled)
            {
                await PlanServices.DeleteAsync(plan.Id);
            }

        }
    }
}
