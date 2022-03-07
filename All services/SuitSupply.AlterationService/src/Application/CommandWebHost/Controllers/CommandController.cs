namespace SuitSupply.AlterationService.Application.CommandWebHost.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using SuitSupply.AlterationService.Application.Commands;
    using SuitSupply.Platform.Infrastructure.Core;
    using SuitSupply.Platform.Infrastructure.Core.Commands;

    //[Authorize]
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

        /// <summary>
        /// API to create alteration.
        /// </summary>
        /// <param name="command"><see cref="CreateAlterationCommand"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAlteration([FromBody] CreateAlterationCommand command)
        {
            this.logger.LogDebug($"CreateAlterationCommand START with CorrelationId: '{command.CorrelationId}'");

            CommandResponse response = await this.dispatcher.SendAsync(command).ConfigureAwait(false);

            if (response.ValidationResult.IsValid)
            {
                this.logger.LogInformation($"DoPaymentCommand DONE with CorrelationId: '{command.CorrelationId}'");

                return Ok(response);
            }
            else
            {
                this.logger.LogInformation($"DoPaymentCommand ENDED with CorrelationId: '{command.CorrelationId}'");

                return BadRequest(response);
            }
        }

        /// <summary>
        /// API to do payment for alteration.
        /// </summary>
        /// <param name="command"><see cref="DoPayment"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> DoPayment([FromBody] DoPaymentCommand command)
        {
            this.logger.LogInformation($"DoPaymentCommand START with CorrelationId: '{command.CorrelationId}'");

            CommandResponse response = await this.dispatcher.SendAsync(command).ConfigureAwait(false);

            if (response.ValidationResult.IsValid)
            {
                this.logger.LogInformation($"DoPaymentCommand DONE with CorrelationId: '{command.CorrelationId}'");

                return Ok(response);
            }
            else
            {
                this.logger.LogInformation($"DoPaymentCommand ENDED with CorrelationId: '{command.CorrelationId}'");

                return BadRequest(response);
            }

        }

        /// <summary>
        /// API to start processing Alteration.
        /// </summary>
        /// <param name="command"><see cref="StartProcessingAlterationCommand"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> StartProcessing([FromBody] StartProcessingAlterationCommand command)
        {
            this.logger.LogInformation($"StartProcessingAlterationCommand START with CorrelationId: '{command.CorrelationId}'");

            CommandResponse response = await this.dispatcher.SendAsync(command).ConfigureAwait(false);

            if (response.ValidationResult.IsValid)
            {
                this.logger.LogInformation($"StartProcessingAlterationCommand DONE with CorrelationId: '{command.CorrelationId}'");

                return Ok(response);
            }
            else
            {
                this.logger.LogInformation($"StartProcessingAlterationCommand ENDED with CorrelationId: '{command.CorrelationId}'");

                return BadRequest(response);
            }

        }

        /// <summary>
        /// API to Finish Alteration.
        /// </summary>
        /// <param name="command"><see cref="FinishAlterationCommand"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> FinishAlteration([FromBody] FinishAlterationCommand command)
        {
            this.logger.LogInformation($"FinishAlterationCommand START with CorrelationId: '{command.CorrelationId}'");

            CommandResponse response = await this.dispatcher.SendAsync(command).ConfigureAwait(false);

            if (response.ValidationResult.IsValid)
            {
                this.logger.LogInformation($"FinishAlterationCommand DONE with CorrelationId: '{command.CorrelationId}'");

                return Ok(response);
            }
            else
            {
                this.logger.LogInformation($"FinishAlterationCommand ENDED with CorrelationId: '{command.CorrelationId}'");

                return BadRequest(response);
            }
        }

        [HttpGet]
        public string Ping()
        {
            return "Server is running";
        }
    }
}
