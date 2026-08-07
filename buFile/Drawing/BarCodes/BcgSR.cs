// Decompiled with JetBrains decompiler
// Type: PdfSharp.Drawing.BarCodes.BcgSR
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

#nullable disable
namespace PdfSharp.Drawing.BarCodes;

internal class BcgSR
{
  internal static string Invalid2Of5Code(string code)
  {
    return $"'{code}' is not a valid code for an interleave 2 of 5 bar code. It can only represent an even number of digits.";
  }

  internal static string Invalid3Of9Code(string code)
  {
    return $"'{code}' is not a valid code for a 3 of 9 standard bar code.";
  }

  internal static string BarCodeNotSet => "A text must be set before rendering the bar code.";

  internal static string EmptyBarCodeSize
  {
    get => "A non-empty size must be set before rendering the bar code.";
  }

  internal static string Invalid2of5Relation
  {
    get
    {
      return "Value of relation between thick and thin lines on the interleaved 2 of 5 code must be between 2 and 3.";
    }
  }

  internal static string InvalidMarkName(string name)
  {
    return $"'{name}' is not a valid mark name for this OMR representation.";
  }

  internal static string OmrAlreadyInitialized
  {
    get => "Mark descriptions cannot be set when marks have already been set on OMR.";
  }

  internal static string DataMatrixTooBig
  {
    get => "The given data and encoding combination is too big for the matrix size.";
  }

  internal static string DataMatrixNotSupported
  {
    get => "Zero sizes, odd sizes and other than ecc200 coded DataMatrix is not supported.";
  }

  internal static string DataMatrixNull => "No DataMatrix code is produced.";

  internal static string DataMatrixInvalid(int columns, int rows)
  {
    return string.Format("'{1}'x'{0}' is an invalid ecc200 DataMatrix size.", (object) columns, (object) rows);
  }
}
