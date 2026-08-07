// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Bike.BikeKemExtractor
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Bike;

public sealed class BikeKemExtractor : IEncapsulatedSecretExtractor
{
  private readonly BikeKeyParameters key;

  public BikeKemExtractor(BikePrivateKeyParameters privParams)
  {
    this.key = (BikeKeyParameters) privParams;
  }

  public byte[] ExtractSecret(byte[] encapsulation)
  {
    BikeParameters parameters = this.key.Parameters;
    BikeEngine bikeEngine = parameters.BikeEngine;
    int defaultKeySize = parameters.DefaultKeySize;
    byte[] numArray = new byte[bikeEngine.SessionKeySize];
    BikePrivateKeyParameters key = (BikePrivateKeyParameters) this.key;
    byte[] c0 = Arrays.CopyOfRange(encapsulation, 0, key.Parameters.RByte);
    byte[] c1 = Arrays.CopyOfRange(encapsulation, key.Parameters.RByte, encapsulation.Length);
    byte[] h0 = key.GetH0();
    byte[] h1 = key.GetH1();
    byte[] sigma = key.GetSigma();
    bikeEngine.Decaps(numArray, h0, h1, sigma, c0, c1);
    return Arrays.CopyOfRange(numArray, 0, defaultKeySize / 8);
  }

  public int EncapsulationLength => this.key.Parameters.RByte + this.key.Parameters.LByte;
}
