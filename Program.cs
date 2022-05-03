using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PKHeX.Web;
using PKHeX.Web.Services;
using PKHeX.Core;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
builder.Services.AddScoped(sp => httpClient);

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();
builder.Services.AddSingleton<SavEdit>();
builder.Services.AddSingleton<SpriteService>();
builder.Services.AddSingleton<PkmEdit>();

var host = builder.Build();

// Loading json data for sprites
var spriteService = host.Services.GetRequiredService<SpriteService>();
await spriteService.InitializeServiceAsync(httpClient);

// Loading settings from localStorage and initializing blank SAV/PKM
var savEdit = host.Services.GetRequiredService<SavEdit>();
var pkmEdit = host.Services.GetRequiredService<PkmEdit>();
var localStorageService = host.Services.GetRequiredService<ILocalStorageService>();

var storedGameVersion = await localStorageService.GetItemAsync<GameVersion>("BlankVersion");
if (storedGameVersion == 0)
{
  storedGameVersion = GameVersion.BD;
  await localStorageService.SetItemAsync("BlankVersion", storedGameVersion);
}
savEdit.SAV = SaveUtil.GetBlankSAV(storedGameVersion, "PKHeX");
pkmEdit.PKM = savEdit.SAV.LoadTemplate();

await host.RunAsync();
