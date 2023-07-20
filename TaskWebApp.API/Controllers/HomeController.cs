using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TaskWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetContentAsync(CancellationToken token)
        {
            try
            {
                _logger.LogInformation("İstek başladı!");

                //Automatic handler
                //await Task.Delay(5000, token);

                //var myTask = new HttpClient().GetStringAsync("https://fenerbahce.org");

                //var data = await myTask;

                Enumerable.Range(1, 10).ToList().ForEach(x => {

                    Thread.Sleep(1000);

                    token.ThrowIfCancellationRequested();
                
                });

                _logger.LogInformation("İstek bitti!");
                return Ok("Process is over!");
            }
            catch (Exception ex)
            {

                _logger.LogInformation("İstek iptal edildi." + ex.Message);
                return BadRequest();
            }

           
        }
    }
}
