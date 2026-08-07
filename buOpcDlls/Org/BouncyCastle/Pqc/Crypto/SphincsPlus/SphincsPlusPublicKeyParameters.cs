// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.SphincsPlus.SphincsPlusPublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.SphincsPlus;

public sealed class SphincsPlusPublicKeyParameters : SphincsPlusKeyParameters
{
  private readonly PK m_pk;

  public SphincsPlusPublicKeyParameters(SphincsPlusParameters parameters, byte[] pkEncoded)
    : base(false, parameters)
  {
    int n = parameters.N;
    if (pkEncoded.Length != 2 * n)
      throw new ArgumentException("public key encoding does not match parameters", nameof (pkEncoded));
    this.m_pk = new PK(Arrays.CopyOfRange(pkEncoded, 0, n), Arrays.CopyOfRange(pkEncoded, n, 2 * n));
  }

  internal SphincsPlusPublicKeyParameters(SphincsPlusParameters parameters, PK pk)
    : base(false, parameters)
  {
    this.m_pk = pk;
  }

  public byte[] GetSeed() => Arrays.Clone(this.m_pk.seed);

  public byte[] GetRoot() => Arrays.Clone(this.m_pk.root);

  public byte[] GetEncoded()
  {
    return Arrays.ConcatenateAll(Pack.UInt32_To_BE((uint) SphincsPlusParameters.GetID(this.Parameters)), this.m_pk.seed, this.m_pk.root);
  }
}
