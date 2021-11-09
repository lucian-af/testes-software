using Demo.Classes;
using Xunit;

namespace Demo.Tests.Classes
{
	public class CalculadoraTests
	{
		[Fact]
		public void Calculadora_Somar_RetornarValorSoma()
		{
			// Arrange
			var calculadora = new Calculadora();

			// Act
			var resultado = calculadora.Somar(4, 2);

			// Assert
			Assert.Equal(6, resultado);
		}

		[Theory]
		[InlineData(1, 1, 2)]
		[InlineData(2, 2, 4)]
		[InlineData(4, 4, 8)]
		[InlineData(7.5, 8, 15.5)]
		[InlineData(16, 16, 32)]
		[InlineData(32, 32, 64)]
		public void Calculadora_Somar_RetornarValoresSomaCorretos(double v1, double v2, double total)
		{
			// Arrange
			var calculadora = new Calculadora();

			// Act
			var resultado = calculadora.Somar(v1, v2);

			// Assert
			Assert.Equal(total, resultado);
		}
	}
}
