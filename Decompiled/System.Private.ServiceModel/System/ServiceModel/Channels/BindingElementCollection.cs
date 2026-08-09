using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace System.ServiceModel.Channels;

public class BindingElementCollection : Collection<BindingElement>
{
	public BindingElementCollection()
	{
	}

	public BindingElementCollection(IEnumerable<BindingElement> elements)
	{
		if (elements == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("elements");
		}
		foreach (BindingElement element in elements)
		{
			Add(element);
		}
	}

	public BindingElementCollection(BindingElement[] elements)
	{
		if (elements == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("elements");
		}
		for (int i = 0; i < elements.Length; i++)
		{
			Add(elements[i]);
		}
	}

	public BindingElementCollection Clone()
	{
		BindingElementCollection bindingElementCollection = new BindingElementCollection();
		for (int i = 0; i < base.Count; i++)
		{
			bindingElementCollection.Add(base[i].Clone());
		}
		return bindingElementCollection;
	}

	public void AddRange(params BindingElement[] elements)
	{
		if (elements == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("elements");
		}
		for (int i = 0; i < elements.Length; i++)
		{
			Add(elements[i]);
		}
	}

	public bool Contains(Type bindingElementType)
	{
		if (bindingElementType == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("bindingElementType");
		}
		for (int i = 0; i < base.Count; i++)
		{
			if (bindingElementType.GetTypeInfo().IsAssignableFrom(base[i].GetType().GetTypeInfo()))
			{
				return true;
			}
		}
		return false;
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
			if (base[i] is T)
			{
				T result = (T)(object)base[i];
				if (remove)
				{
					RemoveAt(i);
				}
				return result;
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
		for (int i = 0; i < base.Count; i++)
		{
			if (base[i] is T)
			{
				T item = (T)(object)base[i];
				if (remove)
				{
					RemoveAt(i);
					i--;
				}
				collection.Add(item);
			}
		}
		return collection;
	}

	protected override void InsertItem(int index, BindingElement item)
	{
		if (item == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("item");
		}
		base.InsertItem(index, item);
	}

	protected override void SetItem(int index, BindingElement item)
	{
		if (item == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("item");
		}
		base.SetItem(index, item);
	}
}
