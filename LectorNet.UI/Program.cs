using LectorNet.UI.Authentication;
using LectorNet.UI.Components;
using LectorNet.UI.Services;
using LectorNet.UI.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddBlazorAppAuthentication();

builder.Services.AddHttpClient();

builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<AuthService>();

// builder.Services.AddAuthorizationCore(options =>
// {
//     options.AddPolicy("NotAuthenticated", policy =>
//     {
//         policy.RequireAssertion(context => !context.User.Identity!.IsAuthenticated);
//     });
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAuthentication();

app.UseAuthorization();

app.UseAntiforgery();


app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();