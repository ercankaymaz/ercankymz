// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber.KyberKemGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber;

public sealed class KyberKemGenerator : IEncapsulatedSecretGenerator
{
  private SecureRandom m_random;

  public KyberKemGenerator(SecureRandom random) => this.m_random = random;

  public ISecretWithEncapsulation GenerateEncapsulated(AsymmetricKeyParameter recipientKey)
  {
    KyberPublicKeyParameters publicKeyParameters = (KyberPublicKeyParameters) recipientKey;
    KyberEngine engine = publicKeyParameters.Parameters.Engine;
    engine.Init(this.m_random);
    byte[] numArray1 = new byte[engine.CryptoCipherTextBytes];
    byte[] numArray2 = new byte[engine.CryptoBytes];
    engine.KemEncrypt(numArray1, numArray2, publicKeyParameters.GetEncoded());
    return (ISecretWithEncapsulation) new KyberKemGenerator.SecretWithEncapsulationImpl(numArray2, numArray1);
  }

  private sealed class SecretWithEncapsulationImpl : ISecretWithEncapsulation, IDisposable
  {
    private volatile bool m_hasBeenDestroyed;
    private byte[] m_sessionKey;
    private byte[] m_cipherText;

    internal SecretWithEncapsulationImpl(byte[] sessionKey, byte[] cipher_text)
    {
      this.m_sessionKey = sessionKey;
      this.m_cipherText = cipher_text;
    }

    public byte[] GetSecret()
    {
      this.CheckDestroyed();
      return Arrays.Clone(this.m_sessionKey);
    }

    public byte[] GetEncapsulation()
    {
      this.CheckDestroyed();
      return Arrays.Clone(this.m_cipherText);
    }

    public void Dispose()
    {
      if (!this.m_hasBeenDestroyed)
      {
        Arrays.Clear(this.m_sessionKey);
        Arrays.Clear(this.m_cipherText);
        this.m_hasBeenDestroyed = true;
      }
      GC.SuppressFinalize((object) this);
    }

    internal bool IsDestroyed() => this.m_hasBeenDestroyed;

    private void CheckDestroyed()
    {
      if (this.IsDestroyed())
        throw new ArgumentException("data has been destroyed");
    }
  }
}
