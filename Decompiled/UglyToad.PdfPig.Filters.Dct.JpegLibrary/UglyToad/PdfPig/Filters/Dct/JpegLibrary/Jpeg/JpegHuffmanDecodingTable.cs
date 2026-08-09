using System;
using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal sealed class JpegHuffmanDecodingTable
{
	public struct Entry
	{
		public byte CodeSize { get; set; }

		public byte SymbolValue { get; set; }
	}

	private byte[]? _values;

	private ushort[]? _maxCode;

	private byte[]? _valOffset;

	private Entry[]? _lookaheadTable;

	public byte TableClass { get; }

	public byte Identifier { get; }

	internal JpegHuffmanDecodingTable(byte tableClass, byte identifier)
	{
		TableClass = tableClass;
		Identifier = identifier;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Entry Lookup(int code16bit)
	{
		int num = code16bit >> 8;
		Entry result = _lookaheadTable[num];
		if (result.CodeSize != 0)
		{
			return result;
		}
		return LookupSlow(code16bit);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Entry LookupSlow(int code16bit)
	{
		ushort[] maxCode = _maxCode;
		int i;
		for (i = 9; code16bit > maxCode[i]; i++)
		{
		}
		if (i > 16)
		{
			throw new InvalidDataException("Invalid Huffman code encountered.");
		}
		code16bit >>= 16 - i;
		return new Entry
		{
			CodeSize = (byte)i,
			SymbolValue = _values[(_valOffset[i] + code16bit) & 0xFF]
		};
	}

	public static bool TryParse(ReadOnlySequence<byte> buffer, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out JpegHuffmanDecodingTable? huffmanTable, out int bytesConsumed)
	{
		ReadOnlyMemory<byte> first;
		if (buffer.IsSingleSegment)
		{
			first = buffer.First;
			return TryParse(first.Span, out huffmanTable, out bytesConsumed);
		}
		bytesConsumed = 0;
		if (buffer.IsEmpty)
		{
			huffmanTable = null;
			return false;
		}
		first = buffer.First;
		byte b = first.Span[0];
		bytesConsumed++;
		return TryParse((byte)(b >> 4), (byte)(b & 0xF), buffer.Slice(1L), out huffmanTable, ref bytesConsumed);
	}

	public static bool TryParse(ReadOnlySpan<byte> buffer, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out JpegHuffmanDecodingTable? huffmanTable, out int bytesConsumed)
	{
		bytesConsumed = 0;
		if (buffer.IsEmpty)
		{
			huffmanTable = null;
			return false;
		}
		byte b = buffer[0];
		bytesConsumed++;
		return TryParse((byte)(b >> 4), (byte)(b & 0xF), buffer.Slice(1), out huffmanTable, ref bytesConsumed);
	}

	public static bool TryParse(byte tableClass, byte identifier, ReadOnlySequence<byte> buffer, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out JpegHuffmanDecodingTable? huffmanTable, ref int bytesConsumed)
	{
		if (buffer.IsSingleSegment)
		{
			return TryParse(tableClass, identifier, buffer.First.Span, out huffmanTable, ref bytesConsumed);
		}
		if (buffer.Length < 16)
		{
			huffmanTable = null;
			return false;
		}
		Span<byte> span = stackalloc byte[16];
		buffer.Slice(0, 16).CopyTo(span);
		int num = 0;
		for (int num2 = 15; num2 >= 0; num2--)
		{
			num += span[num2];
		}
		if (num > 256)
		{
			huffmanTable = null;
			return false;
		}
		Span<byte> span2 = stackalloc byte[257];
		GenerateSizeTable(span, span2);
		buffer = buffer.Slice(16L);
		bytesConsumed += 16;
		if (buffer.Length < num)
		{
			huffmanTable = null;
			return false;
		}
		Span<ushort> span3 = stackalloc ushort[257];
		GenerateCodeTable(span2, span3);
		bytesConsumed += num;
		Span<byte> span4 = stackalloc byte[num];
		buffer.Slice(0, num).CopyTo(span4);
		huffmanTable = new JpegHuffmanDecodingTable(tableClass, identifier);
		huffmanTable.Configure(span, span3, span4);
		return true;
	}

	public static bool TryParse(byte tableClass, byte identifier, ReadOnlySpan<byte> buffer, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out JpegHuffmanDecodingTable? huffmanTable, ref int bytesConsumed)
	{
		if (buffer.Length < 16)
		{
			huffmanTable = null;
			return false;
		}
		int num = 0;
		for (int num2 = 15; num2 >= 0; num2--)
		{
			num += buffer[num2];
		}
		if (num > 256)
		{
			huffmanTable = null;
			return false;
		}
		ReadOnlySpan<byte> readOnlySpan = buffer.Slice(0, 16);
		Span<byte> span = stackalloc byte[257];
		GenerateSizeTable(readOnlySpan, span);
		buffer = buffer.Slice(16);
		bytesConsumed += 16;
		if (buffer.Length < num)
		{
			huffmanTable = null;
			return false;
		}
		Span<ushort> span2 = stackalloc ushort[257];
		GenerateCodeTable(span, span2);
		bytesConsumed += num;
		huffmanTable = new JpegHuffmanDecodingTable(tableClass, identifier);
		huffmanTable.Configure(readOnlySpan, span2, buffer.Slice(0, num));
		return true;
	}

	private static int GenerateSizeTable(ReadOnlySpan<byte> bits, Span<byte> huffSize)
	{
		int num = 0;
		for (int i = 1; i <= 16; i++)
		{
			int num2 = 1;
			while (num2++ <= bits[i - 1])
			{
				huffSize[num++] = (byte)i;
			}
		}
		huffSize[num] = 0;
		return num;
	}

	private static void GenerateCodeTable(ReadOnlySpan<byte> huffSize, Span<ushort> huffCode)
	{
		int num = 0;
		int num2 = 0;
		int num3 = huffSize[0];
		while (true)
		{
			huffCode[num] = (ushort)num2;
			num2++;
			num++;
			if (huffSize[num] != num3)
			{
				if (huffSize[num] == 0)
				{
					break;
				}
				do
				{
					num2 <<= 1;
					num3++;
				}
				while (huffSize[num] != num3);
			}
		}
	}

	private void Configure(ReadOnlySpan<byte> codeLengths, ReadOnlySpan<ushort> huffCode, ReadOnlySpan<byte> values)
	{
		_values = new byte[256];
		_maxCode = new ushort[18];
		_valOffset = new byte[19];
		_lookaheadTable = new Entry[256];
		values.CopyTo(_values);
		int num = 0;
		for (int i = 1; i <= 16; i++)
		{
			if (codeLengths[i - 1] != 0)
			{
				int num2 = num - huffCode[num];
				_valOffset[i] = (byte)num2;
				num += codeLengths[i - 1];
				_maxCode[i] = huffCode[num - 1];
				ref ushort reference = ref _maxCode[i];
				reference = (ushort)(reference << 16 - i);
				_maxCode[i] = (ushort)(_maxCode[i] | ((1 << 16 - i) - 1));
			}
			else
			{
				_maxCode[i] = 0;
			}
		}
		_valOffset[18] = 0;
		_maxCode[17] = ushort.MaxValue;
		num = 0;
		for (int j = 1; j <= 8; j++)
		{
			int num3 = 0;
			while (num3 < codeLengths[j - 1])
			{
				FillByteLookupTable(huffCode[num], (byte)j, _values[num]);
				num3++;
				num++;
			}
		}
	}

	private void FillByteLookupTable(int code, byte codeSize, byte value)
	{
		Entry[] lookaheadTable = _lookaheadTable;
		int num = 8 - codeSize;
		code = (byte)(code << num);
		for (int i = 0; i < 1 << num; i++)
		{
			lookaheadTable[code + i] = new Entry
			{
				CodeSize = codeSize,
				SymbolValue = value
			};
		}
	}
}
