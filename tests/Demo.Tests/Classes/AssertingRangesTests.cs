using Demo.Classes;
using Demo.Classes.Enums;
using Xunit;

namespace Demo.Tests
{
	public class AssertingRangesTests
	{
		[Theory(DisplayName = "Faixa salarial por nível de profissional")]
		[Trait("Asserts", "Ranges")]
		[InlineData(700)]
		[InlineData(1500)]
		[InlineData(2000)]
		[InlineData(7500)]
		[InlineData(8000)]
		[InlineData(15000)]
		public void Funcionario_Salario_FaixasSalariaisDevemRespeitarNivelProfissional(decimal salario)
		{
			// Arrange & Act
			var funcionario = new Funcionario("Lucian", salario);

			// Assert
			if (funcionario.NivelProfissional == NivelProfissional.Junior)
				Assert.InRange(funcionario.Salario, 500, 1999);

			if (funcionario.NivelProfissional == NivelProfissional.Pleno)
				Assert.InRange(funcionario.Salario, 2000, 7999);

			if (funcionario.NivelProfissional == NivelProfissional.Senior)
				Assert.InRange(funcionario.Salario, 8000, decimal.MaxValue);

			Assert.NotInRange(funcionario.Salario, 0, 499);
		}
	}
}
