using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Xbim.Common.Exceptions;

namespace Xbim.Common.Collections;

public abstract class ItemSet<T> : IItemSet<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged, IExpressEnumerable, IItemSet, IList, ICollection
{
	protected readonly int Property;

	protected readonly bool IsEntitySet;

	protected IModel Model => OwningEntity.Model;

	public IPersistEntity OwningEntity { get; private set; }

	protected List<T> Internal { get; private set; }

	public int Count => Internal.Count;

	int ICollection<T>.Count => Count;

	bool ICollection<T>.IsReadOnly => ((ICollection<T>)Internal).IsReadOnly;

	int ICollection.Count => Internal.Count;

	bool ICollection.IsSynchronized => ((ICollection)Internal).IsSynchronized;

	object ICollection.SyncRoot => ((ICollection)Internal).SyncRoot;

	public T this[int index]
	{
		get
		{
			return Internal[index];
		}
		set
		{
			if (Model.IsTransactional && Model.CurrentTransaction == null)
			{
				throw new XbimException("Operation out of transaction");
			}
			if (IsEntitySet && value != null && ((IPersistEntity)(object)value).Model != Model)
			{
				throw new XbimException("Cross model entity assignment");
			}
			if (!OwningEntity.Activated)
			{
				Model.Activate(OwningEntity);
			}
			T oldValue = Internal[index];
			Action action = delegate
			{
				Internal[index] = value;
				NotifyCollectionChanged(NotifyCollectionChangedAction.Replace, value);
			};
			if (!Model.IsTransactional)
			{
				action();
				return;
			}
			Action undoAction = delegate
			{
				Internal[index] = oldValue;
				NotifyCollectionChanged(NotifyCollectionChangedAction.Replace, oldValue);
			};
			Model.CurrentTransaction.DoReversibleAction(action, undoAction, OwningEntity, ChangeType.Modified, Property);
		}
	}

	bool IList.IsFixedSize => false;

	bool IList.IsReadOnly
	{
		get
		{
			if (Model.IsTransactional)
			{
				return Model.CurrentTransaction != null;
			}
			return false;
		}
	}

