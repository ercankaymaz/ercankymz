// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.SymmetricKeyEncSessionPacket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class SymmetricKeyEncSessionPacket : ContainedPacket
{
  private int version;
  private SymmetricKeyAlgorithmTag encAlgorithm;
  private S2k s2k;
  private readonly byte[] secKeyData;

  public SymmetricKeyEncSessionPacket(BcpgInputStream bcpgIn)
  {
    this.version = bcpgIn.ReadByte();
    this.encAlgorithm = (SymmetricKeyAlgorithmTag) bcpgIn.ReadByte();
    this.s2k = new S2k((Stream) bcpgIn);
    this.secKeyData = bcpgIn.ReadAll();
  }

  public SymmetricKeyEncSessionPacket(
    SymmetricKeyAlgorithmTag encAlgorithm,
    S2k s2k,
    byte[] secKeyData)
  {
    this.version = 4;
    this.encAlgorithm = encAlgorithm;
    this.s2k = s2k;
    this.secKeyData = secKeyData;
  }

  public SymmetricKeyAlgorithmTag EncAlgorithm => this.encAlgorithm;

  public S2k S2k => this.s2k;

  public byte[] GetSecKeyData() => this.secKeyData;

  public int Version => this.version;

  public override void Encode(BcpgOutputStream bcpgOut)
  {
    MemoryStream outStr = new MemoryStream();
    using (BcpgOutputStream bcpgOutputStream = new BcpgOutputStream((Stream) outStr))
    {
      bcpgOutputStream.Write((byte) this.version, (byte) this.encAlgorithm);
      bcpgOutputStream.WriteObject((BcpgObject) this.s2k);
      if (this.secKeyData != null)
      {
        if (this.secKeyData.Length != 0)
          bcpgOutputStream.Write(this.secKeyData);
      }
    }
    bcpgOut.WritePacket(PacketTag.SymmetricKeyEncryptedSessionKey, outStr.ToArray());
  }
}
