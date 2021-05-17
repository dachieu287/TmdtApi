using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tmdt.Application.Features.InvoicesFeature.Commands;
using Tmdt.Application.Features.InvoicesFeature.Queries;
using Tmdt.Application.Features.InvoicesFeature.Responses;
using Tmdt.Domain.Enums;
using Tmdt.Infrastructure.Identity.Interfaces;

namespace Tmdt.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IIdentityService _identityService;

        public InvoicesController(IMediator mediator, IIdentityService identityService)
        {
            _mediator = mediator;
            _identityService = identityService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            var userId = _identityService.GetUserId(User);
            await _mediator.Send(new CreateInvoiceCommand(userId));
            return NoContent();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> OrderHistory()
        {
            var userId = _identityService.GetUserId(User);
            var response = await _mediator.Send(new GetHistoryOrderQuery(userId));
            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> CancelOrder([FromBody] CancelOrderCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetInvoices([FromQuery] GetInvoicesByFilterQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetInvoice(int invoiceId)
        {
            var response = await _mediator.Send(new GetInvoiceByIdQuery(invoiceId));
            var user = await _identityService.GetProfile(User);
            var userResponse = new InvoiceResponse.UserReponse
            {
                Name = user.Name,
                Username = user.Username,
                Email = user.Email,
                Phone = user.Phone
            };

            response.User = userResponse;
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
