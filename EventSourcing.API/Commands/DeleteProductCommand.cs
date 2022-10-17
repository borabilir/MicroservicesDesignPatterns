using MediatR;
using System;

namespace EventSourcing.API.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
