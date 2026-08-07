// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Bike.BikePublicKeyParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Bike;

public sealed class BikePublicKeyParameters : BikeKeyParameters
{
  private readonly byte[] publicKey;

  public BikePublicKeyParameters(BikeParameters param, byte[] publicKey)
    : base(false, param)
  {
    this.publicKey = Arrays.Clone(publicKey);
  }

  internal byte[] PublicKey => this.publicKey;

  public byte[] GetEncoded() => Arrays.Clone(this.publicKey);
}
