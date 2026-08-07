// Decompiled with JetBrains decompiler
// Type: System.Formats.Asn1.AsnCharacterStringEncodings
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace System.Formats.Asn1;

internal static class AsnCharacterStringEncodings
{
  private static readonly UTF8Encoding s_utf8Encoding = new UTF8Encoding(false, true);
  private static readonly BMPEncoding s_bmpEncoding = new BMPEncoding();
  private static readonly IA5Encoding s_ia5Encoding = new IA5Encoding();
  private static readonly VisibleStringEncoding s_visibleStringEncoding = new VisibleStringEncoding();
  private static readonly NumericStringEncoding s_numericStringEncoding = new NumericStringEncoding();
  private static readonly PrintableStringEncoding s_printableStringEncoding = new PrintableStringEncoding();
  private static readonly T61Encoding s_t61Encoding = new T61Encoding();

  internal static Encoding GetEncoding(UniversalTagNumber encodingType)
  {
    Encoding encoding;
    switch (encodingType)
    {
      case UniversalTagNumber.UTF8String:
        encoding = (Encoding) AsnCharacterStringEncodings.s_utf8Encoding;
        break;
      case UniversalTagNumber.NumericString:
        encoding = (Encoding) AsnCharacterStringEncodings.s_numericStringEncoding;
        break;
      case UniversalTagNumber.PrintableString:
        encoding = (Encoding) AsnCharacterStringEncodings.s_printableStringEncoding;
        break;
      case UniversalTagNumber.TeletexString:
        encoding = (Encoding) AsnCharacterStringEncodings.s_t61Encoding;
        break;
      case UniversalTagNumber.IA5String:
        encoding = (Encoding) AsnCharacterStringEncodings.s_ia5Encoding;
        break;
      case UniversalTagNumber.VisibleString:
        encoding = (Encoding) AsnCharacterStringEncodings.s_visibleStringEncoding;
        break;
      case UniversalTagNumber.BMPString:
        encoding = (Encoding) AsnCharacterStringEncodings.s_bmpEncoding;
        break;
      default:
        throw new ArgumentOutOfRangeException(nameof (encodingType), (object) encodingType, (string) null);
    }
    return encoding;
  }

  internal static unsafe int GetByteCount(this Encoding encoding, ReadOnlySpan<char> str)
  {
    if (str.IsEmpty)
      str = string.Empty.AsSpan();
    fixed (char* chars = &MemoryMarshal.GetReference<char>(str))
      return encoding.GetByteCount(chars, str.Length);
  }

  internal static unsafe int GetBytes(
    this Encoding encoding,
    ReadOnlySpan<char> chars,
    Span<byte> bytes)
  {
    if (chars.IsEmpty)
      chars = string.Empty.AsSpan();
    if (bytes.IsEmpty)
      bytes = (Span<byte>) Array.Empty<byte>();
    fixed (char* chars1 = &MemoryMarshal.GetReference<char>(chars))
      fixed (byte* bytes1 = &MemoryMarshal.GetReference<byte>(bytes))
        return encoding.GetBytes(chars1, chars.Length, bytes1, bytes.Length);
  }
}
