using System;
using Features.Entidades;
using FluentValidation;

namespace Features.Validations
{
	public class ClienteValidacao : AbstractValidator<Cliente>
	{
		public ClienteValidacao()
		{
			RuleFor(c => c.Nome)
				.NotEmpty().WithMessage("O Nome do cliente é obrigatório.")
				.Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres.");

			RuleFor(c => c.Sobrenome)
				.NotEmpty().WithMessage("O Sobrenome do cliente é obrigatório.")
				.Length(2, 150).WithMessage("O Sobrenome deve ter entre 2 e 150 caracteres.");

			RuleFor(c => c.DataNascimento)
				.NotEmpty()
				.Must(HaveMinimumAge)
				.WithMessage("O Cliente deve ter 18 anos ou mais");

			RuleFor(c => c.Email)
				.NotEmpty()
				.EmailAddress();

			RuleFor(c => c.Id)
				.NotEqual(Guid.Empty);
		}

		public static bool HaveMinimumAge(DateTime birthDate)
			=> birthDate <= DateTime.Now.AddYears(-18);
	}
}
