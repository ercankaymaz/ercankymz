// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.Ed448PublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC.Rfc8032;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public sealed class Ed448PublicKeyParameters : AsymmetricKeyParameter
{
  public static readonly int KeySize = Ed448.PublicKeySize;
  private readonly Ed448.PublicPoint m_publicPoint;

  public Ed448PublicKeyParameters(byte[] buf)
    : this(Ed448PublicKeyParameters.Validate(buf), 0)
  {
  }

  public Ed448PublicKeyParameters(byte[] buf, int off)
    : base(false)
  {
    this.m_publicPoint = Ed448PublicKeyParameters.Parse(buf, off);
  }

  public Ed448PublicKeyParameters(Stream input)
    : base(false)
  {
    byte[] buf = new byte[Ed448PublicKeyParameters.KeySize];
    if (Ed448PublicKeyParameters.KeySize != Streams.ReadFully(input, buf))
      throw new EndOfStreamException("EOF encountered in middle of Ed448 public key");
    this.m_publicPoint = Ed448PublicKeyParameters.Parse(buf, 0);
  }

  public Ed448PublicKeyParameters(Ed448.PublicPoint publicPoint)
    : base(false)
  {
    this.m_publicPoint = publicPoint ?? throw new ArgumentNullException(nameof (publicPoint));
  }

  public void Encode(byte[] buf, int off) => Ed448.EncodePublicPoint(this.m_publicPoint, buf, off);

  public byte[] GetEncoded()
  {
    byte[] buf = new byte[Ed448PublicKeyParameters.KeySize];
    this.Encode(buf, 0);
    return buf;
  }

  public bool Verify(
    Ed448.Algorithm algorithm,
    byte[] ctx,
    byte[] msg,
    int msgOff,
    int msgLen,
    byte[] sig,
    int sigOff)
  {
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
      return Ed448.VerifyPrehash(sig, sigOff, this.m_publicPoint, ctx, msg, msgOff);
    }
    if (ctx == null)
      throw new ArgumentNullException(nameof (ctx));
    if (ctx.Length > (int) byte.MaxValue)
      throw new ArgumentOutOfRangeException(nameof (ctx));
    return Ed448.Verify(sig, sigOff, this.m_publicPoint, ctx, msg, msgOff, msgLen);
  }

  private static Ed448.PublicPoint Parse(byte[] buf, int off)
  {
    return Ed448.ValidatePublicKeyPartialExport(buf, off) ?? throw new ArgumentException("invalid public key");
  }

  private static byte[] Validate(byte[] buf)
  {
    if (buf.Length != Ed448PublicKeyParameters.KeySize)
      throw new ArgumentException("must have length " + Ed448PublicKeyParameters.KeySize.ToString(), nameof (buf));
    return buf;
  }
}
