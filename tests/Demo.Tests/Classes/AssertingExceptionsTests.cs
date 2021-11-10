using System;
using Demo.Classes;
using Xunit;
using static Demo.Classes.Funcionario;

namespace Demo.Tests
{
	public class AssertingExceptionsTests
	{
		[Fact(DisplayName = "Erro de divisão por zero")]
		[Trait("Asserts", "Exceptions")]
		public void Calculadora_Dividir_DeveRetornarErroDivisaoPorZero()
		{
			// Arrange
			var calculadora = new Calculadora();

			// Act & Assert
			Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(10, 0));
		}

		[Fact(DisplayName = "Erro de salário inferior ao permitido")]
		[Trait("Asserts", "Exceptions")]
		public void Funcionario_Salario_DeveRetornarErroSalarioInferiorPermitido()
		{
			// Arrange & Act & Assert
			var exception =
				Assert.Throws<Exception>(() => FuncionarioFactory.Criar("Lucian", 250));

			Assert.Equal("Salario inferior ao permitido", exception.Message);
		}
	}
}
