using MassTransit;
using System;
using System.Collections.Generic;

namespace Shared.Interfaces
{
    public interface IStockNotReservedEvent : CorrelatedBy<Guid>
    {
        string Reason { get; set; }
    }
}
