using Shared.Interfaces;
using System;
using System.Collections.Generic;

namespace Shared.Events
{
    public class StockReservedRequestEvent : IStockReservedRequestEvent
    {
        public StockReservedRequestEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public Guid CorrelationId { get; }
        public PaymentMessage Payment { get; set; }
        public List<OrderItemMessage> OrderItems { get; set; }
    }
}
