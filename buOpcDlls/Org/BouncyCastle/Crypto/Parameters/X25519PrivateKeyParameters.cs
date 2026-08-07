// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.X25519PrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math.EC.Rfc7748;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public sealed class X25519PrivateKeyParameters : AsymmetricKeyParameter
{
  public static readonly int KeySize = 32 /*0x20*/;
  public static readonly int SecretSize = 32 /*0x20*/;
  private readonly byte[] data = new byte[X25519PrivateKeyParameters.KeySize];

  public X25519PrivateKeyParameters(SecureRandom random)
    : base(true)
  {
    X25519.GeneratePrivateKey(random, this.data);
  }

  public X25519PrivateKeyParameters(byte[] buf)
    : this(X25519PrivateKeyParameters.Validate(buf), 0)
  {
  }

  public X25519PrivateKeyParameters(byte[] buf, int off)
    : base(true)
  {
    Array.Copy((Array) buf, off, (Array) this.data, 0, X25519PrivateKeyParameters.KeySize);
  }

  public X25519PrivateKeyParameters(Stream input)
    : base(true)
  {
    if (X25519PrivateKeyParameters.KeySize != Streams.ReadFully(input, this.data))
      throw new EndOfStreamException("EOF encountered in middle of X25519 private key");
  }

  public void Encode(byte[] buf, int off)
  {
    Array.Copy((Array) this.data, 0, (Array) buf, off, X25519PrivateKeyParameters.KeySize);
  }

  public byte[] GetEncoded() => Arrays.Clone(this.data);

  public X25519PublicKeyParameters GeneratePublicKey()
  {
    byte[] numArray = new byte[32 /*0x20*/];
    X25519.GeneratePublicKey(this.data, 0, numArray, 0);
    return new X25519PublicKeyParameters(numArray, 0);
  }

  public void GenerateSecret(X25519PublicKeyParameters publicKey, byte[] buf, int off)
  {
    byte[] numArray = new byte[32 /*0x20*/];
    publicKey.Encode(numArray, 0);
    if (!X25519.CalculateAgreement(this.data, 0, numArray, 0, buf, off))
      throw new InvalidOperationException("X25519 agreement failed");
  }

  private static byte[] Validate(byte[] buf)
  {
    if (buf.Length != X25519PrivateKeyParameters.KeySize)
      throw new ArgumentException("must have length " + X25519PrivateKeyParameters.KeySize.ToString(), nameof (buf));
    return buf;
  }
}
