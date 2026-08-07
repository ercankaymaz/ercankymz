// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.CompressedDataPacket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class CompressedDataPacket : InputStreamPacket
{
  private readonly CompressionAlgorithmTag algorithm;

  internal CompressedDataPacket(BcpgInputStream bcpgIn)
    : base(bcpgIn)
  {
    this.algorithm = (CompressionAlgorithmTag) bcpgIn.ReadByte();
  }

  public CompressionAlgorithmTag Algorithm => this.algorithm;
}
