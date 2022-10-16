using MassTransit;
using Microsoft.Extensions.Logging;
using Shared;
using Shared.Events;
using Shared.Interfaces;
using System.Threading.Tasks;

namespace Payment.API.Consumers
{
    public class StockReservedRequestConsumer : IConsumer<IStockReservedRequestEvent>
    {
        private readonly ILogger<StockReservedRequestConsumer> _logger;

        private readonly IPublishEndpoint _publishEndpoint;

        public StockReservedRequestConsumer(ILogger<StockReservedRequestConsumer> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public async Task Consume(ConsumeContext<IStockReservedRequestEvent> context)
        {
            var balance = 3000m;

            if (balance > context.Message.Payment.TotalPrice)
            {
                _logger.LogInformation($"{context.Message.Payment.TotalPrice} TL was withdrawn from credit card for user id= {context.Message.CorrelationId}");

                await _publishEndpoint.Publish(new PaymentCompletedEvent(context.Message.CorrelationId));
            }
            else
            {
                _logger.LogInformation($"{context.Message.Payment.TotalPrice} TL was not withdrawn from credit card for user id={context.Message.CorrelationId}");

                await _publishEndpoint.Publish(new PaymentFailedEvent(context.Message.CorrelationId) { Reason = "not enough balance", OrderItems = context.Message.OrderItems });
            }
        }
    }
}
