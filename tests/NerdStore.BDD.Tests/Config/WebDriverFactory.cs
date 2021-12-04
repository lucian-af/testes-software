using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace NerdStore.BDD.Tests.Config
{
	public static class WebDriverFactory
	{
		/// <summary>
		/// Cria um drive para uso nos testes
		/// </summary>
		/// <param name="browser">navegador a ser usado para os testes</param>
		/// <param name="caminhoDriver">caminho onde está o driver para uso</param>
		/// <param name="headless">Define se vai abrir o browser, navegar por ele sem visualizar a janela</param>
		/// <returns></returns>
		public static IWebDriver CreateWebDriver(Browser browser, string caminhoDriver, bool headless)
		{
			IWebDriver webDriver = null;

			switch (browser)
			{
				case Browser.Firefox:
					var optionsFireFox = new FirefoxOptions();
					if (headless)
						optionsFireFox.AddArgument("--headless");

					webDriver = new FirefoxDriver(caminhoDriver, optionsFireFox);

					break;
				case Browser.Chrome:
					var optionsChrome = new ChromeOptions();
					if (headless)
						optionsChrome.AddArgument("--headless");

					webDriver = new ChromeDriver(caminhoDriver, optionsChrome);

					break;
				case Browser.Edge:
					var optionsEdge = new EdgeOptions();
					if (headless)
						optionsEdge.AddArgument("--headless");

					webDriver = new EdgeDriver(caminhoDriver, optionsEdge);

					break;
			}

			return webDriver;
		}
	}
}

