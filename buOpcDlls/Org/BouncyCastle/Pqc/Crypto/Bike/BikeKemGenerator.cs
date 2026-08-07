// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Bike.BikeKemGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Bike;

public sealed class BikeKemGenerator : IEncapsulatedSecretGenerator
{
  private readonly SecureRandom sr;

  public BikeKemGenerator(SecureRandom random) => this.sr = random;

  public ISecretWithEncapsulation GenerateEncapsulated(AsymmetricKeyParameter recipientKey)
  {
    BikePublicKeyParameters publicKeyParameters = (BikePublicKeyParameters) recipientKey;
    BikeParameters parameters = publicKeyParameters.Parameters;
    BikeEngine bikeEngine = parameters.BikeEngine;
    byte[] data = new byte[parameters.LByte];
    byte[] cipher_text = new byte[parameters.RByte + parameters.LByte];
    byte[] publicKey = publicKeyParameters.PublicKey;
    byte[] c01 = cipher_text;
    byte[] k = data;
    byte[] h = publicKey;
    SecureRandom sr = this.sr;
    bikeEngine.Encaps(c01, k, h, sr);
    return (ISecretWithEncapsulation) new BikeKemGenerator.SecretWithEncapsulationImpl(Arrays.CopyOfRange(data, 0, parameters.DefaultKeySize / 8), cipher_text);
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
