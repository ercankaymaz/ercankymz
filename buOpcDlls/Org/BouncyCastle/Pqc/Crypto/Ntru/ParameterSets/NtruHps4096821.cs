// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets.NtruHps4096821
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Pqc.Crypto.Ntru.Polynomials;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Ntru.ParameterSets;

internal class NtruHps4096821 : NtruHpsParameterSet
{
  internal NtruHps4096821()
    : base(821, 12, 32 /*0x20*/, 32 /*0x20*/, 32 /*0x20*/)
  {
  }

  internal override Polynomial CreatePolynomial()
  {
    return (Polynomial) new Hps4096Polynomial((NtruParameterSet) this);
  }
}
