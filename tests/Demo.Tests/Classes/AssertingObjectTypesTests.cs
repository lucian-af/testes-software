using Demo.Classes;
using Xunit;
using static Demo.Classes.Funcionario;

namespace Demo.Tests
{
	public class AssertingObjectTypesTests
	{
		[Fact(DisplayName = "Deve retornar tipo funcionário")]
		[Trait("Asserts", "Objects")]
		public void FuncionarioFactory_Criar_DeveRetornarTipoFuncionario()
		{
			// Arrange & Act
			var funcionario = FuncionarioFactory.Criar("Lucian", 10000);

			// Assert
			Assert.IsType<Funcionario>(funcionario);
		}

		[Fact(DisplayName = "Deve retornar classe derivada")]
		[Trait("Asserts", "Objects")]
		public void FuncionarioFactory_Criar_DeveRetornarTipoDerivadoPessoa()
		{
			// Arrange & Act
			var funcionario = FuncionarioFactory.Criar("Lucian", 10000);

			// Assert
			Assert.IsAssignableFrom<Pessoa>(funcionario);
		}
	}
}
