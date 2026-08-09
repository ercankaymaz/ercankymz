using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Parser.FileStructure;

internal static class FirstPassParser
{
	public record StartXRefLocation
	{
		public long? StartXRefDeclaredOffset { get; }

		public long? StartXRefOperatorToken { get; }

		public StartXRefLocation(long? StartXRefOperatorToken, long? StartXRefDeclaredOffset)
		{
			this.StartXRefDeclaredOffset = StartXRefDeclaredOffset;
			this.StartXRefOperatorToken = StartXRefOperatorToken;
			base._002Ector();
		}

		public bool IsValidOffset(IInputBytes bytes)
		{
			if (!StartXRefDeclaredOffset.HasValue || StartXRefDeclaredOffset < 0 || StartXRefDeclaredOffset > bytes.Length)
			{
				return false;
			}
			return true;
		}

		[CompilerGenerated]
		public void Deconstruct(out long? StartXRefOperatorToken, out long? StartXRefDeclaredOffset)
		{
			StartXRefOperatorToken = this.StartXRefOperatorToken;
			StartXRefDeclaredOffset = this.StartXRefDeclaredOffset;
		}
	}

	private static ReadOnlySpan<byte> StartXRefBytes => "startxref"u8;

	public static FirstPassResults Parse(FileHeaderOffset fileHeaderOffset, IInputBytes input, ISeekableTokenScanner scanner, ILog? log = null)
	{
		if (log == null)
		{
			log = new NoOpLog();
		}
		IReadOnlyDictionary<IndirectReference, long> readOnlyDictionary = null;
		bool flag = false;
		DictionaryToken dictionaryToken = null;
		StartXRefLocation firstCrossReferenceOffset = GetFirstCrossReferenceOffset(input, scanner, log);
		IReadOnlyList<IXrefSection> readOnlyList = GetXrefPartsDirectly(fileHeaderOffset, input, scanner, firstCrossReferenceOffset, log);
		if (readOnlyList.Count == 0)
		{
			XrefBruteForcer.Result result = XrefBruteForcer.FindAllXrefsInFileOrder(input, scanner, log);
			readOnlyList = result.XRefParts;
			readOnlyDictionary = result.ObjectOffsets;
			dictionaryToken = result.LastTrailer;
			flag = true;
			if (readOnlyList.Count == 0 && (readOnlyDictionary == null || readOnlyDictionary.Count == 0))
			{
				throw new PdfDocumentFormatException("Could not find any xref tables or streams in this document and could not resolve brute force positions.");
			}
		}
		List<IXrefSection> list = new List<IXrefSection>();
		if (flag)
		{
			list.AddRange(readOnlyList.OrderBy((IXrefSection x) => x.Offset));
		}
		else
		{
			list.AddRange(readOnlyList.OrderBy((IXrefSection x) => x.Offset));
		}
		DictionaryToken dictionaryToken2 = null;
		Dictionary<IndirectReference, long> dictionary = new Dictionary<IndirectReference, long>();
		foreach (IXrefSection item in list)
		{
			if (item.Dictionary != null && (item.Dictionary.ContainsKey(NameToken.Root) || dictionaryToken2 == null || !dictionaryToken2.ContainsKey(NameToken.Root)))
			{
				dictionaryToken2 = item.Dictionary;
			}
			foreach (KeyValuePair<IndirectReference, long> objectOffset in item.ObjectOffsets)
			{
				dictionary[objectOffset.Key] = objectOffset.Value;
			}
		}
		return new FirstPassResults(readOnlyList.ToList(), readOnlyDictionary, dictionary, dictionaryToken2 ?? dictionaryToken);
	}

