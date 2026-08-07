// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.TrustPacket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class TrustPacket : ContainedPacket
{
  private readonly byte[] levelAndTrustAmount;

  public TrustPacket(BcpgInputStream bcpgIn)
  {
    MemoryStream memoryStream = new MemoryStream();
    int num;
    while ((num = bcpgIn.ReadByte()) >= 0)
      memoryStream.WriteByte((byte) num);
    this.levelAndTrustAmount = memoryStream.ToArray();
  }

  public TrustPacket(int trustCode)
  {
    this.levelAndTrustAmount = new byte[1]
    {
      (byte) trustCode
    };
  }

  public byte[] GetLevelAndTrustAmount() => (byte[]) this.levelAndTrustAmount.Clone();

  public override void Encode(BcpgOutputStream bcpgOut)
  {
    bcpgOut.WritePacket(PacketTag.Trust, this.levelAndTrustAmount);
  }
}
