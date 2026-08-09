using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using SharpGLTF.Schema2;

namespace SharpGLTF.Memory;

[DebuggerDisplay("Vector4[{Count}]")]
public readonly struct Vector4Array : IAccessorArray<Vector4>, IReadOnlyList<Vector4>, IEnumerable<Vector4>, IEnumerable, IReadOnlyCollection<Vector4>, IList<Vector4>, ICollection<Vector4>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly FloatingAccessor _Accessor;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private Vector4[] _DebugItems => this.ToArray();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int Count => _Accessor.Count;

	bool ICollection<Vector4>.IsReadOnly => false;

	public Vector4 this[int index]
	{
		get
		{
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			return new Vector4(_Accessor[index, 0], _Accessor[index, 1], _Accessor[index, 2], _Accessor[index, 3]);
		}
		set
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			_Accessor[index, 0] = value.X;
			_Accessor[index, 1] = value.Y;
			_Accessor[index, 2] = value.Z;
			_Accessor[index, 3] = value.W;
		}
	}

	public Vector4Array(Memory<byte> source, int byteStride = 0, EncodingType encoding = EncodingType.FLOAT, bool normalized = false)
		: this(source, 0, int.MaxValue, byteStride, encoding, normalized)
	{
	}

	public Vector4Array(Memory<byte> source, int byteOffset, int itemsCount, int byteStride, EncodingType encoding = EncodingType.FLOAT, bool normalized = false)
	{
		_Accessor = new FloatingAccessor(source, byteOffset, itemsCount, byteStride, 4, encoding, normalized);
	}

	public IEnumerator<Vector4> GetEnumerator()
	{
		return new EncodedArrayEnumerator<Vector4>(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new EncodedArrayEnumerator<Vector4>(this);
	}

	public bool Contains(Vector4 item)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return IndexOf(item) >= 0;
	}

	public int IndexOf(Vector4 item)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		return this._FirstIndexOf(item);
	}

	public void CopyTo(Vector4[] array, int arrayIndex)
	{
		Guard.NotNull(array, "array");
		this._CopyTo(array, arrayIndex);
	}

	public void Fill(IEnumerable<Vector4> values, int dstStart = 0)
	{
		Guard.NotNull(values, "values");
		values._CopyTo(this, dstStart);
	}

	void IList<Vector4>.Insert(int index, Vector4 item)
	{
		throw new NotSupportedException();
	}

	void IList<Vector4>.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	void ICollection<Vector4>.Add(Vector4 item)
	{
		throw new NotSupportedException();
	}

	void ICollection<Vector4>.Clear()
	{
		throw new NotSupportedException();
	}

	bool ICollection<Vector4>.Remove(Vector4 item)
	{
		throw new NotSupportedException();
	}
}
