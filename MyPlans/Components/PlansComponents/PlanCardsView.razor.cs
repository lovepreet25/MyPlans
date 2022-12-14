using AKSoftware.Blazor.Utilities;
using Microsoft.AspNetCore.Components;
using MyPlansLibrary.Models;

namespace MyPlans.Components.PlansComponents
{
    public partial class PlanCardsView
    {
      private bool _isBusy { get; set; }
        private int _pageNumber = 1;
        private int _pageSize = 10;
      
        private string _query = string.Empty;
        [Inject]
        public NavigationManager Navigation { get; set; }

        [Parameter]
        public Func<string, int, int, Task<Pagination<Plan>>> FetchPlans { get; set; }

        [Parameter]
        public EventCallback<Plan> OnEditClicked { get; set; }
        [Parameter]
        public EventCallback<Plan> OnDeleteClicked { get; set; }
        private Pagination<Plan> _result = new ();
        protected override async void OnInitialized()
        {
            MessagingCenter.Subscribe<Pagination, Plan>(this, "plan_deleted", async (sender, args) =>
            {
                await GetPlansAsync(_pageNumber);
                StateHasChanged();

            });
        }

        protected async override Task OnInitializedAsync()
        {
            await GetPlansAsync();
        }

        private async Task GetPlansAsync(int pageNumber = 1)
        {
            _pageNumber = pageNumber;
            _isBusy = true;
            _result = await FetchPlans?.Invoke(_query, _pageNumber, _pageSize);
            _isBusy = false;
        }



       
    }
}
