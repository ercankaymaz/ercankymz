using System;
using Xbim.Common;

namespace Xbim.IO.Esent;

public class XbimReadTransaction : ITransaction, IDisposable
{
	private bool _disposed;

	protected bool InTransaction;

	protected EsentModel Model;

	private EsentReadOnlyTransaction _readTransaction;

	string ITransaction.Name => "";

	public event EntityChangedHandler EntityChanged;

	public event EntityChangingHandler EntityChanging;

	protected XbimReadTransaction()
	{
	}

	internal XbimReadTransaction(EsentModel theModel, EsentReadOnlyTransaction txn)
	{
		Model = theModel;
		_readTransaction = txn;
		InTransaction = true;
	}

	protected virtual void Dispose(bool disposing)
	{
		if (_disposed)
		{
			return;
		}
		if (disposing)
		{
			try
			{
				if (InTransaction)
				{
					_readTransaction.Dispose();
				}
			}
			finally
			{
				Model.EndTransaction();
			}
		}
		_disposed = true;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	void ITransaction.Commit()
	{
		throw new Exception("This is a read-only transaction so you can't commit anything.");
	}

	void ITransaction.RollBack()
	{
		throw new Exception("This is a read-only transaction so you can't commit anything.");
	}

	void ITransaction.DoReversibleAction(Action doAction, Action undoAction, IPersistEntity entity, ChangeType changeType, int property)
	{
		throw new Exception("This is a read-only transaction so you can't commit anything.");
	}

	protected virtual void OnEntityChanged(IPersistEntity entity, ChangeType change, int property)
	{
		this.EntityChanged?.Invoke(entity, change, property);
	}

	protected virtual void OnEntityChanging(IPersistEntity entity, ChangeType change, int property)
	{
		this.EntityChanging?.Invoke(entity, change, property);
	}
}