	object IList.this[int index]
	{
		get
		{
			return this[index];
		}
		set
		{
			this[index] = ((value == null) ? default(T) : ((T)value));
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	public event NotifyCollectionChangedEventHandler CollectionChanged;

	protected ItemSet(IPersistEntity entity, int capacity, int property)
	{
		Internal = new List<T>((capacity > 0) ? capacity : 0);
		Property = property;
		OwningEntity = entity;
		IsEntitySet = typeof(IPersistEntity).GetTypeInfo().IsAssignableFrom(typeof(T));
	}

	public T GetAt(int index)
	{
		if (index < Count)
		{
			return this[index];
		}
		if (index > Count)
		{
			throw new Exception("It is not possible to get object which is more that just the next after the last one.");
		}
		if (!typeof(IItemSet).GetTypeInfo().IsAssignableFrom(typeof(T)))
		{
			return default(T);
		}
		T val = CreateNestedSet();
		Insert(index, val);
		return val;
	}

	protected T CreateNestedSet()
	{
		if (!typeof(IItemSet).GetTypeInfo().IsAssignableFrom(typeof(T)))
		{
			throw new NotSupportedException();
		}
		Type genericTypeDefinition = GetType().GetGenericTypeDefinition();
		Type type = typeof(T).GetTypeInfo().GetGenericArguments()[0];
		return (T)Activator.CreateInstance(genericTypeDefinition.MakeGenericType(type), BindingFlags.Instance | BindingFlags.NonPublic, null, new object[3] { OwningEntity, 4, Property }, null);
	}

	public void AddRange(IEnumerable<T> values)
	{
		if (Model.IsTransactional && Model.CurrentTransaction == null)
		{
			throw new XbimException("Operation out of transaction");
		}
		T[] source = (values as T[]) ?? values.ToArray();
		if (IsEntitySet && source.Any((T v) => v != null && ((IPersistEntity)(object)v).Model != Model))
		{
			throw new XbimException("Cross model entity assignment");
		}
		if (!OwningEntity.Activated)
		{
			Model.Activate(OwningEntity);
		}
		T[] items = (values as T[]) ?? source.ToArray();
		Action action = delegate
		{
			Internal.AddRange(items);
			NotifyCollectionChanged(NotifyCollectionChangedAction.Add, items);
			NotifyCountChanged();
		};
		if (!Model.IsTransactional)
		{
			action();
			return;
		}
		Action undoAction = delegate
		{
			T[] array = items;
			foreach (T item in array)
			{
				Internal.Remove(item);
			}
			NotifyCollectionChanged(NotifyCollectionChangedAction.Remove, items);
			NotifyCountChanged();
		};
		Model.CurrentTransaction.DoReversibleAction(action, undoAction, OwningEntity, ChangeType.Modified, Property);
	}

	public T FirstOrDefault(Func<T, bool> predicate)
	{
		return Enumerable.FirstOrDefault(this, predicate);
	}

	public TF FirstOrDefault<TF>(Func<TF, bool> predicate) where TF : T
	{
		return this.OfType<TF>().FirstOrDefault(predicate);
	}

	public IEnumerable<TW> Where<TW>(Func<TW, bool> predicate) where TW : T
	{
		return this.OfType<TW>().Where(predicate);
	}

	private void NotifyCountChanged()
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs("Count"));
		}
	}

	private void NotifyCollectionChanged(NotifyCollectionChangedAction action, T item)
	{
		if (this.CollectionChanged != null)
		{
			this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, item));
		}
	}

	private void NotifyCollectionChanged(NotifyCollectionChangedAction action, IEnumerable<T> items)
	{
		if (this.CollectionChanged != null)
		{
			this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, items));
		}
	}

	private void NotifyCollectionChanged(NotifyCollectionChangedAction action)
	{
		if (this.CollectionChanged != null)
		{
			this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(action));
		}
	}

	public virtual void Add(T item)
	{
		if (Model.IsTransactional && Model.CurrentTransaction == null)
		{
			throw new Exception("Operation out of transaction");
		}
		if (IsEntitySet && item != null && ((IPersistEntity)(object)item).Model != Model)
		{
			throw new XbimException("Cross model entity assignment");
		}
		if (!OwningEntity.Activated)
		{
			Model.Activate(OwningEntity);
		}
		Action action = delegate
		{
			Internal.Add(item);
			NotifyCollectionChanged(NotifyCollectionChangedAction.Add, item);
			NotifyCountChanged();
		};
		if (!Model.IsTransactional)
		{
			action();
			return;
		}
		Action undoAction = delegate
		{
			Internal.Remove(item);
			NotifyCollectionChanged(NotifyCollectionChangedAction.Remove, item);
			NotifyCountChanged();
		};
		Model.CurrentTransaction.DoReversibleAction(action, undoAction, OwningEntity, ChangeType.Modified, Property);
	}

	public virtual void Clear()
	{
		if (Model.IsTransactional && Model.CurrentTransaction == null)
		{
			throw new Exception("Operation out of transaction");
		}
		if (!OwningEntity.Activated)
		{
			Model.Activate(OwningEntity);
		}
		T[] oldItems = Internal.ToArray();
		Action action = delegate
		{
			Internal.Clear();
			NotifyCollectionChanged(NotifyCollectionChangedAction.Reset);
			NotifyCountChanged();
		};
		if (!Model.IsTransactional)
		{
			action();
			return;
		}
		Action undoAction = delegate
		{
			Internal.AddRange(oldItems);
			NotifyCollectionChanged(NotifyCollectionChangedAction.Add, oldItems);
			NotifyCountChanged();
		};
		Model.CurrentTransaction.DoReversibleAction(action, undoAction, OwningEntity, ChangeType.Modified, Property);
	}

	public bool Contains(T item)
	{
		return Internal.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		Internal.CopyTo(array, arrayIndex);
	}

	public virtual bool Remove(T item)
	{
		if (Model.IsTransactional && Model.CurrentTransaction == null)
		{
			throw new Exception("Operation out of transaction");
		}
		if (!OwningEntity.Activated)
		{
			Model.Activate(OwningEntity);
		}
		bool result = false;
		Action action = delegate
		{
			result = Internal.Remove(item);
			NotifyCollectionChanged(NotifyCollectionChangedAction.Remove, item);
			NotifyCountChanged();
		};
		Action undoAction = delegate
		{
			Internal.Add(item);
			NotifyCollectionChanged(NotifyCollectionChangedAction.Add, item);
			NotifyCountChanged();
		};
		if (!Model.IsTransactional)
		{
			action();
			return true;
		}
		Model.CurrentTransaction.DoReversibleAction(action, undoAction, OwningEntity, ChangeType.Modified, Property);
		return result;
	}

	public IEnumerator<T> GetEnumerator()
	{
		if (Internal.Count != 0)
		{
			return Internal.GetEnumerator();
		}
		return Enumerable.Empty<T>().GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		if (Internal.Count != 0)
		{
			return Internal.GetEnumerator();
		}
		return Enumerable.Empty<T>().GetEnumerator();
	}

	void ICollection<T>.Add(T item)
	{
		Add(item);
	}

	void ICollection<T>.Clear()
	{
		Clear();
	}

	bool ICollection<T>.Contains(T item)
	{
		return Internal.Contains(item);
	}

	void ICollection<T>.CopyTo(T[] array, int arrayIndex)
	{
		Internal.CopyTo(array, arrayIndex);
	}

	bool ICollection<T>.Remove(T item)
	{
		return Remove(item);
	}

	void ICollection.CopyTo(Array array, int index)
	{
		CopyTo((T[])array, index);
	}

	public int IndexOf(T item)
	{
		return Internal.IndexOf(item);
	}

	public void Insert(int index, T item)
	{
		if (Model.IsTransactional && Model.CurrentTransaction == null)
		{
			throw new XbimException("Operation out of transaction");
		}
		if (IsEntitySet && item != null && ((IPersistEntity)(object)item).Model != Model)
		{
			throw new XbimException("Cross model entity assignment");
		}
		if (!OwningEntity.Activated)
		{
			Model.Activate(OwningEntity);
		}
		Action action = delegate
		{
			Internal.Insert(index, item);
			NotifyCollectionChanged(NotifyCollectionChangedAction.Add, item);
			NotifyCountChanged();
		};
		if (!Model.IsTransactional)
		{
			action();
			return;
		}
		Action undoAction = delegate
		{
			Internal.RemoveAt(index);
			NotifyCollectionChanged(NotifyCollectionChangedAction.Remove, item);
			NotifyCountChanged();
		};
		Model.CurrentTransaction.DoReversibleAction(action, undoAction, OwningEntity, ChangeType.Modified, Property);
	}

	public void RemoveAt(int index)
	{
		T item = Internal[index];
		Remove(item);
	}

	int IList.Add(object value)
	{
		if (!(value is T item))
		{
			return -1;
		}
		Add(item);
		return Internal.Count - 1;
	}

	bool IList.Contains(object value)
	{
		return ((IList)Internal).Contains(value);
	}

	int IList.IndexOf(object value)
	{
		return ((IList)Internal).IndexOf(value);
	}

	void IList.Insert(int index, object value)
	{
		Insert(index, (T)value);
	}

	void IList.Remove(object value)
	{
		Remove((T)value);
	}
}
