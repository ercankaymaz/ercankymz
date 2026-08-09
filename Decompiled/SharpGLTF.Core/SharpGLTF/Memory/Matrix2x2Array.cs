using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using SharpGLTF.Schema2;

namespace SharpGLTF.Memory;

[DebuggerDisplay("Matrix2x2[{Count}]")]
public readonly struct Matrix2x2Array : IAccessorArray<Matrix3x2>, IReadOnlyList<Matrix3x2>, IEnumerable<Matrix3x2>, IEnumerable, IReadOnlyCollection<Matrix3x2>, IList<Matrix3x2>, ICollection<Matrix3x2>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly FloatingAccessor _Accessor;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private Matrix3x2[] _DebugItems => this.ToArray();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int Count => _Accessor.Count;

	bool ICollection<Matrix3x2>.IsReadOnly => false;

	public Matrix3x2 this[int index]
	{
		get
		{
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			return new Matrix3x2(_Accessor[index, 0], _Accessor[index, 1], _Accessor[index, 2], _Accessor[index, 3], 0f, 0f);
		}
		set
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			_Accessor[index, 0] = value.M11;
			_Accessor[index, 1] = value.M12;
			_Accessor[index, 2] = value.M21;
			_Accessor[index, 3] = value.M22;
		}
	}

	public Matrix2x2Array(Memory<byte> source, int byteStride = 0, EncodingType encoding = EncodingType.FLOAT, bool normalized = false)
		: this(source, 0, int.MaxValue, byteStride, encoding, normalized)
	{
	}

	public Matrix2x2Array(Memory<byte> source, int byteOffset, int itemsCount, int byteStride, EncodingType encoding, bool normalized)
	{
		_Accessor = new FloatingAccessor(source, byteOffset, itemsCount, byteStride, 4, encoding, normalized);
	}

	public IEnumerator<Matrix3x2> GetEnumerator()
	{
		return new EncodedArrayEnumerator<Matrix3x2>(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new EncodedArrayEnumerator<Matrix3x2>(this);
	}

	public bool Contains(Matrix3x2 item)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return IndexOf(item) >= 0;
	}

	public int IndexOf(Matrix3x2 item)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		return this._FirstIndexOf(item);
	}

	public void CopyTo(Matrix3x2[] array, int arrayIndex)
	{
		Guard.NotNull(array, "array");
		this._CopyTo(array, arrayIndex);
	}

	public void Fill(IEnumerable<Matrix3x2> values, int dstStart = 0)
	{
		Guard.NotNull(values, "values");
		values._CopyTo(this, dstStart);
	}

	void IList<Matrix3x2>.Insert(int index, Matrix3x2 item)
	{
		throw new NotSupportedException();
	}

	void IList<Matrix3x2>.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	void ICollection<Matrix3x2>.Add(Matrix3x2 item)
	{
		throw new NotSupportedException();
	}

	void ICollection<Matrix3x2>.Clear()
	{
		throw new NotSupportedException();
	}

	bool ICollection<Matrix3x2>.Remove(Matrix3x2 item)
	{
		throw new NotSupportedException();
	}
}
