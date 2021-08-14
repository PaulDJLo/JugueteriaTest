using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JugueteriaApp.Controllers
{
    [Route("api/[controller]")]
    public class CreateProductController : Controller
    {
        private readonly String apiBaseUrl;


        public CreateProductController(IConfiguration configuration)
        {
            apiBaseUrl = configuration.GetValue<string>("CreateProductUrl");
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductoResponse result = new ProductoResponse();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
                    using (var response = await client.PostAsync(apiBaseUrl, content))
                    {
                        result = await HttpContentExtensions.ReadAsAsync<ProductoResponse>(response.Content);
                        return CreatedAtAction("GetPersona", new { id = result.Producto.Id }, result.Producto);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
        }
    }
}
