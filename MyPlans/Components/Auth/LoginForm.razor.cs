using Microsoft.AspNetCore.Components;
using MyPlans.Pages.Auth;
using MyPlansLibrary.Models;
namespace MyPlans.Components.Auth
{
    public partial class LoginForm : ComponentBase
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

        private LoginApi _model = new LoginApi();


    }
}