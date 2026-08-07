// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.ECGost3410Parameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class ECGost3410Parameters : ECNamedDomainParameters
{
  private readonly DerObjectIdentifier _publicKeyParamSet;
  private readonly DerObjectIdentifier _digestParamSet;
  private readonly DerObjectIdentifier _encryptionParamSet;

  public DerObjectIdentifier PublicKeyParamSet => this._publicKeyParamSet;

  public DerObjectIdentifier DigestParamSet => this._digestParamSet;

  public DerObjectIdentifier EncryptionParamSet => this._encryptionParamSet;

  public ECGost3410Parameters(
    ECNamedDomainParameters dp,
    DerObjectIdentifier publicKeyParamSet,
    DerObjectIdentifier digestParamSet,
    DerObjectIdentifier encryptionParamSet)
    : base(dp.Name, dp.Curve, dp.G, dp.N, dp.H, dp.GetSeed())
  {
    this._publicKeyParamSet = publicKeyParamSet;
    this._digestParamSet = digestParamSet;
    this._encryptionParamSet = encryptionParamSet;
  }

  public ECGost3410Parameters(
    ECDomainParameters dp,
    DerObjectIdentifier publicKeyParamSet,
    DerObjectIdentifier digestParamSet,
    DerObjectIdentifier encryptionParamSet)
    : base(publicKeyParamSet, dp.Curve, dp.G, dp.N, dp.H, dp.GetSeed())
  {
    this._publicKeyParamSet = publicKeyParamSet;
    this._digestParamSet = digestParamSet;
    this._encryptionParamSet = encryptionParamSet;
  }
}
