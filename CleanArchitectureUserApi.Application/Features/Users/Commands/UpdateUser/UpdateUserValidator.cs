using FluentValidation;

namespace CleanArchitectureUserApi.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Nombres)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Apellidos)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Telefono)
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Direccion)
                .NotEmpty();
        }
    }
}
