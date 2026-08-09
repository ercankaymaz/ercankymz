using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Xbim.Common.Exceptions;

namespace Xbim.Common.Federation;

public class ReferencedModelCollection : KeyedCollection<string, IReferencedModel>, INotifyCollectionChanged, INotifyPropertyChanged
{
	private static readonly PropertyChangedEventArgs CountPropChangedEventArgs = new PropertyChangedEventArgs("Count");

	private event NotifyCollectionChangedEventHandler _collectionChanged;

	public event NotifyCollectionChangedEventHandler CollectionChanged
	{
		add
		{
			_collectionChanged += value;
		}
		remove
		{
			_collectionChanged -= value;
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected override string GetKeyForItem(IReferencedModel item)
	{
		return item.Identifier;
	}

	public string NextIdentifer()
	{
		for (short num = 1; num < short.MaxValue; num++)
		{
			if (!Contains(num.ToString()))
			{
				return num.ToString();
			}
		}
		throw new XbimException("Too many Reference Models added");
	}

	protected override void InsertItem(int index, IReferencedModel item)
	{
		IReferencedModel changedItem = null;
		if (index < base.Count)
		{
			changedItem = base[index];
		}
		base.InsertItem(index, item);
		NotifyCollectionChangedEventHandler notifyCollectionChangedEventHandler = this._collectionChanged;
		if (notifyCollectionChangedEventHandler != null)
		{
			if (index == base.Count)
			{
				notifyCollectionChangedEventHandler(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, changedItem, index));
				return;
			}
			notifyCollectionChangedEventHandler(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
			NotifyCountChanged(base.Count - 1);
		}
	}

	protected override void RemoveItem(int index)
	{
		int count = base.Count;
		IReferencedModel changedItem = base[index];
		base.RemoveItem(index);
		this._collectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, changedItem, index));
		NotifyCountChanged(count);
	}

	protected override void ClearItems()
	{
		int count = base.Count;
		base.ClearItems();
		this._collectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		NotifyCountChanged(count);
	}

	protected override void SetItem(int index, IReferencedModel item)
	{
		IReferencedModel changedItem = null;
		if (index < base.Count)
		{
			changedItem = base[index];
		}
		base.SetItem(index, item);
		this._collectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, changedItem, index));
	}

	private void NotifyCountChanged(int oldValue)
	{
		if (this.PropertyChanged != null && oldValue != base.Count)
		{
			this.PropertyChanged(this, CountPropChangedEventArgs);
		}
	}
}
