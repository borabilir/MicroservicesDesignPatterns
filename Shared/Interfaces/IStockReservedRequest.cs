using MassTransit;
using System;
using System.Collections.Generic;

namespace Shared.Interfaces
{
    public interface IStockReservedRequestEvent : CorrelatedBy<Guid>
    {
        PaymentMessage Payment { get; set; }
        List<OrderItemMessage> OrderItems { get; set; }
    }
}
