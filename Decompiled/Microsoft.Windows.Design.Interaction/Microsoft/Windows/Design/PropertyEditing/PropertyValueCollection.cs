using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Microsoft.Windows.Design.PropertyEditing;

public abstract class PropertyValueCollection : IEnumerable<PropertyValue>, IEnumerable, INotifyCollectionChanged
{
	private PropertyValue _parentValue;

	public PropertyValue ParentValue => _parentValue;

	public abstract PropertyValue this[int index] { get; }

	public abstract int Count { get; }

	public event NotifyCollectionChangedEventHandler CollectionChanged;

	protected PropertyValueCollection(PropertyValue parentValue)
	{
		if (parentValue == null)
		{
			throw new ArgumentNullException("parentValue");
		}
		_parentValue = parentValue;
	}

	public abstract PropertyValue Add(object value);

	public abstract PropertyValue Insert(object value, int index);

	public abstract bool Remove(PropertyValue propertyValue);

	public abstract void RemoveAt(int index);

	public abstract void SetIndex(int currentIndex, int newIndex);

	public abstract IEnumerator<PropertyValue> GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		if (this.CollectionChanged != null)
		{
			this.CollectionChanged(this, e ?? new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}
	}
}
