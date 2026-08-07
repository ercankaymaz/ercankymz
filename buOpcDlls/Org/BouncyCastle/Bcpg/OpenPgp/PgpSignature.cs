// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpSignature
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC.Rfc8032;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Date;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpSignature
{
  public const int BinaryDocument = 0;
  public const int CanonicalTextDocument = 1;
  public const int StandAlone = 2;
  public const int DefaultCertification = 16 /*0x10*/;
  public const int NoCertification = 17;
  public const int CasualCertification = 18;
  public const int PositiveCertification = 19;
  public const int SubkeyBinding = 24;
  public const int PrimaryKeyBinding = 25;
  public const int DirectKey = 31 /*0x1F*/;
  public const int KeyRevocation = 32 /*0x20*/;
  public const int SubkeyRevocation = 40;
  public const int CertificationRevocation = 48 /*0x30*/;
  public const int Timestamp = 64 /*0x40*/;
  public const int ThirdPartyConfirmation = 80 /*0x50*/;
  private readonly SignaturePacket sigPck;
  private readonly int signatureType;
  private readonly TrustPacket trustPck;
  private ISigner sig;
  private byte lastb;

  private static SignaturePacket Cast(Packet packet)
  {
    return packet is SignaturePacket signaturePacket ? signaturePacket : throw new IOException("unexpected packet in stream: " + packet?.ToString());
  }

  internal PgpSignature(BcpgInputStream bcpgInput)
    : this(PgpSignature.Cast(bcpgInput.ReadPacket()))
  {
  }

  internal PgpSignature(SignaturePacket sigPacket)
    : this(sigPacket, (TrustPacket) null)
  {
  }

  internal PgpSignature(SignaturePacket sigPacket, TrustPacket trustPacket)
  {
    this.sigPck = sigPacket ?? throw new ArgumentNullException(nameof (sigPacket));
    this.signatureType = this.sigPck.SignatureType;
    this.trustPck = trustPacket;
  }

  public int Version => this.sigPck.Version;

  public PublicKeyAlgorithmTag KeyAlgorithm => this.sigPck.KeyAlgorithm;

  public HashAlgorithmTag HashAlgorithm => this.sigPck.HashAlgorithm;

  public byte[] GetDigestPrefix() => this.sigPck.GetFingerprint();

  public bool IsCertification() => PgpSignature.IsCertification(this.SignatureType);

  public void InitVerify(PgpPublicKey pubKey)
  {
    this.lastb = (byte) 0;
    AsymmetricKeyParameter key = pubKey.GetKey();
    if (this.sig == null)
      this.sig = PgpUtilities.CreateSigner(this.sigPck.KeyAlgorithm, this.sigPck.HashAlgorithm, key);
    try
    {
      this.sig.Init(false, (ICipherParameters) key);
    }
    catch (InvalidKeyException ex)
    {
      throw new PgpException("invalid key.", (Exception) ex);
    }
  }

  public void Update(byte b)
  {
    if (this.signatureType == 1)
      this.DoCanonicalUpdateByte(b);
    else
      this.sig.Update(b);
  }

  private void DoCanonicalUpdateByte(byte b)
  {
    switch (b)
    {
      case 10:
        if (this.lastb != (byte) 13)
        {
          this.DoUpdateCRLF();
          break;
        }
        break;
      case 13:
        this.DoUpdateCRLF();
        break;
      default:
        this.sig.Update(b);
        break;
    }
    this.lastb = b;
  }

  private void DoUpdateCRLF()
  {
    this.sig.Update((byte) 13);
    this.sig.Update((byte) 10);
  }

  public void Update(params byte[] bytes) => this.Update(bytes, 0, bytes.Length);

  public void Update(byte[] bytes, int off, int length)
  {
    if (this.signatureType == 1)
    {
      int num = off + length;
      for (int index = off; index != num; ++index)
        this.DoCanonicalUpdateByte(bytes[index]);
    }
    else
      this.sig.BlockUpdate(bytes, off, length);
  }

  public bool Verify()
  {
    byte[] signatureTrailer = this.GetSignatureTrailer();
    this.sig.BlockUpdate(signatureTrailer, 0, signatureTrailer.Length);
    return this.sig.VerifySignature(this.GetSignature());
  }

  private void UpdateWithIdData(int header, byte[] idBytes)
  {
    this.Update((byte) header, (byte) (idBytes.Length >> 24), (byte) (idBytes.Length >> 16 /*0x10*/), (byte) (idBytes.Length >> 8), (byte) idBytes.Length);
    this.Update(idBytes);
  }

  private void UpdateWithPublicKey(PgpPublicKey key)
  {
    byte[] encodedPublicKey = PgpSignature.GetEncodedPublicKey(key);
    this.Update((byte) 153, (byte) (encodedPublicKey.Length >> 8), (byte) encodedPublicKey.Length);
    this.Update(encodedPublicKey);
  }

  public bool VerifyCertification(PgpUserAttributeSubpacketVector userAttributes, PgpPublicKey key)
  {
    this.UpdateWithPublicKey(key);
    try
    {
      MemoryStream os = new MemoryStream();
      foreach (UserAttributeSubpacket subpacket in userAttributes.ToSubpacketArray())
        subpacket.Encode((Stream) os);
      this.UpdateWithIdData(209, os.ToArray());
    }
    catch (IOException ex)
    {
      throw new PgpException("cannot encode subpacket array", (Exception) ex);
    }
    return this.Verify();
  }

  public bool VerifyCertification(string id, PgpPublicKey key)
  {
    this.UpdateWithPublicKey(key);
    this.UpdateWithIdData(180, Strings.ToUtf8ByteArray(id));
    return this.Verify();
  }

  public bool VerifyCertification(PgpPublicKey masterKey, PgpPublicKey pubKey)
  {
    this.UpdateWithPublicKey(masterKey);
    this.UpdateWithPublicKey(pubKey);
    return this.Verify();
  }

  public bool VerifyCertification(PgpPublicKey pubKey)
  {
    if (this.SignatureType != 32 /*0x20*/ && this.SignatureType != 40)
      throw new InvalidOperationException("signature is not a key signature");
    this.UpdateWithPublicKey(pubKey);
    return this.Verify();
  }

  public int SignatureType => this.sigPck.SignatureType;

  public long KeyId => this.sigPck.KeyId;

  public DateTime CreationTime => DateTimeUtilities.UnixMsToDateTime(this.sigPck.CreationTime);

  public byte[] GetSignatureTrailer() => this.sigPck.GetSignatureTrailer();

  public bool HasSubpackets
  {
    get => this.sigPck.GetHashedSubPackets() != null || this.sigPck.GetUnhashedSubPackets() != null;
  }

  public PgpSignatureSubpacketVector GetHashedSubPackets()
  {
    return PgpSignature.CreateSubpacketVector(this.sigPck.GetHashedSubPackets());
  }

  public PgpSignatureSubpacketVector GetUnhashedSubPackets()
  {
    return PgpSignature.CreateSubpacketVector(this.sigPck.GetUnhashedSubPackets());
  }

  private static PgpSignatureSubpacketVector CreateSubpacketVector(SignatureSubpacket[] pcks)
  {
    return pcks != null ? new PgpSignatureSubpacketVector(pcks) : (PgpSignatureSubpacketVector) null;
  }

  public byte[] GetSignature()
  {
    MPInteger[] signature = this.sigPck.GetSignature();
    byte[] buf;
    if (signature != null)
    {
      if (signature.Length == 1)
        buf = signature[0].Value.ToByteArrayUnsigned();
      else if (this.KeyAlgorithm == PublicKeyAlgorithmTag.EdDsa)
      {
        BigInteger bigInteger1 = signature.Length == 2 ? signature[0].Value : throw new InvalidOperationException();
        BigInteger bigInteger2 = signature[1].Value;
        if (bigInteger1.BitLength == 918 && bigInteger2.Equals(BigInteger.Zero) && bigInteger1.ShiftRight(912).Equals(BigInteger.ValueOf(64L /*0x40*/)))
        {
          buf = new byte[Ed448.SignatureSize];
          BigIntegers.AsUnsignedByteArray(bigInteger1.ClearBit(918), buf, 0, buf.Length);
        }
        else
        {
          if (bigInteger1.BitLength > 256 /*0x0100*/ || bigInteger2.BitLength > 256 /*0x0100*/)
            throw new InvalidOperationException();
          buf = new byte[Ed25519.SignatureSize];
          BigIntegers.AsUnsignedByteArray(signature[0].Value, buf, 0, 32 /*0x20*/);
          BigIntegers.AsUnsignedByteArray(signature[1].Value, buf, 32 /*0x20*/, 32 /*0x20*/);
        }
      }
      else
      {
        if (signature.Length != 2)
          throw new InvalidOperationException();
        try
        {
          buf = new DerSequence((Asn1Encodable) new DerInteger(signature[0].Value), (Asn1Encodable) new DerInteger(signature[1].Value)).GetEncoded();
        }
        catch (IOException ex)
        {
          throw new PgpException("exception encoding DSA sig.", (Exception) ex);
        }
      }
    }
    else
      buf = this.sigPck.GetSignatureBytes();
    return buf;
  }

  public byte[] GetEncoded()
  {
    MemoryStream outStream = new MemoryStream();
    this.Encode((Stream) outStream);
    return outStream.ToArray();
  }

  public void Encode(Stream outStream) => this.Encode(outStream, false);

  public void Encode(Stream outStream, bool forTransfer)
  {
    if (forTransfer && (!this.GetHashedSubPackets().IsExportable() || !this.GetUnhashedSubPackets().IsExportable()))
      return;
    BcpgOutputStream bcpgOutputStream = BcpgOutputStream.Wrap(outStream);
    bcpgOutputStream.WritePacket((ContainedPacket) this.sigPck);
    if (forTransfer || this.trustPck == null)
      return;
    bcpgOutputStream.WritePacket((ContainedPacket) this.trustPck);
  }

  private static byte[] GetEncodedPublicKey(PgpPublicKey pubKey)
  {
    try
    {
      return pubKey.publicPk.GetEncodedContents();
    }
    catch (IOException ex)
    {
      throw new PgpException("exception preparing key.", (Exception) ex);
    }
  }

  public static bool IsCertification(int signatureType)
  {
    switch (signatureType)
    {
      case 16 /*0x10*/:
      case 17:
      case 18:
      case 19:
        return true;
      default:
        return false;
    }
  }

  public static bool IsSignatureEncodingEqual(PgpSignature sig1, PgpSignature sig2)
  {
    return Arrays.AreEqual(sig1.sigPck.GetSignatureBytes(), sig2.sigPck.GetSignatureBytes());
  }

  public static PgpSignature Join(PgpSignature sig1, PgpSignature sig2)
  {
    SignatureSubpacket[] collection = PgpSignature.IsSignatureEncodingEqual(sig1, sig2) ? sig1.GetUnhashedSubPackets().ToSubpacketArray() : throw new ArgumentException("These are different signatures.");
    SignatureSubpacket[] subpacketArray = sig2.GetUnhashedSubPackets().ToSubpacketArray();
    List<SignatureSubpacket> signatureSubpacketList = new List<SignatureSubpacket>((IEnumerable<SignatureSubpacket>) collection);
    foreach (SignatureSubpacket signatureSubpacket in subpacketArray)
    {
      if (!signatureSubpacketList.Contains(signatureSubpacket))
        signatureSubpacketList.Add(signatureSubpacket);
    }
    SignatureSubpacket[] array = signatureSubpacketList.ToArray();
    return new PgpSignature(new SignaturePacket(sig1.SignatureType, sig1.KeyId, sig1.KeyAlgorithm, sig1.HashAlgorithm, sig1.GetHashedSubPackets().ToSubpacketArray(), array, sig1.GetDigestPrefix(), sig1.sigPck.GetSignature()));
  }
}
