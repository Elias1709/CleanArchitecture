using CleanArchitectureUserApi.Application.DTOs;
using CleanArchitectureUserApi.Domain.Entities;

namespace CleanArchitectureUserApi.Application.Mappings
{
    public static class UserMappings
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Nombres = user.Nombres,
                Apellidos = user.Apellidos,
                Telefono = user.Telefono,
                Email = user.Email,
                Direccion = user.Direccion,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }
    }
}
