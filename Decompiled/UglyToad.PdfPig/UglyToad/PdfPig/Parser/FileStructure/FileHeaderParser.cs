using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using UglyToad.PdfPig.Content;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Logging;
using UglyToad.PdfPig.Tokenization.Scanner;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Util;

namespace UglyToad.PdfPig.Parser.FileStructure;

internal static class FileHeaderParser
{
	public static HeaderVersion Parse(ISeekableTokenScanner scanner, IInputBytes inputBytes, bool isLenientParsing, ILog log)
	{
		if (scanner == null)
		{
			throw new ArgumentNullException("scanner");
		}
		long currentPosition = scanner.CurrentPosition;
		int num = 0;
		CommentToken commentToken;
		do
		{
			if (num == 30 || !scanner.MoveNext())
			{
				if (!TryBruteForceVersionLocation(currentPosition, inputBytes, out HeaderVersion headerVersion))
				{
					throw new PdfDocumentFormatException("Could not find the version header comment at the start of the document.");
				}
				scanner.Seek(currentPosition);
				return headerVersion;
			}
			commentToken = scanner.CurrentToken as CommentToken;
			num++;
		}
		while (commentToken == null);
		return GetHeaderVersionAndResetScanner(commentToken, scanner, isLenientParsing, log);
	}

	private static HeaderVersion GetHeaderVersionAndResetScanner(CommentToken comment, ISeekableTokenScanner scanner, bool isLenientParsing, ILog log)
	{
		if (!comment.Data.StartsWith("PDF-1.", StringComparison.OrdinalIgnoreCase) && !comment.Data.StartsWith("FDF-1.", StringComparison.OrdinalIgnoreCase))
		{
			return HandleMissingVersion(comment, isLenientParsing, log);
		}
		if (!double.TryParse(comment.Data.AsSpanOrSubstring(4), NumberStyles.Number, CultureInfo.InvariantCulture, out var result))
		{
			return HandleMissingVersion(comment, isLenientParsing, log);
		}
		int num = ((scanner.CurrentPosition == scanner.Length) ? 1 : 2);
		long offsetInFile = scanner.CurrentPosition - comment.Data.Length - num;
		scanner.Seek(0L);
		return new HeaderVersion(result, comment.Data, offsetInFile);
	}

	private static bool TryBruteForceVersionLocation(long startPosition, IInputBytes inputBytes, [NotNullWhen(true)] out HeaderVersion? headerVersion)
	{
		headerVersion = null;
		inputBytes.Seek(startPosition);
		Span<byte> span = stackalloc byte[64];
		long num = startPosition;
		int num2;
		do
		{
			num2 = inputBytes.Read(span);
			string text = OtherEncodings.BytesAsLatin1String(span);
			int num3 = text.IndexOf("%PDF-", StringComparison.OrdinalIgnoreCase);
			int num4 = text.IndexOf("%FDF-", StringComparison.OrdinalIgnoreCase);
			int num5 = ((num3 >= 0) ? num3 : num4);
			if (num5 >= 0 && text.Length - num5 >= 8 && double.TryParse(text.AsSpanOrSubstring(num5 + 5, 3), NumberStyles.Number, CultureInfo.InvariantCulture, out var result))
			{
				int startIndex = num5 + 1;
				headerVersion = new HeaderVersion(result, text.Substring(startIndex, 7), num + num5);
				inputBytes.Seek(startPosition);
				return true;
			}
			num += num2 - 8;
			inputBytes.Seek(num);
		}
		while (num2 == 64);
		return false;
	}

	private static HeaderVersion HandleMissingVersion(CommentToken comment, bool isLenientParsing, ILog log)
	{
		if (isLenientParsing)
		{
			log.Warn("Did not find a version header of the correct format, defaulting to 1.4 since lenient. Header was: " + comment.Data + ".");
			return new HeaderVersion(1.4, "PDF-1.4", 0L);
		}
		throw new PdfDocumentFormatException("The comment which should have provided the version was in the wrong format: " + comment.Data + ".");
	}
}
