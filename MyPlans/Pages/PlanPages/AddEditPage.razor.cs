using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace MyPlans.Pages.PlanPages
{
	public partial class AddEditPage
	{
		[Parameter]
		public string Id { get; set; }
		private List<BreadcrumbItem> Breadcrumbs = new()
		{
			new BreadcrumbItem("Home", "/home"),
			new BreadcrumbItem("My Plans", "/plans", true),
	        new BreadcrumbItem("Add", "/plans/form", true)

		};
	}
}
