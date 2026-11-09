using CleanArchitectureUserApi.Application.Abstractions.Persistence;
using CleanArchitectureUserApi.Application.Common.Responses;
using MediatR;

namespace CleanArchitectureUserApi.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ApiResponse<bool>>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApiResponse<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository
                .GetByIdAsync(request.Id);

            if (user is null)
            {
                return new ApiResponse<bool>(
                    false,
                    "Usuario no encontrado",
                    false);
            }

            await _userRepository.DeleteAsync(user);

            return new ApiResponse<bool>(
                true,
                "Usuario eliminado correctamente",
                true);
        }
    }
}
