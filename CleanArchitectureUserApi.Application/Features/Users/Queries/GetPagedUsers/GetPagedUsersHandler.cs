using CleanArchitectureUserApi.Application.Abstractions.Persistence;
using CleanArchitectureUserApi.Application.Common.Pagination;
using CleanArchitectureUserApi.Application.Common.Responses;
using CleanArchitectureUserApi.Application.DTOs;
using CleanArchitectureUserApi.Application.Mappings;
using MediatR;

namespace CleanArchitectureUserApi.Application.Features.Users.Queries.GetPagedUsers
{
    public class GetPagedUsersHandler : IRequestHandler<GetPagedUsersQuery, ApiResponse<PagedResult<UserDto>>>
    {
        private readonly IUserRepository _userRepository;
        public GetPagedUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ApiResponse<PagedResult<UserDto>>> Handle(GetPagedUsersQuery request, CancellationToken cancellationToken)
        {
            var (users, totalRecords) =
                await _userRepository.GetPagedAsync(request.PageNumber, request.PageSize, request.Nombre, request.Email);

            var userDtos = users
                                .Select(user => user.ToDto())
                                .ToList();

            var pagedResult = new PagedResult<UserDto>
            {
                Items = userDtos,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalRecords = totalRecords
            };

            return new ApiResponse<PagedResult<UserDto>>(
                true,
                "Usuarios obtenidos correctamente",
                pagedResult);
        }
    }
}
