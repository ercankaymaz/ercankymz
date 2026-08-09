using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using SharpGLTF.Schema2;

namespace SharpGLTF.Memory;

[DebuggerDisplay("Vector3[{Count}]")]
public readonly struct Vector3Array : IAccessorArray<Vector3>, IReadOnlyList<Vector3>, IEnumerable<Vector3>, IEnumerable, IReadOnlyCollection<Vector3>, IList<Vector3>, ICollection<Vector3>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly FloatingAccessor _Accessor;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private Vector3[] _DebugItems => this.ToArray();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int Count => _Accessor.Count;

	bool ICollection<Vector3>.IsReadOnly => false;

	public Vector3 this[int index]
	{
		get
		{
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			return new Vector3(_Accessor[index, 0], _Accessor[index, 1], _Accessor[index, 2]);
		}
		set
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			_Accessor[index, 0] = value.X;
			_Accessor[index, 1] = value.Y;
			_Accessor[index, 2] = value.Z;
		}
	}

	public Vector3Array(Memory<byte> source, int byteStride = 0, EncodingType encoding = EncodingType.FLOAT, bool normalized = false)
		: this(source, 0, int.MaxValue, byteStride, encoding, normalized)
	{
	}

	public Vector3Array(Memory<byte> source, int byteOffset, int itemsCount, int byteStride, EncodingType encoding = EncodingType.FLOAT, bool normalized = false)
	{
		_Accessor = new FloatingAccessor(source, byteOffset, itemsCount, byteStride, 3, encoding, normalized);
	}

	public IEnumerator<Vector3> GetEnumerator()
	{
		return new EncodedArrayEnumerator<Vector3>(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new EncodedArrayEnumerator<Vector3>(this);
	}

	public bool Contains(Vector3 item)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return IndexOf(item) >= 0;
	}

	public int IndexOf(Vector3 item)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		return this._FirstIndexOf(item);
	}

	public void CopyTo(Vector3[] array, int arrayIndex)
	{
		Guard.NotNull(array, "array");
		this._CopyTo(array, arrayIndex);
	}

	public void Fill(IEnumerable<Vector3> values, int dstStart = 0)
	{
		Guard.NotNull(values, "values");
		values._CopyTo(this, dstStart);
	}

	void IList<Vector3>.Insert(int index, Vector3 item)
	{
		throw new NotSupportedException();
	}

	void IList<Vector3>.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	void ICollection<Vector3>.Add(Vector3 item)
	{
		throw new NotSupportedException();
	}

	void ICollection<Vector3>.Clear()
	{
		throw new NotSupportedException();
	}

	bool ICollection<Vector3>.Remove(Vector3 item)
	{
		throw new NotSupportedException();
	}
}
