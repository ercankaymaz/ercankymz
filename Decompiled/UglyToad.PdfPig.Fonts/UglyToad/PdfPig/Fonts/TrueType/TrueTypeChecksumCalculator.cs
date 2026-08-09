using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Fonts.TrueType;

public static class TrueTypeChecksumCalculator
{
	private const string HeaderTableTag = "head";

	private const int ChecksumAdjustmentPosition = 8;

	public static uint CalculateWholeFontChecksum(IInputBytes bytes, TrueTypeHeaderTable headerTable)
	{
		if (bytes == null)
		{
			throw new ArgumentNullException("bytes");
		}
		if (!IsHeadTable(headerTable))
		{
			throw new ArgumentException($"Can only calculate checksum for the whole font when the head table is provided. Got: {headerTable}.");
		}
		bytes.Seek(0L);
		return Calculate(ToChecksumSkippedEnumerable(bytes, headerTable));
	}

	public static uint Calculate(IInputBytes bytes, TrueTypeHeaderTable table)
	{
		bytes.Seek(table.Offset);
		if (IsHeadTable(table))
		{
			byte[] array = new byte[table.Length];
			if (bytes.Read(array) != table.Length)
			{
				throw new InvalidOperationException();
			}
			array[8] = 0;
			array[9] = 0;
			array[10] = 0;
			array[11] = 0;
			return Calculate(array);
		}
		uint num = 0u;
		uint result;
		while (TryReadUInt(bytes, table.Offset + table.Length, out result))
		{
			num += result;
		}
		return num;
	}

	public static uint Calculate(IEnumerable<byte> bytes)
	{
		uint num = 0u;
		using IEnumerator<byte> enumerator = bytes.GetEnumerator();
		uint result;
		while (TryReadUInt(enumerator, out result))
		{
			num += result;
		}
		return num;
	}

	private static bool IsHeadTable(TrueTypeHeaderTable table)
	{
		return string.Equals("head", table.Tag, StringComparison.OrdinalIgnoreCase);
	}

	private static bool TryReadUInt(IEnumerator<byte> enumerator, out uint result)
	{
		result = 0u;
		if (!enumerator.MoveNext())
		{
			return false;
		}
		byte current = enumerator.Current;
		int num = (enumerator.MoveNext() ? enumerator.Current : 0);
		int num2 = (enumerator.MoveNext() ? enumerator.Current : 0);
		int num3 = (enumerator.MoveNext() ? enumerator.Current : 0);
		result = (uint)((long)((ulong)current << 24) + ((long)num << 16) + (num2 << 8) + num3);
		return true;
	}

	private static bool TryReadUInt(IInputBytes input, long endAt, out uint result)
	{
		result = 0u;
		if (input.CurrentOffset >= endAt)
		{
			return false;
		}
		byte b = ReadNext();
		byte b2 = ReadNext();
		byte b3 = ReadNext();
		byte b4 = ReadNext();
		result = (uint)((long)(((ulong)b << 24) + ((ulong)b2 << 16)) + (long)(b3 << 8) + (int)b4);
		return true;
		byte ReadNext()
		{
			if (input.CurrentOffset == endAt || !input.MoveNext())
			{
				return 0;
			}
			return input.CurrentByte;
		}
	}

	private static IEnumerable<byte> ToChecksumSkippedEnumerable(IInputBytes bytes, TrueTypeHeaderTable table)
	{
		while (bytes.MoveNext())
		{
			if (bytes.CurrentOffset <= table.Offset + 8 || bytes.CurrentOffset > table.Offset + 8 + 4)
			{
				yield return bytes.CurrentByte;
			}
		}
	}
}
