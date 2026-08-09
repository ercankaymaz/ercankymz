using System;
using System.Collections.Generic;
using System.Linq;

namespace Xbim.Common.Delta;

public class TransactionLog : IDisposable
{
	private ITransaction _transaction;

	private readonly Dictionary<int, EntityChange> _log = new Dictionary<int, EntityChange>();

	public IEnumerable<EntityChange> Changes => _log.Values.Where((EntityChange v) => !v.IsNewDeleted);

	public TransactionLog(ITransaction transaction)
	{
		if (transaction == null)
		{
			throw new ArgumentNullException("transaction");
		}
		_transaction = transaction;
		_transaction.EntityChanging += EntityChanging;
		_transaction.EntityChanged += EntityChanged;
	}

	private void EntityChanged(IPersistEntity entity, ChangeType change, int property)
	{
		_log[entity.EntityLabel].AddChanged(change, property);
	}

	private void EntityChanging(IPersistEntity entity, ChangeType change, int property)
	{
		if (!_log.TryGetValue(entity.EntityLabel, out var value))
		{
			value = new EntityChange(entity);
			_log.Add(entity.EntityLabel, value);
		}
		value.AddChanging(change, property);
	}

	public void Dispose()
	{
		if (_transaction != null)
		{
			_transaction.EntityChanged -= EntityChanged;
			_transaction.EntityChanging -= EntityChanging;
			_transaction = null;
		}
	}
}
