using Xunit;

namespace Features.Tests.Skip
{
	public class TesteNaoPassandoMotivoEspecifico
	{
		[Fact(DisplayName = "Novo Cliente 2.0", Skip = "Nova versão 2.0 quebrando")]
		[Trait("Categoria", "Skip")]
		public void Teste_NaoEstaPassando_VersaoNovaNaoCompativel()
			=> Assert.True(false);
	}
}
