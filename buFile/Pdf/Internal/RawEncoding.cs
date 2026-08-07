// Decompiled with JetBrains decompiler
// Type: PdfSharp.Pdf.Internal.RawEncoding
// Assembly: buFile, Version=1.50.4740.0, Culture=neutral, PublicKeyToken=f94615aa0424f9eb
// MVID: 1F93257A-1245-4898-8C4E-DC1AB39EF50B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buFile.dll

using System.Text;

#nullable disable
namespace PdfSharp.Pdf.Internal;

public sealed class RawEncoding : Encoding
{
  public override int GetByteCount(char[] chars, int index, int count) => count;

  public override int GetBytes(
    char[] chars,
    int charIndex,
    int charCount,
    byte[] bytes,
    int byteIndex)
  {
    for (int index = charCount; index > 0; --index)
    {
      bytes[byteIndex] = (byte) chars[charIndex];
      ++charIndex;
      ++byteIndex;
    }
    return charCount;
  }

  public override int GetCharCount(byte[] bytes, int index, int count) => count;

  public override int GetChars(
    byte[] bytes,
    int byteIndex,
    int byteCount,
    char[] chars,
    int charIndex)
  {
    for (int index = byteCount; index > 0; --index)
    {
      chars[charIndex] = (char) bytes[byteIndex];
      ++byteIndex;
      ++charIndex;
    }
    return byteCount;
  }

  public override int GetMaxByteCount(int charCount) => charCount;

  public override int GetMaxCharCount(int byteCount) => byteCount;
}
