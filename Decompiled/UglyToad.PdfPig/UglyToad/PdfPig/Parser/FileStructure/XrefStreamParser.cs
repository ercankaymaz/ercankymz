using System;
using System.Collections.Generic;
using System.Linq;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Filters;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Parser.FileStructure;

internal static class XrefStreamParser
{
	private class XrefFieldSize
	{
		public int Field1Size { get; }

		public int Field2Size { get; }

		public int Field3Size { get; }

		public int LineLength { get; }

		public XrefFieldSize(ArrayToken wArray)
		{
			if (wArray.Data.Count < 3)
			{
				throw new PdfDocumentFormatException($"There must be at least 3 entries in a W entry for a stream dictionary: {wArray}.");
			}
			Field1Size = wArray.GetNumeric(0).Int;
			Field2Size = wArray.GetNumeric(1).Int;
			Field3Size = wArray.GetNumeric(2).Int;
			LineLength = Field1Size + Field2Size + Field3Size;
		}
	}

	public static XrefStream? TryReadStreamAtOffset(FileHeaderOffset fileHeaderOffset, long xrefOffset, IInputBytes bytes, ISeekableTokenScanner scanner, ILog log)
	{
		if (xrefOffset >= bytes.Length || xrefOffset < 0)
		{
			return null;
		}
		XrefOffsetCorrection correctionType = XrefOffsetCorrection.None;
		long offsetCorrection = 0L;
		bytes.Seek(xrefOffset);
		if (!TryReadStreamObjAt(xrefOffset, scanner, out DictionaryToken dictionary) || dictionary == null)
		{
			log.Debug($"Did not find the stream at {xrefOffset} attempting correction");
			(long, XrefOffsetCorrection)? tuple = TryRecoverOffset(fileHeaderOffset, xrefOffset, scanner);
			if (!tuple.HasValue || !TryReadStreamObjAt(tuple.Value.Item1, scanner, out DictionaryToken dictionary2) || dictionary2 == null)
			{
				return null;
			}
			dictionary = dictionary2;
			offsetCorrection = tuple.Value.Item1 - xrefOffset;
			correctionType = tuple.Value.Item2;
			xrefOffset = tuple.Value.Item1;
		}
		if (!dictionary.TryGet(NameToken.Type, out NameToken token) || token != NameToken.Xref)
		{
			return null;
		}
		if (!dictionary.TryGet(NameToken.W, out ArrayToken token2))
		{
			return null;
		}
		try
		{
			(long, long?) tuple2 = ReadStreamTolerant(bytes);
			if (!tuple2.Item2.HasValue)
			{
				return null;
			}
			long num = tuple2.Item2.Value - tuple2.Item1;
			if (num <= 0)
			{
				return null;
			}
			bytes.Seek(tuple2.Item1);
			byte[] array = new byte[num];
			if (bytes.Read(array) != num)
			{
				return null;
			}
			Span<byte> span = new StreamToken(dictionary, array).Decode(DefaultFilterProvider.Instance).Span;
			XrefFieldSize xrefFieldSize = new XrefFieldSize(token2);
			int num2 = span.Length / xrefFieldSize.LineLength;
			ReadOnlySpan<long> objectNumbers = GetObjectNumbers(dictionary);
			int num3 = 0;
			Span<byte> span2 = ((xrefFieldSize.LineLength > 1024) ? ((Span<byte>)new byte[xrefFieldSize.LineLength]) : stackalloc byte[xrefFieldSize.LineLength]);
			Span<byte> span3 = span2;
			List<(long, int, int)> list = new List<(long, int, int)>();
			ReadOnlySpan<long> readOnlySpan = objectNumbers;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				long objectNumber = readOnlySpan[i];
				if (num3 >= num2)
				{
					break;
				}
				int num4 = num3 * xrefFieldSize.LineLength;
				for (int j = 0; j < xrefFieldSize.LineLength; j++)
				{
					span3[j] = span[num4 + j];
				}
				int num5;
				if (xrefFieldSize.Field1Size == 0)
				{
					num5 = 1;
				}
				else
				{
					num5 = 0;
					for (int k = 0; k < xrefFieldSize.Field1Size; k++)
					{
						num5 += (span3[k] & 0xFF) << (xrefFieldSize.Field1Size - k - 1) * 8;
					}
				}
				ReadNextStreamObject(num5, objectNumber, xrefFieldSize, list, span3);
				num3++;
			}
			return new XrefStream(xrefOffset, list.ToDictionary<(long, int, int), IndirectReference, long>(((long obj, int gen, int off) x) => new IndirectReference(x.obj, x.gen), ((long obj, int gen, int off) x) => x.off), dictionary, correctionType, offsetCorrection);
		}
		catch (Exception ex)
		{
			log.Error($"Failed to parse the XRef stream at {xrefOffset}", ex);
			return null;
		}
	}

	private static (long correctOffset, XrefOffsetCorrection correctionType)? TryRecoverOffset(FileHeaderOffset fileHeaderOffset, long xrefOffset, ISeekableTokenScanner scanner)
	{
		if (fileHeaderOffset.Value > 0 && TryReadStreamObjAt(xrefOffset + fileHeaderOffset.Value, scanner, out DictionaryToken _))
		{
			return (xrefOffset + fileHeaderOffset.Value, XrefOffsetCorrection.FileHeaderOffset);
		}
		return null;
	}

	private static void ReadNextStreamObject(int type, long objectNumber, XrefFieldSize fieldSizes, List<(long, int, int)> results, ReadOnlySpan<byte> lineBuffer)
	{
		switch (type)
		{
		case 1:
		{
			int num2 = 0;
			for (int j = 0; j < fieldSizes.Field2Size; j++)
			{
				num2 += (lineBuffer[j + fieldSizes.Field1Size] & 0xFF) << (fieldSizes.Field2Size - j - 1) * 8;
			}
			int num3 = 0;
			for (int k = 0; k < fieldSizes.Field3Size; k++)
			{
				num3 += (lineBuffer[k + fieldSizes.Field1Size + fieldSizes.Field2Size] & 0xFF) << (fieldSizes.Field3Size - k - 1) * 8;
			}
			results.Add((objectNumber, num3, num2));
			break;
		}
		case 2:
		{
			int num = 0;
			for (int i = 0; i < fieldSizes.Field2Size; i++)
			{
				num += (lineBuffer[i + fieldSizes.Field1Size] & 0xFF) << (fieldSizes.Field2Size - i - 1) * 8;
			}
			results.Add((objectNumber, 0, -num));
			break;
		}
		case 0:
			break;
		}
	}

	private static (long from, long? to) ReadStreamTolerant(IInputBytes bytes)
	{
		CircularByteBuffer circularByteBuffer = new CircularByteBuffer("endstream ".Length);
		long currentOffset = bytes.CurrentOffset;
		long? item = null;
		while (bytes.CurrentByte == 62 && bytes.MoveNext())
		{
		}
		bool flag = IsStreamWhitespace();
		do
		{
			if (IsStreamWhitespace())
			{
				circularByteBuffer.Add(32);
				if (flag)
				{
					currentOffset = bytes.CurrentOffset;
				}
			}
			else
			{
				circularByteBuffer.Add(bytes.CurrentByte);
				flag = false;
			}
			if (circularByteBuffer.EndsWith("endstream "))
			{
				item = bytes.CurrentOffset - "endstream ".Length;
				break;
			}
			if (circularByteBuffer.EndsWith("stream "))
			{
				currentOffset = bytes.CurrentOffset;
				flag = IsStreamWhitespace();
			}
			else if (circularByteBuffer.EndsWith("endobj "))
			{
				item = bytes.CurrentOffset - "endobj ".Length;
				break;
			}
		}
		while (bytes.MoveNext());
		return (from: currentOffset, to: item);
		bool IsStreamWhitespace()
		{
			if (bytes.CurrentByte != 32 && bytes.CurrentByte != 13)
			{
				return bytes.CurrentByte == 10;
			}
			return true;
		}
	}

	private static ReadOnlySpan<long> GetObjectNumbers(DictionaryToken dictionary)
	{
		if (!dictionary.TryGet(NameToken.Size, out var token) || !(token is NumericToken numericToken))
		{
			throw new PdfDocumentFormatException($"The stream dictionary must contain a numeric size value: {dictionary}.");
		}
		List<long> list = new List<long>();
		if (dictionary.TryGet(NameToken.Index, out var token2) && token2 is ArrayToken arrayToken)
		{
			for (int i = 0; i < arrayToken.Length; i += 2)
			{
				int num = arrayToken.GetNumeric(i).Int;
				int num2 = arrayToken.GetNumeric(i + 1).Int;
				for (int j = 0; j < num2; j++)
				{
					list.Add(num + j);
				}
			}
		}
		else
		{
			for (int k = 0; k < numericToken.Int; k++)
			{
				list.Add(k);
			}
		}
		return list.ToArray();
	}

	private static bool TryReadStreamObjAt(long offset, ISeekableTokenScanner scanner, out DictionaryToken? dictionary)
	{
		dictionary = null;
		scanner.Seek(offset);
		if (scanner.TryReadToken<NumericToken>(out var token) && scanner.TryReadToken<NumericToken>(out token) && scanner.TryReadToken<OperatorToken>(out var token2) && token2 == OperatorToken.StartObject && scanner.TryReadToken<DictionaryToken>(out var token3))
		{
			dictionary = token3;
			return true;
		}
		return false;
	}
}
