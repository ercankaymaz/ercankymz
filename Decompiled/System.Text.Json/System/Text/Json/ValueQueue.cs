using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace System.Text.Json;

[StructLayout(LayoutKind.Auto)]
internal struct ValueQueue<T>
{
	private byte _state;

	private T _single;

	private Queue<T> _multiple;

	public readonly int Count
	{
		get
		{
			if (_state >= 2)
			{
				return _multiple.Count;
			}
			return _state;
		}
	}

	public void Enqueue(T value)
	{
		switch (_state)
		{
		case 0:
			_single = value;
			_state = 1;
			return;
		case 1:
			(_multiple ?? (_multiple = new Queue<T>())).Enqueue(_single);
			_single = default(T);
			_state = 2;
			break;
		}
		_multiple.Enqueue(value);
	}

	public bool TryDequeue([System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out T value)
	{
		switch (_state)
		{
		case 0:
			value = default(T);
			return false;
		case 1:
			value = _single;
			_single = default(T);
			_state = 0;
			return true;
		default:
			return _multiple.TryDequeue(out value);
		}
	}
}
