using System;
using System.Text.RegularExpressions;
using NerdStore.BDD.Tests.Config;

namespace NerdStore.BDD.Tests.Pedido
{
	public class PedidoTela : PageObjectModel
	{
		public PedidoTela(SeleniumHelper helper) : base(helper) { }

		public void AcessarVitrineDeProdutos()
			=> Helper.IrParaUrl(Helper.Configuration.VitrineUrl);

		public void ObterDetalhesDoProduto(int posicao = 1)
			=> Helper.ClicarPorXPath($"html/body/div/main/div/div/div[{posicao}]/span/a");

		public bool ValidarProdutoDisponivel()
			=> Helper.ValidarConteudoUrl(Helper.Configuration.ProdutoUrl);

		public int ObterQuantidadeNoEstoque()
		{
			var elemento = Helper.ObterElementoPorXPath("/html/body/div/main/div/div/div[2]/p[1]");
			var quantidade = elemento.Text.ApenasNumeros();

			if (char.IsNumber(quantidade.ToString(), 0)) return quantidade;

			return 0;
		}

		public void ClicarEmComprarAgora()
			=> Helper.ClicarPorXPath("/html/body/div/main/div/div/div[2]/form/div[2]/button");

		public bool ValidarSeEstaNoCarrinhoDeCompras()
			=> Helper.ValidarConteudoUrl(Helper.Configuration.CarrinhoUrl);

		public decimal ObterValorUnitarioProdutoCarrinho()
		{
			var input = Helper.ObterTextoElementoPorId("valorUnitario");
			var valorUnitario = new Regex(@"^[a-zA-Z]{1}[\W]{1}[\s]").Replace(input, "").Trim();
			return Convert.ToDecimal(valorUnitario);
		}

		public decimal ObterValorTotalCarrinho()
		{
			var input = Helper.ObterTextoElementoPorId("valorTotalCarrinho");
			var valorTotalCarrinho = new Regex(@"^[a-zA-Z]{1}[\W]{1}[\s]").Replace(input, "").Trim();
			return Convert.ToDecimal(valorTotalCarrinho);
		}

		public void ClicarAdicionarQuantidadeItens(int quantidade)
		{
			var botaoAdicionar = Helper.ObterElementoPorClasse("btn-plus");
			if (botaoAdicionar == null) return;

			for (var i = 1; i < quantidade; i++)
			{
				botaoAdicionar.Click();
			}
		}

		public string ObterMensagemDeErroProduto()
			=> Helper.ObterTextoElementoPorClasseCss("alert-danger");

		public void NavegarParaCarrinhoDeCompras()
			=> Helper.ObterElementoPorXPath("/html/body/header/nav/div/div/ul/li[2]/a").Click();

		public string ObterIdPrimeiroProdutoCarrinho()
			=> Helper.ObterElementoPorXPath("/html/body/div/main/div/div/div/table/tbody/tr[1]/td[1]/div/div/h4/a")
				.GetAttribute("href");

		public void GarantirQueOPrimeiroItemDaVitrineEstejaAdicionado()
		{
			NavegarParaCarrinhoDeCompras();
			if (ObterValorTotalCarrinho() > 0) return;

			AcessarVitrineDeProdutos();
			ObterDetalhesDoProduto();
			ClicarEmComprarAgora();
		}

		public int ObterQuantidadeDeItensPrimeiroProdutoCarrinho()
			=> Convert.ToInt32(Helper.ObterValorTextBoxPorId("quantidade"));

		public void VoltarNavegacao(int vezes = 1)
			=> Helper.VoltarNavegacao(vezes);

		public void ZerarCarrinhoDeCompras()
		{
			while (ObterValorTotalCarrinho() > 0)
			{
				Helper.ClicarPorXPath("/html/body/div/main/div/div/div/table/tbody/tr[1]/td[5]/form/button");
			}
		}
	}
}
