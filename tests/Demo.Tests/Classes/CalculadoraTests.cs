using Demo.Classes;
using Xunit;

namespace Demo.Tests.Classes
{
	public class CalculadoraTests
	{
		[Fact(DisplayName = "Retornar valor somado")]
		[Trait("Calculadora", "Operações")]
		public void Calculadora_Somar_RetornarValorSoma()
		{
			// Arrange
			var calculadora = new Calculadora();

			// Act
			var resultado = calculadora.Somar(4, 2);

			// Assert
			Assert.Equal(6, resultado);
		}

		[Theory(DisplayName = "Comparar soma de uma lista de valores")]
		[Trait("Calculadora", "Operações")]
		[InlineData(1, 1, 2)]
		[InlineData(2, 2, 4)]
		[InlineData(4, 4, 8)]
		[InlineData(7.5, 8, 15.5)]
		[InlineData(16, 16, 32)]
		[InlineData(32, 32, 64)]
		public void Calculadora_Somar_RetornarValoresSomaCorretos(decimal v1, decimal v2, decimal total)
		{
			// Arrange
			var calculadora = new Calculadora();

			// Act
			var resultado = calculadora.Somar(v1, v2);

			// Assert
			Assert.Equal(total, resultado);
		}

		[Fact(DisplayName = "Retornar valor subtraído")]
		[Trait("Calculadora", "Operações")]
		public void Calculadora_Subtrair_RetornarValorSubtraido()
		{
			// Arrange
			var calculadora = new Calculadora();

			// Act
			var resultado = calculadora.Subtrair(4, 2);

			// Assert
			Assert.Equal(2, resultado);
		}

		[Theory(DisplayName = "Comparar subtração de uma lista de valores")]
		[Trait("Calculadora", "Operações")]
		[InlineData(1, 1, 0)]
		[InlineData(2, 1, 1)]
		[InlineData(3, 4, -1)]
		[InlineData(7.5, 8, -.5)]
		[InlineData(100, 47, 53)]
		[InlineData(101, 473, -372)]
		public void Calculadora_Somar_RetornarValoresSubtracaoCorretos(decimal v1, decimal v2, decimal total)
		{
			// Arrange
			var calculadora = new Calculadora();

			// Act
			var resultado = calculadora.Subtrair(v1, v2);

			// Assert
			Assert.Equal(total, resultado);
		}
	}
}
