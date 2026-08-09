using System.Collections.Generic;
using System.Globalization;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Parser.FileStructure;

internal static class XrefBruteForcer
{
	public class Result(IReadOnlyList<IXrefSection> xRefParts, IReadOnlyDictionary<IndirectReference, long> objectOffsets, DictionaryToken? lastTrailer)
	{
		public IReadOnlyList<IXrefSection> XRefParts { get; } = xRefParts;

		public IReadOnlyDictionary<IndirectReference, long> ObjectOffsets { get; } = objectOffsets;

		public DictionaryToken? LastTrailer { get; } = lastTrailer;
	}

	public static Result FindAllXrefsInFileOrder(IInputBytes bytes, ISeekableTokenScanner scanner, ILog log)
	{
		List<IXrefSection> list = new List<IXrefSection>();
		HashSet<long> hashSet = new HashSet<long>();
		Dictionary<IndirectReference, long> dictionary = new Dictionary<IndirectReference, long>();
		DictionaryToken lastTrailer = null;
		bytes.Seek(0L);
		CircularByteBuffer circularByteBuffer = new CircularByteBuffer(10);
		List<byte> numberByteBuffer = new List<byte>();
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		long[] numericsQueue = new long[2];
		long[] positionsQueue = new long[2];
		long? num = null;
		while (bytes.MoveNext() && !bytes.IsAtEnd())
		{
			if (bytes.CurrentByte == 37)
			{
				flag3 = true;
				if (flag && numberByteBuffer.Count > 0)
				{
					if (long.TryParse(OtherEncodings.BytesAsLatin1String(numberByteBuffer.ToArray()), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
					{
						AddQueues(result);
					}
					numberByteBuffer.Clear();
				}
				flag = false;
				flag2 = false;
			}
			if (ReadHelper.IsWhitespace(bytes.CurrentByte))
			{
				if (ReadHelper.IsEndOfLine(bytes.CurrentByte))
				{
					flag3 = false;
				}
				circularByteBuffer.Add(32);
				if (flag && numberByteBuffer.Count > 0)
				{
					if (long.TryParse(OtherEncodings.BytesAsLatin1String(numberByteBuffer.ToArray()), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result2))
					{
						AddQueues(result2);
					}
					numberByteBuffer.Clear();
				}
				flag2 = true;
				flag = false;
			}
			else
			{
				circularByteBuffer.Add(bytes.CurrentByte);
				if (!flag3 && ReadHelper.IsDigit(bytes.CurrentByte) && (flag || flag2))
				{
					flag = true;
					numberByteBuffer.Add(bytes.CurrentByte);
				}
				else
				{
					flag = false;
					numberByteBuffer.Clear();
				}
				flag2 = false;
			}
			if (circularByteBuffer.EndsWith(" obj") && numericsQueue[0] > 0)
			{
				dictionary[new IndirectReference(numericsQueue[0], (int)numericsQueue[1])] = positionsQueue[0];
				num = positionsQueue[0];
				ClearQueues();
			}
			else if (circularByteBuffer.EndsWith(" xref"))
			{
				ClearQueues();
				long num2 = bytes.CurrentOffset - 4;
				if (hashSet.Contains(num2))
				{
					log.Debug($"Skipping circular xref reference at {num2}");
					continue;
				}
				hashSet.Add(num2);
				XrefTable xrefTable = XrefTableParser.TryReadTableAtOffset(new FileHeaderOffset(0), num2, bytes, scanner, log);
				if (xrefTable != null)
				{
					list.Add(xrefTable);
				}
				else
				{
					log.Warn($"Found a table at {num2} but couldn't parse it.");
				}
			}
			else if (circularByteBuffer.EndsWith("/XRef"))
			{
				ClearQueues();
				if (num.HasValue)
				{
					long valueOrDefault = num.GetValueOrDefault();
					if (hashSet.Contains(valueOrDefault))
					{
						log.Debug($"Skipping circular /XRef reference at {valueOrDefault}");
						continue;
					}
					hashSet.Add(valueOrDefault);
					XrefStream xrefStream = XrefStreamParser.TryReadStreamAtOffset(new FileHeaderOffset(0), valueOrDefault, bytes, scanner, log);
					if (xrefStream != null)
					{
						list.Add(xrefStream);
					}
				}
				else
				{
					log.Error("Found an /XRef without having encountered an object first");
				}
			}
			else if (circularByteBuffer.EndsWith("trailer "))
			{
				ClearQueues();
				if (scanner.TryReadToken<DictionaryToken>(out var token))
				{
					lastTrailer = token;
				}
			}
		}
		return new Result(list, dictionary, lastTrailer);
		void AddQueues(long num3)
		{
			numericsQueue[0] = numericsQueue[1];
			numericsQueue[1] = num3;
			positionsQueue[0] = positionsQueue[1];
			positionsQueue[1] = bytes.CurrentOffset - numberByteBuffer.Count - 1;
		}
		void ClearQueues()
		{
			numericsQueue[0] = 0L;
			numericsQueue[1] = 0L;
			positionsQueue[0] = 0L;
			positionsQueue[1] = 0L;
		}
	}
}
