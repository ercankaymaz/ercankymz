// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.ExperimentalPacket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class ExperimentalPacket : ContainedPacket
{
  private readonly PacketTag m_tag;
  private readonly byte[] m_contents;

  internal ExperimentalPacket(PacketTag tag, BcpgInputStream bcpgIn)
  {
    this.m_tag = tag;
    this.m_contents = bcpgIn.ReadAll();
  }

  public PacketTag Tag => this.m_tag;

  public byte[] GetContents() => (byte[]) this.m_contents.Clone();

  public override void Encode(BcpgOutputStream bcpgOut)
  {
    bcpgOut.WritePacket(this.m_tag, this.m_contents);
  }
}
