// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.NtruPrime.SNtruPrimePrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.NtruPrime;

public sealed class SNtruPrimePrivateKeyParameters : SNtruPrimeKeyParameters
{
  internal byte[] privKey;

  public SNtruPrimePrivateKeyParameters(SNtruPrimeParameters primeParameters, byte[] privKey)
    : base(true, primeParameters)
  {
    this.privKey = Arrays.Clone(privKey);
  }

  public byte[] GetPrivateKey() => Arrays.Clone(this.privKey);

  public byte[] GetEncoded() => this.GetPrivateKey();
}
