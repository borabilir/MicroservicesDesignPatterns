﻿using Shared.Interfaces;
using System;
using System.Collections.Generic;

namespace Shared.Events
{
    public class PaymentFailedEvent : IPaymentFailedEvent
    {
        public PaymentFailedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public Guid CorrelationId { get; }
        public string Reason { get; set; }
        public List<OrderItemMessage> OrderItems { get; set; }
    }
}
