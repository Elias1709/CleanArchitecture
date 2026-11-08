using MediatR;

namespace CleanArchitectureUserApi.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public string Nombres { get; set; } = string.Empty;

        public string Apellidos { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Direccion { get; set; } = string.Empty;
    }
}
