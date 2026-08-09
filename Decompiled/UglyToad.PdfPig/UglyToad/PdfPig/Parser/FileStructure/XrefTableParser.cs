using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Parser.FileStructure;

internal static class XrefTableParser
{
	private enum XrefTableReadMode
	{
		SubsectionHeader = 2,
		Entry
	}

	public static XrefTable? TryReadTableAtOffset(FileHeaderOffset fileHeaderOffset, long xrefOffset, IInputBytes bytes, ISeekableTokenScanner scanner, ILog log)
	{
		if (xrefOffset >= bytes.Length || xrefOffset < 0)
		{
			return null;
		}
		bytes.Seek(xrefOffset);
		XrefOffsetCorrection correctionType = XrefOffsetCorrection.None;
		long offsetCorrection = 0L;
		if (!TryReadXrefToken(scanner))
		{
			log.Debug($"Xref not found at {xrefOffset}, trying to recover");
			(long, XrefOffsetCorrection)? tuple = TryRecoverOffset(fileHeaderOffset, xrefOffset, bytes, scanner);
			if (!tuple.HasValue)
			{
				return null;
			}
			log.Debug($"Xref found at {tuple.Value.Item1}");
			scanner.Seek(tuple.Value.Item1);
			if (!TryReadXrefToken(scanner))
			{
				return null;
			}
			correctionType = tuple.Value.Item2;
			offsetCorrection = tuple.Value.Item1 - xrefOffset;
			xrefOffset = tuple.Value.Item1;
		}
		List<long> readNums = new List<long>();
		DictionaryToken dictionaryToken = null;
		int num = 0;
		bool flag = false;
		int num2 = 0;
		XrefTableReadMode xrefTableReadMode = XrefTableReadMode.SubsectionHeader;
		while (scanner.MoveNext())
		{
			if (xrefTableReadMode == XrefTableReadMode.Entry && num2 <= 0)
			{
				xrefTableReadMode = XrefTableReadMode.SubsectionHeader;
			}
			num++;
			IToken currentToken = scanner.CurrentToken;
			if (currentToken is NumericToken numericToken)
			{
				readNums.Add(numericToken.Long);
				if (xrefTableReadMode == XrefTableReadMode.SubsectionHeader && num == 2)
				{
					xrefTableReadMode = XrefTableReadMode.Entry;
					num2 = (int)numericToken.Long;
					flag = true;
				}
				else if (xrefTableReadMode == XrefTableReadMode.Entry && num > 2)
				{
					if (!flag)
					{
						return null;
					}
					flag = false;
					num = 1;
				}
			}
			else if (currentToken is OperatorToken operatorToken)
			{
				if (string.Equals("f", operatorToken.Data, StringComparison.OrdinalIgnoreCase) && num == 3)
				{
					readNums.Add(0L);
					num = 0;
					num2--;
					readNums.Insert(readNums.Count - 3, -1L);
					continue;
				}
				if (!string.Equals("n", operatorToken.Data, StringComparison.OrdinalIgnoreCase) || num != 3)
				{
					if (string.Equals(operatorToken.Data, "trailer", StringComparison.OrdinalIgnoreCase))
					{
						if (scanner.TryReadToken<DictionaryToken>(out var token))
						{
							dictionaryToken = token;
							break;
						}
						return null;
					}
					if (xrefTableReadMode == XrefTableReadMode.SubsectionHeader)
					{
						if (string.Equals(operatorToken.Data, "obj", StringComparison.OrdinalIgnoreCase))
						{
							readNums.RemoveRange(readNums.Count - 2, 2);
						}
						break;
					}
					return null;
				}
				readNums.Add(1L);
				num = 0;
				num2--;
				readNums.Insert(readNums.Count - 3, -1L);
			}
			else if (currentToken is CommentToken)
			{
				num--;
			}
			else if (!(currentToken is CommentToken))
			{
				break;
			}
		}
		Dictionary<IndirectReference, long> dictionary = new Dictionary<IndirectReference, long>();
		if (readNums.Count == 0)
		{
			if (dictionaryToken != null)
			{
				return new XrefTable(xrefOffset, dictionary, dictionaryToken, correctionType, offsetCorrection);
			}
			return null;
		}
		long[] buff = new long[4];
		long num3 = -1L;
		int ix = 0;
		do
		{
			if (!TryReadBuff(2))
			{
				return null;
			}
			long num4 = buff[0];
			long num5 = buff[1];
			if (num4 != -1)
			{
				num3 = num4;
			}
			else
			{
				if (num3 == -1)
				{
					return null;
				}
				num5 = 1L;
				ix -= 2;
			}
			for (int i = 0; i < num5; i++)
			{
				if (!TryReadBuff(4))
				{
					return null;
				}
				long num6 = buff[0];
				long value = buff[1];
				long num7 = buff[2];
				long num8 = buff[3];
				if (num6 != -1)
				{
					return null;
				}
				if (num8 == 1)
				{
					IndirectReference key = new IndirectReference(num3, (int)num7);
					dictionary[key] = value;
				}
				num3++;
			}
		}
		while (ix < readNums.Count);
		return new XrefTable(xrefOffset, dictionary, dictionaryToken, correctionType, offsetCorrection);
		bool TryReadBuff(int len)
		{
			for (int j = 0; j < len; j++)
			{
				if (ix >= readNums.Count)
				{
					return false;
				}
				buff[j] = readNums[ix++];
			}
			return true;
		}
	}

	private static bool TryReadXrefToken(ISeekableTokenScanner scanner)
	{
		if (!scanner.TryReadToken<OperatorToken>(out var token))
		{
			return false;
		}
		if (string.Equals("xref", token.Data, StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		if (token.Data.StartsWith("xref", StringComparison.OrdinalIgnoreCase))
		{
			int num = token.Data.Length - "xref".Length;
			scanner.Seek(scanner.CurrentPosition - num);
			return true;
		}
		return false;
	}

	private static (long correctOffset, XrefOffsetCorrection correctionType)? TryRecoverOffset(FileHeaderOffset fileHeaderOffset, long xrefOffset, IInputBytes bytes, ISeekableTokenScanner scanner)
	{
		if (fileHeaderOffset.Value > 0)
		{
			scanner.Seek(xrefOffset + fileHeaderOffset.Value);
			if (TryReadXrefToken(scanner))
			{
				return (xrefOffset + fileHeaderOffset.Value, XrefOffsetCorrection.FileHeaderOffset);
			}
		}
		byte[] array = new byte[20];
		long num = Math.Max(0L, xrefOffset - 10);
		bytes.Seek(num);
		if (bytes.Read(array) < array.Length)
		{
			return null;
		}
		int num2 = OtherEncodings.BytesAsLatin1String(array).IndexOf("xref", StringComparison.OrdinalIgnoreCase);
		if (num2 < 0)
		{
			return null;
		}
		long num3 = num + num2;
		scanner.Seek(num3);
		if (TryReadXrefToken(scanner))
		{
			return (num3, XrefOffsetCorrection.Random);
		}
		return null;
	}
}
