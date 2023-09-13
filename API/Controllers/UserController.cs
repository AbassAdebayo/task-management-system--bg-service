using APi.Filters;
using Application.Commands.Users.CreateUserCommand;
using Application.Commands.Users.DeleteUserCommand;
using Application.Commands.Users.UpdateUserCommand;
using Application.Models;
using Application.Queries.Users.GetUserByEmailQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public UserController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand request)
        {
            var response = await _mediatr.Send(request);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request)
        {
            var response = await _mediatr.Send(new UpdateUserRequest(request.name, request.email));
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Delete([FromBody] DeleteUserRequest request)
        {
            var response = await _mediatr.Send(new DeleteUserRequest(request.email));
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Get([FromBody] GetUserByMailRequest request)
        {
            var response = await _mediatr.Send(new GetUserByMailRequest(request.email));
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }
    }
}
