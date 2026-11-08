using CleanArchitectureUserApi.Application.DTOs;
using MediatR;

namespace CleanArchitectureUserApi.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserDto?>
    {
        public Guid Id { get; set; }
    }
}
