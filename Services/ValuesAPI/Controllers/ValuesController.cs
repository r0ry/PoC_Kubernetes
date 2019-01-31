using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ValuesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            // Create a New HttpClient object and dispose it when done, so the app doesn't leak resources
            using (HttpClient client = new HttpClient())
            {
                // Call asynchronous network methods in a try/catch block to handle exceptions
                try
                {

                    string responseBody = await client.GetStringAsync("http://ocelot.default/catalog");

                    return new string[] { "This is Values API. Message from CatalogAPI:", responseBody };
                }
                catch (HttpRequestException e)
                {
                    return new string[] { Request.Host.ToString(), e.Message };
                }
            }
        }
    }
}
