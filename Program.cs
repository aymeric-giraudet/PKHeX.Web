using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PKHeX.Web;
using PKHeX.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
builder.Services.AddScoped(sp => httpClient);

builder.Services.AddMudServices();
builder.Services.AddSingleton<SaveFileService>();
builder.Services.AddSingleton<SpriteService>();
builder.Services.AddSingleton<PokemonEditorService>();

var host = builder.Build();

var spriteService = host.Services.GetRequiredService<SpriteService>();
await spriteService.InitializeServiceAsync(httpClient);

await host.RunAsync();

