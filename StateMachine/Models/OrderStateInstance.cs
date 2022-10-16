using MassTransit;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace StateMachine.Models
{
    public class OrderStateInstance : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public string BuyerId { get; set; }
        public int OrderId { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public override string ToString()
        {
            var properties = GetType().GetProperties();

            var sb = new StringBuilder();

            properties.ToList().ForEach(prop =>
            {
                var value = prop.GetValue(this, null);
                sb.AppendLine($"{prop.Name}:{value}");
            });

            sb.Append("------------------------");
            return sb.ToString();
        }
    }
}
