namespace Suit.AlterationService.APIService.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Suit.AlterationService.Application.Commands;
    using Suit.Platform.Infrastructure.Core;
    using Suit.Platform.Infrastructure.Core.Commands;

    [ApiController]
    [Route("[controller]/[action]")]
    public class CommandController : ControllerBase
    {
        private readonly ILogger<CommandController> logger;
        private readonly IDispatcher dispatcher;

        public CommandController(ILogger<CommandController> logger, IDispatcher dispatcher)
        {
            this.logger = logger;
            this.dispatcher = dispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlteration([FromBody] CreateAlterationCommand command)
        {
            return CheckResponse(await this.dispatcher.SendAsync(command));
        }

        [HttpPost]
        public async Task<IActionResult> StartProcessing([FromBody] StartProcessingAlterationCommand command)
        {
            return CheckResponse(await this.dispatcher.SendAsync(command));
        }

        [HttpPost]
        public async Task<IActionResult> FinishAlteration([FromBody] FinishAlterationCommand command)
        {
            return CheckResponse(await this.dispatcher.SendAsync(command));
        }

        private IActionResult CheckResponse(CommandResponse response)
        {
            if (!response.ValidationResult.IsValid)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public string Ping()
        {
            return "Server is running";
        }
    }
}