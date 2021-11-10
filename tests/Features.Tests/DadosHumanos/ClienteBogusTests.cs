using Xunit;

namespace Features.Tests.DadosHumanos
{
	[Collection(nameof(ClienteBogusCollection))]
	public class ClienteBogusTests
	{
		private readonly ClienteTestsBogusFixture _clienteTestsFixture;

		public ClienteBogusTests(ClienteTestsBogusFixture clienteTestsFixture) => _clienteTestsFixture = clienteTestsFixture;


		[Fact(DisplayName = "Novo Cliente Válido")]
		[Trait("Categoria", "Bogus")]
		public void Cliente_NovoCliente_DeveEstarValido()
		{
			// Arrange
			var cliente = _clienteTestsFixture.GerarClienteValido();

			// Act
			var result = cliente.EhValido();

			// Assert 
			Assert.True(result);
			Assert.Equal(0, cliente.ValidationResult.Errors.Count);
		}

		[Fact(DisplayName = "Novo Cliente Inválido")]
		[Trait("Categoria", "Bogus")]
		public void Cliente_NovoCliente_DeveEstarInvalido()
		{
			// Arrange
			var cliente = _clienteTestsFixture.GerarClienteInvalido();

			// Act
			var result = cliente.EhValido();

			// Assert 
			Assert.False(result);
			Assert.NotEqual(0, cliente.ValidationResult.Errors.Count);
		}
	}
}
