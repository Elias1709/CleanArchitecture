using CleanArchitectureUserApi.Application.Abstractions.Persistence;
using MediatR;

namespace CleanArchitectureUserApi.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user is null)
                return false;

            user.Update(
                request.Nombres,
                request.Apellidos,
                request.Telefono,
                request.Email,
                request.Direccion);

            await _userRepository.UpdateAsync(user);

            return true;
        }
    }
}
