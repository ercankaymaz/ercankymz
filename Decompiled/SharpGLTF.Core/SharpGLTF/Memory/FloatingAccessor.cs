using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpGLTF.Schema2;

namespace SharpGLTF.Memory;

internal readonly struct FloatingAccessor
{
	private delegate float _GetterCallback(int byteOffset);

	private delegate void _SetterCallback(int byteOffset, float value);

	private const string ERR_UNSUPPORTEDENCODING = "Unsupported encoding.";

	private readonly Memory<byte> _Data;

	private readonly int _ByteStride;

	private readonly int _EncodedLen;

	private readonly int _ItemCount;

	private readonly _GetterCallback _Getter;

	private readonly _SetterCallback _Setter;

	public int ByteLength => _Data.Length;

	public int Count => _ItemCount;

	public float this[int index]
	{
		get
		{
			return _Getter(index * _ByteStride);
		}
		set
		{
			if (!value._IsFinite())
			{
				throw new NotFiniteNumberException("value", value);
			}
			_Setter(index * _ByteStride, value);
		}
	}

	public float this[int rowIndex, int subIndex]
	{
		get
		{
			return _Getter(rowIndex * _ByteStride + subIndex * _EncodedLen);
		}
		set
		{
			if (!value._IsFinite())
			{
				throw new NotFiniteNumberException("value", value);
			}
			_Setter(rowIndex * _ByteStride + subIndex * _EncodedLen, value);
		}
	}

	public FloatingAccessor(Memory<byte> source, int byteOffset, int itemsCount, int byteStride, int dimensions, EncodingType encoding, bool normalized)
	{
		int num = encoding.ByteLength();
		_Data = source.Slice(byteOffset);
		_Getter = null;
		_Setter = null;
		_ByteStride = Math.Max(byteStride, num * dimensions);
		_EncodedLen = num;
		_ItemCount = _Data.Length / _ByteStride;
		if (_Data.Length % _ByteStride >= num * dimensions)
		{
			_ItemCount++;
		}
		_ItemCount = Math.Min(itemsCount, _ItemCount);
		if (encoding == EncodingType.FLOAT)
		{
			_Setter = _SetValue;
			_Getter = _GetValue<float>;
			return;
		}
		if (normalized)
		{
			switch (encoding)
			{
			case EncodingType.BYTE:
				_Setter = _SetNormalizedS8;
				_Getter = _GetNormalizedS8;
				break;
			case EncodingType.UNSIGNED_BYTE:
				_Setter = _SetNormalizedU8;
				_Getter = _GetNormalizedU8;
				break;
			case EncodingType.SHORT:
				_Setter = _SetNormalizedS16;
				_Getter = _GetNormalizedS16;
				break;
			case EncodingType.UNSIGNED_SHORT:
				_Setter = _SetNormalizedU16;
				_Getter = _GetNormalizedU16;
				break;
			default:
				throw new ArgumentException("Unsupported encoding.", "encoding");
			}
			return;
		}
		switch (encoding)
		{
		case EncodingType.BYTE:
			_Setter = _SetValueS8;
			_Getter = _GetValueS8;
			break;
		case EncodingType.UNSIGNED_BYTE:
			_Setter = _SetValueU8;
			_Getter = _GetValueU8;
			break;
		case EncodingType.SHORT:
			_Setter = _SetValueS16;
			_Getter = _GetValueS16;
			break;
		case EncodingType.UNSIGNED_SHORT:
			_Setter = _SetValueU16;
			_Getter = _GetValueU16;
			break;
		case EncodingType.UNSIGNED_INT:
			_Setter = _SetValueU32;
			_Getter = _GetValueU32;
			break;
		default:
			throw new ArgumentException("Unsupported encoding.", "encoding");
		case EncodingType.FLOAT:
			break;
		}
	}

	private float _GetValueU8(int byteOffset)
	{
		return (int)_GetValue<byte>(byteOffset);
	}

	private void _SetValueU8(int byteOffset, float value)
	{
		_SetValue(byteOffset, (byte)value);
	}

	private float _GetValueS8(int byteOffset)
	{
		return _GetValue<sbyte>(byteOffset);
	}

	private void _SetValueS8(int byteOffset, float value)
	{
		_SetValue(byteOffset, (sbyte)value);
	}

	private float _GetValueU16(int byteOffset)
	{
		return (int)_GetValue<ushort>(byteOffset);
	}

	private void _SetValueU16(int byteOffset, float value)
	{
		_SetValue(byteOffset, (ushort)value);
	}

	private float _GetValueS16(int byteOffset)
	{
		return _GetValue<short>(byteOffset);
	}

	private void _SetValueS16(int byteOffset, float value)
	{
		_SetValue(byteOffset, (short)value);
	}

	private float _GetValueU32(int byteOffset)
	{
		return _GetValue<uint>(byteOffset);
	}

	private void _SetValueU32(int byteOffset, float value)
	{
		_SetValue(byteOffset, (uint)value);
	}

	private float _GetNormalizedU8(int byteOffset)
	{
		return _GetValueU8(byteOffset) / 255f;
	}

	private void _SetNormalizedU8(int byteOffset, float value)
	{
		_SetValueU8(byteOffset, value * 255f);
	}

	private float _GetNormalizedS8(int byteOffset)
	{
		return Math.Max(_GetValueS8(byteOffset) / 127f, -1f);
	}

	private void _SetNormalizedS8(int byteOffset, float value)
	{
		_SetValueS8(byteOffset, (float)Math.Round(value * 127f));
	}

	private float _GetNormalizedU16(int byteOffset)
	{
		return _GetValueU16(byteOffset) / 65535f;
	}

	private void _SetNormalizedU16(int byteOffset, float value)
	{
		_SetValueU16(byteOffset, value * 65535f);
	}

	private float _GetNormalizedS16(int byteOffset)
	{
		return Math.Max(_GetValueS16(byteOffset) / 32767f, -1f);
	}

	private void _SetNormalizedS16(int byteOffset, float value)
	{
		_SetValueS16(byteOffset, (float)Math.Round(value * 32767f));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private T _GetValue<T>(int byteOffset) where T : unmanaged
	{
		return MemoryMarshal.Read<T>(_Data.Span.Slice(byteOffset));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void _SetValue<T>(int byteOffset, T value) where T : unmanaged
	{
		Span<byte> destination = _Data.Span.Slice(byteOffset);
		MemoryMarshal.Write(destination, ref value);
	}
}
