using Microsoft.AspNetCore.Components;
using MyPlans.Pages.Auth;
using MyPlansLibrary.Models;
using MyPlansLibrary.Responses;
using MyPlansLibrary;
using MyPlans.Components;
using System.Net.Http;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using System.Net.Http.Json;
using System.ComponentModel.DataAnnotations;
using MyPlansLibrary.ApiResponses;
using Microsoft.AspNetCore.Components.Authorization;

namespace MyPlans.Components.Auth
{
    public partial class LoginForm : ComponentBase

    {
        [Inject]
        public HttpClient HttpClient { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
        private LoginApi _model = new LoginApi();
=======
=======
>>>>>>> af0ec36aa12348dc0f5f7ecdad7a84ccb5cc8b81

        [Inject]
        public NavigationManager Navigation { get; set; }
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; } 
        public LoginApi _model = new LoginApi();
        private bool _isBusy = false;
        private string _errorMessage = string.Empty;
        [Inject]
        public ILocalStorageService StorageServices { get; set; }    
        private async Task loginUserAsync()
        {
            _isBusy = true;
            _errorMessage = string.Empty;
            var response = await HttpClient.PostAsJsonAsync("/api/v2/auth/login", _model);
            if (response.IsSuccessStatusCode)
            { 
             var result = await response.Content.ReadFromJsonAsync<ApiResponses<LoginApiResult>>();

                await StorageServices.SetItemAsStringAsync("access_token", result.Value.Token);
                await StorageServices.SetItemAsync<DateTime>("expiry_date", result.Value.ExpiryDate);

                await AuthenticationStateProvider.GetAuthenticationStateAsync();

                Navigation.NavigateTo("/");
<<<<<<< HEAD
>>>>>>> af0ec36aa12348dc0f5f7ecdad7a84ccb5cc8b81
=======
>>>>>>> af0ec36aa12348dc0f5f7ecdad7a84ccb5cc8b81


            }
            else
            {
                var errResult = await response.Content.ReadFromJsonAsync<ApiErrorsResponses>();
                 _errorMessage = errResult.Message;
            }
            _isBusy = false;  
        }

      
    }
}
     
