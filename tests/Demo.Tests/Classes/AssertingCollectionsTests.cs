using Xunit;
using static Demo.Classes.Funcionario;

namespace Demo.Tests
{
	public class AssertingCollectionsTests
	{
		[Fact(DisplayName = "Não Possuir Habilidades Vazias")]
		[Trait("Asserts", "Collections")]
		public void Funcionario_Habilidades_NaoDevePossuirHabilidadesVazias()
		{
			// Arrange & Act
			var funcionario = FuncionarioFactory.Criar("Lucian", 10000);

			// Assert
			Assert.All(funcionario.Habilidades, habilidade => Assert.False(string.IsNullOrWhiteSpace(habilidade)));
		}

		[Fact(DisplayName = "Não Possuir Habilidades Básicas")]
		[Trait("Asserts", "Collections")]
		public void Funcionario_Habilidades_JuniorDevePossuirHabilidadeBasica()
		{
			// Arrange & Act
			var funcionario = FuncionarioFactory.Criar("Lucian", 1000);

			// Assert
			Assert.Contains("OOP", funcionario.Habilidades);
		}

		[Fact(DisplayName = "Não Possuir Habilidades Avançadas")]
		[Trait("Asserts", "Collections")]
		public void Funcionario_Habilidades_JuniorNaoDevePossuirHabilidadeAvancada()
		{
			// Arrange & Act
			var funcionario = FuncionarioFactory.Criar("Lucian", 1000);

			// Assert
			Assert.DoesNotContain("Microservices", funcionario.Habilidades);
		}

		[Fact(DisplayName = "Possuir Todas Habilidades")]
		[Trait("Asserts", "Collections")]
		public void Funcionario_Habilidades_SeniorDevePossuirTodasHabilidades()
		{
			// Arrange & Act
			var funcionario = FuncionarioFactory.Criar("Lucian", 15000);

			var habilidadesBasicas = new[]
			{
				"Lógica de Programação",
				"OOP",
				"Testes",
				"Microservices"
			};

			// Assert
			Assert.Equal(habilidadesBasicas, funcionario.Habilidades);
		}
	}
}
