using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using SharpGLTF.Schema2;

namespace SharpGLTF.Memory;

[DebuggerDisplay("Quaternion[{Count}]")]
public readonly struct QuaternionArray : IAccessorArray<Quaternion>, IReadOnlyList<Quaternion>, IEnumerable<Quaternion>, IEnumerable, IReadOnlyCollection<Quaternion>, IList<Quaternion>, ICollection<Quaternion>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly FloatingAccessor _Accessor;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private Quaternion[] _DebugItems => this.ToArray();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int Count => _Accessor.Count;

	bool ICollection<Quaternion>.IsReadOnly => false;

	public Quaternion this[int index]
	{
		get
		{
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			return new Quaternion(_Accessor[index, 0], _Accessor[index, 1], _Accessor[index, 2], _Accessor[index, 3]);
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

	public QuaternionArray(Memory<byte> source, int byteStride = 0, EncodingType encoding = EncodingType.FLOAT, bool normalized = false)
		: this(source, 0, int.MaxValue, byteStride, encoding, normalized)
	{
	}

	public QuaternionArray(Memory<byte> source, int byteOffset, int itemsCount, int byteStride, EncodingType encoding, bool normalized)
	{
		_Accessor = new FloatingAccessor(source, byteOffset, itemsCount, byteStride, 4, encoding, normalized);
	}

	public IEnumerator<Quaternion> GetEnumerator()
	{
		return new EncodedArrayEnumerator<Quaternion>(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new EncodedArrayEnumerator<Quaternion>(this);
	}

	public bool Contains(Quaternion item)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return IndexOf(item) >= 0;
	}

	public int IndexOf(Quaternion item)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		return this._FirstIndexOf(item);
	}

	public void CopyTo(Quaternion[] array, int arrayIndex)
	{
		Guard.NotNull(array, "array");
		this._CopyTo(array, arrayIndex);
	}

	public void Fill(IEnumerable<Quaternion> values, int dstStart = 0)
	{
		Guard.NotNull(values, "values");
		values._CopyTo(this, dstStart);
	}

	void IList<Quaternion>.Insert(int index, Quaternion item)
	{
		throw new NotSupportedException();
	}

	void IList<Quaternion>.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	void ICollection<Quaternion>.Add(Quaternion item)
	{
		throw new NotSupportedException();
	}

	void ICollection<Quaternion>.Clear()
	{
		throw new NotSupportedException();
	}

	bool ICollection<Quaternion>.Remove(Quaternion item)
	{
		throw new NotSupportedException();
	}
}
