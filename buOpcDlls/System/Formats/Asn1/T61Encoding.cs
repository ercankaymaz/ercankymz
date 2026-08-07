// Decompiled with JetBrains decompiler
// Type: System.Formats.Asn1.T61Encoding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Text;

#nullable disable
namespace System.Formats.Asn1;

internal sealed class T61Encoding : Encoding
{
  private static readonly UTF8Encoding s_utf8Encoding = new UTF8Encoding(false, true);
  private static readonly Encoding s_latin1Encoding = Encoding.GetEncoding("iso-8859-1");

  public override int GetByteCount(char[] chars, int index, int count)
  {
    return T61Encoding.s_utf8Encoding.GetByteCount(chars, index, count);
  }

  public override unsafe int GetByteCount(char* chars, int count)
  {
    return T61Encoding.s_utf8Encoding.GetByteCount(chars, count);
  }

  public override int GetByteCount(string s) => T61Encoding.s_utf8Encoding.GetByteCount(s);

  public override int GetBytes(
    char[] chars,
    int charIndex,
    int charCount,
    byte[] bytes,
    int byteIndex)
  {
    return T61Encoding.s_utf8Encoding.GetBytes(chars, charIndex, charCount, bytes, byteIndex);
  }

  public override unsafe int GetBytes(char* chars, int charCount, byte* bytes, int byteCount)
  {
    return T61Encoding.s_utf8Encoding.GetBytes(chars, charCount, bytes, byteCount);
  }

  public override int GetCharCount(byte[] bytes, int index, int count)
  {
    try
    {
      return T61Encoding.s_utf8Encoding.GetCharCount(bytes, index, count);
    }
    catch (DecoderFallbackException ex)
    {
      return T61Encoding.s_latin1Encoding.GetCharCount(bytes, index, count);
    }
  }

  public override unsafe int GetCharCount(byte* bytes, int count)
  {
    try
    {
      return T61Encoding.s_utf8Encoding.GetCharCount(bytes, count);
    }
    catch (DecoderFallbackException ex)
    {
      return T61Encoding.s_latin1Encoding.GetCharCount(bytes, count);
    }
  }

  public override int GetChars(
    byte[] bytes,
    int byteIndex,
    int byteCount,
    char[] chars,
    int charIndex)
  {
    try
    {
      return T61Encoding.s_utf8Encoding.GetChars(bytes, byteIndex, byteCount, chars, charIndex);
    }
    catch (DecoderFallbackException ex)
    {
      return T61Encoding.s_latin1Encoding.GetChars(bytes, byteIndex, byteCount, chars, charIndex);
    }
  }

  public override unsafe int GetChars(byte* bytes, int byteCount, char* chars, int charCount)
  {
    try
    {
      return T61Encoding.s_utf8Encoding.GetChars(bytes, byteCount, chars, charCount);
    }
    catch (DecoderFallbackException ex)
    {
      return T61Encoding.s_latin1Encoding.GetChars(bytes, byteCount, chars, charCount);
    }
  }

  public override int GetMaxByteCount(int charCount)
  {
    return T61Encoding.s_utf8Encoding.GetMaxByteCount(charCount);
  }

  public override int GetMaxCharCount(int byteCount) => byteCount;
}
