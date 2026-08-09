using System;
using System.Collections;
using System.Collections.Generic;

namespace Xbim.Common.Collections;

internal class ProxyNestedEnumerator<TInner, TOuter> : IEnumerator<IItemSet<TOuter>>, IEnumerator, IDisposable where TInner : TOuter
{
	private readonly IEnumerator<IItemSet<TInner>> _inner;

	public IItemSet<TOuter> Current => new ProxyItemSet<TInner, TOuter>(_inner.Current);

	object IEnumerator.Current => Current;

	public ProxyNestedEnumerator(IEnumerator<IItemSet<TInner>> inner)
	{
		_inner = inner;
	}

	public void Dispose()
	{
		_inner.Dispose();
	}

	public bool MoveNext()
	{
		return _inner.MoveNext();
	}

	public void Reset()
	{
		_inner.Reset();
	}
}
