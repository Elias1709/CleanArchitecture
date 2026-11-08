using CleanArchitectureUserApi.Application.Abstractions.Persistence;
using CleanArchitectureUserApi.Application.DTOs;
using MediatR;

namespace CleanArchitectureUserApi.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(user => new UserDto
            {
                Id = user.Id,
                Nombres = user.Nombres,
                Apellidos = user.Apellidos,
                Telefono = user.Telefono,
                Email = user.Email,
                Direccion = user.Direccion,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            }).ToList();
        }
    }
}
