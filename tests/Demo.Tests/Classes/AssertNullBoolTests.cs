using Demo.Classes;
using Xunit;

namespace Demo.Tests
{
	public class AssertNullBoolTests
	{
		[Fact(DisplayName = "N?o deve ser nulo ou vazio")]
		[Trait("Asserts", "Booleanos")]
		public void Funcionario_Nome_NaoDeveSerNuloOuVazio()
		{
			// Arrange & Act
			var funcionario = new Funcionario("", 1000);

			// Assert
			Assert.False(string.IsNullOrEmpty(funcionario.Nome));
		}

		[Fact(DisplayName = "N?o deve retorar valor")]
		[Trait("Asserts", "Booleanos")]
		public void Funcionario_Apelido_NaoDeveTerApelido()
		{
			// Arrange & Act
			var funcionario = new Funcionario("Lucian", 1000);

			// Assert
			Assert.Null(funcionario.Apelido);

			// Assert Bool
			Assert.True(string.IsNullOrEmpty(funcionario.Apelido));
			Assert.False(funcionario.Apelido?.Length > 0);
		}
	}
}
