using System;
using System.Buffers;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal readonly struct JpegQuantizationTable
{
	private readonly ushort[] _elements;

	public byte ElementPrecision { get; }

	public byte Identifier { get; }

	public ReadOnlySpan<ushort> Elements => _elements;

	public bool IsEmpty
	{
		get
		{
			if (ElementPrecision == 0 && Identifier == 0)
			{
				return _elements == null;
			}
			return false;
		}
	}

	public byte BytesRequired
	{
		get
		{
			if (ElementPrecision != 0)
			{
				return 129;
			}
			return 65;
		}
	}

	public JpegQuantizationTable(byte elementPrecision, byte identifier, ushort[] elements)
	{
		ElementPrecision = elementPrecision;
		Identifier = identifier;
		_elements = elements ?? throw new ArgumentNullException("elements");
		if (elements.Length != 64)
		{
			throw new ArgumentException("The length of elements must be 64.");
		}
	}

	public static bool TryParse(ReadOnlySequence<byte> buffer, out JpegQuantizationTable quantizationTable, out int bytesConsumed)
	{
		ReadOnlyMemory<byte> first;
		if (buffer.IsSingleSegment)
		{
			first = buffer.First;
			return TryParse(first.Span, out quantizationTable, out bytesConsumed);
		}
		bytesConsumed = 0;
		if (buffer.IsEmpty)
		{
			quantizationTable = default(JpegQuantizationTable);
			return false;
		}
		first = buffer.First;
		byte b = first.Span[0];
		bytesConsumed++;
		return TryParse((byte)(b >> 4), (byte)(b & 0xF), buffer.Slice(1L), out quantizationTable, ref bytesConsumed);
	}

	public static bool TryParse(ReadOnlySpan<byte> buffer, out JpegQuantizationTable quantizationTable, out int bytesConsumed)
	{
		bytesConsumed = 0;
		if (buffer.IsEmpty)
		{
			quantizationTable = default(JpegQuantizationTable);
			return false;
		}
		byte b = buffer[0];
		bytesConsumed++;
		return TryParse((byte)(b >> 4), (byte)(b & 0xF), buffer.Slice(1), out quantizationTable, ref bytesConsumed);
	}

	public static bool TryParse(byte precision, byte identifier, ReadOnlySequence<byte> buffer, out JpegQuantizationTable quantizationTable, ref int bytesConsumed)
	{
		if (buffer.IsSingleSegment)
		{
			return TryParse(precision, identifier, buffer.First.Span, out quantizationTable, ref bytesConsumed);
		}
		Span<byte> destination = stackalloc byte[128];
		ushort[] array;
		switch (precision)
		{
		case 0:
		{
			if (buffer.Length < 64)
			{
				quantizationTable = default(JpegQuantizationTable);
				return false;
			}
			buffer.Slice(0, 64).CopyTo(destination);
			array = new ushort[64];
			for (int j = 0; j < 64; j++)
			{
				array[j] = destination[j];
			}
			bytesConsumed += 64;
			break;
		}
		case 1:
		{
			if (buffer.Length < 128)
			{
				quantizationTable = default(JpegQuantizationTable);
				return false;
			}
			buffer.Slice(0, 128).CopyTo(destination);
			array = new ushort[64];
			for (int i = 0; i < 64; i++)
			{
				array[i] = (ushort)((destination[2 * i] << 8) | destination[2 * i + 1]);
			}
			bytesConsumed += 128;
			break;
		}
		default:
			quantizationTable = default(JpegQuantizationTable);
			return false;
		}
		quantizationTable = new JpegQuantizationTable(precision, identifier, array);
		return true;
	}

	public static bool TryParse(byte precision, byte identifier, ReadOnlySpan<byte> buffer, out JpegQuantizationTable quantizationTable, ref int bytesConsumed)
	{
		ushort[] array;
		switch (precision)
		{
		case 0:
		{
			if (buffer.Length < 64)
			{
				quantizationTable = default(JpegQuantizationTable);
				return false;
			}
			array = new ushort[64];
			for (int j = 0; j < 64; j++)
			{
				array[j] = buffer[j];
			}
			bytesConsumed += 64;
			break;
		}
		case 1:
		{
			if (buffer.Length < 128)
			{
				quantizationTable = default(JpegQuantizationTable);
				return false;
			}
			array = new ushort[64];
			for (int i = 0; i < 64; i++)
			{
				array[i] = (ushort)((buffer[2 * i] << 8) | buffer[2 * i + 1]);
			}
			bytesConsumed += 128;
			break;
		}
		default:
			quantizationTable = default(JpegQuantizationTable);
			return false;
		}
		quantizationTable = new JpegQuantizationTable(precision, identifier, array);
		return true;
	}

	public bool TryWrite(Span<byte> buffer, out int bytesWritten)
	{
		bytesWritten = 0;
		if (buffer.IsEmpty)
		{
			return false;
		}
		buffer[0] = (byte)((ElementPrecision << 4) | (Identifier & 0xF));
		buffer = buffer.Slice(1);
		bytesWritten++;
		ReadOnlySpan<ushort> elements = Elements;
		if (ElementPrecision == 0)
		{
			if (buffer.Length < 64)
			{
				return false;
			}
			for (int i = 0; i < 64; i++)
			{
				buffer[i] = (byte)elements[i];
			}
			bytesWritten += 64;
		}
		else if (ElementPrecision == 1)
		{
			if (buffer.Length < 128)
			{
				return false;
			}
			for (int j = 0; j < 64; j++)
			{
				buffer[2 * j] = (byte)(elements[j] >> 8);
				buffer[2 * j + 1] = (byte)elements[j];
			}
			bytesWritten += 128;
		}
		return true;
	}
}
