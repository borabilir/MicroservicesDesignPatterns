namespace Shared
{
    public class RabbitMQSettings
    {
        public const string OrderSaga= "order-saga-queue";
        public const string StockOrderCreatedEventQueue = "stock-order-created-queue";
        public const string StockReservedEventQueue = "stock-reserved-queue";
        public const string StockPaymentFailedEventQueue = "stock-payment-failed-queue";
        public const string OrderPaymentCompletedEventQueue = "order-payment-completed-queue";
        public const string OrderPaymentFailedEventQueue = "order-payment-failed-queue";
        public const string OrderStockNotReservedEventQueue = "order-stock-not-reserved-queue";
        public const string PaymentStockReservedRequestQueue = "payment-stock-reserved-request-queue";
        public const string StockRollbackMessageQueue = "stock-rollback-message-queue";
        public const string OrderRequestCompletedEventQueue = "order-request-completed-queue";
        public const string OrderRequestFailedEventQueue = "order-request-failed-queue";
    }
}
