using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal struct JpegReader
{
	private ReadOnlySequence<byte> _data;

	private readonly int _initialLength;

	public readonly bool IsEmpty => _data.IsEmpty;

	public readonly int RemainingByteCount => (int)_data.Length;

	public readonly int ConsumedByteCount => _initialLength - (int)_data.Length;

	public readonly ReadOnlySequence<byte> RemainingBytes => _data;

	public JpegReader(ReadOnlySequence<byte> data)
	{
		_data = data;
		_initialLength = checked((int)data.Length);
	}

	public JpegReader(ReadOnlyMemory<byte> data)
	{
		_data = new ReadOnlySequence<byte>(data);
		_initialLength = data.Length;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private readonly bool TryPeekToBuffer(Span<byte> buffer)
	{
		ReadOnlySpan<byte> span = _data.First.Span;
		if (span.Length >= buffer.Length)
		{
			span.Slice(0, buffer.Length).CopyTo(buffer);
			return true;
		}
		return TryPeekToBufferSlow(span, buffer);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private readonly bool TryPeekToBufferSlow(ReadOnlySpan<byte> firstSpan, Span<byte> buffer)
	{
		firstSpan.CopyTo(buffer);
		buffer = buffer.Slice(firstSpan.Length);
		ReadOnlySequence<byte> readOnlySequence = _data.Slice(firstSpan.Length);
		if (readOnlySequence.Length >= buffer.Length)
		{
			readOnlySequence.Slice(0, buffer.Length).CopyTo(buffer);
			return true;
		}
		return false;
	}

	public bool TryReadStartOfImageMarker()
	{
		Span<byte> buffer = stackalloc byte[2];
		if (!TryPeekToBuffer(buffer))
		{
			return false;
		}
		if (buffer[0] == byte.MaxValue && buffer[1] == 216)
		{
			_data = _data.Slice(2L);
			return true;
		}
		return false;
	}

	public bool TryReadMarker(out JpegMarker marker)
	{
		Span<byte> buffer = stackalloc byte[2];
		while (TryPeekToBuffer(buffer))
		{
			byte num = buffer[0];
			byte b = buffer[1];
			if (num == byte.MaxValue)
			{
				switch (b)
				{
				case byte.MaxValue:
					_data = _data.Slice(1L);
					break;
				case 0:
					_data = _data.Slice(2L);
					break;
				default:
					_data = _data.Slice(2L);
					marker = (JpegMarker)b;
					return true;
				}
			}
			else
			{
				SequencePosition? sequencePosition = _data.PositionOf(byte.MaxValue);
				if (!sequencePosition.HasValue)
				{
					_data = default(ReadOnlySequence<byte>);
					marker = (JpegMarker)0;
					return false;
				}
				_data = _data.Slice(sequencePosition.GetValueOrDefault());
			}
		}
		marker = (JpegMarker)0;
		return false;
	}

	public bool TryReadLength(out ushort length)
	{
		Span<byte> buffer = stackalloc byte[2];
		if (!TryPeekToBuffer(buffer))
		{
			length = 0;
			return false;
		}
		length = (ushort)((buffer[0] << 8) | (buffer[1] - 2));
		_data = _data.Slice(2L);
		return true;
	}

	public readonly bool TryPeekLength(out ushort length)
	{
		Span<byte> buffer = stackalloc byte[2];
		if (!TryPeekToBuffer(buffer))
		{
			length = 0;
			return false;
		}
		length = (ushort)((buffer[0] << 8) | (buffer[1] - 2));
		return true;
	}

	public bool TryReadBytes(int length, out ReadOnlySequence<byte> bytes)
	{
		ReadOnlySequence<byte> data = _data;
		if (data.Length < length)
		{
			bytes = default(ReadOnlySequence<byte>);
			return false;
		}
		bytes = data.Slice(0, length);
		_data = data.Slice(length);
		return true;
	}

	public readonly bool TryPeekBytes(int length, out ReadOnlySequence<byte> bytes)
	{
		ReadOnlySequence<byte> data = _data;
		if (data.Length < length)
		{
			bytes = default(ReadOnlySequence<byte>);
			return false;
		}
		bytes = data.Slice(0, length);
		return true;
	}

	public bool TryAdvance(int length)
	{
		if (_data.Length < length)
		{
			return false;
		}
		_data = _data.Slice(length);
		return true;
	}
}
