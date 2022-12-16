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

        public async Task<ApiResponses<PlanDetails>> CreateAsync(PlanDetails model, FormFile coverFile)
        {
            var form = PreparePlanForm(model, coverFile, false);
            var response = await _client.PostAsync("/api/v2/plans", form);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponses<PlanDetails>>();
                return result;

            }
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorsResponses>();
                throw new APIException(errorResponse, response.StatusCode);

            }
        }

        public async
            Task<ApiResponses<PlanDetails>> EditAsync(PlanDetails model, FormFile coverFile)
        {
            var form = PreparePlanForm(model, coverFile, true);
            var response = await _client.PutAsync("/api/v2/plans", form);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ApiResponses<PlanDetails>>();
                return result;

            }
            else
            {
                var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorsResponses>();
                throw new APIException(errorResponse, response.StatusCode);

            }
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

        private HttpContent PreparePlanForm(PlanDetails model, FormFile coverFile, bool isUpdated) 

        {
            var form = new MultipartFormDataContent();
            form.Add(new StringContent(model.Title), nameof(PlanDetails.Title));
            if(!string.IsNullOrWhiteSpace(model.Description)) 
                form.Add(new StringContent(model.Description), nameof(PlanDetails.Description));
            if(isUpdated)
                form.Add(new StringContent(model.Id), nameof(PlanDetails.Id));
            if(coverFile != null)
                form.Add(new StreamContent(coverFile.FileStream),nameof(PlanDetails.CoverFile), coverFile.FileName);
            return form;
        }
    }

}
