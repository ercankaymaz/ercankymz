// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpSignatureGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Bcpg.Sig;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC.Rfc8032;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpSignatureGenerator
{
  private static readonly SignatureSubpacket[] EmptySignatureSubpackets = new SignatureSubpacket[0];
  private readonly PublicKeyAlgorithmTag keyAlgorithm;
  private readonly HashAlgorithmTag hashAlgorithm;
  private PgpPrivateKey privKey;
  private ISigner sig;
  private IDigest dig;
  private int signatureType;
  private byte lastb;
  private SignatureSubpacket[] unhashed = PgpSignatureGenerator.EmptySignatureSubpackets;
  private SignatureSubpacket[] hashed = PgpSignatureGenerator.EmptySignatureSubpackets;

  public PgpSignatureGenerator(PublicKeyAlgorithmTag keyAlgorithm, HashAlgorithmTag hashAlgorithm)
  {
    this.keyAlgorithm = keyAlgorithm;
    this.hashAlgorithm = hashAlgorithm;
    this.dig = PgpUtilities.CreateDigest(hashAlgorithm);
  }

  public void InitSign(int sigType, PgpPrivateKey privKey)
  {
    this.InitSign(sigType, privKey, (SecureRandom) null);
  }

  public void InitSign(int sigType, PgpPrivateKey privKey, SecureRandom random)
  {
    this.privKey = privKey;
    this.signatureType = sigType;
    AsymmetricKeyParameter key = privKey.Key;
    this.sig = PgpUtilities.CreateSigner(this.keyAlgorithm, this.hashAlgorithm, key);
    try
    {
      ICipherParameters cipherParameters = (ICipherParameters) key;
      if (this.keyAlgorithm != PublicKeyAlgorithmTag.EdDsa)
        cipherParameters = ParameterUtilities.WithRandom(cipherParameters, random);
      this.sig.Init(true, cipherParameters);
    }
    catch (InvalidKeyException ex)
    {
      throw new PgpException("invalid key.", (Exception) ex);
    }
    this.dig.Reset();
    this.lastb = (byte) 0;
  }

  public void Update(byte b)
  {
    if (this.signatureType == 1)
      this.DoCanonicalUpdateByte(b);
    else
      this.DoUpdateByte(b);
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
        this.DoUpdateByte(b);
        break;
    }
    this.lastb = b;
  }

  private void DoUpdateCRLF()
  {
    this.DoUpdateByte((byte) 13);
    this.DoUpdateByte((byte) 10);
  }

  private void DoUpdateByte(byte b)
  {
    this.sig.Update(b);
    this.dig.Update(b);
  }

  public void Update(params byte[] b) => this.Update(b, 0, b.Length);

  public void Update(byte[] b, int off, int len)
  {
    if (this.signatureType == 1)
    {
      int num = off + len;
      for (int index = off; index != num; ++index)
        this.DoCanonicalUpdateByte(b[index]);
    }
    else
    {
      this.sig.BlockUpdate(b, off, len);
      this.dig.BlockUpdate(b, off, len);
    }
  }

  public void SetHashedSubpackets(PgpSignatureSubpacketVector hashedPackets)
  {
    this.hashed = hashedPackets == null ? PgpSignatureGenerator.EmptySignatureSubpackets : hashedPackets.ToSubpacketArray();
  }

  public void SetUnhashedSubpackets(PgpSignatureSubpacketVector unhashedPackets)
  {
    this.unhashed = unhashedPackets == null ? PgpSignatureGenerator.EmptySignatureSubpackets : unhashedPackets.ToSubpacketArray();
  }

  public PgpOnePassSignature GenerateOnePassVersion(bool isNested)
  {
    return new PgpOnePassSignature(new OnePassSignaturePacket(this.signatureType, this.hashAlgorithm, this.keyAlgorithm, this.privKey.KeyId, isNested));
  }

  public PgpSignature Generate()
  {
    SignatureSubpacket[] signatureSubpacketArray1 = this.hashed;
    SignatureSubpacket[] signatureSubpacketArray2 = this.unhashed;
    if (!PgpSignatureGenerator.IsPacketPresent(this.hashed, SignatureSubpacketTag.CreationTime))
      signatureSubpacketArray1 = PgpSignatureGenerator.InsertSubpacket(signatureSubpacketArray1, (SignatureSubpacket) new SignatureCreationTime(false, DateTime.UtcNow));
    if (!PgpSignatureGenerator.IsPacketPresent(this.hashed, SignatureSubpacketTag.IssuerKeyId) && !PgpSignatureGenerator.IsPacketPresent(this.unhashed, SignatureSubpacketTag.IssuerKeyId))
      signatureSubpacketArray2 = PgpSignatureGenerator.InsertSubpacket(signatureSubpacketArray2, (SignatureSubpacket) new IssuerKeyId(false, this.privKey.KeyId));
    int num = 4;
    byte[] array1;
    try
    {
      MemoryStream os = new MemoryStream();
      for (int index = 0; index != signatureSubpacketArray1.Length; ++index)
        signatureSubpacketArray1[index].Encode((Stream) os);
      byte[] array2 = os.ToArray();
      MemoryStream memoryStream = new MemoryStream(array2.Length + 6);
      memoryStream.WriteByte((byte) num);
      memoryStream.WriteByte((byte) this.signatureType);
      memoryStream.WriteByte((byte) this.keyAlgorithm);
      memoryStream.WriteByte((byte) this.hashAlgorithm);
      memoryStream.WriteByte((byte) (array2.Length >> 8));
      memoryStream.WriteByte((byte) array2.Length);
      memoryStream.Write(array2, 0, array2.Length);
      array1 = memoryStream.ToArray();
    }
    catch (IOException ex)
    {
      throw new PgpException("exception encoding hashed data.", (Exception) ex);
    }
    this.sig.BlockUpdate(array1, 0, array1.Length);
    this.dig.BlockUpdate(array1, 0, array1.Length);
    byte[] input = new byte[6]
    {
      (byte) num,
      byte.MaxValue,
      (byte) (array1.Length >> 24),
      (byte) (array1.Length >> 16 /*0x10*/),
      (byte) (array1.Length >> 8),
      (byte) array1.Length
    };
    this.sig.BlockUpdate(input, 0, input.Length);
    this.dig.BlockUpdate(input, 0, input.Length);
    byte[] signature1 = this.sig.GenerateSignature();
    byte[] numArray = DigestUtilities.DoFinal(this.dig);
    byte[] fingerprint = new byte[2]
    {
      numArray[0],
      numArray[1]
    };
    MPInteger[] signature2;
    if (this.keyAlgorithm == PublicKeyAlgorithmTag.EdDsa)
    {
      int length = signature1.Length;
      if (length == Ed25519.SignatureSize)
      {
        signature2 = new MPInteger[2]
        {
          new MPInteger(new BigInteger(1, signature1, 0, 32 /*0x20*/)),
          new MPInteger(new BigInteger(1, signature1, 32 /*0x20*/, 32 /*0x20*/))
        };
      }
      else
      {
        if (length != Ed448.SignatureSize)
          throw new InvalidOperationException();
        signature2 = new MPInteger[2]
        {
          new MPInteger(new BigInteger(1, Arrays.Prepend(signature1, (byte) 64 /*0x40*/))),
          new MPInteger(BigInteger.Zero)
        };
      }
    }
    else
      signature2 = this.keyAlgorithm == PublicKeyAlgorithmTag.RsaSign || this.keyAlgorithm == PublicKeyAlgorithmTag.RsaGeneral ? PgpUtilities.RsaSigToMpi(signature1) : PgpUtilities.DsaSigToMpi(signature1);
    return new PgpSignature(new SignaturePacket(this.signatureType, this.privKey.KeyId, this.keyAlgorithm, this.hashAlgorithm, signatureSubpacketArray1, signatureSubpacketArray2, fingerprint, signature2));
  }

  public PgpSignature GenerateCertification(string id, PgpPublicKey pubKey)
  {
    this.UpdateWithPublicKey(pubKey);
    this.UpdateWithIdData(180, Strings.ToUtf8ByteArray(id));
    return this.Generate();
  }

  public PgpSignature GenerateCertification(
    PgpUserAttributeSubpacketVector userAttributes,
    PgpPublicKey pubKey)
  {
    this.UpdateWithPublicKey(pubKey);
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
    return this.Generate();
  }

  public PgpSignature GenerateCertification(PgpPublicKey masterKey, PgpPublicKey pubKey)
  {
    this.UpdateWithPublicKey(masterKey);
    this.UpdateWithPublicKey(pubKey);
    return this.Generate();
  }

  public PgpSignature GenerateCertification(PgpPublicKey pubKey)
  {
    this.UpdateWithPublicKey(pubKey);
    return this.Generate();
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

  private static bool IsPacketPresent(SignatureSubpacket[] packets, SignatureSubpacketTag type)
  {
    for (int index = 0; index != packets.Length; ++index)
    {
      if (packets[index].SubpacketType == type)
        return true;
    }
    return false;
  }

  private static SignatureSubpacket[] InsertSubpacket(
    SignatureSubpacket[] packets,
    SignatureSubpacket subpacket)
  {
    return Arrays.Prepend<SignatureSubpacket>(packets, subpacket);
  }

  private void UpdateWithIdData(int header, byte[] idBytes)
  {
    this.Update((byte) header, (byte) (idBytes.Length >> 24), (byte) (idBytes.Length >> 16 /*0x10*/), (byte) (idBytes.Length >> 8), (byte) idBytes.Length);
    this.Update(idBytes);
  }

  private void UpdateWithPublicKey(PgpPublicKey key)
  {
    byte[] encodedPublicKey = PgpSignatureGenerator.GetEncodedPublicKey(key);
    this.Update((byte) 153, (byte) (encodedPublicKey.Length >> 8), (byte) encodedPublicKey.Length);
    this.Update(encodedPublicKey);
  }
}
