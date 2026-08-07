// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.Ed25519phSigner
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math.EC.Rfc8032;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class Ed25519phSigner : ISigner
{
  private readonly IDigest prehash = Ed25519.CreatePrehash();
  private readonly byte[] context;
  private bool forSigning;
  private Ed25519PrivateKeyParameters privateKey;
  private Ed25519PublicKeyParameters publicKey;

  public Ed25519phSigner(byte[] context)
  {
    this.context = context != null ? (byte[]) context.Clone() : throw new ArgumentNullException(nameof (context));
  }

  public virtual string AlgorithmName => "Ed25519ph";

  public virtual void Init(bool forSigning, ICipherParameters parameters)
  {
    this.forSigning = forSigning;
    if (forSigning)
    {
      this.privateKey = (Ed25519PrivateKeyParameters) parameters;
      this.publicKey = (Ed25519PublicKeyParameters) null;
    }
    else
    {
      this.privateKey = (Ed25519PrivateKeyParameters) null;
      this.publicKey = (Ed25519PublicKeyParameters) parameters;
    }
    this.Reset();
  }

  public virtual void Update(byte b) => this.prehash.Update(b);

  public virtual void BlockUpdate(byte[] buf, int off, int len)
  {
    this.prehash.BlockUpdate(buf, off, len);
  }

  public virtual int GetMaxSignatureSize() => Ed25519.SignatureSize;

  public virtual byte[] GenerateSignature()
  {
    if (!this.forSigning || this.privateKey == null)
      throw new InvalidOperationException("Ed25519phSigner not initialised for signature generation.");
    byte[] numArray = new byte[Ed25519.PrehashSize];
    if (Ed25519.PrehashSize != this.prehash.DoFinal(numArray, 0))
      throw new InvalidOperationException("Prehash calculation failed");
    byte[] sig = new byte[Ed25519PrivateKeyParameters.SignatureSize];
    this.privateKey.Sign(Ed25519.Algorithm.Ed25519ph, this.context, numArray, 0, Ed25519.PrehashSize, sig, 0);
    return sig;
  }

  public virtual bool VerifySignature(byte[] signature)
  {
    if (this.forSigning || this.publicKey == null)
      throw new InvalidOperationException("Ed25519phSigner not initialised for verification");
    if (Ed25519.SignatureSize != signature.Length)
    {
      this.prehash.Reset();
      return false;
    }
    byte[] numArray = new byte[Ed25519.PrehashSize];
    if (Ed25519.PrehashSize != this.prehash.DoFinal(numArray, 0))
      throw new InvalidOperationException("Prehash calculation failed");
    return this.publicKey.Verify(Ed25519.Algorithm.Ed25519ph, this.context, numArray, 0, Ed25519.PrehashSize, signature, 0);
  }

  public void Reset() => this.prehash.Reset();
}
