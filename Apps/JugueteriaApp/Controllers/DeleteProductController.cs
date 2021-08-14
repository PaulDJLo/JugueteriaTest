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
    public class DeleteProductController : Controller
    {
        private readonly String apiBaseUrl;

        public DeleteProductController(IConfiguration configuration)
        {
            apiBaseUrl = configuration.GetValue<string>("DeleteProductUrl");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
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
                    String url = apiBaseUrl + id;
                    using (var response = await client.DeleteAsync(url))
                    {
                        result = await HttpContentExtensions.ReadAsAsync<ProductoResponse>(response.Content);
                        if(result.IsSuccess)
                        {
                            return Ok();
                        }
                        else
                        {
                            return NotFound();
                        }
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
