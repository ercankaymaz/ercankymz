// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.X25519PublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public sealed class X25519PublicKeyParameters : AsymmetricKeyParameter
{
  public static readonly int KeySize = 32 /*0x20*/;
  private readonly byte[] data = new byte[X25519PublicKeyParameters.KeySize];

  public X25519PublicKeyParameters(byte[] buf)
    : this(X25519PublicKeyParameters.Validate(buf), 0)
  {
  }

  public X25519PublicKeyParameters(byte[] buf, int off)
    : base(false)
  {
    Array.Copy((Array) buf, off, (Array) this.data, 0, X25519PublicKeyParameters.KeySize);
  }

  public X25519PublicKeyParameters(Stream input)
    : base(false)
  {
    if (X25519PublicKeyParameters.KeySize != Streams.ReadFully(input, this.data))
      throw new EndOfStreamException("EOF encountered in middle of X25519 public key");
  }

  public void Encode(byte[] buf, int off)
  {
    Array.Copy((Array) this.data, 0, (Array) buf, off, X25519PublicKeyParameters.KeySize);
  }

  public byte[] GetEncoded() => Arrays.Clone(this.data);

  private static byte[] Validate(byte[] buf)
  {
    if (buf.Length != X25519PublicKeyParameters.KeySize)
      throw new ArgumentException("must have length " + X25519PublicKeyParameters.KeySize.ToString(), nameof (buf));
    return buf;
  }
}
