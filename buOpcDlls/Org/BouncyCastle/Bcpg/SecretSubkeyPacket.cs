// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.SecretSubkeyPacket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class SecretSubkeyPacket : SecretKeyPacket
{
  internal SecretSubkeyPacket(BcpgInputStream bcpgIn)
    : base(bcpgIn)
  {
  }

  public SecretSubkeyPacket(
    PublicKeyPacket pubKeyPacket,
    SymmetricKeyAlgorithmTag encAlgorithm,
    S2k s2k,
    byte[] iv,
    byte[] secKeyData)
    : base(pubKeyPacket, encAlgorithm, s2k, iv, secKeyData)
  {
  }

  public SecretSubkeyPacket(
    PublicKeyPacket pubKeyPacket,
    SymmetricKeyAlgorithmTag encAlgorithm,
    int s2kUsage,
    S2k s2k,
    byte[] iv,
    byte[] secKeyData)
    : base(pubKeyPacket, encAlgorithm, s2kUsage, s2k, iv, secKeyData)
  {
  }

  public override void Encode(BcpgOutputStream bcpgOut)
  {
    bcpgOut.WritePacket(PacketTag.SecretSubkey, this.GetEncodedContents());
  }
}
