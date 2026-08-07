// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OnePassSignaturePacket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class OnePassSignaturePacket : ContainedPacket
{
  private int version;
  private int sigType;
  private HashAlgorithmTag hashAlgorithm;
  private PublicKeyAlgorithmTag keyAlgorithm;
  private long keyId;
  private int nested;

  internal OnePassSignaturePacket(BcpgInputStream bcpgIn)
  {
    this.version = bcpgIn.ReadByte();
    this.sigType = bcpgIn.ReadByte();
    this.hashAlgorithm = (HashAlgorithmTag) bcpgIn.ReadByte();
    this.keyAlgorithm = (PublicKeyAlgorithmTag) bcpgIn.ReadByte();
    this.keyId |= (long) bcpgIn.ReadByte() << 56;
    this.keyId |= (long) bcpgIn.ReadByte() << 48 /*0x30*/;
    this.keyId |= (long) bcpgIn.ReadByte() << 40;
    this.keyId |= (long) bcpgIn.ReadByte() << 32 /*0x20*/;
    this.keyId |= (long) bcpgIn.ReadByte() << 24;
    this.keyId |= (long) bcpgIn.ReadByte() << 16 /*0x10*/;
    this.keyId |= (long) bcpgIn.ReadByte() << 8;
    this.keyId |= (long) (uint) bcpgIn.ReadByte();
    this.nested = bcpgIn.ReadByte();
  }

  public OnePassSignaturePacket(
    int sigType,
    HashAlgorithmTag hashAlgorithm,
    PublicKeyAlgorithmTag keyAlgorithm,
    long keyId,
    bool isNested)
  {
    this.version = 3;
    this.sigType = sigType;
    this.hashAlgorithm = hashAlgorithm;
    this.keyAlgorithm = keyAlgorithm;
    this.keyId = keyId;
    this.nested = isNested ? 0 : 1;
  }

  public int SignatureType => this.sigType;

  public PublicKeyAlgorithmTag KeyAlgorithm => this.keyAlgorithm;

  public HashAlgorithmTag HashAlgorithm => this.hashAlgorithm;

  public long KeyId => this.keyId;

  public override void Encode(BcpgOutputStream bcpgOut)
  {
    MemoryStream outStr = new MemoryStream();
    using (BcpgOutputStream bcpgOutputStream = new BcpgOutputStream((Stream) outStr))
    {
      bcpgOutputStream.Write((byte) this.version, (byte) this.sigType, (byte) this.hashAlgorithm, (byte) this.keyAlgorithm);
      bcpgOutputStream.WriteLong(this.keyId);
      bcpgOutputStream.WriteByte((byte) this.nested);
    }
    bcpgOut.WritePacket(PacketTag.OnePassSignature, outStr.ToArray());
  }
}
