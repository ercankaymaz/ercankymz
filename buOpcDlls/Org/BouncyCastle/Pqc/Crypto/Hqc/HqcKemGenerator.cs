// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Hqc.HqcKemGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Hqc;

public class HqcKemGenerator : IEncapsulatedSecretGenerator
{
  private SecureRandom sr;

  public HqcKemGenerator(SecureRandom random) => this.sr = random;

  public ISecretWithEncapsulation GenerateEncapsulated(AsymmetricKeyParameter recipientKey)
  {
    HqcPublicKeyParameters publicKeyParameters = (HqcPublicKeyParameters) recipientKey;
    HqcEngine engine = publicKeyParameters.Parameters.Engine;
    byte[] numArray1 = new byte[publicKeyParameters.Parameters.Sha512Bytes];
    byte[] u = new byte[publicKeyParameters.Parameters.NBytes];
    byte[] v = new byte[publicKeyParameters.Parameters.N1n2Bytes];
    byte[] d = new byte[publicKeyParameters.Parameters.Sha512Bytes];
    byte[] salt = new byte[publicKeyParameters.Parameters.SaltSizeBytes];
    byte[] publicKey = publicKeyParameters.PublicKey;
    byte[] numArray2 = new byte[48 /*0x30*/];
    this.sr.NextBytes(numArray2);
    engine.Encaps(u, v, numArray1, d, publicKey, numArray2, salt);
    byte[] cipher_text = Arrays.ConcatenateAll(u, v, d, salt);
    return (ISecretWithEncapsulation) new HqcKemGenerator.SecretWithEncapsulationImpl(numArray1, cipher_text);
  }

  private sealed class SecretWithEncapsulationImpl : ISecretWithEncapsulation, IDisposable
  {
    private volatile bool hasBeenDestroyed;
    private byte[] sessionKey;
    private byte[] cipher_text;

    public SecretWithEncapsulationImpl(byte[] sessionKey, byte[] cipher_text)
    {
      this.sessionKey = sessionKey;
      this.cipher_text = cipher_text;
    }

    public byte[] GetSecret()
    {
      this.CheckDestroyed();
      return Arrays.Clone(this.sessionKey);
    }

    public byte[] GetEncapsulation()
    {
      this.CheckDestroyed();
      return Arrays.Clone(this.cipher_text);
    }

    public void Dispose()
    {
      if (!this.hasBeenDestroyed)
      {
        Arrays.Clear(this.sessionKey);
        Arrays.Clear(this.cipher_text);
        this.hasBeenDestroyed = true;
      }
      GC.SuppressFinalize((object) this);
    }

    public bool IsDestroyed() => this.hasBeenDestroyed;

    private void CheckDestroyed()
    {
      if (this.IsDestroyed())
        throw new Exception("data has been destroyed");
    }
  }
}
