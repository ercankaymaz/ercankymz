// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.X448PublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public sealed class X448PublicKeyParameters : AsymmetricKeyParameter
{
  public static readonly int KeySize = 56;
  private readonly byte[] data = new byte[X448PublicKeyParameters.KeySize];

  public X448PublicKeyParameters(byte[] buf)
    : this(X448PublicKeyParameters.Validate(buf), 0)
  {
  }

  public X448PublicKeyParameters(byte[] buf, int off)
    : base(false)
  {
    Array.Copy((Array) buf, off, (Array) this.data, 0, X448PublicKeyParameters.KeySize);
  }

  public X448PublicKeyParameters(Stream input)
    : base(false)
  {
    if (X448PublicKeyParameters.KeySize != Streams.ReadFully(input, this.data))
      throw new EndOfStreamException("EOF encountered in middle of X448 public key");
  }

  public void Encode(byte[] buf, int off)
  {
    Array.Copy((Array) this.data, 0, (Array) buf, off, X448PublicKeyParameters.KeySize);
  }

  public byte[] GetEncoded() => Arrays.Clone(this.data);

  private static byte[] Validate(byte[] buf)
  {
    if (buf.Length != X448PublicKeyParameters.KeySize)
      throw new ArgumentException("must have length " + X448PublicKeyParameters.KeySize.ToString(), nameof (buf));
    return buf;
  }
}
