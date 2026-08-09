using System.Collections.ObjectModel;
using System.ServiceModel;

namespace System.Collections.Generic;

public class KeyedByTypeCollection<TItem> : KeyedCollection<Type, TItem>
{
	public KeyedByTypeCollection()
		: base((IEqualityComparer<Type>?)null, 4)
	{
	}

	public KeyedByTypeCollection(IEnumerable<TItem> items)
		: base((IEqualityComparer<Type>?)null, 4)
	{
		if (items == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("items");
		}
		foreach (TItem item in items)
		{
			Add(item);
		}
	}

	public T Find<T>()
	{
		return Find<T>(remove: false);
	}

	public T Remove<T>()
	{
		return Find<T>(remove: true);
	}

	private T Find<T>(bool remove)
	{
		for (int i = 0; i < base.Count; i++)
		{
			TItem val = base[i];
			if (val is T)
			{
				if (remove)
				{
					Remove(val);
				}
				return (T)(object)val;
			}
		}
		return default(T);
	}

	public Collection<T> FindAll<T>()
	{
		return FindAll<T>(remove: false);
	}

	public Collection<T> RemoveAll<T>()
	{
		return FindAll<T>(remove: true);
	}

	private Collection<T> FindAll<T>(bool remove)
	{
		Collection<T> collection = new Collection<T>();
		using (IEnumerator<TItem> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				TItem current = enumerator.Current;
				if (current is T)
				{
					collection.Add((T)(object)current);
				}
			}
		}
		if (remove)
		{
			foreach (T item in collection)
			{
				Remove((TItem)(object)item);
			}
		}
		return collection;
	}

	protected override Type GetKeyForItem(TItem item)
	{
		if (item == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("item");
		}
		return item.GetType();
	}

	protected override void InsertItem(int index, TItem item)
	{
		if (item == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("item");
		}
		if (Contains(item.GetType()))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("item", System.SR.Format(System.SR.DuplicateBehavior1, item.GetType().FullName));
		}
		base.InsertItem(index, item);
	}

	protected override void SetItem(int index, TItem item)
	{
		if (item == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("item");
		}
		base.SetItem(index, item);
	}
}
