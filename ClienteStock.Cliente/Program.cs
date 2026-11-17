using ClienteStock.Cliente;
using ClienteStock.Cliente.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// El cliente se ejecuta en su propio puerto (https://localhost:7024),
// por lo que todas las llamadas HTTP deben apuntar al servidor de la API.
const string apiBaseUrl = "https://localhost:7156/";

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(apiBaseUrl)
});

builder.Services.AddScoped<ProductoService>();

await builder.Build().RunAsync();
