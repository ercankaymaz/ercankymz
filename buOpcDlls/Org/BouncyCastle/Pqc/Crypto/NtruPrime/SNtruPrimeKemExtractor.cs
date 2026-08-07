// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.NtruPrime.SNtruPrimeKemExtractor
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.NtruPrime;

public class SNtruPrimeKemExtractor : IEncapsulatedSecretExtractor
{
  private NtruPrimeEngine _primeEngine;
  private readonly SNtruPrimeKeyParameters _primeKey;

  public SNtruPrimeKemExtractor(SNtruPrimeKeyParameters privParams)
  {
    this._primeKey = privParams;
    this.InitCipher(this._primeKey.Parameters);
  }

  private void InitCipher(SNtruPrimeParameters param) => this._primeEngine = param.PrimeEngine;

  public byte[] ExtractSecret(byte[] encapsulation)
  {
    byte[] ss = new byte[this._primeEngine.SessionKeySize];
    this._primeEngine.kem_dec(ss, encapsulation, ((SNtruPrimePrivateKeyParameters) this._primeKey).privKey);
    return ss;
  }

  public int EncapsulationLength => this._primeEngine.CipherTextSize;
}
