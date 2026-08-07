// Decompiled with JetBrains decompiler
// Type: System.Formats.Asn1.RestrictedAsciiStringEncoding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Formats.Asn1;

internal abstract class RestrictedAsciiStringEncoding : SpanBasedEncoding
{
  private readonly bool[] _isAllowed;

  protected RestrictedAsciiStringEncoding(byte minCharAllowed, byte maxCharAllowed)
  {
    bool[] array = new bool[128 /*0x80*/];
    array.AsSpan<bool>((int) minCharAllowed, (int) maxCharAllowed - (int) minCharAllowed + 1).Fill(true);
    this._isAllowed = array;
  }

  protected RestrictedAsciiStringEncoding(string allowedChars)
  {
    bool[] flagArray = new bool[(int) sbyte.MaxValue];
    foreach (char allowedChar in allowedChars)
    {
      if ((int) allowedChar >= flagArray.Length)
        throw new ArgumentOutOfRangeException(nameof (allowedChars));
      flagArray[(int) allowedChar] = true;
    }
    this._isAllowed = flagArray;
  }

  public override int GetMaxByteCount(int charCount) => charCount;

  public override int GetMaxCharCount(int byteCount) => byteCount;

  protected override int GetBytes(ReadOnlySpan<char> chars, Span<byte> bytes, bool write)
  {
    if (chars.IsEmpty)
      return 0;
    for (int index = 0; index < chars.Length; ++index)
    {
      char charUnknown = chars[index];
      if ((uint) charUnknown < (uint) this._isAllowed.Length && this._isAllowed[(int) charUnknown])
      {
        if (write)
          bytes[index] = (byte) charUnknown;
      }
      else
      {
        this.EncoderFallback.CreateFallbackBuffer().Fallback(charUnknown, index);
        throw new InvalidOperationException();
      }
    }
    return chars.Length;
  }

  protected override int GetChars(ReadOnlySpan<byte> bytes, Span<char> chars, bool write)
  {
    if (bytes.IsEmpty)
      return 0;
    for (int index1 = 0; index1 < bytes.Length; ++index1)
    {
      byte index2 = bytes[index1];
      if ((uint) index2 < (uint) this._isAllowed.Length && this._isAllowed[(int) index2])
      {
        if (write)
          chars[index1] = (char) index2;
      }
      else
      {
        this.DecoderFallback.CreateFallbackBuffer().Fallback(new byte[1]
        {
          index2
        }, index1);
        throw new InvalidOperationException();
      }
    }
    return bytes.Length;
  }
}
