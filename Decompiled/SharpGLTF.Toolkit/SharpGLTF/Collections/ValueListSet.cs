using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace SharpGLTF.Collections;

internal class ValueListSet<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T> where T : struct
{
	[DebuggerDisplay("Hash:{HashCode} Next:{Next} Value:{Value}")]
	private struct _Entry
	{
		public int HashCode;

		public int Next;

		public T Value;
	}

	private struct _ValueEnumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		private readonly ValueListSet<T> _Source;

		private readonly int _Version;

		private int _Index;

		private T _Current;

		public T Current => _Current;

		object IEnumerator.Current => _Current;

		internal _ValueEnumerator(ValueListSet<T> source)
		{
			_Source = source;
			_Version = source._Version;
			_Index = 0;
			_Current = default(T);
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			if (_Version != _Source._Version)
			{
				throw new InvalidOperationException("collection changed");
			}
			while ((uint)_Index < (uint)_Source._Count)
			{
				if (_Source._Entries[_Index].HashCode >= 0)
				{
					_Current = _Source._Entries[_Index].Value;
					_Index++;
					return true;
				}
				_Index++;
			}
			_Index = _Source._Count + 1;
			_Current = default(T);
			return false;
		}

		void IEnumerator.Reset()
		{
			if (_Version != _Source._Version)
			{
				throw new InvalidOperationException("collection changed");
			}
			_Index = 0;
			_Current = default(T);
		}
	}

	private readonly struct _IndexCollection(ValueListSet<T> source) : IEnumerable<int>, IEnumerable
	{
		private readonly ValueListSet<T> _Source = source;

		public IEnumerator<int> GetEnumerator()
		{
			return new _IndexEnumerator(_Source);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new _IndexEnumerator(_Source);
		}
	}

	private struct _IndexEnumerator : IEnumerator<int>, IEnumerator, IDisposable
	{
		private readonly ValueListSet<T> _Source;

		private readonly int _Version;

		private int _Index;

		private int _Current;

		public int Current => _Current;

		object IEnumerator.Current => _Current;

		internal _IndexEnumerator(ValueListSet<T> source)
		{
			_Source = source;
			_Version = source._Version;
			_Index = 0;
			_Current = -1;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			if (_Version != _Source._Version)
			{
				throw new InvalidOperationException("collection changed");
			}
			while ((uint)_Index < (uint)_Source._Count)
			{
				if (_Source._Entries[_Index].HashCode >= 0)
				{
					_Current = _Index;
					_Index++;
					return true;
				}
				_Index++;
			}
			_Index = _Source._Count + 1;
			_Current = 0;
			return false;
		}

		void IEnumerator.Reset()
		{
			if (_Version != _Source._Version)
			{
				throw new InvalidOperationException("collection changed");
			}
			_Index = 0;
			_Current = 0;
		}
	}

	private IEqualityComparer<T> _Comparer;

	private _Entry[] _Entries;

	private int[] _Buckets;

	private int _Count;

	private int _Version;

	public IEqualityComparer<T> Comparer => _Comparer;

	public int Count => _Count;

	public T this[int index]
	{
		get
		{
			if (index < 0 || index >= _Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (_Entries[index].HashCode == -1)
			{
				throw new ArgumentException("Invalid entry", "index");
			}
			return _Entries[index].Value;
		}
	}

	public IEnumerable<int> Indices => new _IndexCollection(this);

	public ValueListSet()
		: this(0, (IEqualityComparer<T>)null)
	{
	}

	public ValueListSet(int capacity, IEqualityComparer<T> comparer = null)
	{
		if (capacity < 0)
		{
			throw new ArgumentOutOfRangeException("capacity");
		}
		if (capacity > 0)
		{
			_Initialize(capacity);
		}
		_Comparer = comparer ?? EqualityComparer<T>.Default;
	}

	public void Clear()
	{
		if (_Count > 0)
		{
			MemoryExtensions.AsSpan(_Entries).Clear();
			MemoryExtensions.AsSpan(_Buckets).Fill(-1);
			_Count = 0;
			_Version++;
		}
	}

	public bool Exists(int index)
	{
		if (index < 0 || index >= _Count)
		{
			return false;
		}
		if (_Entries[index].HashCode == -1)
		{
			return false;
		}
		return true;
	}

	public int IndexOf(in T value)
	{
		if (_Buckets != null)
		{
			return _IndexOf(in value);
		}
		return -1;
	}

	public int Use(in T value)
	{
		int num = ((_Buckets == null) ? (-1) : _IndexOf(in value));
		if (num >= 0)
		{
			return num;
		}
		return _Insert(in value);
	}

	public int Add(in T value)
	{
		if (_IndexOf(in value) >= 0)
		{
			throw new ArgumentException("${value} already exists", "value");
		}
		return _Insert(in value);
	}

	public bool Contains(in T item)
	{
		return IndexOf(in item) >= 0;
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		for (int i = 0; i < _Count; i++)
		{
			_Entry entry = _Entries[i];
			if (entry.HashCode != -1)
			{
				array[arrayIndex++] = entry.Value;
			}
		}
	}

	public void CopyTo(ValueListSet<T> dst)
	{
		if (_Count == 0)
		{
			dst.Clear();
			return;
		}
		if (dst._Buckets == null || dst._Buckets.Length < _Buckets.Length)
		{
			dst._Buckets = new int[_Buckets.Length];
		}
		if (dst._Entries == null || dst._Entries.Length < _Entries.Length)
		{
			dst._Entries = new _Entry[_Entries.Length];
		}
		dst._Count = _Count;
		MemoryExtensions.AsSpan(_Entries, 0, _Count).CopyTo(dst._Entries);
		if (_Comparer == dst._Comparer)
		{
			MemoryExtensions.AsSpan(_Buckets, 0).CopyTo(dst._Buckets);
		}
		else
		{
			dst._Resize(dst._Count, forceNewHashCodes: true);
		}
		dst._Version++;
	}

	public IEnumerator<T> GetEnumerator()
	{
		return new _ValueEnumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new _ValueEnumerator(this);
	}

	public void ApplyTransform(Func<T, T> transformFunc)
	{
		for (int i = 0; i < _Count; i++)
		{
			_Entries[i].Value = transformFunc(_Entries[i].Value);
		}
		_Resize(_Count, forceNewHashCodes: true);
	}

	private void _Initialize(int capacity)
	{
		int prime = _PrimeNumberHelpers.GetPrime(capacity);
		_Buckets = new int[prime];
		MemoryExtensions.AsSpan(_Buckets).Fill(-1);
		_Entries = new _Entry[prime];
		_Count = 0;
	}

	private int _IndexOf(in T value)
	{
		int num = _Comparer.GetHashCode(value) & 0x7FFFFFFF;
		int num2 = num % _Buckets.Length;
		for (int num3 = _Buckets[num2]; num3 >= 0; num3 = _Entries[num3].Next)
		{
			if (_Entries[num3].HashCode == num && _Comparer.Equals(_Entries[num3].Value, value))
			{
				return num3;
			}
		}
		return -1;
	}

	private int _Insert(in T value)
	{
		if (_Buckets == null)
		{
			_Initialize(0);
		}
		if (_Count == _Entries.Length)
		{
			_Grow();
		}
		int num = _Comparer.GetHashCode(value) & 0x7FFFFFFF;
		int num2 = num % _Buckets.Length;
		int count = _Count;
		_Count++;
		_Entries[count].HashCode = num;
		_Entries[count].Next = _Buckets[num2];
		_Entries[count].Value = value;
		_Buckets[num2] = count;
		_Version++;
		return count;
	}

	private void _Grow()
	{
		int newSize = _PrimeNumberHelpers.ExpandPrime(_Count);
		_Resize(newSize, forceNewHashCodes: false);
	}

	private void _Resize(int newSize, bool forceNewHashCodes)
	{
		if (newSize < _Entries.Length)
		{
			newSize = _Entries.Length;
		}
		Array.Resize(ref _Entries, newSize);
		if (forceNewHashCodes)
		{
			for (int i = 0; i < _Count; i++)
			{
				if (_Entries[i].HashCode != -1)
				{
					_Entries[i].HashCode = _Comparer.GetHashCode(_Entries[i].Value) & 0x7FFFFFFF;
				}
			}
		}
		if (_Buckets.Length != _Entries.Length)
		{
			_Buckets = new int[_Entries.Length];
		}
		MemoryExtensions.AsSpan(_Buckets).Fill(-1);
		for (int j = 0; j < _Count; j++)
		{
			if (_Entries[j].HashCode >= 0)
			{
				int num = _Entries[j].HashCode % _Buckets.Length;
				_Entries[j].Next = _Buckets[num];
				_Buckets[num] = j;
			}
		}
	}
}
