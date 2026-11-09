using CleanArchitectureUserApi.Application.Abstractions.Persistence;
using CleanArchitectureUserApi.Application.Common.Responses;
using MediatR;

namespace CleanArchitectureUserApi.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand,ApiResponse<bool>>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ApiResponse<bool>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user is null)
            {
                return new ApiResponse<bool>(
                    false,
                    "Usuario no encontrado",
                    false);
            }

            user.Update(
                request.Nombres,
                request.Apellidos,
                request.Telefono,
                request.Email,
                request.Direccion);

            await _userRepository.UpdateAsync(user);

            return new ApiResponse<bool>(
                true,
                "Usuario actualizado correctamente",
                true);
        }
    }
}
