using MyPlansLibrary.ApiResponses;
using MyPlansLibrary.Models;
using MyPlansLibrary.Responses;
using MyPlansServices.Exceptions;
using MyPlansServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyPlansServices
{
    public  class HttpPlansServices : IPlanServices
    {
        private readonly HttpClient _client;
        public HttpPlansServices(HttpClient client)
        {
            _client = client;
        }
        public async Task  <ApiResponses<Pagination<Plan>>>GetPlansAsync(string query = null , int pageNumber = 1, int pageSize = 10)
        {
            var response = await _client.GetAsync($"/api/v2/plans?query={query}&pageNumber={pageNumber}&pageSize={pageSize}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponses<Pagination<Plan>>>();
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
