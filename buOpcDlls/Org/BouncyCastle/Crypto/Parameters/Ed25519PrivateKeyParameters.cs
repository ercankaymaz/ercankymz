// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.Ed25519PrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC.Rfc8032;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public sealed class Ed25519PrivateKeyParameters : AsymmetricKeyParameter
{
  public static readonly int KeySize = Ed25519.SecretKeySize;
  public static readonly int SignatureSize = Ed25519.SignatureSize;
  private readonly byte[] data = new byte[Ed25519PrivateKeyParameters.KeySize];
  private Ed25519PublicKeyParameters cachedPublicKey;

  public Ed25519PrivateKeyParameters(SecureRandom random)
    : base(true)
  {
    Ed25519.GeneratePrivateKey(random, this.data);
  }

  public Ed25519PrivateKeyParameters(byte[] buf)
    : this(Ed25519PrivateKeyParameters.Validate(buf), 0)
  {
  }

  public Ed25519PrivateKeyParameters(byte[] buf, int off)
    : base(true)
  {
    Array.Copy((Array) buf, off, (Array) this.data, 0, Ed25519PrivateKeyParameters.KeySize);
  }

  public Ed25519PrivateKeyParameters(Stream input)
    : base(true)
  {
    if (Ed25519PrivateKeyParameters.KeySize != Streams.ReadFully(input, this.data))
      throw new EndOfStreamException("EOF encountered in middle of Ed25519 private key");
  }

  public void Encode(byte[] buf, int off)
  {
    Array.Copy((Array) this.data, 0, (Array) buf, off, Ed25519PrivateKeyParameters.KeySize);
  }

  public byte[] GetEncoded() => Arrays.Clone(this.data);

  public Ed25519PublicKeyParameters GeneratePublicKey()
  {
    lock (this.data)
    {
      if (this.cachedPublicKey == null)
        this.cachedPublicKey = new Ed25519PublicKeyParameters(Ed25519.GeneratePublicKey(this.data, 0));
      return this.cachedPublicKey;
    }
  }

  public void Sign(
    Ed25519.Algorithm algorithm,
    byte[] ctx,
    byte[] msg,
    int msgOff,
    int msgLen,
    byte[] sig,
    int sigOff)
  {
    Ed25519PublicKeyParameters publicKey = this.GeneratePublicKey();
    byte[] pk = new byte[Ed25519.PublicKeySize];
    byte[] buf = pk;
    publicKey.Encode(buf, 0);
    switch (algorithm)
    {
      case Ed25519.Algorithm.Ed25519:
        if (ctx != null)
          throw new ArgumentOutOfRangeException(nameof (ctx));
        Ed25519.Sign(this.data, 0, pk, 0, msg, msgOff, msgLen, sig, sigOff);
        break;
      case Ed25519.Algorithm.Ed25519ctx:
        if (ctx == null)
          throw new ArgumentNullException(nameof (ctx));
        if (ctx.Length > (int) byte.MaxValue)
          throw new ArgumentOutOfRangeException(nameof (ctx));
        Ed25519.Sign(this.data, 0, pk, 0, ctx, msg, msgOff, msgLen, sig, sigOff);
        break;
      case Ed25519.Algorithm.Ed25519ph:
        if (ctx == null)
          throw new ArgumentNullException(nameof (ctx));
        if (ctx.Length > (int) byte.MaxValue)
          throw new ArgumentOutOfRangeException(nameof (ctx));
        if (Ed25519.PrehashSize != msgLen)
          throw new ArgumentOutOfRangeException(nameof (msgLen));
        Ed25519.SignPrehash(this.data, 0, pk, 0, ctx, msg, msgOff, sig, sigOff);
        break;
      default:
        throw new ArgumentOutOfRangeException(nameof (algorithm));
    }
  }

  private static byte[] Validate(byte[] buf)
  {
    if (buf.Length != Ed25519PrivateKeyParameters.KeySize)
      throw new ArgumentException("must have length " + Ed25519PrivateKeyParameters.KeySize.ToString(), nameof (buf));
    return buf;
  }
}
