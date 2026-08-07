// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.PublicKeyEncSessionPacket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class PublicKeyEncSessionPacket : ContainedPacket
{
  private int version;
  private long keyId;
  private PublicKeyAlgorithmTag algorithm;
  private byte[][] data;

  internal PublicKeyEncSessionPacket(BcpgInputStream bcpgIn)
  {
    this.version = bcpgIn.ReadByte();
    this.keyId |= (long) bcpgIn.ReadByte() << 56;
    this.keyId |= (long) bcpgIn.ReadByte() << 48 /*0x30*/;
    this.keyId |= (long) bcpgIn.ReadByte() << 40;
    this.keyId |= (long) bcpgIn.ReadByte() << 32 /*0x20*/;
    this.keyId |= (long) bcpgIn.ReadByte() << 24;
    this.keyId |= (long) bcpgIn.ReadByte() << 16 /*0x10*/;
    this.keyId |= (long) bcpgIn.ReadByte() << 8;
    this.keyId |= (long) (uint) bcpgIn.ReadByte();
    this.algorithm = (PublicKeyAlgorithmTag) bcpgIn.ReadByte();
    switch (this.algorithm)
    {
      case PublicKeyAlgorithmTag.RsaGeneral:
      case PublicKeyAlgorithmTag.RsaEncrypt:
        this.data = new byte[1][]
        {
          new MPInteger(bcpgIn).GetEncoded()
        };
        break;
      case PublicKeyAlgorithmTag.ElGamalEncrypt:
      case PublicKeyAlgorithmTag.ElGamalGeneral:
        MPInteger mpInteger1 = new MPInteger(bcpgIn);
        MPInteger mpInteger2 = new MPInteger(bcpgIn);
        this.data = new byte[2][]
        {
          mpInteger1.GetEncoded(),
          mpInteger2.GetEncoded()
        };
        break;
      case PublicKeyAlgorithmTag.ECDH:
        this.data = new byte[1][]
        {
          Streams.ReadAll((Stream) bcpgIn)
        };
        break;
      default:
        throw new IOException("unknown PGP public key algorithm encountered");
    }
  }

  public PublicKeyEncSessionPacket(long keyId, PublicKeyAlgorithmTag algorithm, byte[][] data)
  {
    this.version = 3;
    this.keyId = keyId;
    this.algorithm = algorithm;
    this.data = new byte[data.Length][];
    for (int index = 0; index < data.Length; ++index)
      this.data[index] = Arrays.Clone(data[index]);
  }

  public int Version => this.version;

  public long KeyId => this.keyId;

  public PublicKeyAlgorithmTag Algorithm => this.algorithm;

  public byte[][] GetEncSessionKey() => this.data;

  public override void Encode(BcpgOutputStream bcpgOut)
  {
    MemoryStream outStr = new MemoryStream();
    using (BcpgOutputStream bcpgOutputStream = new BcpgOutputStream((Stream) outStr))
    {
      bcpgOutputStream.WriteByte((byte) this.version);
      bcpgOutputStream.WriteLong(this.keyId);
      bcpgOutputStream.WriteByte((byte) this.algorithm);
      for (int index = 0; index < this.data.Length; ++index)
        bcpgOutputStream.Write(this.data[index]);
    }
    bcpgOut.WritePacket(PacketTag.PublicKeyEncryptedSession, outStr.ToArray());
  }
}
