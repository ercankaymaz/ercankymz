// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.Ed25519PublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC.Rfc8032;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public sealed class Ed25519PublicKeyParameters : AsymmetricKeyParameter
{
  public static readonly int KeySize = Ed25519.PublicKeySize;
  private readonly Ed25519.PublicPoint m_publicPoint;

  public Ed25519PublicKeyParameters(byte[] buf)
    : this(Ed25519PublicKeyParameters.Validate(buf), 0)
  {
  }

  public Ed25519PublicKeyParameters(byte[] buf, int off)
    : base(false)
  {
    this.m_publicPoint = Ed25519PublicKeyParameters.Parse(buf, off);
  }

  public Ed25519PublicKeyParameters(Stream input)
    : base(false)
  {
    byte[] buf = new byte[Ed25519PublicKeyParameters.KeySize];
    if (Ed25519PublicKeyParameters.KeySize != Streams.ReadFully(input, buf))
      throw new EndOfStreamException("EOF encountered in middle of Ed25519 public key");
    this.m_publicPoint = Ed25519PublicKeyParameters.Parse(buf, 0);
  }

  public Ed25519PublicKeyParameters(Ed25519.PublicPoint publicPoint)
    : base(false)
  {
    this.m_publicPoint = publicPoint ?? throw new ArgumentNullException(nameof (publicPoint));
  }

  public void Encode(byte[] buf, int off)
  {
    Ed25519.EncodePublicPoint(this.m_publicPoint, buf, off);
  }

  public byte[] GetEncoded()
  {
    byte[] buf = new byte[Ed25519PublicKeyParameters.KeySize];
    this.Encode(buf, 0);
    return buf;
  }

  public bool Verify(
    Ed25519.Algorithm algorithm,
    byte[] ctx,
    byte[] msg,
    int msgOff,
    int msgLen,
    byte[] sig,
    int sigOff)
  {
    switch (algorithm)
    {
      case Ed25519.Algorithm.Ed25519:
        if (ctx != null)
          throw new ArgumentOutOfRangeException(nameof (ctx));
        return Ed25519.Verify(sig, sigOff, this.m_publicPoint, msg, msgOff, msgLen);
      case Ed25519.Algorithm.Ed25519ctx:
        if (ctx == null)
          throw new ArgumentNullException(nameof (ctx));
        if (ctx.Length > (int) byte.MaxValue)
          throw new ArgumentOutOfRangeException(nameof (ctx));
        return Ed25519.Verify(sig, sigOff, this.m_publicPoint, ctx, msg, msgOff, msgLen);
      case Ed25519.Algorithm.Ed25519ph:
        if (ctx == null)
          throw new ArgumentNullException(nameof (ctx));
        if (ctx.Length > (int) byte.MaxValue)
          throw new ArgumentOutOfRangeException(nameof (ctx));
        if (Ed25519.PrehashSize != msgLen)
          throw new ArgumentOutOfRangeException(nameof (msgLen));
        return Ed25519.VerifyPrehash(sig, sigOff, this.m_publicPoint, ctx, msg, msgOff);
      default:
        throw new ArgumentOutOfRangeException(nameof (algorithm));
    }
  }

  private static Ed25519.PublicPoint Parse(byte[] buf, int off)
  {
    return Ed25519.ValidatePublicKeyPartialExport(buf, off) ?? throw new ArgumentException("invalid public key");
  }

  private static byte[] Validate(byte[] buf)
  {
    if (buf.Length != Ed25519PublicKeyParameters.KeySize)
      throw new ArgumentException("must have length " + Ed25519PublicKeyParameters.KeySize.ToString(), nameof (buf));
    return buf;
  }
}
