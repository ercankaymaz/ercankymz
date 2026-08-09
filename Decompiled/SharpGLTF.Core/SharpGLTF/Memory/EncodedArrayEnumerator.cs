using System;
using System.Collections;
using System.Collections.Generic;

namespace SharpGLTF.Memory;

internal struct EncodedArrayEnumerator<T>(IReadOnlyList<T> accessor) : IEnumerator<T>, IEnumerator, IDisposable
{
	private readonly IReadOnlyList<T> _Accessor = accessor;

	private readonly int _Count = accessor.Count;

	private int _Index = -1;

	public T Current => _Accessor[_Index];

	object IEnumerator.Current => _Accessor[_Index];

	public void Dispose()
	{
	}

	public bool MoveNext()
	{
		_Index++;
		return _Index < _Count;
	}

	public void Reset()
	{
		_Index = -1;
	}
}
