using APi.Filters;
using Application.Commands.Projects.CreateProjectCommand;
using Application.Commands.Projects.DeleteProjectCommand;
using Application.Commands.Projects.RemoveTaskFromProjectCommand;
using Application.Commands.Projects.UpdateProjectCommand;
using Application.Models;
using Application.Queries.Projects.ListProjectTasksQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public ProjectController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost("create-project")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Create([FromBody] CreateProjectRequest request)
        {
            var response = await _mediatr.Send(new CreateProjectRequest(request.userId, request.name, request.description));
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }


        [HttpPut("update-project")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Update([FromBody] UpdateProjectRequest request)
        {
            var response = await _mediatr.Send(new UpdateProjectRequest(request.projectId, request.userId, request.name, request.description));
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(BaseResponse))]
        public async Task<IActionResult> Delete([FromBody] DeleteProjectRequest request)
        {
            var response = await _mediatr.Send(new DeleteProjectRequest(request.userId, request.projectId));
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("remove-task-from-project")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(BaseResponse))]
        public async Task<IActionResult> RemoveTaskFromProject([FromBody] RemoveTaskFromProjectRequest request)
        {
            var response = await _mediatr.Send(new RemoveTaskFromProjectRequest(request.projectId, request.taskId));
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("get-all-project-tasks")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized, Type = typeof(BaseResponse))]
        public async Task<IActionResult> GetAllProjectTasks([FromBody] ListProjectTasksRequest request)
        {
            var response = await _mediatr.Send(request);
            return response.Succeeded ? Ok(response) : BadRequest(response);
        }
    }
}
