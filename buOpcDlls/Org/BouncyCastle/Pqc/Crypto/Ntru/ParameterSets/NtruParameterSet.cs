// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets.NtruParameterSet
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Pqc.Crypto.Ntru.Polynomials;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets;

internal abstract class NtruParameterSet
{
  internal int N { get; }

  internal int LogQ { get; }

  internal int SeedBytes { get; }

  internal int PrfKeyBytes { get; }

  internal int SharedKeyBytes { get; }

  internal NtruParameterSet(int n, int logQ, int seedBytes, int prfKeyBytes, int sharedKeyBytes)
  {
    this.N = n;
    this.LogQ = logQ;
    this.SeedBytes = seedBytes;
    this.PrfKeyBytes = prfKeyBytes;
    this.SharedKeyBytes = sharedKeyBytes;
  }

  internal abstract Polynomial CreatePolynomial();

  internal int Q() => 1 << this.LogQ;

  internal int SampleIidBytes() => this.N - 1;

  internal int SampleFixedTypeBytes() => (30 * (this.N - 1) + 7) / 8;

  internal abstract int SampleFgBytes();

  internal abstract int SampleRmBytes();

  internal int PackDegree() => this.N - 1;

  internal int PackTrinaryBytes() => (this.PackDegree() + 4) / 5;

  internal int OwcpaMsgBytes() => 2 * this.PackTrinaryBytes();

  internal int OwcpaPublicKeyBytes() => (this.LogQ * this.PackDegree() + 7) / 8;

  internal int OwcpaSecretKeyBytes() => 2 * this.PackTrinaryBytes() + this.OwcpaPublicKeyBytes();

  internal int OwcpaBytes() => (this.LogQ * this.PackDegree() + 7) / 8;

  internal int NtruPublicKeyBytes() => this.OwcpaPublicKeyBytes();

  internal int NtruSecretKeyBytes() => this.OwcpaSecretKeyBytes() + this.PrfKeyBytes;

  internal int NtruCiphertextBytes() => this.OwcpaBytes();
}
