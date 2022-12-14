using MyPlansLibrary.ApiResponses;
using MyPlansLibrary.Models;
using MyPlansLibrary.Responses;
using MyPlansServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyPlansServices.Exceptions
{
    public class HttpAuthenticationServices : IAuthenticationServices
    {
        private readonly HttpClient _client;
        public HttpAuthenticationServices(HttpClient client)
        {
            _client = client;
        }
        public async Task<ApiResponses> RegisterUserAsync(RegisterAPI model)
        {
            var response = await _client.PostAsJsonAsync("/api/v2/auth/register", model);
            if (response.IsSuccessStatusCode) 
            { 
            var result = await response.Content.ReadFromJsonAsync<ApiResponses>();
                return result;
            }
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorsResponses>();
                throw new APIException(errorResponse, response.StatusCode);
            }
        }
    }

}