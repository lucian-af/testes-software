using System;
using Features.Entidades;
using Xunit;

namespace Features.Tests.Fixtures
{
	[CollectionDefinition(nameof(ClienteCollection))]
	public class ClienteCollection : ICollectionFixture<ClienteTestsFixture> { }

	public class ClienteTestsFixture : IDisposable
	{
		public Cliente GerarClienteValido()
		{
			var cliente = new Cliente(
				Guid.NewGuid(),
				"Lucian",
				"AF",
				DateTime.Now.AddYears(-32),
				"teste@teste.com",
				true,
				DateTime.Now);

			return cliente;
		}

		public Cliente GerarClienteInValido()
		{
			var cliente = new Cliente(
				Guid.NewGuid(),
				"",
				"",
				DateTime.Now,
				"teste2.com",
				true,
				DateTime.Now);

			return cliente;
		}

		public void Dispose() { }
	}
}