	private static IReadOnlyList<IXrefSection> GetXrefPartsDirectly(FileHeaderOffset offset, IInputBytes input, ISeekableTokenScanner scanner, StartXRefLocation startLocation, ILog log)
	{
		if (!startLocation.StartXRefDeclaredOffset.HasValue || !startLocation.IsValidOffset(input))
		{
			return Array.Empty<IXrefSection>();
		}
		HashSet<long> hashSet = new HashSet<long>();
		List<IXrefSection> list = new List<IXrefSection>();
		long? num = startLocation.StartXRefDeclaredOffset.Value;
		do
		{
			IXrefSection xrefStreamOrTable = GetXrefStreamOrTable(offset, input, scanner, num.Value, log);
			if (!hashSet.Add(num.Value))
			{
				return Array.Empty<IXrefSection>();
			}
			if (xrefStreamOrTable == null)
			{
				return Array.Empty<IXrefSection>();
			}
			if (xrefStreamOrTable is XrefTable xrefTable)
			{
				list.Add(xrefTable);
				num = xrefTable.GetPrevious();
				long? xRefStm = xrefTable.GetXRefStm();
				if (xRefStm.HasValue)
				{
					long valueOrDefault = xRefStm.GetValueOrDefault();
					IXrefSection xrefStreamOrTable2 = GetXrefStreamOrTable(offset, input, scanner, valueOrDefault, log);
					if (xrefStreamOrTable2 != null)
					{
						list.Add(xrefStreamOrTable2);
					}
				}
			}
			else if (xrefStreamOrTable is XrefStream xrefStream)
			{
				list.Add(xrefStream);
				num = xrefStream.GetPrevious();
			}
		}
		while (num.HasValue);
		return list;
	}

	private static IXrefSection? GetXrefStreamOrTable(FileHeaderOffset fileHeaderOffset, IInputBytes input, ISeekableTokenScanner scanner, long location, ILog log)
	{
		XrefTable xrefTable = XrefTableParser.TryReadTableAtOffset(fileHeaderOffset, location, input, scanner, log);
		if (xrefTable != null)
		{
			return xrefTable;
		}
		return XrefStreamParser.TryReadStreamAtOffset(fileHeaderOffset, location, input, scanner, log);
	}

	public static StartXRefLocation GetFirstCrossReferenceOffset(IInputBytes bytes, ISeekableTokenScanner scanner, ILog log)
	{
		long length = bytes.Length;
		CircularByteBuffer circularByteBuffer = new CircularByteBuffer(StartXRefBytes.Length);
		bytes.Seek(length);
		long? startXRefOperatorToken = null;
		int num = 0;
		do
		{
			circularByteBuffer.AddReverse(bytes.CurrentByte);
			num++;
			if (num >= StartXRefBytes.Length)
			{
				if (circularByteBuffer.IsCurrentlyEqual("startxref"))
				{
					startXRefOperatorToken = bytes.CurrentOffset - 1;
					break;
				}
				if (circularByteBuffer.EndsWith("startref"))
				{
					startXRefOperatorToken = bytes.CurrentOffset;
					break;
				}
			}
			bytes.Seek(bytes.CurrentOffset - 1);
		}
		while (bytes.CurrentOffset > 0);
		long? num2 = null;
		if (startXRefOperatorToken.HasValue)
		{
			scanner.Seek(startXRefOperatorToken.Value);
			if (scanner.TryReadToken<OperatorToken>(out var token) && (token.Data == "startxref" || token.Data == "startref"))
			{
				num2 = GetNumericTokenFollowingCurrent(scanner);
				log.Debug($"Found startxref at {num2}");
			}
		}
		else
		{
			log.Warn("No startxref token found in the document");
		}
		return new StartXRefLocation(startXRefOperatorToken, num2);
	}

	private static long? GetNumericTokenFollowingCurrent(ISeekableTokenScanner scanner)
	{
		while (scanner.MoveNext())
		{
			if (scanner.CurrentToken is NumericToken numericToken)
			{
				return numericToken.Long;
			}
			if (!(scanner.CurrentToken is CommentToken))
			{
				break;
			}
		}
		return null;
	}
}
