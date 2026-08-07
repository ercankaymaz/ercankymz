// Decompiled with JetBrains decompiler
// Type: System.Formats.Asn1.BMPEncoding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Buffers.Binary;

#nullable disable
namespace System.Formats.Asn1;

internal sealed class BMPEncoding : SpanBasedEncoding
{
  protected override int GetBytes(ReadOnlySpan<char> chars, Span<byte> bytes, bool write)
  {
    if (chars.IsEmpty)
      return 0;
    int index1 = 0;
    for (int index2 = 0; index2 < chars.Length; ++index2)
    {
      char ch = chars[index2];
      if (!char.IsSurrogate(ch))
      {
        ushort num = (ushort) ch;
        if (write)
        {
          bytes[index1 + 1] = (byte) num;
          bytes[index1] = (byte) ((uint) num >> 8);
        }
        index1 += 2;
      }
      else
      {
        this.EncoderFallback.CreateFallbackBuffer().Fallback(ch, index2);
        throw new InvalidOperationException();
      }
    }
    return index1;
  }

  protected override int GetChars(ReadOnlySpan<byte> bytes, Span<char> chars, bool write)
  {
    if (bytes.IsEmpty)
      return 0;
    if (bytes.Length % 2 != 0)
    {
      this.DecoderFallback.CreateFallbackBuffer().Fallback(bytes.Slice(bytes.Length - 1).ToArray(), bytes.Length - 1);
      throw new InvalidOperationException();
    }
    int index1 = 0;
    for (int index2 = 0; index2 < bytes.Length; index2 += 2)
    {
      char c = (char) BinaryPrimitives.ReadInt16BigEndian(bytes.Slice(index2));
      if (!char.IsSurrogate(c))
      {
        if (write)
          chars[index1] = c;
        ++index1;
      }
      else
      {
        this.DecoderFallback.CreateFallbackBuffer().Fallback(bytes.Slice(index2, 2).ToArray(), index2);
        throw new InvalidOperationException();
      }
    }
    return index1;
  }

  public override int GetMaxByteCount(int charCount) => checked (charCount * 2);

  public override int GetMaxCharCount(int byteCount) => byteCount / 2;
}
