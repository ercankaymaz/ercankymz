// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpV3SignatureGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Date;
using System;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpV3SignatureGenerator
{
  private readonly PublicKeyAlgorithmTag keyAlgorithm;
  private readonly HashAlgorithmTag hashAlgorithm;
  private PgpPrivateKey privKey;
  private ISigner sig;
  private IDigest dig;
  private int signatureType;
  private byte lastb;

  public PgpV3SignatureGenerator(PublicKeyAlgorithmTag keyAlgorithm, HashAlgorithmTag hashAlgorithm)
  {
    this.keyAlgorithm = keyAlgorithm != PublicKeyAlgorithmTag.EdDsa ? keyAlgorithm : throw new ArgumentException("Invalid algorithm for V3 signature", nameof (keyAlgorithm));
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
      this.sig.Init(true, ParameterUtilities.WithRandom((ICipherParameters) key, random));
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

  public PgpOnePassSignature GenerateOnePassVersion(bool isNested)
  {
    return new PgpOnePassSignature(new OnePassSignaturePacket(this.signatureType, this.hashAlgorithm, this.keyAlgorithm, this.privKey.KeyId, isNested));
  }

  public PgpSignature Generate()
  {
    long num = DateTimeUtilities.CurrentUnixMs() / 1000L;
    byte[] input = new byte[5]
    {
      (byte) this.signatureType,
      (byte) (num >> 24),
      (byte) (num >> 16 /*0x10*/),
      (byte) (num >> 8),
      (byte) num
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
    MPInteger[] signature2 = (this.keyAlgorithm == PublicKeyAlgorithmTag.RsaSign ? 1 : (this.keyAlgorithm == PublicKeyAlgorithmTag.RsaGeneral ? 1 : 0)) != 0 ? PgpUtilities.RsaSigToMpi(signature1) : PgpUtilities.DsaSigToMpi(signature1);
    return new PgpSignature(new SignaturePacket(3, this.signatureType, this.privKey.KeyId, this.keyAlgorithm, this.hashAlgorithm, num * 1000L, fingerprint, signature2));
  }
}
