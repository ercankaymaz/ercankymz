// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.Ed448phSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math.EC.Rfc8032;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class Ed448phSigner : ISigner
{
  private readonly IXof prehash = Ed448.CreatePrehash();
  private readonly byte[] context;
  private bool forSigning;
  private Ed448PrivateKeyParameters privateKey;
  private Ed448PublicKeyParameters publicKey;

  public Ed448phSigner(byte[] context)
  {
    this.context = context != null ? (byte[]) context.Clone() : throw new ArgumentNullException(nameof (context));
  }

  public virtual string AlgorithmName => "Ed448ph";

  public virtual void Init(bool forSigning, ICipherParameters parameters)
  {
    this.forSigning = forSigning;
    if (forSigning)
    {
      this.privateKey = (Ed448PrivateKeyParameters) parameters;
      this.publicKey = (Ed448PublicKeyParameters) null;
    }
    else
    {
      this.privateKey = (Ed448PrivateKeyParameters) null;
      this.publicKey = (Ed448PublicKeyParameters) parameters;
    }
    this.Reset();
  }

  public virtual void Update(byte b) => this.prehash.Update(b);

  public virtual void BlockUpdate(byte[] buf, int off, int len)
  {
    this.prehash.BlockUpdate(buf, off, len);
  }

  public virtual int GetMaxSignatureSize() => Ed448.SignatureSize;

  public virtual byte[] GenerateSignature()
  {
    if (!this.forSigning || this.privateKey == null)
      throw new InvalidOperationException("Ed448phSigner not initialised for signature generation.");
    byte[] numArray = new byte[Ed448.PrehashSize];
    if (Ed448.PrehashSize != this.prehash.OutputFinal(numArray, 0, Ed448.PrehashSize))
      throw new InvalidOperationException("Prehash calculation failed");
    byte[] sig = new byte[Ed448PrivateKeyParameters.SignatureSize];
    this.privateKey.Sign(Ed448.Algorithm.Ed448ph, this.context, numArray, 0, Ed448.PrehashSize, sig, 0);
    return sig;
  }

  public virtual bool VerifySignature(byte[] signature)
  {
    if (this.forSigning || this.publicKey == null)
      throw new InvalidOperationException("Ed448phSigner not initialised for verification");
    if (Ed448.SignatureSize != signature.Length)
    {
      this.prehash.Reset();
      return false;
    }
    byte[] numArray = new byte[Ed448.PrehashSize];
    if (Ed448.PrehashSize != this.prehash.OutputFinal(numArray, 0, Ed448.PrehashSize))
      throw new InvalidOperationException("Prehash calculation failed");
    return this.publicKey.Verify(Ed448.Algorithm.Ed448ph, this.context, numArray, 0, Ed448.PrehashSize, signature, 0);
  }

  public void Reset() => this.prehash.Reset();
}
