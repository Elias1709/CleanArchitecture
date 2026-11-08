using CleanArchitectureUserApi.Application.DTOs;
using MediatR;

namespace CleanArchitectureUserApi.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserDto>>
    {
    }
}
