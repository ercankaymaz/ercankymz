// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.X448PrivateKeyParameters
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

public sealed class X448PrivateKeyParameters : AsymmetricKeyParameter
{
  public static readonly int KeySize = 56;
  public static readonly int SecretSize = 56;
  private readonly byte[] data = new byte[X448PrivateKeyParameters.KeySize];

  public X448PrivateKeyParameters(SecureRandom random)
    : base(true)
  {
    X448.GeneratePrivateKey(random, this.data);
  }

  public X448PrivateKeyParameters(byte[] buf)
    : this(X448PrivateKeyParameters.Validate(buf), 0)
  {
  }

  public X448PrivateKeyParameters(byte[] buf, int off)
    : base(true)
  {
    Array.Copy((Array) buf, off, (Array) this.data, 0, X448PrivateKeyParameters.KeySize);
  }

  public X448PrivateKeyParameters(Stream input)
    : base(true)
  {
    if (X448PrivateKeyParameters.KeySize != Streams.ReadFully(input, this.data))
      throw new EndOfStreamException("EOF encountered in middle of X448 private key");
  }

  public void Encode(byte[] buf, int off)
  {
    Array.Copy((Array) this.data, 0, (Array) buf, off, X448PrivateKeyParameters.KeySize);
  }

  public byte[] GetEncoded() => Arrays.Clone(this.data);

  public X448PublicKeyParameters GeneratePublicKey()
  {
    byte[] numArray = new byte[56];
    X448.GeneratePublicKey(this.data, 0, numArray, 0);
    return new X448PublicKeyParameters(numArray, 0);
  }

  public void GenerateSecret(X448PublicKeyParameters publicKey, byte[] buf, int off)
  {
    byte[] numArray = new byte[56];
    publicKey.Encode(numArray, 0);
    if (!X448.CalculateAgreement(this.data, 0, numArray, 0, buf, off))
      throw new InvalidOperationException("X448 agreement failed");
  }

  private static byte[] Validate(byte[] buf)
  {
    if (buf.Length != X448PrivateKeyParameters.KeySize)
      throw new ArgumentException("must have length " + X448PrivateKeyParameters.KeySize.ToString(), nameof (buf));
    return buf;
  }
}
