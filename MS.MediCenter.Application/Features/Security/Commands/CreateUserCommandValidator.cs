using FluentValidation;

namespace MS.MediCenter.Application.Features.Security.Commands
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(150).WithMessage("{PropertyName} no dede exceder de {MaxLength} caracteres");

            RuleFor(p => p.Contrasenia)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");

            //RuleFor(p => p.Nombre)
            //    .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
            //    .EmailAddress().WithMessage("{PropertyName} debe ser una dirección de email válida.")
            //    .MaximumLength(150).WithMessage("{PropertyName} no dede exceder de {MaxLength} caracteres");
        }
    }
}
