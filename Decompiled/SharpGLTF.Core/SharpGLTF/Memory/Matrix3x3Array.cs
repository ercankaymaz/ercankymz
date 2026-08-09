using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using SharpGLTF.Schema2;

namespace SharpGLTF.Memory;

[DebuggerDisplay("Matrix3x3[{Count}]")]
public readonly struct Matrix3x3Array : IAccessorArray<Matrix4x4>, IReadOnlyList<Matrix4x4>, IEnumerable<Matrix4x4>, IEnumerable, IReadOnlyCollection<Matrix4x4>, IList<Matrix4x4>, ICollection<Matrix4x4>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly FloatingAccessor _Accessor;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private Matrix4x4[] _DebugItems => this.ToArray();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int Count => _Accessor.Count;

	bool ICollection<Matrix4x4>.IsReadOnly => false;

	public Matrix4x4 this[int index]
	{
		get
		{
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			return new Matrix4x4(_Accessor[index, 0], _Accessor[index, 1], _Accessor[index, 2], 0f, _Accessor[index, 3], _Accessor[index, 4], _Accessor[index, 5], 0f, _Accessor[index, 6], _Accessor[index, 7], _Accessor[index, 8], 0f, 0f, 0f, 0f, 1f);
		}
		set
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			_Accessor[index, 0] = value.M11;
			_Accessor[index, 1] = value.M12;
			_Accessor[index, 2] = value.M13;
			_Accessor[index, 3] = value.M21;
			_Accessor[index, 4] = value.M22;
			_Accessor[index, 5] = value.M23;
			_Accessor[index, 6] = value.M31;
			_Accessor[index, 7] = value.M32;
			_Accessor[index, 8] = value.M33;
		}
	}

	public Matrix3x3Array(Memory<byte> source, int byteStride = 0, EncodingType encoding = EncodingType.FLOAT, bool normalized = false)
		: this(source, 0, int.MaxValue, byteStride, encoding, normalized)
	{
	}

	public Matrix3x3Array(Memory<byte> source, int byteOffset, int itemsCount, int byteStride, EncodingType encoding, bool normalized)
	{
		_Accessor = new FloatingAccessor(source, byteOffset, itemsCount, byteStride, 9, encoding, normalized);
	}

	public IEnumerator<Matrix4x4> GetEnumerator()
	{
		return new EncodedArrayEnumerator<Matrix4x4>(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new EncodedArrayEnumerator<Matrix4x4>(this);
	}

	public bool Contains(Matrix4x4 item)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return IndexOf(item) >= 0;
	}

	public int IndexOf(Matrix4x4 item)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		return this._FirstIndexOf(item);
	}

	public void CopyTo(Matrix4x4[] array, int arrayIndex)
	{
		Guard.NotNull(array, "array");
		this._CopyTo(array, arrayIndex);
	}

	public void Fill(IEnumerable<Matrix4x4> values, int dstStart = 0)
	{
		Guard.NotNull(values, "values");
		values._CopyTo(this, dstStart);
	}

	void IList<Matrix4x4>.Insert(int index, Matrix4x4 item)
	{
		throw new NotSupportedException();
	}

	void IList<Matrix4x4>.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	void ICollection<Matrix4x4>.Add(Matrix4x4 item)
	{
		throw new NotSupportedException();
	}

	void ICollection<Matrix4x4>.Clear()
	{
		throw new NotSupportedException();
	}

	bool ICollection<Matrix4x4>.Remove(Matrix4x4 item)
	{
		throw new NotSupportedException();
	}
}
