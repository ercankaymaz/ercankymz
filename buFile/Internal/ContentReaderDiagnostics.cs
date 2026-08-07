// Decompiled with JetBrains decompiler
// Type: PdfSharp.Internal.ContentReaderDiagnostics
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using PdfSharp.Pdf.Content;
using System;
using System.Globalization;

#nullable disable
namespace PdfSharp.Internal;

internal static class ContentReaderDiagnostics
{
  public static void ThrowContentReaderException(string message)
  {
    throw new ContentReaderException(message);
  }

  public static void ThrowContentReaderException(string message, Exception innerException)
  {
    throw new ContentReaderException(message, innerException);
  }

  public static void ThrowNumberOutOfIntegerRange(long value)
  {
    ContentReaderDiagnostics.ThrowContentReaderException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Number '{0}' out of integer range.", (object) value));
  }

  public static void HandleUnexpectedCharacter(char ch)
  {
    ContentReaderDiagnostics.ThrowContentReaderException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Unexpected character '0x{0:x4}' in content stream. The stream may be corrupted or the feature is not implemented. If you think this is a bug in PDFsharp, please send us your PDF file.", (object) (int) ch));
  }
}
