using MyPlansLibrary.ApiResponses;
using MyPlansLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlansServices.Interfaces
{
    public interface IAuthenticationServices
    {
        Task<ApiResponses> RegisterUserAsync (RegisterAPI model);


    }
}
