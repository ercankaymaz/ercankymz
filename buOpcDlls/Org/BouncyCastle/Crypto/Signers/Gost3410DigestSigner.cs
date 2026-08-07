// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.Gost3410DigestSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class Gost3410DigestSigner : ISigner
{
  private readonly IDigest digest;
  private readonly IDsa dsaSigner;
  private readonly int size;
  private int halfSize;
  private bool forSigning;

  public Gost3410DigestSigner(IDsa signer, IDigest digest)
  {
    this.dsaSigner = signer;
    this.digest = digest;
    this.halfSize = digest.GetDigestSize();
    this.size = this.halfSize * 2;
  }

  public virtual string AlgorithmName
  {
    get => $"{this.digest.AlgorithmName}with{this.dsaSigner.AlgorithmName}";
  }

  public virtual void Init(bool forSigning, ICipherParameters parameters)
  {
    this.forSigning = forSigning;
    AsymmetricKeyParameter asymmetricKeyParameter = !(parameters is ParametersWithRandom parametersWithRandom) ? (AsymmetricKeyParameter) parameters : (AsymmetricKeyParameter) parametersWithRandom.Parameters;
    if (forSigning && !asymmetricKeyParameter.IsPrivate)
      throw new InvalidKeyException("Signing Requires Private Key.");
    if (!forSigning && asymmetricKeyParameter.IsPrivate)
      throw new InvalidKeyException("Verification Requires Public Key.");
    this.Reset();
    this.dsaSigner.Init(forSigning, parameters);
  }

  public virtual void Update(byte input) => this.digest.Update(input);

  public virtual void BlockUpdate(byte[] input, int inOff, int inLen)
  {
    this.digest.BlockUpdate(input, inOff, inLen);
  }

  public virtual int GetMaxSignatureSize() => this.size;

  public virtual byte[] GenerateSignature()
  {
    if (!this.forSigning)
      throw new InvalidOperationException("GOST3410DigestSigner not initialised for signature generation.");
    byte[] numArray = new byte[this.digest.GetDigestSize()];
    this.digest.DoFinal(numArray, 0);
    try
    {
      BigInteger[] signature1 = this.dsaSigner.GenerateSignature(numArray);
      byte[] signature2 = new byte[this.size];
      byte[] byteArrayUnsigned1 = signature1[0].ToByteArrayUnsigned();
      byte[] byteArrayUnsigned2 = signature1[1].ToByteArrayUnsigned();
      byteArrayUnsigned2.CopyTo((Array) signature2, this.halfSize - byteArrayUnsigned2.Length);
      byteArrayUnsigned1.CopyTo((Array) signature2, this.size - byteArrayUnsigned1.Length);
      return signature2;
    }
    catch (Exception ex)
    {
      throw new SignatureException(ex.Message, ex);
    }
  }

  public virtual bool VerifySignature(byte[] signature)
  {
    if (this.forSigning)
      throw new InvalidOperationException("DSADigestSigner not initialised for verification");
    byte[] numArray = new byte[this.digest.GetDigestSize()];
    this.digest.DoFinal(numArray, 0);
    BigInteger r;
    BigInteger s;
    try
    {
      r = new BigInteger(1, signature, this.halfSize, this.halfSize);
      s = new BigInteger(1, signature, 0, this.halfSize);
    }
    catch (Exception ex)
    {
      throw new SignatureException("error decoding signature bytes.", ex);
    }
    return this.dsaSigner.VerifySignature(numArray, r, s);
  }

  public virtual void Reset() => this.digest.Reset();
}
