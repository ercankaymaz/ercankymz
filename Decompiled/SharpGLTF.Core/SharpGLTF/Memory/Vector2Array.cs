using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using SharpGLTF.Schema2;

namespace SharpGLTF.Memory;

[DebuggerDisplay("Vector2[{Count}]")]
public readonly struct Vector2Array : IAccessorArray<Vector2>, IReadOnlyList<Vector2>, IEnumerable<Vector2>, IEnumerable, IReadOnlyCollection<Vector2>, IList<Vector2>, ICollection<Vector2>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly FloatingAccessor _Accessor;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private Vector2[] _DebugItems => this.ToArray();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int Count => _Accessor.Count;

	bool ICollection<Vector2>.IsReadOnly => false;

	public Vector2 this[int index]
	{
		get
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			return new Vector2(_Accessor[index, 0], _Accessor[index, 1]);
		}
		set
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			_Accessor[index, 0] = value.X;
			_Accessor[index, 1] = value.Y;
		}
	}

	public Vector2Array(Memory<byte> source, int byteStride = 0, EncodingType encoding = EncodingType.FLOAT, bool normalized = false)
		: this(source, 0, int.MaxValue, byteStride, encoding, normalized)
	{
	}

	public Vector2Array(Memory<byte> source, int byteOffset, int itemsCount, int byteStride, EncodingType encoding = EncodingType.FLOAT, bool normalized = false)
	{
		_Accessor = new FloatingAccessor(source, byteOffset, itemsCount, byteStride, 2, encoding, normalized);
	}

	public IEnumerator<Vector2> GetEnumerator()
	{
		return new EncodedArrayEnumerator<Vector2>(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new EncodedArrayEnumerator<Vector2>(this);
	}

	public bool Contains(Vector2 item)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return IndexOf(item) >= 0;
	}

	public int IndexOf(Vector2 item)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		return this._FirstIndexOf(item);
	}

	public void CopyTo(Vector2[] array, int arrayIndex)
	{
		Guard.NotNull(array, "array");
		this._CopyTo(array, arrayIndex);
	}

	public void Fill(IEnumerable<Vector2> values, int dstStart = 0)
	{
		Guard.NotNull(values, "values");
		values._CopyTo(this, dstStart);
	}

	void IList<Vector2>.Insert(int index, Vector2 item)
	{
		throw new NotSupportedException();
	}

	void IList<Vector2>.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	void ICollection<Vector2>.Add(Vector2 item)
	{
		throw new NotSupportedException();
	}

	void ICollection<Vector2>.Clear()
	{
		throw new NotSupportedException();
	}

	bool ICollection<Vector2>.Remove(Vector2 item)
	{
		throw new NotSupportedException();
	}
}
