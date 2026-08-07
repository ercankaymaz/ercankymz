// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets.NtruHpsParameterSet
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Pqc.Crypto.Ntru.Polynomials;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets;

internal class NtruHpsParameterSet : NtruParameterSet
{
  private protected NtruHpsParameterSet(
    int n,
    int logQ,
    int seedBytes,
    int prfKeyBytes,
    int sharedKeyBytes)
    : base(n, logQ, seedBytes, prfKeyBytes, sharedKeyBytes)
  {
  }

  internal override Polynomial CreatePolynomial()
  {
    return (Polynomial) new HpsPolynomial((NtruParameterSet) this);
  }

  internal override int SampleFgBytes() => this.SampleIidBytes() + this.SampleFixedTypeBytes();

  internal override int SampleRmBytes() => this.SampleIidBytes() + this.SampleFixedTypeBytes();

  internal int Weight() => this.Q() / 8 - 2;
}
