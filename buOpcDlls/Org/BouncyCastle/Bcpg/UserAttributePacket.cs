// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.UserAttributePacket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class UserAttributePacket : ContainedPacket
{
  private readonly UserAttributeSubpacket[] subpackets;

  public UserAttributePacket(BcpgInputStream bcpgIn)
  {
    UserAttributeSubpacketsParser subpacketsParser = new UserAttributeSubpacketsParser((Stream) bcpgIn);
    List<UserAttributeSubpacket> attributeSubpacketList = new List<UserAttributeSubpacket>();
    UserAttributeSubpacket attributeSubpacket;
    while ((attributeSubpacket = subpacketsParser.ReadPacket()) != null)
      attributeSubpacketList.Add(attributeSubpacket);
    this.subpackets = attributeSubpacketList.ToArray();
  }

  public UserAttributePacket(UserAttributeSubpacket[] subpackets) => this.subpackets = subpackets;

  public UserAttributeSubpacket[] GetSubpackets() => this.subpackets;

  public override void Encode(BcpgOutputStream bcpgOut)
  {
    MemoryStream os = new MemoryStream();
    for (int index = 0; index != this.subpackets.Length; ++index)
      this.subpackets[index].Encode((Stream) os);
    bcpgOut.WritePacket(PacketTag.UserAttribute, os.ToArray());
  }
}
