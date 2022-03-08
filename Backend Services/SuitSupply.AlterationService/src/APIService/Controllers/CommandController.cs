namespace SuitSupply.AlterationService.APIService.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using SuitSupply.AlterationService.Application.Commands;
    using SuitSupply.Platform.Infrastructure.Core;
    using SuitSupply.Platform.Infrastructure.Core.Commands;
    using SuitSupply.Infrastructure.Repository.RDBRepository;

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
            CommandResponse response = await this.dispatcher.SendAsync(command).ConfigureAwait(false);

            if (!response.ValidationResult.IsValid)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// API to complete payment for alteration.
        /// </summary>
        /// <param name="command"><see cref="DoPayment"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> CompletePayment([FromBody] CompletePaymentCommand command)
        {
            CommandResponse response = await this.dispatcher.SendAsync(command).ConfigureAwait(false);

            if (!response.ValidationResult.IsValid)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }

        /// <summary>
        /// API to start processing Alteration.
        /// </summary>
        /// <param name="command"><see cref="StartProcessingAlterationCommand"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> StartProcessing([FromBody] StartProcessingAlterationCommand command)
        {
            CommandResponse response = await this.dispatcher.SendAsync(command).ConfigureAwait(false);

            if (!response.ValidationResult.IsValid)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        /// <summary>
        /// API to Finish Alteration.
        /// </summary>
        /// <param name="command"><see cref="FinishAlterationCommand"/>.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> FinishAlteration([FromBody] FinishAlterationCommand command)
        {
            CommandResponse response = await this.dispatcher.SendAsync(command).ConfigureAwait(false);

            if (!response.ValidationResult.IsValid)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet]
        public string Ping()
        {
            this.logger.LogInformation("sdfsd");
            return "Server is running";
        }
    }
}