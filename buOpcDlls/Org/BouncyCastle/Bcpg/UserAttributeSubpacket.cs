// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.UserAttributeSubpacket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class UserAttributeSubpacket
{
  internal readonly UserAttributeSubpacketTag type;
  private readonly bool longLength;
  protected readonly byte[] data;

  protected internal UserAttributeSubpacket(UserAttributeSubpacketTag type, byte[] data)
    : this(type, false, data)
  {
  }

  protected internal UserAttributeSubpacket(
    UserAttributeSubpacketTag type,
    bool forceLongLength,
    byte[] data)
  {
    this.type = type;
    this.longLength = forceLongLength;
    this.data = data;
  }

  public virtual UserAttributeSubpacketTag SubpacketType => this.type;

  public virtual byte[] GetData() => this.data;

  public virtual void Encode(Stream os)
  {
    int num1 = this.data.Length + 1;
    if (num1 < 192 /*0xC0*/ && !this.longLength)
      os.WriteByte((byte) num1);
    else if (num1 <= 8383 && !this.longLength)
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
    os.WriteByte((byte) this.type);
    os.Write(this.data, 0, this.data.Length);
  }

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    return obj is UserAttributeSubpacket attributeSubpacket && this.type == attributeSubpacket.type && Arrays.AreEqual(this.data, attributeSubpacket.data);
  }

  public override int GetHashCode() => this.type.GetHashCode() ^ Arrays.GetHashCode(this.data);
}
