using CleanArchitectureUserApi.Application.Common.Pagination;
using CleanArchitectureUserApi.Application.Common.Responses;
using CleanArchitectureUserApi.Application.DTOs;
using MediatR;

namespace CleanArchitectureUserApi.Application.Features.Users.Queries.GetPagedUsers
{
    public class GetPagedUsersQuery : IRequest<ApiResponse<PagedResult<UserDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Nombre { get; set; }
        public string? Email { get; set; }
    }
}
