
using MudBlazor;

namespace MyPlans.Pages.PlanPages
{
    public partial class Plans
    {
        private List<BreadcrumbItem> Breadcrumbs = new()
        {
            new BreadcrumbItem("Home", "/home"),
            new BreadcrumbItem("My Plans", "/plans", true)
        };
    }
}
