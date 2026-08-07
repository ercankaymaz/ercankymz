// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets.NtruHrssParameterSet
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Pqc.Crypto.Ntru.Polynomials;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets;

internal class NtruHrssParameterSet : NtruParameterSet
{
  private protected NtruHrssParameterSet(
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
    return (Polynomial) new HrssPolynomial((NtruParameterSet) this);
  }

  internal override int SampleFgBytes() => 2 * this.SampleIidBytes();

  internal override int SampleRmBytes() => 2 * this.SampleIidBytes();
}
