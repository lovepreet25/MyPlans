using Microsoft.AspNetCore.Components;
using MyPlansLibrary.Models;

namespace MyPlans.Components.PlansComponents
{
    public partial class PlanCard
    {
        [Parameter]
        public Plan Plan { get; set; } = new();
        [Parameter]
        public bool IsBusy { get; set; }
        [Parameter]
        public EventCallback<Plan> OnViewClicked { get; set; }
        [Parameter]
        public EventCallback<Plan> OnEditClicked { get; set; }
        [Parameter]
        public EventCallback<Plan> OnDeleteClicked { get; set; }
    }
}
