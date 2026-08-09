using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Xbim.Common;

namespace Xbim.Presentation;

public class EntitySelection : INotifyCollectionChanged, IEnumerable<IPersistEntity>, IEnumerable
{
	private enum Action
	{
		Add,
		Remove
	}

	private struct SelectionEvent
	{
		public Action Action;

		public IEnumerable<IPersistEntity> Entities;
	}

	private readonly List<SelectionEvent> _selectionLog;

	private readonly XbimIPersistEntityCollection<IPersistEntity> _selection = new XbimIPersistEntityCollection<IPersistEntity>();

	private int _position = -1;

	public event NotifyCollectionChangedEventHandler CollectionChanged;

	public EntitySelection(bool keepLogging = false)
	{
		if (keepLogging)
		{
			_selectionLog = new List<SelectionEvent>();
		}
	}

	public void Undo()
	{
		if (_selectionLog != null && _position >= 0)
		{
			RollBack(_selectionLog[_position]);
			_position--;
		}
	}

	public void Redo()
	{
		int position = _position;
		List<SelectionEvent> selectionLog = _selectionLog;
		if (position < ((selectionLog != null) ? new int?(selectionLog.Count - 1) : ((int?)null)))
		{
			_position++;
			RollForward(_selectionLog[_position]);
		}
	}

	private void RollBack(SelectionEvent e)
	{
		switch (e.Action)
		{
		case Action.Add:
			RemoveRange(e.Entities);
			break;
		case Action.Remove:
			AddRange(e.Entities);
			break;
		}
	}

	private void RollForward(SelectionEvent e)
	{
		switch (e.Action)
		{
		case Action.Add:
			AddRange(e.Entities);
			break;
		case Action.Remove:
			RemoveRange(e.Entities);
			break;
		}
	}

	public IEnumerable<IPersistEntity> SetRange(IEnumerable<IPersistEntity> entities)
	{
		Clear();
		return AddRange(entities);
	}

	public IEnumerable<IPersistEntity> AddRange(IEnumerable<IPersistEntity> entities)
	{
		List<IPersistEntity> list = new List<IPersistEntity>();
		foreach (IPersistEntity entity in entities)
		{
			if (!_selection.Contains(entity))
			{
				_selection.Add(entity);
				list.Add(entity);
			}
		}
		OnCollectionChanged(NotifyCollectionChangedAction.Add, list);
		return list;
	}

	private IEnumerable<IPersistEntity> RemoveRange(IEnumerable<IPersistEntity> entities)
	{
		List<IPersistEntity> list = new List<IPersistEntity>();
		foreach (IPersistEntity entity in entities)
		{
			if (_selection.Contains(entity))
			{
				list.Add(entity);
				_selection.Remove(entity);
			}
		}
		OnCollectionChanged(NotifyCollectionChangedAction.Remove, list);
		return list;
	}

	public void Add(IPersistEntity entity)
	{
		if (entity != null)
		{
			Add(new IPersistEntity[1] { entity });
		}
	}

	public void Add(IEnumerable<IPersistEntity> entity)
	{
		IEnumerable<IPersistEntity> entities = AddRange(entity);
		if (_selectionLog != null)
		{
			_selectionLog.Add(new SelectionEvent
			{
				Action = Action.Add,
				Entities = entities
			});
			ResetLog();
		}
	}

	public void Remove(IPersistEntity entity)
	{
		Remove(new IPersistEntity[1] { entity });
	}

	public void Remove(IEnumerable<IPersistEntity> entity)
	{
		if (entity != null)
		{
			IEnumerable<IPersistEntity> entities = RemoveRange(entity);
			if (_selectionLog != null)
			{
				_selectionLog.Add(new SelectionEvent
				{
					Action = Action.Remove,
					Entities = entities
				});
				ResetLog();
			}
		}
	}

	private void ResetLog()
	{
		if (_position == _selectionLog.Count - 2)
		{
			_position = _selectionLog.Count - 1;
		}
		if (_position < _selectionLog.Count - 2)
		{
			_selectionLog.RemoveRange(_position + 1, _selectionLog.Count - 2);
			_position = _selectionLog.Count - 1;
		}
	}

	private void OnCollectionChanged(NotifyCollectionChangedAction action, IList entities)
	{
		if (action != NotifyCollectionChangedAction.Add && action != NotifyCollectionChangedAction.Remove)
		{
			throw new ArgumentException("Only Add and Remove operations are supported");
		}
		this.CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, entities));
	}

	public IEnumerator<IPersistEntity> GetEnumerator()
	{
		return _selection.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public bool Toggle(IPersistEntity item)
	{
		if (_selection.Contains(item))
		{
			Remove(item);
			return false;
		}
		Add(item);
		return true;
	}

	public void Clear()
	{
		IPersistEntity[] array = new IPersistEntity[_selection.Count];
		_selection.CopyTo(array, 0);
		RemoveRange(array);
	}
}
