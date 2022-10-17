using EventSourcing.API.DTOs;
using MediatR;
using System.Collections.Generic;

namespace EventSourcing.API.Queries
{
    public class GetProductAllListByUserId : IRequest<List<ProductDto>>
    {
        public int UserId { get; set; }
    }
}
