using FluentValidation;

namespace CleanArchitectureUserApi.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Nombres)
                .NotEmpty()
                .WithMessage("Los nombres son obligatorios.")
                .MaximumLength(100);

            RuleFor(x => x.Apellidos)
                .NotEmpty()
                .WithMessage("Los apellidos son obligatorios.")
                .MaximumLength(100);

            RuleFor(x => x.Telefono)
                .NotEmpty()
                .WithMessage("El teléfono es obligatorio.")
                .MaximumLength(20);

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("El email es obligatorio.")
                .EmailAddress()
                .WithMessage("El formato del email es inválido.");

            RuleFor(x => x.Direccion)
                .NotEmpty()
                .WithMessage("La dirección es obligatoria.")
                .MaximumLength(200);
        }
    }
}
