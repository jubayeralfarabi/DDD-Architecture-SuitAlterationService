namespace SuitSupply.EmailService.APIService.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("[controller]/[action]")]
    public class CommandController : ControllerBase
    {
        private readonly ILogger<CommandController> logger;

        public CommandController(ILogger<CommandController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public string Ping()
        {
            this.logger.LogInformation("Ping...");
            return "Server is running";
        }
    }
}