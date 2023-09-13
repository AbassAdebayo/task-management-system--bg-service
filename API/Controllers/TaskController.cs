using APi.Filters;
using Application.Commands.Tasks.AssignTaskToProjectCommand;
using Application.Commands.Tasks.CreateTaskCommand;
using Application.Commands.Tasks.DeleteTaskCommand;
using Application.Commands.Tasks.UpdateTaskCommand;
using Application.Models;
using Application.Queries.Tasks;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public TaskController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Create([FromBody] CreateTaskRequest request)
        {
            var response = await _mediatr.Send(new CreateTaskRequest(request.tittle, request.userId, request.description, request.dueDate, request.priority, request.status));
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpPost("AssignTaskToProjectRequest")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(BaseResponse))]
        public async Task<IActionResult> AssignTaskToProject([FromBody] AssignTaskToProjectRequest request)
        {
            var response = await _mediatr.Send(new AssignTaskToProjectRequest(request.taskId, request.projectId));
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpGet("ListTasksDueWithin48Hours")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(BaseResponse))]
        public async Task<IActionResult> ListTasksDueWithin48Hours([FromBody] ListTasksDueWithin48HoursQuery request)
        {
            var response = await _mediatr.Send(request);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Update([FromBody] UpdateTaskRequest request)
        {
            var response = await _mediatr.Send(new UpdateTaskRequest(request.taskId,request.tittle, request.userId, request.description, request.dueDate, request.priority, request.status));
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Delete([FromBody] DeleteTaskRequest request)
        {
            var response = await _mediatr.Send(new DeleteTaskRequest(request.userId, request.taskId));
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }
    }
}
