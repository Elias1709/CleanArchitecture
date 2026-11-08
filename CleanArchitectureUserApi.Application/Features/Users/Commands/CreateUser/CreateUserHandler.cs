using CleanArchitectureUserApi.Application.Abstractions.Persistence;
using CleanArchitectureUserApi.Domain.Entities;
using MediatR;

namespace CleanArchitectureUserApi.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(
                request.Nombres,
                request.Apellidos,
                request.Telefono,
                request.Email,
                request.Direccion);

            await _userRepository.AddAsync(user);

            return user.Id;
        }
    }
}
