using System;
using System.Collections.Generic;
using Features.Entidades;

namespace Features.Interfaces
{
	public interface IClienteService : IDisposable
	{
		IEnumerable<Cliente> ObterTodosAtivos();
		void Adicionar(Cliente cliente);
		void Atualizar(Cliente cliente);
		void Remover(Cliente cliente);
		void Inativar(Cliente cliente);
	}
}
