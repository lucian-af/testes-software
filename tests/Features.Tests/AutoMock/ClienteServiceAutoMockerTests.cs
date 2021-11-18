using System.Linq;
using System.Threading;
using Features.Interfaces;
using Features.Services;
using Features.Tests.DadosHumanos;
using MediatR;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace Features.Tests.AutoMock
{
	[Collection(nameof(ClienteBogusCollection))]
	public class ClienteServiceAutoMockerTests
	{
		private readonly ClienteTestsBogusFixture _clienteTestsBogus;

		public ClienteServiceAutoMockerTests(ClienteTestsBogusFixture clienteTestsFixture)
			=> _clienteTestsBogus = clienteTestsFixture;

		[Fact(DisplayName = "Adicionar Cliente com Sucesso")]
		[Trait("Categoria", "AutoMock")]
		public void ClienteService_Adicionar_DeveExecutarComSucesso()
		{
			// Arrange
			var cliente = _clienteTestsBogus.GerarClienteValido();
			var mocker = new AutoMocker();
			var clienteService = mocker.CreateInstance<ClienteService>();

			// Act
			clienteService.Adicionar(cliente);

			// Assert			
			mocker.GetMock<IClienteRepository>().Verify(r => r.Adicionar(cliente), Times.Once);
			mocker.GetMock<IMediator>().Verify(m => m.Publish(
				   It.IsAny<INotification>(),
					 CancellationToken.None),
					   Times.Once);
		}

		[Fact(DisplayName = "Adicionar Cliente com Falha")]
		[Trait("Categoria", "AutoMock")]
		public void ClienteService_Adicionar_DeveFalharDevidoClienteInvalido()
		{
			// Arrange
			var cliente = _clienteTestsBogus.GerarClienteInvalido();
			var mocker = new AutoMocker();
			var clienteService = mocker.CreateInstance<ClienteService>();

			// Act
			clienteService.Adicionar(cliente);

			// Assert			
			mocker.GetMock<IClienteRepository>().Verify(r => r.Adicionar(cliente), Times.Never);
			mocker.GetMock<IMediator>().Verify(m => m.Publish(
				   It.IsAny<INotification>(),
					 CancellationToken.None),
					   Times.Never);
		}

		[Fact(DisplayName = "Obter Clientes Ativos")]
		[Trait("Categoria", "AutoMock")]
		public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesAtivos()
		{
			// Arrange
			var mocker = new AutoMocker();
			var clienteService = mocker.CreateInstance<ClienteService>();

			mocker.GetMock<IClienteRepository>().Setup(c => c.ObterTodos())
				.Returns(_clienteTestsBogus.GerarClientesAleatorios());

			// Act
			var clientes = clienteService.ObterTodosAtivos();

			// Assert 
			mocker.GetMock<IClienteRepository>().Verify(r => r.ObterTodos(), Times.Once);
			Assert.True(clientes.Any());
			Assert.False(clientes.Count(c => !c.Ativo) > 0);
		}
	}
}
