using Microsoft.AspNetCore.Components;
using MyPlans.Pages.Auth;
using MyPlansLibrary.Models;

using MyPlans.Components;
using System.Net.Http;
using System.Threading.Tasks;



namespace MyPlans.Components.Auth
{
    public partial class LoginForm : ComponentBase

    {
        [Inject]
        public HttpClient HttpClient { get; set; }


        public LoginApi _model = new LoginApi();

        private async Task loginUserAsync()
        {
            throw new NotImplementedException();
        }


    }
}
     
