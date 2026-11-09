using CleanArchitectureUserApi.Application.Common.Responses;
using MediatR;

namespace CleanArchitectureUserApi.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<ApiResponse<bool>>
    {
        public Guid Id { get; set; }
    }
}
