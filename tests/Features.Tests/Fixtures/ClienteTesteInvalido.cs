using Features.Tests.Fixtures;
using Xunit;

namespace Features.Tests.Fixtures
{
	[Collection(nameof(ClienteCollection))]
	public class ClienteTesteInvalido
	{
		private readonly ClienteTestsFixture _clienteTestsFixture;

		public ClienteTesteInvalido(ClienteTestsFixture clienteTestsFixture) => _clienteTestsFixture = clienteTestsFixture;

		[Fact(DisplayName = "Novo Cliente Inválido")]
		[Trait("Categoria", "Fixture")]
		public void Cliente_NovoCliente_DeveEstarInvalido()
		{
			// Arrange
			var cliente = _clienteTestsFixture.GerarClienteInValido();

			// Act
			var result = cliente.EhValido();

			// Assert 
			Assert.False(result);
			Assert.NotEmpty(cliente.ValidationResult.Errors);
		}
	}
}
