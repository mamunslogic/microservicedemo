using CoreApiResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Commands.CreateOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Queries.GetOrdersByUsername;
using System.Net;

namespace Ordering.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : BaseController
    {
        IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrderByUsername(string username)
        {
            try
            {
                var getOrdersByUserQuery = new GetOrdersByUserQuery(username);
                var orders = await _mediator.Send(getOrdersByUserQuery);
                return CustomResult("Order load successful.", orders);
            }
            catch (Exception exception)
            {
                return CustomResult(exception.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand orderCommand)
        {
            try
            {
                var isOrderPlaced = await _mediator.Send(orderCommand);
                if (isOrderPlaced)
                    return CustomResult("Order has been placed.");
                else
                    return CustomResult("Order not placed.", HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                return CustomResult(exception.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand orderCommand)
        {
            try
            {
                var isOrderModified = await _mediator.Send(orderCommand);
                if (isOrderModified)
                    return CustomResult("Order has been modified.");
                else
                    return CustomResult("Order modification failed.", HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                return CustomResult(exception.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            try
            {
                var isOrderDeleted = await _mediator.Send(new DeleteOrderCommand { Id = orderId });
                if (isOrderDeleted)
                    return CustomResult("Order has been deleted.");
                else
                    return CustomResult("Order deletion failed.", HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                return CustomResult(exception.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
