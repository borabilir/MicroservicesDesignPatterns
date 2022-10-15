namespace Shared
{
    public class RabbitMQSettings
    {
        public const string StockOrderCreatedEventQueue = "stock-order-created-queue";
        public const string StockReservedEventQueue = "stock-reserved-queue";
        public const string StockPaymentFailedEventQueue = "stock-payment-failed-queue";
        public const string OrderPaymentCompletedEventQueue = "order-payment-completed-queue";
        public const string OrderPaymentFailedEventQueue = "order-payment-failed-queue";
        public const string OrderStockNotReservedEventQueue = "order-stock-not-reserved-queue";
    }
}
