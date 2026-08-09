using System;
using System.Collections.Generic;
using System.Linq;

namespace Xbim.Common.Model;

internal class Transaction : ITransaction, IDisposable
{
	private class Change
	{
		public Action DoAction { get; private set; }

		public Action UndoAction { get; private set; }

		public Change(Action doAction, Action undoAction)
		{
			DoAction = doAction;
			UndoAction = undoAction;
		}
	}

	private readonly StepModel _model;

	private bool _closed;

	private bool _undone;

	private readonly List<Change> _log = new List<Change>();

	public string Name { get; set; }

	public event EntityChangedHandler EntityChanged;

	public event EntityChangingHandler EntityChanging;

	public Transaction(StepModel model, string name)
	{
		Name = name;
		_model = model;
	}

	public Transaction(StepModel model)
	{
		_model = model;
	}

	public void Commit()
	{
		if (_closed)
		{
			throw new Exception("Transaction closed already");
		}
		Finish();
	}

	public void RollBack()
	{
		if (_closed)
		{
			throw new Exception("Transaction is closed already");
		}
		for (int num = _log.Count - 1; num >= 0; num--)
		{
			_log[num].UndoAction();
		}
		Finish();
	}

	public void DoReversibleAction(Action doAction, Action undoAction, IPersistEntity entity, ChangeType changeType, int propertyOrder)
	{
		if (_closed)
		{
			throw new Exception("Transaction is closed already");
		}
		OnEntityChanging(entity, changeType, propertyOrder);
		doAction();
		_log.Add(new Change(doAction, undoAction));
		OnEntityChanged(entity, changeType, propertyOrder);
		_model.HandleEntityChange(changeType, entity, propertyOrder);
	}

	public void DoReversibleAction(Action doAction, Action undoAction, IPersistEntity[] entities, ChangeType changeType, int propertyOrder)
	{
		if (_closed)
		{
			throw new Exception("Transaction is closed already");
		}
		IPersistEntity[] array = entities;
		foreach (IPersistEntity entity in array)
		{
			OnEntityChanging(entity, changeType, propertyOrder);
		}
		doAction();
		_log.Add(new Change(doAction, undoAction));
		array = entities;
		foreach (IPersistEntity entity2 in array)
		{
			OnEntityChanged(entity2, changeType, propertyOrder);
			_model.HandleEntityChange(changeType, entity2, propertyOrder);
		}
	}

	private void Finish()
	{
		if (_closed)
		{
			throw new Exception("Transaction closed already");
		}
		_log.Clear();
		_model.CurrentTransaction = null;
		_closed = true;
	}

	public void Undo()
	{
		if (!_closed)
		{
			throw new Exception("Transaction is not closed yet. You can only undo closed transaction.");
		}
		if (!_undone)
		{
			for (int num = _log.Count - 1; num >= 0; num--)
			{
				_log[num].UndoAction();
			}
			_undone = true;
		}
	}

	public void Redo()
	{
		if (!_closed)
		{
			throw new Exception("Transaction is not closed yet. You can only undo closed transaction.");
		}
		if (!_undone)
		{
			return;
		}
		foreach (Action item in _log.Select((Change c) => c.DoAction))
		{
			item();
		}
		_undone = false;
	}

	public void Dispose()
	{
		if (!_closed)
		{
			RollBack();
		}
		_log.Clear();
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
