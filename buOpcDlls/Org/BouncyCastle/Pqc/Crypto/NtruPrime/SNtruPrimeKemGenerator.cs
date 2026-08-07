// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.NtruPrime.SNtruPrimeKemGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.NtruPrime;

public class SNtruPrimeKemGenerator : IEncapsulatedSecretGenerator
{
  private SecureRandom sr;

  public SNtruPrimeKemGenerator(SecureRandom sr) => this.sr = sr;

  public ISecretWithEncapsulation GenerateEncapsulated(AsymmetricKeyParameter recipientKey)
  {
    SNtruPrimePublicKeyParameters publicKeyParameters = (SNtruPrimePublicKeyParameters) recipientKey;
    NtruPrimeEngine primeEngine = publicKeyParameters.Parameters.PrimeEngine;
    byte[] numArray1 = new byte[primeEngine.CipherTextSize];
    byte[] numArray2 = new byte[primeEngine.SessionKeySize];
    primeEngine.kem_enc(numArray1, numArray2, publicKeyParameters.pubKey, this.sr);
    return (ISecretWithEncapsulation) new NtruLPRimeKemGenerator.SecretWithEncapsulationImpl(numArray2, numArray1);
  }

  public class SecretWithEncapsulationImpl : ISecretWithEncapsulation, IDisposable
  {
    private volatile bool hasBeenDestroyed;
    private byte[] sessionKey;
    private byte[] cipherText;

    public SecretWithEncapsulationImpl(byte[] sessionKey, byte[] cipherText)
    {
      this.sessionKey = sessionKey;
      this.cipherText = cipherText;
    }

    public byte[] GetSecret()
    {
      this.CheckDestroyed();
      return Arrays.Clone(this.sessionKey);
    }

    public byte[] GetEncapsulation() => Arrays.Clone(this.cipherText);

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing || this.hasBeenDestroyed)
        return;
      Arrays.Clear(this.sessionKey);
      Arrays.Clear(this.cipherText);
      this.hasBeenDestroyed = true;
    }

    public bool IsDestroyed() => this.hasBeenDestroyed;

    private void CheckDestroyed()
    {
      if (this.IsDestroyed())
        throw new Exception("data has been destroyed");
    }
  }
}
