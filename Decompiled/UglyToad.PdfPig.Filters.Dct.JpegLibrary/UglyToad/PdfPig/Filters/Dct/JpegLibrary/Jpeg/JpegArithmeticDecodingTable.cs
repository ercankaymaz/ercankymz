using System;
using System.Buffers;
using System.Diagnostics.CodeAnalysis;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg;

internal sealed class JpegArithmeticDecodingTable
{
	public byte TableClass { get; }

	public byte Identifier { get; }

	public byte ConditioningTableValue { get; private set; }

	public int DcL { get; private set; }

	public int DcU { get; private set; }

	public int AcKx { get; private set; }

	public JpegArithmeticDecodingTable(byte tableClass, byte identifier)
	{
		TableClass = tableClass;
		Identifier = identifier;
	}

	public void Configure(byte conditioningTableValue)
	{
		ConditioningTableValue = conditioningTableValue;
		if (TableClass == 0)
		{
			DcL = conditioningTableValue & 0xF;
			DcU = conditioningTableValue >> 4;
			AcKx = 0;
		}
		else
		{
			DcL = 0;
			DcU = 0;
			AcKx = conditioningTableValue;
		}
	}

	public static bool TryParse(ReadOnlySequence<byte> buffer, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out JpegArithmeticDecodingTable? arithmeticTable, out int bytesConsumed)
	{
		ReadOnlySpan<byte> span = buffer.First.Span;
		if (span.Length >= 2)
		{
			return TryParse(span, out arithmeticTable, out bytesConsumed);
		}
		bytesConsumed = 0;
		if (span.IsEmpty)
		{
			arithmeticTable = null;
			return false;
		}
		byte b = span[0];
		bytesConsumed++;
		return TryParse((byte)(b >> 4), (byte)(b & 0xF), buffer.Slice(1L), out arithmeticTable, ref bytesConsumed);
	}

	public static bool TryParse(ReadOnlySpan<byte> buffer, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out JpegArithmeticDecodingTable? arithmeticTable, out int bytesConsumed)
	{
		bytesConsumed = 0;
		if (buffer.IsEmpty)
		{
			arithmeticTable = null;
			return false;
		}
		byte b = buffer[0];
		bytesConsumed++;
		return TryParse((byte)(b >> 4), (byte)(b & 0xF), buffer.Slice(1), out arithmeticTable, ref bytesConsumed);
	}

	public static bool TryParse(byte tableClass, byte identifier, ReadOnlySequence<byte> buffer, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out JpegArithmeticDecodingTable? arithmeticTable, ref int bytesConsumed)
	{
		ReadOnlySpan<byte> span = buffer.First.Span;
		return TryParse(tableClass, identifier, span, out arithmeticTable, ref bytesConsumed);
	}

	public static bool TryParse(byte tableClass, byte identifier, ReadOnlySpan<byte> buffer, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out JpegArithmeticDecodingTable? arithmeticTable, ref int bytesConsumed)
	{
		if (buffer.IsEmpty)
		{
			arithmeticTable = null;
			return false;
		}
		byte b = buffer[0];
		if (tableClass == 1 && (b < 1 || b > 63))
		{
			arithmeticTable = null;
			return false;
		}
		arithmeticTable = new JpegArithmeticDecodingTable(tableClass, identifier);
		arithmeticTable.Configure(b);
		bytesConsumed++;
		return true;
	}
}
