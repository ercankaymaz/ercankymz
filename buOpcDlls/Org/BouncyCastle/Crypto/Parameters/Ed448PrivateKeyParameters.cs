// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.Ed448PrivateKeyParameters
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

public sealed class Ed448PrivateKeyParameters : AsymmetricKeyParameter
{
  public static readonly int KeySize = Ed448.SecretKeySize;
  public static readonly int SignatureSize = Ed448.SignatureSize;
  private readonly byte[] data = new byte[Ed448PrivateKeyParameters.KeySize];
  private Ed448PublicKeyParameters cachedPublicKey;

  public Ed448PrivateKeyParameters(SecureRandom random)
    : base(true)
  {
    Ed448.GeneratePrivateKey(random, this.data);
  }

  public Ed448PrivateKeyParameters(byte[] buf)
    : this(Ed448PrivateKeyParameters.Validate(buf), 0)
  {
  }

  public Ed448PrivateKeyParameters(byte[] buf, int off)
    : base(true)
  {
    Array.Copy((Array) buf, off, (Array) this.data, 0, Ed448PrivateKeyParameters.KeySize);
  }

  public Ed448PrivateKeyParameters(Stream input)
    : base(true)
  {
    if (Ed448PrivateKeyParameters.KeySize != Streams.ReadFully(input, this.data))
      throw new EndOfStreamException("EOF encountered in middle of Ed448 private key");
  }

  public void Encode(byte[] buf, int off)
  {
    Array.Copy((Array) this.data, 0, (Array) buf, off, Ed448PrivateKeyParameters.KeySize);
  }

  public byte[] GetEncoded() => Arrays.Clone(this.data);

  public Ed448PublicKeyParameters GeneratePublicKey()
  {
    lock (this.data)
    {
      if (this.cachedPublicKey == null)
        this.cachedPublicKey = new Ed448PublicKeyParameters(Ed448.GeneratePublicKey(this.data, 0));
      return this.cachedPublicKey;
    }
  }

  public void Sign(
    Ed448.Algorithm algorithm,
    byte[] ctx,
    byte[] msg,
    int msgOff,
    int msgLen,
    byte[] sig,
    int sigOff)
  {
    Ed448PublicKeyParameters publicKey = this.GeneratePublicKey();
    byte[] pk = new byte[Ed448.PublicKeySize];
    byte[] buf = pk;
    publicKey.Encode(buf, 0);
    if (algorithm != Ed448.Algorithm.Ed448)
    {
      if (algorithm != Ed448.Algorithm.Ed448ph)
        throw new ArgumentOutOfRangeException(nameof (algorithm));
      if (ctx == null)
        throw new ArgumentNullException(nameof (ctx));
      if (ctx.Length > (int) byte.MaxValue)
        throw new ArgumentOutOfRangeException(nameof (ctx));
      if (Ed448.PrehashSize != msgLen)
        throw new ArgumentOutOfRangeException(nameof (msgLen));
      Ed448.SignPrehash(this.data, 0, pk, 0, ctx, msg, msgOff, sig, sigOff);
    }
    else
    {
      if (ctx == null)
        throw new ArgumentNullException(nameof (ctx));
      if (ctx.Length > (int) byte.MaxValue)
        throw new ArgumentOutOfRangeException(nameof (ctx));
      Ed448.Sign(this.data, 0, pk, 0, ctx, msg, msgOff, msgLen, sig, sigOff);
    }
  }

  private static byte[] Validate(byte[] buf)
  {
    if (buf.Length != Ed448PrivateKeyParameters.KeySize)
      throw new ArgumentException("must have length " + Ed448PrivateKeyParameters.KeySize.ToString(), nameof (buf));
    return buf;
  }
}
