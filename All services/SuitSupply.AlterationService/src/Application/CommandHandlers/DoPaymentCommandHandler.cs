//namespace SuitSupply.DeliveryPlatform.Shop.Applications.CommandHandlers
//{
//    using System;
//    using System.Threading.Tasks;
//    using Microsoft.Extensions.Logging;
//    using Newtonsoft.Json;
//    using SuitSupply.AlterationService.Application.Commands;
//    using SuitSupply.Platform.Infrastructure.Core.Commands;

//    / <summary>
//    / Responsible to handle shop Update Command request.
//    / </summary>
//    public class DoPaymentCommandHandler : ICommandHandlerAsync<DoPaymentCommand>
//    {
//        private ILogger<DoPaymentCommandHandler> logger;
//        private IAggregateRepository<ShopAggregate> aggregateRepository;
//        private ISecurityClaimManager securityClaimManager;
//        private IDomainEventPublisher domainEventPublisher;

//        / <summary>
//        / Initializes a new instance of the<see cref="UpdateShopCommandHandler"/> class.
//        / </summary>
//        / <param name = "logger" > Logger instance.</param>
//        / <param name = "aggregateRepository" >< see cref="IAggregateRepository."/>Aggregate Repository.</param>
//        public DoPaymentCommandHandler(
//            ILogger<DoPaymentCommandHandler> logger,
//            IAggregateRepository<ShopAggregate> aggregateRepository,
//            ISecurityClaimManager securityClaimManager,
//            IDomainEventPublisher domainEventPublisher)
//        {
//            this.domainEventPublisher = domainEventPublisher;
//            this.logger = logger;
//            this.aggregateRepository = aggregateRepository;
//            this.securityClaimManager = securityClaimManager;
//        }

//        / <summary>
//        / Handler.
//        / </summary>
//        / <param name = "command" >< see cref="CreateShopCommand"/>.</param>
//        / <returns>Task of<see cref= "CommandResponse" />.</ returns >
//        public async Task<CommandResponse> HandleAsync(DoPaymentCommand command)
//        {
//            try
//            {
//                this.logger.LogInformation($"UpdateShopCommandHandler START with CorrelationId: '{command.CorrelationId}'");

//                foreach (var shopDto in command.Shops)
//                {
//                    try
//                    {
//                        ShopAggregate shop = this.aggregateRepository.GetById(shopDto.ShopId);

//                        if (shop == null)
//                        {
//                            await this.domainEventPublisher.PublishInvalidIdRuleViolationEvent(shopDto.ShopId.ToString(), nameof(shopDto.ShopId), nameof(ShopUpdatedEvent), shopDto);
//                            continue;
//                        }

//                        shop.Update(shopDto, command.CorrelationId, command.UserContext, command.IsBatchUpload);

//                        await this.aggregateRepository.UpdateAsync(shop).ConfigureAwait(false);
//                    }
//                    catch (Exception e)
//                    {
//                        this.logger.LogError(e, $"Exception: UpdateShopCommandHandler with CorrelationId: '{command.CorrelationId}', for dto {shopDto}, Message {e.Message}");

//                        await this.domainEventPublisher.PublishInternalExceptionRuleViolationEvent(
//                            shopDto.ShopId.ToString(),
//                            nameof(ShopUpdatedEvent),
//                            shopDto,
//                            exception: JsonConvert.SerializeObject(e)).ConfigureAwait(false);
//                    }
//                }

//                this.logger.LogInformation($"UpdateShopCommandHandler DONE with CorrelationId: '{command.CorrelationId}'");
//            }
//            catch (Exception ex)
//            {
//                this.logger.LogError(ex, $"Exception: UpdateShopCommandHandler with CorrelationId: '{command.CorrelationId}', {ex.Message}");
//                throw;
//            }

//            return new CommandResponse();
//        }
//    }
//}
