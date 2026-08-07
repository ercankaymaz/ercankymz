// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.DsaDigestSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class DsaDigestSigner : ISigner
{
  private readonly IDsa dsa;
  private readonly IDigest digest;
  private readonly IDsaEncoding encoding;
  private bool forSigning;

  public DsaDigestSigner(IDsa dsa, IDigest digest)
    : this(dsa, digest, (IDsaEncoding) StandardDsaEncoding.Instance)
  {
  }

  public DsaDigestSigner(IDsa dsa, IDigest digest, IDsaEncoding encoding)
  {
    this.dsa = dsa;
    this.digest = digest;
    this.encoding = encoding;
  }

  public virtual string AlgorithmName => $"{this.digest.AlgorithmName}with{this.dsa.AlgorithmName}";

  public virtual void Init(bool forSigning, ICipherParameters parameters)
  {
    this.forSigning = forSigning;
    AsymmetricKeyParameter asymmetricKeyParameter = !(parameters is ParametersWithRandom parametersWithRandom) ? (AsymmetricKeyParameter) parameters : (AsymmetricKeyParameter) parametersWithRandom.Parameters;
    if (forSigning && !asymmetricKeyParameter.IsPrivate)
      throw new InvalidKeyException("Signing Requires Private Key.");
    if (!forSigning && asymmetricKeyParameter.IsPrivate)
      throw new InvalidKeyException("Verification Requires Public Key.");
    this.Reset();
    this.dsa.Init(forSigning, parameters);
  }

  public virtual void Update(byte input) => this.digest.Update(input);

  public virtual void BlockUpdate(byte[] input, int inOff, int inLen)
  {
    this.digest.BlockUpdate(input, inOff, inLen);
  }

  public virtual int GetMaxSignatureSize() => this.encoding.GetMaxEncodingSize(this.GetOrder());

  public virtual byte[] GenerateSignature()
  {
    if (!this.forSigning)
      throw new InvalidOperationException("DsaDigestSigner not initialized for signature generation.");
    byte[] numArray = new byte[this.digest.GetDigestSize()];
    this.digest.DoFinal(numArray, 0);
    BigInteger[] signature = this.dsa.GenerateSignature(numArray);
    try
    {
      return this.encoding.Encode(this.GetOrder(), signature[0], signature[1]);
    }
    catch (Exception ex)
    {
      throw new InvalidOperationException("unable to encode signature");
    }
  }

  public virtual bool VerifySignature(byte[] signature)
  {
    if (this.forSigning)
      throw new InvalidOperationException("DsaDigestSigner not initialized for verification");
    byte[] numArray = new byte[this.digest.GetDigestSize()];
    this.digest.DoFinal(numArray, 0);
    try
    {
      BigInteger[] bigIntegerArray = this.encoding.Decode(this.GetOrder(), signature);
      return this.dsa.VerifySignature(numArray, bigIntegerArray[0], bigIntegerArray[1]);
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public virtual void Reset() => this.digest.Reset();

  protected virtual BigInteger GetOrder() => this.dsa.Order;
}
