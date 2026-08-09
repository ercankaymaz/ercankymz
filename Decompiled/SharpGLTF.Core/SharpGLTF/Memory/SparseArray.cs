using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SharpGLTF.Memory;

[DebuggerDisplay("Sparse {typeof(T).Name} Accessor {Count}")]
public sealed class SparseArray<T> : IAccessorArray<T>, IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, IList<T>, ICollection<T> where T : unmanaged
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly IReadOnlyList<T> _DenseItems;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly IReadOnlyList<T> _SparseItems;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Dictionary<int, int> _SparseIndices;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private T[] _DebugItems => this.ToArray();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int Count => _DenseItems.Count;

	public bool IsReadOnly => true;

	public T this[int index]
	{
		get
		{
			if (!_SparseIndices.TryGetValue(index, out var value))
			{
				return _DenseItems[index];
			}
			return _SparseItems[value];
		}
		set
		{
			throw new NotSupportedException("Collection is read only.");
		}
	}

	public SparseArray(IReadOnlyList<T> denseValues, IReadOnlyList<T> sparseValues, IReadOnlyList<uint> sparseKeys)
	{
		Guard.NotNull(denseValues, "denseValues");
		Guard.NotNull(sparseValues, "sparseValues");
		Guard.NotNull(sparseKeys, "sparseKeys");
		Guard.MustBeEqualTo(sparseKeys.Count, sparseValues.Count, "Count");
		Guard.MustBeLessThanOrEqualTo(sparseKeys.Count, denseValues.Count, "Count");
		_DenseItems = denseValues;
		_SparseItems = sparseValues;
		_SparseIndices = new Dictionary<int, int>();
		for (int i = 0; i < sparseKeys.Count; i++)
		{
			int num = (int)sparseKeys[i];
			if (num >= denseValues.Count)
			{
				throw new ArgumentOutOfRangeException("sparseKeys");
			}
			_SparseIndices[num] = i;
		}
	}

	public IEnumerator<T> GetEnumerator()
	{
		return new EncodedArrayEnumerator<T>(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new EncodedArrayEnumerator<T>(this);
	}

	public bool Contains(T item)
	{
		return IndexOf(item) >= 0;
	}

	public int IndexOf(T item)
	{
		return this._FirstIndexOf(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		Guard.NotNull(array, "array");
		this._CopyTo(array, arrayIndex);
	}

	void IList<T>.Insert(int index, T item)
	{
		throw new NotSupportedException();
	}

	void IList<T>.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	void ICollection<T>.Add(T item)
	{
		throw new NotSupportedException();
	}

	void ICollection<T>.Clear()
	{
		throw new NotSupportedException();
	}

	bool ICollection<T>.Remove(T item)
	{
		throw new NotSupportedException();
	}
}
