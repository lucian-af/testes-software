using System.Linq;
using System.Threading;
using Features.Interfaces;
using Features.Services;
using Features.Tests.DadosHumanos;
using MediatR;
using Moq;
using Xunit;

namespace Features.Tests.Mock
{
	[Collection(nameof(ClienteBogusCollection))]
	public class ClienteServiceTests
	{
		private readonly ClienteTestsBogusFixture _clienteTestsBogus;

		public ClienteServiceTests(ClienteTestsBogusFixture clienteTestsFixture)
			=> _clienteTestsBogus = clienteTestsFixture;

		[Fact(DisplayName = "Adicionar Cliente com Sucesso")]
		[Trait("Categoria", "Mock")]
		public void ClienteService_Adicionar_DeveExecutarComSucesso()
		{
			// Arrange
			var cliente = _clienteTestsBogus.GerarClienteValido();
			var clienteRepo = new Mock<IClienteRepository>();
			var mediatr = new Mock<IMediator>();

			var clienteService = new ClienteService(clienteRepo.Object, mediatr.Object);

			// Act
			clienteService.Adicionar(cliente);

			// Assert			
			clienteRepo.Verify(r => r.Adicionar(cliente), Times.Once);
			mediatr.Verify(m => m.Publish(
				   It.IsAny<INotification>(),
					 CancellationToken.None),
					   Times.Once);
		}

		[Fact(DisplayName = "Adicionar Cliente com Falha")]
		[Trait("Categoria", "Mock")]
		public void ClienteService_Adicionar_DeveFalharDevidoClienteInvalido()
		{
			// Arrange
			var cliente = _clienteTestsBogus.GerarClienteInvalido();
			var clienteRepo = new Mock<IClienteRepository>();
			var mediatr = new Mock<IMediator>();

			var clienteService = new ClienteService(clienteRepo.Object, mediatr.Object);

			// Act
			clienteService.Adicionar(cliente);

			// Assert			
			clienteRepo.Verify(r => r.Adicionar(cliente), Times.Never);
			mediatr.Verify(m => m.Publish(
				   It.IsAny<INotification>(),
					 CancellationToken.None),
					   Times.Never);
		}

		[Fact(DisplayName = "Obter Clientes Ativos")]
		[Trait("Categoria", "Mock")]
		public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesAtivos()
		{
			// Arrange
			var clienteRepo = new Mock<IClienteRepository>();
			var mediatr = new Mock<IMediator>();

			clienteRepo.Setup(c => c.ObterTodos())
				.Returns(_clienteTestsBogus.GerarClientesAleatorios());

			var clienteService = new ClienteService(clienteRepo.Object, mediatr.Object);

			// Act
			var clientes = clienteService.ObterTodosAtivos();

			// Assert 
			clienteRepo.Verify(r => r.ObterTodos(), Times.Once);
			Assert.True(clientes.Any());
			Assert.False(clientes.Count(c => !c.Ativo) > 0);
		}
	}
}
