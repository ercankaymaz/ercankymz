// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.UserAttributeSubpacketsParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Bcpg.Attr;
using Org.BouncyCastle.Utilities.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class UserAttributeSubpacketsParser
{
  private readonly Stream input;

  public UserAttributeSubpacketsParser(Stream input) => this.input = input;

  public virtual UserAttributeSubpacket ReadPacket()
  {
    int num1 = this.input.ReadByte();
    if (num1 < 0)
      return (UserAttributeSubpacket) null;
    bool forceLongLength = false;
    int num2;
    if (num1 < 192 /*0xC0*/)
      num2 = num1;
    else if (num1 <= 223)
    {
      num2 = (num1 - 192 /*0xC0*/ << 8) + this.input.ReadByte() + 192 /*0xC0*/;
    }
    else
    {
      if (num1 != (int) byte.MaxValue)
        throw new IOException("unrecognised length reading user attribute sub packet");
      num2 = this.input.ReadByte() << 24 | this.input.ReadByte() << 16 /*0x10*/ | this.input.ReadByte() << 8 | this.input.ReadByte();
      forceLongLength = true;
    }
    int num3 = this.input.ReadByte();
    if (num3 < 0)
      throw new EndOfStreamException("unexpected EOF reading user attribute sub packet");
    byte[] numArray = new byte[num2 - 1];
    if (Streams.ReadFully(this.input, numArray) < numArray.Length)
      throw new EndOfStreamException();
    UserAttributeSubpacketTag type = (UserAttributeSubpacketTag) num3;
    return type == UserAttributeSubpacketTag.ImageAttribute ? (UserAttributeSubpacket) new ImageAttrib(forceLongLength, numArray) : new UserAttributeSubpacket(type, forceLongLength, numArray);
  }
}
