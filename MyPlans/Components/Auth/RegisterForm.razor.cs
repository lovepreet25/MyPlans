using Microsoft.AspNetCore.Components;
using MyPlansServices.Exceptions;
using MyPlansServices.Interfaces;
using MyPlansLibrary.Models;

namespace MyPlans.Components.Auth
{
    public partial class RegisterForm
    {


        [Inject]
        public IAuthenticationServices AuthenticationService { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        



        private RegisterAPI _model = new();
        private bool _isBusy = false;
        private string _errorMessage = string.Empty;

       
       

        private async Task RegisterUserAsync()
        {
            _isBusy = true;
            _errorMessage = string.Empty;

            try
            {
                await AuthenticationService.RegisterUserAsync(_model);
                Navigation.NavigateTo("/auth/login");
            }
            catch (APIException ex)
            {
                _errorMessage = ex.ApiErrorsResponses.Message;
            }
            catch (Exception ex)
            {
               _errorMessage= ex.Message;
            }

            _isBusy = false;
        }

        private void RedirectToLogin()
        {
            Navigation.NavigateTo("/auth/login");
        }

    }
}
