using FluentValidation;
using Vendr.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vendr.Service.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioDto>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Objeto não encontrado.");
                });

            RuleFor(c => c.email)
                .NotEmpty().WithMessage("Necessário informar o campo e-mail.")
                .NotNull().WithMessage("Necessário informar o campo e-mail.");

        }
    }
}
