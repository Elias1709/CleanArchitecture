using CleanArchitectureUserApi.Application.Features.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitectureUserApi.Application.Features.Users.Queries.GetUserById;
using CleanArchitectureUserApi.Application.Features.Users.Queries.GetAllUsers;
using CleanArchitectureUserApi.Application.Features.Users.Commands.UpdateUser;
using CleanArchitectureUserApi.Application.Features.Users.Commands.DeleteUser;
using CleanArchitectureUserApi.Application.Features.Users.Queries.GetPagedUsers;
using Azure;

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
        var response = await _mediator.Send(
            new GetUserByIdQuery
            {
                Id = id
            });

        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(
        new GetAllUsersQuery());

        return Ok(response);
    }

    [HttpGet("paged")]
    public async Task<IActionResult> GetPaged([FromQuery] int pageNumber = 1,[FromQuery] int pageSize = 10, [FromQuery] string? nombre = null, [FromQuery] string? email = null)
    {
        var result = await _mediator.Send(
            new GetPagedUsersQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
            Nombre = nombre,
            Email = email
            });

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id,[FromBody] UpdateUserCommand command)
    {
        command.Id = id;

        var response = await _mediator.Send(command);

        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(
        new DeleteUserCommand
        {
            Id = id
        });
        if (!response.Success)
            return NotFound(response);
        return Ok(response);
    }
}
