using Xunit;

namespace Features.Tests.Order
{
	/// <summary>
	/// Não é recomendado o uso de ordenação em testes de unidade
	/// Se a necessidade for por dependência de algum outro teste, o fluxo não está correto
	/// Testes de Unidade não devem possuir dependências de métodos entre si
	/// </summary>
	[TestCaseOrderer("Features.Tests.Order.PriorityOrderer", "Features.Tests")]
	public class OrdemTestes
	{
		public static bool Teste1Chamado;
		public static bool Teste2Chamado;
		public static bool Teste3Chamado;
		public static bool Teste4Chamado;

		[Fact(DisplayName = "Teste 04"), TestPriority(3)]
		[Trait("Categoria", "Order")]
		public void Teste04()
		{
			Teste4Chamado = true;

			Assert.True(Teste3Chamado);
			Assert.True(Teste1Chamado);
			Assert.False(Teste2Chamado);
		}

		[Fact(DisplayName = "Teste 01"), TestPriority(2)]
		[Trait("Categoria", "Order")]
		public void Teste01()
		{
			Teste1Chamado = true;

			Assert.True(Teste3Chamado);
			Assert.False(Teste4Chamado);
			Assert.False(Teste2Chamado);
		}

		[Fact(DisplayName = "Teste 03"), TestPriority(1)]
		[Trait("Categoria", "Order")]
		public void Teste03()
		{
			Teste3Chamado = true;

			Assert.False(Teste1Chamado);
			Assert.False(Teste2Chamado);
			Assert.False(Teste4Chamado);
		}

		[Fact(DisplayName = "Teste 02"), TestPriority(4)]
		[Trait("Categoria", "Order")]
		public void Teste02()
		{
			Teste2Chamado = true;

			Assert.True(Teste3Chamado);
			Assert.True(Teste4Chamado);
			Assert.True(Teste1Chamado);
		}
	}
}
