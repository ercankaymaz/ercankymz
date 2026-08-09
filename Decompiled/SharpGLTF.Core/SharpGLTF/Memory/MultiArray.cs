using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SharpGLTF.Schema2;

namespace SharpGLTF.Memory;

[DebuggerDisplay("Float[][{Count}]")]
public readonly struct MultiArray(Memory<byte> source, int byteOffset, int itemsCount, int byteStride, int dimensions, EncodingType encoding, bool normalized) : IAccessorArray<float[]>, IReadOnlyList<float[]>, IEnumerable<float[]>, IEnumerable, IReadOnlyCollection<float[]>, IList<float[]>, ICollection<float[]>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _Dimensions = dimensions;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly FloatingAccessor _Accessor = new FloatingAccessor(source, byteOffset, itemsCount, byteStride, dimensions, encoding, normalized);

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private float[][] _DebugItems => this.ToArray();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int Count => _Accessor.Count;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int Dimensions => _Dimensions;

	bool ICollection<float[]>.IsReadOnly => false;

	public float[] this[int index]
	{
		get
		{
			float[] array = new float[_Dimensions];
			CopyItemTo(index, array);
			return array;
		}
		set
		{
			Guard.NotNull(value, "value");
			Guard.IsTrue(value.Length == _Dimensions, "value");
			for (int i = 0; i < _Dimensions; i++)
			{
				_Accessor[index, i] = value[i];
			}
		}
	}

	public void CopyItemTo(int index, float[] dstItem)
	{
		Guard.NotNull(dstItem, "dstItem");
		int dimensions = _Dimensions;
		for (int i = 0; i < dimensions; i++)
		{
			dstItem[i] = _Accessor[index, i];
		}
	}

	public IEnumerator<float[]> GetEnumerator()
	{
		return new EncodedArrayEnumerator<float[]>(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new EncodedArrayEnumerator<float[]>(this);
	}

	public bool Contains(float[] item)
	{
		return IndexOf(item) >= 0;
	}

	public int IndexOf(float[] item)
	{
		return this._FirstIndexOf(item);
	}

	public void CopyTo(float[][] array, int arrayIndex)
	{
		Guard.NotNull(array, "array");
		this._CopyTo(array, arrayIndex);
	}

	public void Fill(IEnumerable<float[]> values, int dstStart = 0)
	{
		Guard.NotNull(values, "values");
		values._CopyTo(this, dstStart);
	}

	void IList<float[]>.Insert(int index, float[] item)
	{
		throw new NotSupportedException();
	}

	void IList<float[]>.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	void ICollection<float[]>.Add(float[] item)
	{
		throw new NotSupportedException();
	}

	void ICollection<float[]>.Clear()
	{
		throw new NotSupportedException();
	}

	bool ICollection<float[]>.Remove(float[] item)
	{
		throw new NotSupportedException();
	}
}
