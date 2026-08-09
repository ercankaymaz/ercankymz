using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Parser.Parts;

internal static class BruteForceSearcher
{
	private const int MinimumSearchOffset = 6;

	public static IReadOnlyDictionary<IndirectReference, long> GetObjectLocations(IInputBytes bytes)
	{
		if (bytes == null)
		{
			throw new ArgumentNullException("bytes");
		}
		int num = 0;
		long lastEndOfFileMarker = GetLastEndOfFileMarker(bytes);
		Dictionary<IndirectReference, long> dictionary = new Dictionary<IndirectReference, long>();
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		long currentOffset = bytes.CurrentOffset;
		long num2 = 6L;
		bool flag = false;
		byte[] array = new byte[4];
		do
		{
			if (num > 10000000)
			{
				throw new PdfDocumentFormatException("Failed to brute-force search the file due to an infinite loop.");
			}
			num++;
			if (flag)
			{
				if (bytes.CurrentByte == 101)
				{
					byte? b = bytes.Peek();
					if (b.HasValue && b == 110)
					{
						if (ReadHelper.IsString(bytes, "endobj"))
						{
							flag = false;
							num = 0;
							for (int i = 0; i < "endobj".Length; i++)
							{
								bytes.MoveNext();
								num2++;
							}
						}
						else
						{
							bytes.MoveNext();
							num2++;
						}
					}
					else
					{
						bytes.MoveNext();
						num2++;
					}
				}
				else if (ReadHelper.IsWhitespace(bytes.CurrentByte))
				{
					byte? b2 = bytes.Peek();
					if (b2.HasValue && b2.Value == 111)
					{
						if (ReadHelper.IsString(bytes, " obj"))
						{
							flag = false;
							num2--;
							num = 0;
						}
						else
						{
							bytes.MoveNext();
							num2++;
							num = 0;
						}
					}
					else
					{
						bytes.MoveNext();
						num2++;
						num = 0;
					}
				}
				else
				{
					bytes.MoveNext();
					num2++;
					num = 0;
				}
				continue;
			}
			bytes.Seek(num2);
			bytes.Read(array);
			if (!IsStartObjMarker(array))
			{
				num2++;
				continue;
			}
			long num3 = num2 + 1;
			bytes.Seek(num3);
			while (ReadHelper.IsWhitespace(bytes.CurrentByte) && num3 >= 6)
			{
				bytes.Seek(--num3);
			}
			while (ReadHelper.IsDigit(bytes.CurrentByte) && num3 >= 6)
			{
				stringBuilder.Insert(0, (char)bytes.CurrentByte);
				num3--;
				bytes.Seek(num3);
			}
			if (!ReadHelper.IsWhitespace(bytes.CurrentByte))
			{
				num2++;
				continue;
			}
			while (ReadHelper.IsWhitespace(bytes.CurrentByte))
			{
				bytes.Seek(--num3);
			}
			while (ReadHelper.IsDigit(bytes.CurrentByte) && num3 >= 6)
			{
				stringBuilder2.Insert(0, (char)bytes.CurrentByte);
				num3--;
				bytes.Seek(num3);
			}
			if (stringBuilder2.Length == 0 || stringBuilder.Length == 0)
			{
				stringBuilder.Clear();
				stringBuilder2.Clear();
				num2++;
				continue;
			}
			long objectNumber = long.Parse(stringBuilder2.ToString(), CultureInfo.InvariantCulture);
			int generation = int.Parse(stringBuilder.ToString(), CultureInfo.InvariantCulture);
			dictionary[new IndirectReference(objectNumber, generation)] = bytes.CurrentOffset;
			stringBuilder.Clear();
			stringBuilder2.Clear();
			flag = true;
			num2 += array.Length;
			bytes.Seek(num2);
			num = 0;
		}
		while (num2 < lastEndOfFileMarker && !bytes.IsAtEnd());
		bytes.Seek(currentOffset);
		return dictionary;
	}

	private static long GetLastEndOfFileMarker(IInputBytes bytes)
	{
		long currentOffset = bytes.CurrentOffset;
		long position = bytes.Length - "%%EOF".Length + 1;
		bytes.Seek(position);
		while (bytes.CurrentOffset > 0)
		{
			if (ReadHelper.IsString(bytes, "%%EOF"))
			{
				long currentOffset2 = bytes.CurrentOffset;
				bytes.Seek(currentOffset);
				return currentOffset2;
			}
			bytes.Seek(position--);
		}
		bytes.Seek(currentOffset);
		return long.MaxValue;
	}

	private static bool IsStartObjMarker(ReadOnlySpan<byte> data)
	{
		if (!ReadHelper.IsWhitespace(data[0]))
		{
			return false;
		}
		if ((data[1] == 111 || data[1] == 79) && (data[2] == 98 || data[2] == 66))
		{
			if (data[3] != 106)
			{
				return data[3] == 74;
			}
			return true;
		}
		return false;
	}
}
