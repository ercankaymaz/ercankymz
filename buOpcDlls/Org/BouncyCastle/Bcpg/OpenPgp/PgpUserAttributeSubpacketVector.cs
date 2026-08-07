// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpUserAttributeSubpacketVector
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Bcpg.Attr;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpUserAttributeSubpacketVector : IUserDataPacket
{
  private readonly UserAttributeSubpacket[] packets;

  public static PgpUserAttributeSubpacketVector FromSubpackets(UserAttributeSubpacket[] packets)
  {
    if (packets == null)
      packets = new UserAttributeSubpacket[0];
    return new PgpUserAttributeSubpacketVector(packets);
  }

  internal PgpUserAttributeSubpacketVector(UserAttributeSubpacket[] packets)
  {
    this.packets = packets;
  }

  public UserAttributeSubpacket GetSubpacket(UserAttributeSubpacketTag type)
  {
    for (int index = 0; index != this.packets.Length; ++index)
    {
      if (this.packets[index].SubpacketType == type)
        return this.packets[index];
    }
    return (UserAttributeSubpacket) null;
  }

  public ImageAttrib GetImageAttribute()
  {
    return (ImageAttrib) this.GetSubpacket(UserAttributeSubpacketTag.ImageAttribute) ?? (ImageAttrib) null;
  }

  internal UserAttributeSubpacket[] ToSubpacketArray() => this.packets;

  public override bool Equals(object obj)
  {
    if (obj == this)
      return true;
    if (!(obj is PgpUserAttributeSubpacketVector attributeSubpacketVector) || attributeSubpacketVector.packets.Length != this.packets.Length)
      return false;
    for (int index = 0; index != this.packets.Length; ++index)
    {
      if (!attributeSubpacketVector.packets[index].Equals((object) this.packets[index]))
        return false;
    }
    return true;
  }

  public override int GetHashCode()
  {
    int hashCode = 0;
    foreach (object packet in this.packets)
      hashCode ^= packet.GetHashCode();
    return hashCode;
  }
}
