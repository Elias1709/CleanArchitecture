using CleanArchitectureUserApi.Application.Abstractions.Persistence;
using CleanArchitectureUserApi.Application.Common.Responses;
using CleanArchitectureUserApi.Application.DTOs;
using CleanArchitectureUserApi.Application.Mappings;
using MediatR;

namespace CleanArchitectureUserApi.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler< GetAllUsersQuery, ApiResponse<List<UserDto>>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ApiResponse<List<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            var usersDto = users
        .Select(user => user.ToDto())
        .ToList();

            return new ApiResponse<List<UserDto>>(
                true,
                "Usuarios obtenidos correctamente",
                usersDto);
        }
    }
}
