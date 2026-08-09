using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.IO.Esent;

public class XbimReadWriteTransaction : XbimReadTransaction, ITransaction, IDisposable
{
	private EsentLazyDBTransaction _readWriteTransaction;

	private int _pulseCount;

	private int _transactionBatchSize;

	private readonly List<Action> _undoActions = new List<Action>();

	public int TransactionBatchSize
	{
		get
		{
			return _transactionBatchSize;
		}
		set
		{
			_transactionBatchSize = value;
		}
	}

	public string Name { get; protected set; }

	string ITransaction.Name => Name;

	internal XbimReadWriteTransaction(EsentModel model, EsentLazyDBTransaction txn, string name = null)
	{
		Name = name;
		Model = model;
		_readWriteTransaction = txn;
		InTransaction = true;
		_pulseCount = 0;
		_transactionBatchSize = 100;
	}

	public int Pulse()
	{
		Interlocked.Increment(ref _pulseCount);
		if ((long)(_pulseCount % _transactionBatchSize) == _transactionBatchSize - 1)
		{
			Commit();
			Begin();
		}
		return _pulseCount;
	}

	public void Commit()
	{
		try
		{
			Model.Flush();
			_readWriteTransaction.Commit();
			Model.CurrentTransaction = null;
		}
		finally
		{
			InTransaction = false;
		}
	}

	public void Begin()
	{
		try
		{
			_readWriteTransaction.Begin();
			Model.CurrentTransaction = this;
		}
		finally
		{
			InTransaction = true;
		}
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (InTransaction)
			{
				((ITransaction)this).RollBack();
				_readWriteTransaction.Dispose();
			}
			_undoActions.Clear();
		}
		finally
		{
			InTransaction = false;
			base.Dispose(disposing);
		}
	}

	public IEnumerable<IInstantiableEntity> Modified()
	{
		return Model.Cache.Modified().OfType<IInstantiableEntity>();
	}

	void ITransaction.Commit()
	{
		Commit();
	}

	void ITransaction.RollBack()
	{
		try
		{
			for (int num = _undoActions.Count - 1; num >= 0; num--)
			{
				_undoActions[num]();
			}
			if (InTransaction)
			{
				_readWriteTransaction.RollBack();
			}
			InTransaction = false;
			Model.CurrentTransaction = null;
		}
		catch (Exception inner)
		{
			throw new XbimException("It wasn't possible to roll back transaction '" + Name + "'. Model is inconsistent now.", inner);
		}
	}

	void ITransaction.DoReversibleAction(Action doAction, Action undoAction, IPersistEntity entity, ChangeType changeType, int property)
	{
		OnEntityChanging(entity, changeType, property);
		doAction();
		_undoActions.Add(undoAction);
		OnEntityChanged(entity, changeType, property);
		Model.HandleEntityChange(changeType, entity, property);
	}
}
