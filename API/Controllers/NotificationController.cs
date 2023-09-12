using APi.Filters;
using Application.Commands.Notifications.DeleteNotificationCommand;
using Application.Commands.Tasks.DeleteTaskCommand;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public NotificationController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Delete([FromBody] DeleteNotificationRequest request)
        {
            var response = await _mediatr.Send(new DeleteNotificationRequest(request.userId, request.notificationId));
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }
    }
}
