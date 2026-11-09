using CleanArchitectureUserApi.Application.Abstractions.Persistence;
using CleanArchitectureUserApi.Application.Common.Pagination;
using CleanArchitectureUserApi.Application.DTOs;
using MediatR;

namespace CleanArchitectureUserApi.Application.Features.Users.Queries.GetPagedUsers
{
    public class GetPagedUsersHandler : IRequestHandler<GetPagedUsersQuery,PagedResult<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        public GetPagedUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<PagedResult<UserDto>> Handle(GetPagedUsersQuery request, CancellationToken cancellationToken)
        {
            var (users, totalRecords) =
                await _userRepository.GetPagedAsync(request.PageNumber, request.PageSize, request.Nombre, request.Email);

            var userDtos = users.Select(user =>
                new UserDto
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

            return new PagedResult<UserDto>
            {
                Items = userDtos,

                PageNumber = request.PageNumber,

                PageSize = request.PageSize,

                TotalRecords = totalRecords
            };
        }
    }
}
