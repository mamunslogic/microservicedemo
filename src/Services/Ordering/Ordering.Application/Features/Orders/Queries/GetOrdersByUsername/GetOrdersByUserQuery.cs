using MediatR;

namespace Ordering.Application.Features.Orders.Queries.GetOrdersByUsername
{
    public class GetOrdersByUserQuery : IRequest<List<OrderViewModel>>
    {
        public string Username { get; set; }

        public GetOrdersByUserQuery(string username)
        {
            Username = username;
        }
    }
}
