using System.Net.Http.Json;
using ControlStock.Shared.DTOs;

namespace ClienteStock.Cliente.Services
{
    public class ProductoService
    {
        private readonly HttpClient http;

        public ProductoService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<List<ProductoListadoDTO>> ObtenerTodosAsync()
        {
            var productos = await http.GetFromJsonAsync<List<ProductoListadoDTO>>("api/producto");
            return productos ?? new List<ProductoListadoDTO>();
        }

        public async Task<ProductoDTO> CrearAsync(ProductoDTO producto)
        {
            var response = await http.PostAsJsonAsync("api/producto", producto);

            if (!response.IsSuccessStatusCode)
            {
                var detalle = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(
                    $"El servidor respondió {(int)response.StatusCode} ({response.StatusCode}). {detalle}");
            }

            var creado = await response.Content.ReadFromJsonAsync<ProductoDTO>();
            return creado ?? producto;
        }

        public async Task EliminarAsync(int id)
        {
            var response = await http.DeleteAsync($"api/producto/{id}");

            if (!response.IsSuccessStatusCode)
            {
                var detalle = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(
                    $"El servidor respondió {(int)response.StatusCode} ({response.StatusCode}). {detalle}");
            }
        }

        public async Task<int> EliminarTodosAsync()
        {
            // confirmar=true evita que el endpoint se ejecute por accidente.
            var response = await http.DeleteAsync("api/producto/todos?confirmar=true");

            if (!response.IsSuccessStatusCode)
            {
                var detalle = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(
                    $"El servidor respondió {(int)response.StatusCode} ({response.StatusCode}). {detalle}");
            }

            var contenido = await response.Content.ReadAsStringAsync();
            return int.TryParse(contenido, out var eliminados) ? eliminados : 0;
        }
    }
}
