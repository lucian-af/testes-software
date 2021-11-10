using System;
using Features.Entidades;
using Xunit;

namespace Features.Tests.Traits
{
	public class ClienteTests
	{
		[Fact(DisplayName = "Novo Cliente Válido")]
		[Trait("Categoria", "Trait")]
		public void Cliente_NovoCliente_DeveEstarValido()
		{
			// Arrange
			var cliente = new Cliente(
				Guid.NewGuid(),
				"Lucian",
				"AF",
				DateTime.Now.AddYears(-32),
				"teste@teste.com",
				true,
				DateTime.Now);

			// Act
			var result = cliente.EhValido();

			// Assert 
			Assert.True(result);
			Assert.Empty(cliente.ValidationResult.Errors);
		}

		[Fact(DisplayName = "Novo Cliente Inválido")]
		[Trait("Categoria", "Trait")]
		public void Cliente_NovoCliente_DeveEstarInvalido()
		{
			// Arrange
			var cliente = new Cliente(
				Guid.NewGuid(),
				"",
				"",
				DateTime.Now,
				"teste2teste.com",
				true,
				DateTime.Now);

			// Act
			var result = cliente.EhValido();

			// Assert 
			Assert.False(result);
			Assert.NotEmpty(cliente.ValidationResult.Errors);
		}
	}
}
