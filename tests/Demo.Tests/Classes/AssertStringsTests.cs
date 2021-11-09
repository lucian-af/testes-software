using System.Text.RegularExpressions;
using Demo.Classes;
using Xunit;

namespace Demo.Tests
{
	public class AssertStringsTests
	{
		[Fact]
		public void StringsTools_UnirNomes_RetornarNomeCompleto()
		{
			// Arrange
			var sut = new StringsTools();

			// Act
			var nomeCompleto = sut.Unir("Lucian", "AF");

			// Assert
			Assert.Equal("Lucian AF", nomeCompleto);
		}

		[Fact]
		public void StringsTools_UnirNomes_DeveIgnorarCase()
		{
			// Arrange
			var sut = new StringsTools();

			// Act
			var nomeCompleto = sut.Unir("Lucian", "AF");

			// Assert
			Assert.Equal("LuCiAn AF", nomeCompleto, true);
		}

		[Fact]
		public void StringsTools_UnirNomes_DeveConterTrecho()
		{
			// Arrange
			var sut = new StringsTools();

			// Act
			var nomeCompleto = sut.Unir("Lucian", "AF");

			// Assert
			Assert.Contains("uci", nomeCompleto);
		}

		[Fact]
		public void StringsTools_UnirNomes_DeveComecarCom()
		{
			// Arrange
			var sut = new StringsTools();

			// Act
			var nomeCompleto = sut.Unir("Lucian", "AF");

			// Assert
			Assert.StartsWith("Lu", nomeCompleto);
		}

		[Fact]
		public void StringsTools_UnirNomes_DeveAcabarCom()
		{
			// Arrange
			var sut = new StringsTools();

			// Act
			var nomeCompleto = sut.Unir("Lucian", "AF");

			// Assert
			Assert.EndsWith("AF", nomeCompleto);
		}

		[Fact]
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
