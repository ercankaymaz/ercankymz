// Decompiled with JetBrains decompiler
// Type: PdfSharp.Internal.ParserDiagnostics
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.IO;
using System;
using System.Globalization;

#nullable disable
namespace PdfSharp.Internal;

internal static class ParserDiagnostics
{
  public static void ThrowParserException(string message) => throw new PdfReaderException(message);

  public static void ThrowParserException(string message, Exception innerException)
  {
    throw new PdfReaderException(message, innerException);
  }

  public static void HandleUnexpectedCharacter(char ch)
  {
    ParserDiagnostics.ThrowParserException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Unexpected character '0x{0:x4}' in PDF stream. The file may be corrupted. If you think this is a bug in PDFsharp, please send us your PDF file.", (object) (int) ch));
  }

  public static void HandleUnexpectedToken(string token)
  {
    ParserDiagnostics.ThrowParserException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Unexpected token '{0}' in PDF stream. The file may be corrupted. If you think this is a bug in PDFsharp, please send us your PDF file.", (object) token));
  }
}
