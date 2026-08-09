using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SharpGLTF.Schema2;

namespace SharpGLTF.Memory;

[DebuggerDisplay("Float[{Count}]")]
public readonly struct ScalarArray : IAccessorArray<float>, IReadOnlyList<float>, IEnumerable<float>, IEnumerable, IReadOnlyCollection<float>, IList<float>, ICollection<float>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly FloatingAccessor _Accessor;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private float[] _DebugItems => this.ToArray();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int Count => _Accessor.Count;

	bool ICollection<float>.IsReadOnly => false;

	public float this[int index]
	{
		get
		{
			return _Accessor[index, 0];
		}
		set
		{
			_Accessor[index, 0] = value;
		}
	}

	public ScalarArray(Memory<byte> source, int byteStride = 0, EncodingType encoding = EncodingType.FLOAT, bool normalized = false)
		: this(source, 0, int.MaxValue, byteStride, encoding, normalized)
	{
	}

	public ScalarArray(Memory<byte> source, int byteOffset, int itemsCount, int byteStride, EncodingType encoding = EncodingType.FLOAT, bool normalized = false)
	{
		_Accessor = new FloatingAccessor(source, byteOffset, itemsCount, byteStride, 1, encoding, normalized);
	}

	public IEnumerator<float> GetEnumerator()
	{
		return new EncodedArrayEnumerator<float>(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new EncodedArrayEnumerator<float>(this);
	}

	public bool Contains(float item)
	{
		return IndexOf(item) >= 0;
	}

	public int IndexOf(float item)
	{
		return this._FirstIndexOf(item);
	}

	public void CopyTo(float[] array, int arrayIndex)
	{
		Guard.NotNull(array, "array");
		this._CopyTo(array, arrayIndex);
	}

	public void Fill(IEnumerable<float> values, int dstStart = 0)
	{
		Guard.NotNull(values, "values");
		values._CopyTo(this, dstStart);
	}

	void IList<float>.Insert(int index, float item)
	{
		throw new NotSupportedException();
	}

	void IList<float>.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	void ICollection<float>.Add(float item)
	{
		throw new NotSupportedException();
	}

	void ICollection<float>.Clear()
	{
		throw new NotSupportedException();
	}

	bool ICollection<float>.Remove(float item)
	{
		throw new NotSupportedException();
	}
}
