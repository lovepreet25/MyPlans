using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace MyPlans.Components.BaseLayout
{
    public partial class MyPlanPage
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter] 
        public string Title { get; set; }
        [Parameter]
        public List<BreadcrumbItem> Breadcrumbs { get; set; } = new();
    }
}
