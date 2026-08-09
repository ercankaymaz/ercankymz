using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.ServiceModel;

public sealed class ExtensionCollection<T> : SynchronizedCollection<IExtension<T>>, IExtensionCollection<T>, ICollection<IExtension<T>>, IEnumerable<IExtension<T>>, IEnumerable where T : IExtensibleObject<T>
{
	private T _owner;

	bool ICollection<IExtension<T>>.IsReadOnly => false;

	public ExtensionCollection(T owner)
	{
		if (owner == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("owner");
		}
		_owner = owner;
	}

	public ExtensionCollection(T owner, object syncRoot)
		: base(syncRoot)
	{
		if (owner == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("owner");
		}
		_owner = owner;
	}

	protected override void ClearItems()
	{
		lock (base.SyncRoot)
		{
			IExtension<T>[] array = new IExtension<T>[base.Count];
			CopyTo(array, 0);
			base.ClearItems();
			IExtension<T>[] array2 = array;
			foreach (IExtension<T> extension in array2)
			{
				extension.Detach(_owner);
			}
		}
	}

	public E Find<E>()
	{
		List<IExtension<T>> items = base.Items;
		lock (base.SyncRoot)
		{
			for (int num = base.Count - 1; num >= 0; num--)
			{
				IExtension<T> extension = items[num];
				if (extension is E)
				{
					return (E)extension;
				}
			}
		}
		return default(E);
	}

	public Collection<E> FindAll<E>()
	{
		Collection<E> collection = new Collection<E>();
		List<IExtension<T>> items = base.Items;
		lock (base.SyncRoot)
		{
			for (int i = 0; i < items.Count; i++)
			{
				IExtension<T> extension = items[i];
				if (extension is E)
				{
					collection.Add((E)extension);
				}
			}
			return collection;
		}
	}

	protected override void InsertItem(int index, IExtension<T> item)
	{
		if (item == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("item");
		}
		lock (base.SyncRoot)
		{
			item.Attach(_owner);
			base.InsertItem(index, item);
		}
	}

	protected override void RemoveItem(int index)
	{
		lock (base.SyncRoot)
		{
			base.Items[index].Detach(_owner);
			base.RemoveItem(index);
		}
	}

	protected override void SetItem(int index, IExtension<T> item)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.SFxCannotSetExtensionsByIndex));
	}
}
