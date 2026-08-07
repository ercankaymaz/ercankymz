// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.PublicKeyPacket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Date;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class PublicKeyPacket : ContainedPacket
{
  private int version;
  private long time;
  private int validDays;
  private PublicKeyAlgorithmTag algorithm;
  private IBcpgKey key;

  internal PublicKeyPacket(BcpgInputStream bcpgIn)
  {
    this.version = bcpgIn.ReadByte();
    this.time = (long) (uint) (bcpgIn.ReadByte() << 24 | bcpgIn.ReadByte() << 16 /*0x10*/ | bcpgIn.ReadByte() << 8 | bcpgIn.ReadByte());
    if (this.version <= 3)
      this.validDays = bcpgIn.ReadByte() << 8 | bcpgIn.ReadByte();
    this.algorithm = (PublicKeyAlgorithmTag) bcpgIn.ReadByte();
    switch (this.algorithm)
    {
      case PublicKeyAlgorithmTag.RsaGeneral:
      case PublicKeyAlgorithmTag.RsaEncrypt:
      case PublicKeyAlgorithmTag.RsaSign:
        this.key = (IBcpgKey) new RsaPublicBcpgKey(bcpgIn);
        break;
      case PublicKeyAlgorithmTag.ElGamalEncrypt:
      case PublicKeyAlgorithmTag.ElGamalGeneral:
        this.key = (IBcpgKey) new ElGamalPublicBcpgKey(bcpgIn);
        break;
      case PublicKeyAlgorithmTag.Dsa:
        this.key = (IBcpgKey) new DsaPublicBcpgKey(bcpgIn);
        break;
      case PublicKeyAlgorithmTag.ECDH:
        this.key = (IBcpgKey) new ECDHPublicBcpgKey(bcpgIn);
        break;
      case PublicKeyAlgorithmTag.ECDsa:
        this.key = (IBcpgKey) new ECDsaPublicBcpgKey(bcpgIn);
        break;
      case PublicKeyAlgorithmTag.EdDsa:
        this.key = (IBcpgKey) new EdDsaPublicBcpgKey(bcpgIn);
        break;
      default:
        throw new IOException("unknown PGP public key algorithm encountered");
    }
  }

  public PublicKeyPacket(PublicKeyAlgorithmTag algorithm, DateTime time, IBcpgKey key)
  {
    this.version = 4;
    this.time = DateTimeUtilities.DateTimeToUnixMs(time) / 1000L;
    this.algorithm = algorithm;
    this.key = key;
  }

  public virtual int Version => this.version;

  public virtual PublicKeyAlgorithmTag Algorithm => this.algorithm;

  public virtual int ValidDays => this.validDays;

  public virtual DateTime GetTime() => DateTimeUtilities.UnixMsToDateTime(this.time * 1000L);

  public virtual IBcpgKey Key => this.key;

  public virtual byte[] GetEncodedContents()
  {
    MemoryStream outStr = new MemoryStream();
    BcpgOutputStream bcpgOutputStream = new BcpgOutputStream((Stream) outStr);
    bcpgOutputStream.WriteByte((byte) this.version);
    bcpgOutputStream.WriteInt((int) this.time);
    if (this.version <= 3)
      bcpgOutputStream.WriteShort((short) this.validDays);
    bcpgOutputStream.WriteByte((byte) this.algorithm);
    bcpgOutputStream.WriteObject((BcpgObject) this.key);
    return outStr.ToArray();
  }

  public override void Encode(BcpgOutputStream bcpgOut)
  {
    bcpgOut.WritePacket(PacketTag.PublicKey, this.GetEncodedContents());
  }
}
