using Demo.Classes;
using Xunit;

namespace Demo.Tests.Classes
{
	public class AssertNumbersTests
	{
		[Fact]
		public void Calculadora_Somar_DeveSerIgual()
		{
			// Arrange
			var calculadora = new Calculadora();

			// Act
			var result = calculadora.Somar(1, 2);

			// Assert
			Assert.Equal(3, result);
		}

		[Fact]
		public void Calculadora_Somar_NaoDeveSerIgual()
		{
			// Arrange
			var calculadora = new Calculadora();

			// Act
			var result = calculadora.Somar(1.13123123123m, 2.2312313123m);

			// Assert
			Assert.NotEqual(3.3m, result, 1);
		}
	}
}
