using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using SharpGLTF.Schema2;

namespace SharpGLTF.Memory;

[DebuggerDisplay("Integer[{Count}]")]
public readonly struct IntegerArray : IAccessorArray<uint>, IReadOnlyList<uint>, IEnumerable<uint>, IEnumerable, IReadOnlyCollection<uint>, IList<uint>, ICollection<uint>
{
	private delegate uint _GetterCallback(int index);

	private delegate void _SetterCallback(int index, uint value);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Memory<byte> _Data;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _ByteStride;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _GetterCallback _Getter;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _SetterCallback _Setter;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	private uint[] _DebugItems => this.ToArray();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public int Count => _Data.Length / _ByteStride;

	bool ICollection<uint>.IsReadOnly => false;

	public uint this[int index]
	{
		get
		{
			return _Getter(index);
		}
		set
		{
			_Setter(index, value);
		}
	}

	public IntegerArray(Memory<byte> source, IndexEncodingType encoding = IndexEncodingType.UNSIGNED_INT)
		: this(source, 0, int.MaxValue, encoding)
	{
	}

	public IntegerArray(Memory<byte> source, int byteOffset, int itemsCount, IndexEncodingType encoding)
	{
		_Data = source.Slice(byteOffset);
		_ByteStride = encoding.ByteLength();
		_Setter = null;
		_Getter = null;
		if (itemsCount < Count)
		{
			_Data = _Data.Slice(0, itemsCount * _ByteStride);
		}
		switch (encoding)
		{
		case IndexEncodingType.UNSIGNED_BYTE:
			_Setter = _SetValueU8;
			_Getter = _GetValueU8;
			break;
		case IndexEncodingType.UNSIGNED_SHORT:
			_Setter = _SetValueU16;
			_Getter = _GetValueU16;
			break;
		case IndexEncodingType.UNSIGNED_INT:
			_Setter = _SetValue;
			_Getter = _GetValue<uint>;
			break;
		default:
			throw new ArgumentException("Unsupported encoding.", "encoding");
		}
	}

	private uint _GetValueU8(int index)
	{
		return _GetValue<byte>(index);
	}

	private void _SetValueU8(int index, uint value)
	{
		_SetValue(index, (byte)value);
	}

	private uint _GetValueU16(int index)
	{
		return _GetValue<ushort>(index);
	}

	private void _SetValueU16(int index, uint value)
	{
		_SetValue(index, (ushort)value);
	}

	private T _GetValue<T>(int index) where T : unmanaged
	{
		return MemoryMarshal.Cast<byte, T>(_Data.Span)[index];
	}

	private void _SetValue<T>(int index, T value) where T : unmanaged
	{
		MemoryMarshal.Cast<byte, T>(_Data.Span)[index] = value;
	}

	public IEnumerator<uint> GetEnumerator()
	{
		return new EncodedArrayEnumerator<uint>(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new EncodedArrayEnumerator<uint>(this);
	}

	public bool Contains(uint item)
	{
		return IndexOf(item) >= 0;
	}

	public int IndexOf(uint item)
	{
		return this._FirstIndexOf(item);
	}

	public void CopyTo(uint[] array, int arrayIndex)
	{
		Guard.NotNull(array, "array");
		this._CopyTo(array, arrayIndex);
	}

	public void Fill(IEnumerable<int> values, int dstStart = 0)
	{
		Guard.NotNull(values, "values");
		values._CopyTo(this, dstStart);
	}

	public void Fill(IEnumerable<uint> values, int dstStart = 0)
	{
		Guard.NotNull(values, "values");
		values._CopyTo(this, dstStart);
	}

	void IList<uint>.Insert(int index, uint item)
	{
		throw new NotSupportedException();
	}

	void IList<uint>.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	void ICollection<uint>.Add(uint item)
	{
		throw new NotSupportedException();
	}

	void ICollection<uint>.Clear()
	{
		throw new NotSupportedException();
	}

	bool ICollection<uint>.Remove(uint item)
	{
		throw new NotSupportedException();
	}
}
