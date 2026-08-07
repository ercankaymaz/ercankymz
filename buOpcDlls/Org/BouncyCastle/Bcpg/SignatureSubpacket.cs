// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.SignatureSubpacket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class SignatureSubpacket
{
  private readonly SignatureSubpacketTag type;
  private readonly bool critical;
  private readonly bool isLongLength;
  internal byte[] data;

  protected internal SignatureSubpacket(
    SignatureSubpacketTag type,
    bool critical,
    bool isLongLength,
    byte[] data)
  {
    this.type = type;
    this.critical = critical;
    this.isLongLength = isLongLength;
    this.data = data;
  }

  public SignatureSubpacketTag SubpacketType => this.type;

  public bool IsCritical() => this.critical;

  public bool IsLongLength() => this.isLongLength;

  public byte[] GetData() => (byte[]) this.data.Clone();

  public void Encode(Stream os)
  {
    int num1 = this.data.Length + 1;
    if (this.isLongLength)
    {
      os.WriteByte(byte.MaxValue);
      os.WriteByte((byte) (num1 >> 24));
      os.WriteByte((byte) (num1 >> 16 /*0x10*/));
      os.WriteByte((byte) (num1 >> 8));
      os.WriteByte((byte) num1);
    }
    else if (num1 < 192 /*0xC0*/)
      os.WriteByte((byte) num1);
    else if (num1 <= 8383)
    {
      int num2 = num1 - 192 /*0xC0*/;
      os.WriteByte((byte) ((num2 >> 8 & (int) byte.MaxValue) + 192 /*0xC0*/));
      os.WriteByte((byte) num2);
    }
    else
    {
      os.WriteByte(byte.MaxValue);
      os.WriteByte((byte) (num1 >> 24));
      os.WriteByte((byte) (num1 >> 16 /*0x10*/));
      os.WriteByte((byte) (num1 >> 8));
      os.WriteByte((byte) num1);
    }
    if (this.critical)
      os.WriteByte((byte) ((SignatureSubpacketTag) 128 /*0x80*/ | this.type));
    else
      os.WriteByte((byte) this.type);
    os.Write(this.data, 0, this.data.Length);
  }

  public override int GetHashCode()
  {
    return (this.critical ? 1 : 0) + 7 * (int) this.type + 49 * Arrays.GetHashCode(this.data);
  }

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is SignatureSubpacket signatureSubpacket && this.type == signatureSubpacket.type && this.critical == signatureSubpacket.critical && Arrays.AreEqual(this.data, signatureSubpacket.data);
  }
}
