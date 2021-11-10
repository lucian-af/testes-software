using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Features.Core.DomainObjects;

namespace Features.Core.Interfaces
{
	public interface IRepository<TEntity> : IDisposable where TEntity : Entity
	{
		void Adicionar(TEntity obj);
		TEntity ObterPorId(Guid id);
		IEnumerable<TEntity> ObterTodos();
		void Atualizar(TEntity obj);
		void Remover(Guid id);
		IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
		int Commit();
	}
}
