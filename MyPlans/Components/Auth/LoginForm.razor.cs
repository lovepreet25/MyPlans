using Microsoft.AspNetCore.Components;
using MyPlans.Pages.Auth;
using MyPlansLibrary.Models;
<<<<<<< HEAD
using MyPlans.Components;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyPlans.Components.Auth
{
    public partial class LoginForm: ComponentBase
=======
namespace MyPlans.Components.Auth
{
    public partial class LoginForm : ComponentBase
>>>>>>> 00d9e338268d23b9c71728cb641b500305f4c01e
    {
        [Inject]
        public HttpClient HttpClient { get; set; }

<<<<<<< HEAD
        public LoginApi _model = new LoginApi();

        private async Task loginUserAsync()
        {
            throw new NotImplementedException();
        }


    }
}
=======
        private LoginApi _model = new LoginApi();


    }
}
>>>>>>> 00d9e338268d23b9c71728cb641b500305f4c01e
