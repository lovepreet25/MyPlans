using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using MudBlazor;
using MyPlansLibrary.Models;
using MyPlansServices.Interfaces;

namespace MyPlans.Components.PlansComponents
{
    public partial class TableView
    {
        [Inject]
        public IPlanServices PlanServices { get; set; }
        [Parameter]
        public EventCallback<Plan> OnViewClicked { get; set; }
        [Parameter]
        public EventCallback<Plan> OnEditClicked { get; set; }
        [Parameter]
        public EventCallback<Plan> OnDeleteClicked { get; set; }
        private MudTable<Plan> _table;
        private string _query = string.Empty;
        private async Task<TableData<Plan>> ServerReloadAsync(TableState state)
        {
            var result = await PlanServices.GetPlansAsync(_query, state.Page, state.PageSize);
            return new TableData<Plan>
            {
                Items = result.Value.Records,
                TotalItems = result.Value.ItemCount

            };
        }

        private void OnSearch(string query)
        {
            _query = query;
        }

    }
}
