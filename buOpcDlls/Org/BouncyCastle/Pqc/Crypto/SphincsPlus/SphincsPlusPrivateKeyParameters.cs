// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.SphincsPlus.SphincsPlusPrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

public sealed class SphincsPlusPrivateKeyParameters : SphincsPlusKeyParameters
{
  internal readonly SK m_sk;
  internal readonly PK m_pk;

  public SphincsPlusPrivateKeyParameters(SphincsPlusParameters parameters, byte[] skpkEncoded)
    : base(true, parameters)
  {
    int n = parameters.N;
    if (skpkEncoded.Length != 4 * n)
      throw new ArgumentException("private key encoding does not match parameters");
    this.m_sk = new SK(Arrays.CopyOfRange(skpkEncoded, 0, n), Arrays.CopyOfRange(skpkEncoded, n, 2 * n));
    this.m_pk = new PK(Arrays.CopyOfRange(skpkEncoded, 2 * n, 3 * n), Arrays.CopyOfRange(skpkEncoded, 3 * n, 4 * n));
  }

  internal SphincsPlusPrivateKeyParameters(SphincsPlusParameters parameters, SK sk, PK pk)
    : base(true, parameters)
  {
    this.m_sk = sk;
    this.m_pk = pk;
  }

  public byte[] GetSeed() => Arrays.Clone(this.m_sk.seed);

  public byte[] GetPrf() => Arrays.Clone(this.m_sk.prf);

  public byte[] GetPublicSeed() => Arrays.Clone(this.m_pk.seed);

  public byte[] GetPublicKey() => Arrays.Concatenate(this.m_pk.seed, this.m_pk.root);

  public byte[] GetEncoded()
  {
    return Arrays.ConcatenateAll(Pack.UInt32_To_BE((uint) SphincsPlusParameters.GetID(this.Parameters)), this.m_sk.seed, this.m_sk.prf, this.m_pk.seed, this.m_pk.root);
  }

  public byte[] GetEncodedPublicKey()
  {
    return Arrays.ConcatenateAll(Pack.UInt32_To_BE((uint) SphincsPlusParameters.GetID(this.Parameters)), this.m_pk.seed, this.m_pk.root);
  }
}
