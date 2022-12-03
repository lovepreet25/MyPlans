using Blazored.LocalStorage;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class AuthorizationMessageHandler : DelegatingHandler
{
    private readonly ILocalStorageService _storageService;
    public AuthorizationMessageHandler(ILocalStorageService storageService)
    {
        _storageService = storageService;
    }
    protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (await _storageService.ContainKeyAsync("access_token"))
        {
            var token = await _storageService.GetItemAsStringAsync("access_token");
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        }
        Console.WriteLine("Handler is called");
        return await base.SendAsync(request, cancellationToken);
    }
}