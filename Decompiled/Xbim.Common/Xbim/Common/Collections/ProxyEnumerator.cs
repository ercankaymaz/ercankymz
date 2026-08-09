using System;
using System.Collections;
using System.Collections.Generic;

namespace Xbim.Common.Collections;

internal class ProxyEnumerator<TInner, TOuter> : IEnumerator<TOuter>, IEnumerator, IDisposable where TInner : TOuter
{
	private readonly IEnumerator<TInner> _inner;

	public TOuter Current => (TOuter)(object)_inner.Current;

	object IEnumerator.Current => Current;

	public ProxyEnumerator(IEnumerator<TInner> inner)
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
