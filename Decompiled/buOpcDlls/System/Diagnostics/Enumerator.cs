using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Diagnostics;

internal struct Enumerator<T>(DiagNode<T> head) : IEnumerator<T>, IDisposable, IEnumerator
{
	private DiagNode<T> _nextNode = head;

	[System_002EDiagnostics_002EDiagnosticSource3462135_002EAllowNull]
	[System_002EDiagnostics_002EDiagnosticSource3462135_002EMaybeNull]
	private T _currentItem = default(T);

	public T Current => _currentItem;

	object IEnumerator.Current => Current;

	public bool MoveNext()
	{
		if (_nextNode == null)
		{
			_currentItem = default(T);
			return false;
		}
		_currentItem = _nextNode.Value;
		_nextNode = _nextNode.Next;
		return true;
	}

	public void Reset()
	{
		throw new NotSupportedException();
	}

	public void Dispose()
	{
	}
}
