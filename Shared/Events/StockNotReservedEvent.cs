using Shared.Interfaces;
using System;

namespace Shared.Events
{
    public class StockNotReservedEvent : IStockNotReservedEvent
    {
        public StockNotReservedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }
        public Guid CorrelationId { get; }
        public int OrderId { get; set; }
        public string Message { get; set; }
        public string Reason { get; set; }

    }
}
