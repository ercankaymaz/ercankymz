using System.Collections.Generic;

namespace System.ServiceModel.Channels;

internal class CommunicationObjectManager<ItemType> : LifetimeManager where ItemType : class, ICommunicationObject
{
	private bool _inputClosed;

	private HashSet<ItemType> _table;

	public CommunicationObjectManager(object mutex)
		: base(mutex)
	{
		_table = new HashSet<ItemType>();
	}

	public void Add(ItemType item)
	{
		bool flag = false;
		lock (base.ThisLock)
		{
			if (base.State == LifetimeState.Opened && !_inputClosed)
			{
				if (_table.Contains(item))
				{
					return;
				}
				_table.Add(item);
				base.IncrementBusyCountWithoutLock();
				item.Closed += OnItemClosed;
				flag = true;
			}
		}
		if (!flag)
		{
			item.Abort();
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ObjectDisposedException(GetType().ToString()));
		}
	}

	public void CloseInput()
	{
		_inputClosed = true;
	}

	public void DecrementActivityCount()
	{
		DecrementBusyCount();
	}

	public void IncrementActivityCount()
	{
		IncrementBusyCount();
	}

	private void OnItemClosed(object sender, EventArgs args)
	{
		Remove((ItemType)sender);
	}

	public void Remove(ItemType item)
	{
		lock (base.ThisLock)
		{
			if (!_table.Contains(item))
			{
				return;
			}
			_table.Remove(item);
		}
		item.Closed -= OnItemClosed;
		DecrementBusyCount();
	}

	public ItemType[] ToArray()
	{
		lock (base.ThisLock)
		{
			int num = 0;
			ItemType[] array = new ItemType[_table.Count];
			foreach (ItemType item in _table)
			{
				array[num++] = item;
			}
			return array;
		}
	}
}
