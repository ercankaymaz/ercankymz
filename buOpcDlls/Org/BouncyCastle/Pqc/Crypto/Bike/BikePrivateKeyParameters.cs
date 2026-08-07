// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Bike.BikePrivateKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Bike;

public sealed class BikePrivateKeyParameters : BikeKeyParameters
{
  private byte[] h0;
  private byte[] h1;
  private byte[] sigma;

  public BikePrivateKeyParameters(
    BikeParameters bikeParameters,
    byte[] h0,
    byte[] h1,
    byte[] sigma)
    : base(true, bikeParameters)
  {
    this.h0 = Arrays.Clone(h0);
    this.h1 = Arrays.Clone(h1);
    this.sigma = Arrays.Clone(sigma);
  }

  public byte[] GetH0() => this.h0;

  public byte[] GetH1() => this.h1;

  public byte[] GetSigma() => this.sigma;

  public byte[] GetEncoded() => Arrays.ConcatenateAll(this.h0, this.h1, this.sigma);
}
