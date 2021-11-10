using Features.Core.Interfaces;
using Features.Entidades;

namespace Features.Interfaces
{
	public interface IClienteRepository : IRepository<Cliente>
	{
		Cliente ObterPorEmail(string email);
	}
}
