// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.Sig.RegularExpression
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg.Sig;

public class RegularExpression : SignatureSubpacket
{
  public RegularExpression(bool critical, bool isLongLength, byte[] data)
    : base(SignatureSubpacketTag.RegExp, critical, isLongLength, data)
  {
    if (data[data.Length - 1] != (byte) 0)
      throw new ArgumentException("data in regex missing null termination");
  }

  public RegularExpression(bool critical, string regex)
    : base(SignatureSubpacketTag.RegExp, critical, false, RegularExpression.ToNullTerminatedUtf8ByteArray(regex))
  {
  }

  public string Regex => Strings.FromUtf8ByteArray(this.data, 0, this.data.Length - 1);

  public byte[] GetRawRegex() => Arrays.Clone(this.data);

  private static byte[] ToNullTerminatedUtf8ByteArray(string str)
  {
    return Arrays.Append(Strings.ToUtf8ByteArray(str), (byte) 0);
  }
}
