// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.NtruPrime.SNtruPrimeKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.NtruPrime;

public abstract class SNtruPrimeKeyParameters : AsymmetricKeyParameter
{
  private readonly SNtruPrimeParameters m_primeParameters;

  internal SNtruPrimeKeyParameters(bool isPrivate, SNtruPrimeParameters primeParameters)
    : base(isPrivate)
  {
    this.m_primeParameters = primeParameters;
  }

  public SNtruPrimeParameters Parameters => this.m_primeParameters;
}
