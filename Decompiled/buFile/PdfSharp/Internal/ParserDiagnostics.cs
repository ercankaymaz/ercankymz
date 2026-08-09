using System;
using System.Globalization;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Internal;

internal static class ParserDiagnostics
{
	public static void ThrowParserException(string message)
	{
		throw new PdfReaderException(message);
	}

	public static void ThrowParserException(string message, Exception innerException)
	{
		throw new PdfReaderException(message, innerException);
	}

	public static void HandleUnexpectedCharacter(char ch)
	{
		string message = string.Format(CultureInfo.InvariantCulture, "Unexpected character '0x{0:x4}' in PDF stream. The file may be corrupted. If you think this is a bug in PDFsharp, please send us your PDF file.", (int)ch);
		ThrowParserException(message);
	}

	public static void HandleUnexpectedToken(string token)
	{
		string message = string.Format(CultureInfo.InvariantCulture, "Unexpected token '{0}' in PDF stream. The file may be corrupted. If you think this is a bug in PDFsharp, please send us your PDF file.", token);
		ThrowParserException(message);
	}
}
