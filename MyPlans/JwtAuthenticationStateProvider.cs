using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

public class JwtAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _storageService;
    public JwtAuthenticationStateProvider(ILocalStorageService storageService)
    {
        _storageService = storageService;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    { 
       if (await _storageService.ContainKeyAsync("access_token"))
        {
            var tokenAsString = await _storageService.GetItemAsStringAsync("access_token");
            var tokehandler = new JwtSecurityTokenHandler();

            var token = tokehandler.ReadJwtToken(tokenAsString);
            var identity = new ClaimsIdentity(token.Claims, "Bearer");
            var user = new ClaimsPrincipal(identity);
            var authState = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(authState));
            return authState;
        }
        return new AuthenticationState(new ClaimsPrincipal());
    }
}
