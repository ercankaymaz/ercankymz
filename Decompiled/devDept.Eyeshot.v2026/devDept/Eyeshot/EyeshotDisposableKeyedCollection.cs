using System;
using System.Collections.Generic;

namespace devDept.Eyeshot;

[Serializable]
public abstract class EyeshotDisposableKeyedCollection<T> : EyeshotKeyedCollection<T> where T : IKeyedCollectionDisposableItem<T>
{
	protected bool DisposeItems => base.Document != null;

	protected EyeshotDisposableKeyedCollection()
	{
	}

	protected EyeshotDisposableKeyedCollection(IEqualityComparer<string> comparer)
		: base(comparer)
	{
	}

	protected EyeshotDisposableKeyedCollection(IEqualityComparer<string> comparer, int dictionaryCreationThreshold)
		: base(comparer, dictionaryCreationThreshold)
	{
	}

	protected EyeshotDisposableKeyedCollection(IEnumerable<T> collection, IEqualityComparer<string> comparer)
		: base(collection, comparer)
	{
	}

	private void _0023_003DzEOJRE3lJRPC4()
	{
		if (_0023_003Dzo60vEkkaRGxX() != null && _0023_003Dzo60vEkkaRGxX().IsRenderingContextValid())
		{
			_0023_003Dzo60vEkkaRGxX().RenderContext.MakeCurrent();
		}
	}

	internal void _0023_003DzhM3qURBkRYYd()
	{
		if (!DisposeItems)
		{
			return;
		}
		using IEnumerator<T> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			enumerator.Current.Dispose();
		}
	}

	protected override void SetItem(int index, T item)
	{
		_0023_003Dzj49Ii94_003D(index);
		base.SetItem(index, item);
	}

	protected override void RemoveItem(int index)
	{
		_0023_003Dzj49Ii94_003D(index);
		base.RemoveItem(index);
	}

	protected void DisposeItem(T item)
	{
		if (DisposeItems)
		{
			_0023_003DzEOJRE3lJRPC4();
			item.Dispose();
		}
	}

	private void _0023_003Dzj49Ii94_003D(int _0023_003DzyzK8swU_003D)
	{
		DisposeItem(base.Items[_0023_003DzyzK8swU_003D]);
	}

	protected override void ClearItems()
	{
		_0023_003DzEOJRE3lJRPC4();
		_0023_003DzhM3qURBkRYYd();
		base.ClearItems();
	}
}
