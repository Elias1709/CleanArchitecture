using CleanArchitectureUserApi.Application.Features.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitectureUserApi.Application.Features.Users.Queries.GetUserById;
using CleanArchitectureUserApi.Application.Features.Users.Queries.GetAllUsers;
using CleanArchitectureUserApi.Application.Features.Users.Commands.UpdateUser;
using CleanArchitectureUserApi.Application.Features.Users.Commands.DeleteUser;
using CleanArchitectureUserApi.Application.Features.Users.Queries.GetPagedUsers;

namespace CleanArchitectureUserApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateUserCommand command)
    {
        var userId = await _mediator.Send(command);

        return Ok(userId);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _mediator.Send(
            new GetUserByIdQuery
            {
                Id = id
            });

        if (user is null)
            return NotFound();

        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _mediator.Send(
            new GetAllUsersQuery());

        return Ok(users);
    }

    [HttpGet("paged")]
    public async Task<IActionResult> GetPaged([FromQuery] int pageNumber = 1,[FromQuery] int pageSize = 10)
    {
        var result = await _mediator.Send(
            new GetPagedUsersQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            });

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id,[FromBody] UpdateUserCommand command)
    {
        command.Id = id;

        var updated = await _mediator.Send(command);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _mediator.Send(
            new DeleteUserCommand
            {
                Id = id
            });

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
