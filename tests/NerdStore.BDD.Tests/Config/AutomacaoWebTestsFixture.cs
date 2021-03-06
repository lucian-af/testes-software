using Xunit;

namespace NerdStore.BDD.Tests.Config
{
	[CollectionDefinition(nameof(AutomacaoWebFixtureCollection))]
	public class AutomacaoWebFixtureCollection : ICollectionFixture<AutomacaoWebTestsFixture> { }

	public class AutomacaoWebTestsFixture
	{
		public SeleniumHelper BrowserHelper;
		public readonly ConfigurationHelper Configuration;

		public AutomacaoWebTestsFixture()
		{
			Configuration = new ConfigurationHelper();
			BrowserHelper = new SeleniumHelper(Browser.Edge, Configuration);
		}
	}
}
