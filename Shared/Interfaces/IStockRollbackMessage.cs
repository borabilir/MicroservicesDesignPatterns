using System.Collections.Generic;

namespace Shared.Interfaces
{
    public interface IStockRollbackMessage
    {
        List<OrderItemMessage> OrderItems { get; set; }
    }
}
