// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.Ed25519Signer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math.EC.Rfc8032;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class Ed25519Signer : ISigner
{
  private readonly Ed25519Signer.Buffer buffer = new Ed25519Signer.Buffer();
  private bool forSigning;
  private Ed25519PrivateKeyParameters privateKey;
  private Ed25519PublicKeyParameters publicKey;

  public virtual string AlgorithmName => "Ed25519";

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

  public virtual void Update(byte b) => this.buffer.WriteByte(b);

  public virtual void BlockUpdate(byte[] buf, int off, int len) => this.buffer.Write(buf, off, len);

  public virtual int GetMaxSignatureSize() => Ed25519.SignatureSize;

  public virtual byte[] GenerateSignature()
  {
    return this.forSigning && this.privateKey != null ? this.buffer.GenerateSignature(this.privateKey) : throw new InvalidOperationException("Ed25519Signer not initialised for signature generation.");
  }

  public virtual bool VerifySignature(byte[] signature)
  {
    if (this.forSigning || this.publicKey == null)
      throw new InvalidOperationException("Ed25519Signer not initialised for verification");
    return this.buffer.VerifySignature(this.publicKey, signature);
  }

  public virtual void Reset() => this.buffer.Reset();

  private sealed class Buffer : MemoryStream
  {
    internal byte[] GenerateSignature(Ed25519PrivateKeyParameters privateKey)
    {
      lock (this)
      {
        byte[] buffer = this.GetBuffer();
        int int32 = Convert.ToInt32(this.Length);
        byte[] sig = new byte[Ed25519PrivateKeyParameters.SignatureSize];
        privateKey.Sign(Ed25519.Algorithm.Ed25519, (byte[]) null, buffer, 0, int32, sig, 0);
        this.Reset();
        return sig;
      }
    }

    internal bool VerifySignature(Ed25519PublicKeyParameters publicKey, byte[] signature)
    {
      if (Ed25519.SignatureSize != signature.Length)
      {
        this.Reset();
        return false;
      }
      lock (this)
      {
        byte[] buffer = this.GetBuffer();
        int int32 = Convert.ToInt32(this.Length);
        int num = publicKey.Verify(Ed25519.Algorithm.Ed25519, (byte[]) null, buffer, 0, int32, signature, 0) ? 1 : 0;
        this.Reset();
        return num != 0;
      }
    }

    internal void Reset()
    {
      lock (this)
      {
        int int32 = Convert.ToInt32(this.Length);
        Array.Clear((Array) this.GetBuffer(), 0, int32);
        this.SetLength(0L);
      }
    }
  }
}
