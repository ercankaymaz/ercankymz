// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.MarkerPacket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class MarkerPacket : ContainedPacket
{
  private readonly byte[] marker = new byte[3]
  {
    (byte) 80 /*0x50*/,
    (byte) 71,
    (byte) 80 /*0x50*/
  };

  public MarkerPacket(BcpgInputStream bcpgIn) => bcpgIn.ReadFully(this.marker);

  public override void Encode(BcpgOutputStream bcpgOut)
  {
    bcpgOut.WritePacket(PacketTag.Marker, this.marker);
  }
}
