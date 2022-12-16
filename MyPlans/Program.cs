using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyPlans;
using MudBlazor;
using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MudBlazor.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MyPlansServices.Exceptions;
using MyPlansServices.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddHttpClient("PlannerApp.Api", Client =>
{
    Client.BaseAddress = new Uri("https://plannerapp-api.azurewebsites.net");
}).AddHttpMessageHandler<AuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("PlannerApp.Api"));
builder.Services.AddTransient<AuthorizationMessageHandler>();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
<<<<<<< HEAD

=======
builder.Services.AddScoped<IAuthenticationServices, HttpAuthenticationServices>();
>>>>>>> 37abf200acb0d7327f8d3bc4bd94cf2cbba04838

await builder.Build().RunAsync();
