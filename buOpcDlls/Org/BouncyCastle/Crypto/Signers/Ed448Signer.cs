// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.Ed448Signer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math.EC.Rfc8032;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class Ed448Signer : ISigner
{
  private readonly Ed448Signer.Buffer buffer = new Ed448Signer.Buffer();
  private readonly byte[] context;
  private bool forSigning;
  private Ed448PrivateKeyParameters privateKey;
  private Ed448PublicKeyParameters publicKey;

  public Ed448Signer(byte[] context)
  {
    this.context = context != null ? (byte[]) context.Clone() : throw new ArgumentNullException(nameof (context));
  }

  public virtual string AlgorithmName => "Ed448";

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

  public virtual void Update(byte b) => this.buffer.WriteByte(b);

  public virtual void BlockUpdate(byte[] buf, int off, int len) => this.buffer.Write(buf, off, len);

  public virtual int GetMaxSignatureSize() => Ed448.SignatureSize;

  public virtual byte[] GenerateSignature()
  {
    if (!this.forSigning || this.privateKey == null)
      throw new InvalidOperationException("Ed448Signer not initialised for signature generation.");
    return this.buffer.GenerateSignature(this.privateKey, this.context);
  }

  public virtual bool VerifySignature(byte[] signature)
  {
    if (this.forSigning || this.publicKey == null)
      throw new InvalidOperationException("Ed448Signer not initialised for verification");
    return this.buffer.VerifySignature(this.publicKey, this.context, signature);
  }

  public virtual void Reset() => this.buffer.Reset();

  private sealed class Buffer : MemoryStream
  {
    internal byte[] GenerateSignature(Ed448PrivateKeyParameters privateKey, byte[] ctx)
    {
      lock (this)
      {
        byte[] buffer = this.GetBuffer();
        int int32 = Convert.ToInt32(this.Length);
        byte[] sig = new byte[Ed448PrivateKeyParameters.SignatureSize];
        privateKey.Sign(Ed448.Algorithm.Ed448, ctx, buffer, 0, int32, sig, 0);
        this.Reset();
        return sig;
      }
    }

    internal bool VerifySignature(Ed448PublicKeyParameters publicKey, byte[] ctx, byte[] signature)
    {
      if (Ed448.SignatureSize != signature.Length)
      {
        this.Reset();
        return false;
      }
      lock (this)
      {
        byte[] buffer = this.GetBuffer();
        int int32 = Convert.ToInt32(this.Length);
        int num = publicKey.Verify(Ed448.Algorithm.Ed448, ctx, buffer, 0, int32, signature, 0) ? 1 : 0;
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
