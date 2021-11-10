using System.Text.RegularExpressions;
using Demo.Classes;
using Xunit;

namespace Demo.Tests
{
	public class AssertStringsTests
	{
		[Fact(DisplayName = "Retornar nome completo")]
		[Trait("Asserts", "Strings")]
		public void StringsTools_UnirNomes_RetornarNomeCompleto()
		{
			// Arrange
			var sut = new StringsTools();

			// Act
			var nomeCompleto = sut.Unir("Lucian", "AF");

			// Assert
			Assert.Equal("Lucian AF", nomeCompleto);
		}

		[Fact(DisplayName = "Ignorar letras maísculas e minúsculas")]
		[Trait("Asserts", "Strings")]
		public void StringsTools_UnirNomes_DeveIgnorarCase()
		{
			// Arrange
			var sut = new StringsTools();

			// Act
			var nomeCompleto = sut.Unir("Lucian", "AF");

			// Assert
			Assert.Equal("LuCiAn AF", nomeCompleto, true);
		}

		[Fact(DisplayName = "Deve conter parte do texto")]
		[Trait("Asserts", "Strings")]
		public void StringsTools_UnirNomes_DeveConterTrecho()
		{
			// Arrange
			var sut = new StringsTools();

			// Act
			var nomeCompleto = sut.Unir("Lucian", "AF");

			// Assert
			Assert.Contains("uci", nomeCompleto);
		}

		[Fact(DisplayName = "Deve começar com parte do texto")]
		[Trait("Asserts", "Strings")]
		public void StringsTools_UnirNomes_DeveComecarCom()
		{
			// Arrange
			var sut = new StringsTools();

			// Act
			var nomeCompleto = sut.Unir("Lucian", "AF");

			// Assert
			Assert.StartsWith("Lu", nomeCompleto);
		}

		[Fact(DisplayName = "Deve terminar com parte do texto")]
		[Trait("Asserts", "Strings")]
		public void StringsTools_UnirNomes_DeveAcabarCom()
		{
			// Arrange
			var sut = new StringsTools();

			// Act
			var nomeCompleto = sut.Unir("Lucian", "AF");

			// Assert
			Assert.EndsWith("AF", nomeCompleto);
		}

		[Fact(DisplayName = "Validar por expressão regular")]
		[Trait("Asserts", "Strings")]
		public void StringsTools_UnirNomes_ValidarExpressaoRegular()
		{
			// Arrange
			var sut = new StringsTools();

			// Act
			var nomeCompleto = sut.Unir("Lucian", "AF");

			// Assert
			Assert.Matches(new Regex("[A-Z]{1}[a-z]+ [A-Z]{2}"), nomeCompleto);
		}
	}
}
