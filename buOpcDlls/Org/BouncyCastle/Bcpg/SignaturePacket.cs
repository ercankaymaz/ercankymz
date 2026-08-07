// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.SignaturePacket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Bcpg.Sig;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Date;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class SignaturePacket : ContainedPacket
{
  private int version;
  private int signatureType;
  private long creationTime;
  private long keyId;
  private PublicKeyAlgorithmTag keyAlgorithm;
  private HashAlgorithmTag hashAlgorithm;
  private MPInteger[] signature;
  private byte[] fingerprint;
  private SignatureSubpacket[] hashedData;
  private SignatureSubpacket[] unhashedData;
  private byte[] signatureEncoding;

  internal SignaturePacket(BcpgInputStream bcpgIn)
  {
    this.version = bcpgIn.ReadByte();
    if (this.version != 3 && this.version != 2)
    {
      if (this.version == 4)
      {
        this.signatureType = bcpgIn.ReadByte();
        this.keyAlgorithm = (PublicKeyAlgorithmTag) bcpgIn.ReadByte();
        this.hashAlgorithm = (HashAlgorithmTag) bcpgIn.ReadByte();
        byte[] buffer1 = new byte[bcpgIn.ReadByte() << 8 | bcpgIn.ReadByte()];
        bcpgIn.ReadFully(buffer1);
        SignatureSubpacketsParser subpacketsParser1 = new SignatureSubpacketsParser((Stream) new MemoryStream(buffer1, false));
        List<SignatureSubpacket> signatureSubpacketList = new List<SignatureSubpacket>();
        SignatureSubpacket signatureSubpacket1;
        while ((signatureSubpacket1 = subpacketsParser1.ReadPacket()) != null)
          signatureSubpacketList.Add(signatureSubpacket1);
        this.hashedData = signatureSubpacketList.ToArray();
        foreach (SignatureSubpacket signatureSubpacket2 in this.hashedData)
        {
          switch (signatureSubpacket2)
          {
            case IssuerKeyId issuerKeyId:
              this.keyId = issuerKeyId.KeyId;
              break;
            case SignatureCreationTime signatureCreationTime:
              this.creationTime = DateTimeUtilities.DateTimeToUnixMs(signatureCreationTime.GetTime());
              break;
          }
        }
        byte[] buffer2 = new byte[bcpgIn.ReadByte() << 8 | bcpgIn.ReadByte()];
        bcpgIn.ReadFully(buffer2);
        SignatureSubpacketsParser subpacketsParser2 = new SignatureSubpacketsParser((Stream) new MemoryStream(buffer2, false));
        signatureSubpacketList.Clear();
        SignatureSubpacket signatureSubpacket3;
        while ((signatureSubpacket3 = subpacketsParser2.ReadPacket()) != null)
          signatureSubpacketList.Add(signatureSubpacket3);
        this.unhashedData = signatureSubpacketList.ToArray();
        foreach (SignatureSubpacket signatureSubpacket4 in this.unhashedData)
        {
          if (signatureSubpacket4 is IssuerKeyId issuerKeyId)
            this.keyId = issuerKeyId.KeyId;
        }
      }
      else
      {
        Streams.Drain((Stream) bcpgIn);
        throw new UnsupportedPacketVersionException("unsupported version: " + this.version.ToString());
      }
    }
    else
    {
      bcpgIn.ReadByte();
      this.signatureType = bcpgIn.ReadByte();
      this.creationTime = ((long) bcpgIn.ReadByte() << 24 | (long) bcpgIn.ReadByte() << 16 /*0x10*/ | (long) bcpgIn.ReadByte() << 8 | (long) (uint) bcpgIn.ReadByte()) * 1000L;
      this.keyId |= (long) bcpgIn.ReadByte() << 56;
      this.keyId |= (long) bcpgIn.ReadByte() << 48 /*0x30*/;
      this.keyId |= (long) bcpgIn.ReadByte() << 40;
      this.keyId |= (long) bcpgIn.ReadByte() << 32 /*0x20*/;
      this.keyId |= (long) bcpgIn.ReadByte() << 24;
      this.keyId |= (long) bcpgIn.ReadByte() << 16 /*0x10*/;
      this.keyId |= (long) bcpgIn.ReadByte() << 8;
      this.keyId |= (long) (uint) bcpgIn.ReadByte();
      this.keyAlgorithm = (PublicKeyAlgorithmTag) bcpgIn.ReadByte();
      this.hashAlgorithm = (HashAlgorithmTag) bcpgIn.ReadByte();
    }
    this.fingerprint = new byte[2];
    bcpgIn.ReadFully(this.fingerprint);
    switch (this.keyAlgorithm)
    {
      case PublicKeyAlgorithmTag.RsaGeneral:
      case PublicKeyAlgorithmTag.RsaSign:
        this.signature = new MPInteger[1]
        {
          new MPInteger(bcpgIn)
        };
        break;
      case PublicKeyAlgorithmTag.ElGamalEncrypt:
      case PublicKeyAlgorithmTag.ElGamalGeneral:
        this.signature = new MPInteger[3]
        {
          new MPInteger(bcpgIn),
          new MPInteger(bcpgIn),
          new MPInteger(bcpgIn)
        };
        break;
      case PublicKeyAlgorithmTag.Dsa:
        this.signature = new MPInteger[2]
        {
          new MPInteger(bcpgIn),
          new MPInteger(bcpgIn)
        };
        break;
      case PublicKeyAlgorithmTag.ECDsa:
      case PublicKeyAlgorithmTag.EdDsa:
        this.signature = new MPInteger[2]
        {
          new MPInteger(bcpgIn),
          new MPInteger(bcpgIn)
        };
        break;
      default:
        if (this.keyAlgorithm < PublicKeyAlgorithmTag.Experimental_1 || this.keyAlgorithm > PublicKeyAlgorithmTag.Experimental_11)
          throw new IOException("unknown signature key algorithm: " + this.keyAlgorithm.ToString());
        this.signature = (MPInteger[]) null;
        this.signatureEncoding = Streams.ReadAll((Stream) bcpgIn);
        break;
    }
  }

  public SignaturePacket(
    int signatureType,
    long keyId,
    PublicKeyAlgorithmTag keyAlgorithm,
    HashAlgorithmTag hashAlgorithm,
    SignatureSubpacket[] hashedData,
    SignatureSubpacket[] unhashedData,
    byte[] fingerprint,
    MPInteger[] signature)
    : this(4, signatureType, keyId, keyAlgorithm, hashAlgorithm, hashedData, unhashedData, fingerprint, signature)
  {
  }

  public SignaturePacket(
    int version,
    int signatureType,
    long keyId,
    PublicKeyAlgorithmTag keyAlgorithm,
    HashAlgorithmTag hashAlgorithm,
    long creationTime,
    byte[] fingerprint,
    MPInteger[] signature)
    : this(version, signatureType, keyId, keyAlgorithm, hashAlgorithm, (SignatureSubpacket[]) null, (SignatureSubpacket[]) null, fingerprint, signature)
  {
    this.creationTime = creationTime;
  }

  public SignaturePacket(
    int version,
    int signatureType,
    long keyId,
    PublicKeyAlgorithmTag keyAlgorithm,
    HashAlgorithmTag hashAlgorithm,
    SignatureSubpacket[] hashedData,
    SignatureSubpacket[] unhashedData,
    byte[] fingerprint,
    MPInteger[] signature)
  {
    this.version = version;
    this.signatureType = signatureType;
    this.keyId = keyId;
    this.keyAlgorithm = keyAlgorithm;
    this.hashAlgorithm = hashAlgorithm;
    this.hashedData = hashedData;
    this.unhashedData = unhashedData;
    this.fingerprint = fingerprint;
    this.signature = signature;
    if (hashedData == null)
      return;
    this.SetCreationTime();
  }

  public int Version => this.version;

  public int SignatureType => this.signatureType;

  public long KeyId => this.keyId;

  public byte[] GetFingerprint() => Arrays.Clone(this.fingerprint);

  public byte[] GetSignatureTrailer()
  {
    if (this.version == 3)
    {
      long num = this.creationTime / 1000L;
      return new byte[5]
      {
        (byte) this.signatureType,
        (byte) (num >> 24),
        (byte) (num >> 16 /*0x10*/),
        (byte) (num >> 8),
        (byte) num
      };
    }
    MemoryStream os = new MemoryStream();
    os.WriteByte((byte) this.Version);
    os.WriteByte((byte) this.SignatureType);
    os.WriteByte((byte) this.KeyAlgorithm);
    os.WriteByte((byte) this.HashAlgorithm);
    long position = os.Position;
    os.WriteByte((byte) 0);
    os.WriteByte((byte) 0);
    SignatureSubpacket[] hashedSubPackets = this.GetHashedSubPackets();
    for (int index = 0; index != hashedSubPackets.Length; ++index)
      hashedSubPackets[index].Encode((Stream) os);
    ushort uint16 = Convert.ToUInt16(os.Position - position - 2L);
    uint uint32 = Convert.ToUInt32(os.Position);
    os.WriteByte((byte) this.Version);
    os.WriteByte(byte.MaxValue);
    os.WriteByte((byte) (uint32 >> 24));
    os.WriteByte((byte) (uint32 >> 16 /*0x10*/));
    os.WriteByte((byte) (uint32 >> 8));
    os.WriteByte((byte) uint32);
    os.Position = position;
    os.WriteByte((byte) ((uint) uint16 >> 8));
    os.WriteByte((byte) uint16);
    return os.ToArray();
  }

  public PublicKeyAlgorithmTag KeyAlgorithm => this.keyAlgorithm;

  public HashAlgorithmTag HashAlgorithm => this.hashAlgorithm;

  public MPInteger[] GetSignature() => this.signature;

  public byte[] GetSignatureBytes()
  {
    if (this.signatureEncoding != null)
      return (byte[]) this.signatureEncoding.Clone();
    MemoryStream outStr = new MemoryStream();
    using (BcpgOutputStream bcpgOutputStream = new BcpgOutputStream((Stream) outStr))
    {
      foreach (MPInteger mpInteger in this.signature)
      {
        try
        {
          bcpgOutputStream.WriteObject((BcpgObject) mpInteger);
        }
        catch (IOException ex)
        {
          throw new Exception("internal error: " + ex?.ToString());
        }
      }
    }
    return outStr.ToArray();
  }

  public SignatureSubpacket[] GetHashedSubPackets() => this.hashedData;

  public SignatureSubpacket[] GetUnhashedSubPackets() => this.unhashedData;

  public long CreationTime => this.creationTime;

  public override void Encode(BcpgOutputStream bcpgOut)
  {
    MemoryStream outStr = new MemoryStream();
    using (BcpgOutputStream pOut = new BcpgOutputStream((Stream) outStr))
    {
      pOut.WriteByte((byte) this.version);
      if (this.version != 3 && this.version != 2)
      {
        if (this.version != 4)
          throw new IOException("unknown version: " + this.version.ToString());
        pOut.Write((byte) this.signatureType, (byte) this.keyAlgorithm, (byte) this.hashAlgorithm);
        SignaturePacket.EncodeLengthAndData(pOut, SignaturePacket.GetEncodedSubpackets(this.hashedData));
        SignaturePacket.EncodeLengthAndData(pOut, SignaturePacket.GetEncodedSubpackets(this.unhashedData));
      }
      else
      {
        pOut.Write((byte) 5, (byte) this.signatureType);
        pOut.WriteInt((int) (this.creationTime / 1000L));
        pOut.WriteLong(this.keyId);
        pOut.Write((byte) this.keyAlgorithm, (byte) this.hashAlgorithm);
      }
      pOut.Write(this.fingerprint);
      if (this.signature != null)
        pOut.WriteObjects((BcpgObject[]) this.signature);
      else
        pOut.Write(this.signatureEncoding);
    }
    bcpgOut.WritePacket(PacketTag.Signature, outStr.ToArray());
  }

  private static void EncodeLengthAndData(BcpgOutputStream pOut, byte[] data)
  {
    pOut.WriteShort((short) data.Length);
    pOut.Write(data);
  }

  private static byte[] GetEncodedSubpackets(SignatureSubpacket[] ps)
  {
    MemoryStream os = new MemoryStream();
    foreach (SignatureSubpacket p in ps)
      p.Encode((Stream) os);
    return os.ToArray();
  }

  private void SetCreationTime()
  {
    foreach (SignatureSubpacket signatureSubpacket in this.hashedData)
    {
      if (signatureSubpacket is SignatureCreationTime signatureCreationTime)
      {
        this.creationTime = DateTimeUtilities.DateTimeToUnixMs(signatureCreationTime.GetTime());
        break;
      }
    }
  }

  public static SignaturePacket FromByteArray(byte[] data)
  {
    return new SignaturePacket(BcpgInputStream.Wrap((Stream) new MemoryStream(data)));
  }
}
