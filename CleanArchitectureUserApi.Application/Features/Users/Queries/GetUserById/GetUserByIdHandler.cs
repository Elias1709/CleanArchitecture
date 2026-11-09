using CleanArchitectureUserApi.Application.Abstractions.Persistence;
using CleanArchitectureUserApi.Application.Common.Responses;
using CleanArchitectureUserApi.Application.DTOs;
using CleanArchitectureUserApi.Application.Mappings;
using MediatR;

namespace CleanArchitectureUserApi.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ApiResponse<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ApiResponse<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user is null)
            {
                return new ApiResponse<UserDto>(
                    false,
                    "Usuario no encontrado",
                    null);
            }

            return new ApiResponse<UserDto>(
                true,
                "Usuario obtenido correctamente",
                user.ToDto());
        }
    }
}
