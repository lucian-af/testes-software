using NerdStore.BDD.Tests.Config;
using TechTalk.SpecFlow;
using Xunit;

namespace NerdStore.BDD.Tests.Pedido
{
	[Collection(nameof(AutomacaoWebFixtureCollection))]
	[Binding]
	public class Pedido_AdicionarItemAoCarrinhoSteps
	{
		private readonly AutomacaoWebTestsFixture _automacaoWebFixture;

		public Pedido_AdicionarItemAoCarrinhoSteps(AutomacaoWebTestsFixture automacaoWebFixture)
			=> _automacaoWebFixture = automacaoWebFixture;

		[Given(@"Que um produto esteja na vitrine")]
		public void DadoQueUmProdutoEstejaNaVitrine()
		{
			// Arrange
			var browser = _automacaoWebFixture.BrowserHelper;
			browser.IrParaUrl("https://www.uol.com.br");

			// Act

			//Assert
		}

		[Given(@"Esteja disponivel no estoque")]
		public void DadoEstejaDisponivelNoEstoque()
		{
			// Arrange // Act //Assert
		}

		[Given(@"O usuario esteja logado")]
		public void DadoOUsuarioEstejaLogado()
		{
			// Arrange // Act //Assert
		}

		[Given(@"O mesmo produto já tenha sido adicionado ao carrinho anteriormente")]
		public void DadoOMesmoProdutoJaTenhaSidoAdicionadoAoCarrinhoAnteriormente()
		{
			// Arrange // Act //Assert
		}

		[When(@"O usuário adicionar uma unidade ao carrinho")]
		public void QuandoOUsuarioAdicionarUmaUnidadeAoCarrinho()
		{
			// Arrange // Act //Assert
		}

		[When(@"O usuário adicionar um item acima da quantidade máxima permitida")]
		public void QuandoOUsuarioAdicionarUmItemAcimaDaQuantidadeMaximaPermitida()
		{
			// Arrange // Act //Assert
		}

		[When(@"O usuário adicionar a quantidade máxima permitida ao carrinho")]
		public void QuandoOUsuarioAdicionarAQuantidadeMaximaPermitidaAoCarrinho()
		{
			// Arrange // Act //Assert
		}

		[Then(@"O usuário será redirecionado ao resumo da compra")]
		public void EntaoOUsuarioSeraRedirecionadoAoResumoDaCompra()
		{
			// Arrange // Act //Assert
		}

		[Then(@"O valor total do pedido será exatamente o valor do item adicionado")]
		public void EntaoOValorTotalDoPedidoSeraExatamenteOValorDoItemAdicionado()
		{
			// Arrange // Act //Assert
		}

		[Then(@"Receberá uma mensagem de erro mencionando que foi ultrapassada a quantidade limite")]
		public void EntaoReceberaUmaMensagemDeErroMencionandoQueFoiUltrapassadaAQuantidadeLimite()
		{
			// Arrange // Act //Assert
		}

		[Then(@"A quantidade de itens daquele produto terá sido acrescida em uma unidade a mais")]
		public void EntaoAQuantidadeDeItensDaqueleProdutoTeraSidoAcrescidaEmUmaUnidadeAMais()
		{
			// Arrange // Act //Assert
		}

		[Then(@"O valor total do pedido será a multiplicação da quantidade de itens pelo valor unitario")]
		public void EntaoOValorTotalDoPedidoSeraAMultiplicacaoDaQuantidadeDeItensPeloValorUnitario()
		{
			// Arrange // Act //Assert
		}
	}
}
