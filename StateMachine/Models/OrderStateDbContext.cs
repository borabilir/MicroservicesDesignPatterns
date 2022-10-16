using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace StateMachine.Models
{
    public class OrderStateDbContext : SagaDbContext
    {

        public OrderStateDbContext(DbContextOptions<OrderStateDbContext> options) : base(options)
        {

        }

        protected override IEnumerable<ISagaClassMap> Configurations
        {
            get
            {
                yield return new OrderStateMap();
            }
        }
    }
}
