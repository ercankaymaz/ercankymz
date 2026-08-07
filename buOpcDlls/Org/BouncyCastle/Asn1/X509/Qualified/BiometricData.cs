// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.Qualified.BiometricData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509.Qualified;

public class BiometricData : Asn1Encodable
{
  private readonly TypeOfBiometricData typeOfBiometricData;
  private readonly AlgorithmIdentifier hashAlgorithm;
  private readonly Asn1OctetString biometricDataHash;
  private readonly DerIA5String sourceDataUri;

  public static BiometricData GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case BiometricData _:
        return (BiometricData) obj;
      case Asn1Sequence _:
        return new BiometricData(Asn1Sequence.GetInstance(obj));
      default:
        throw new ArgumentException("unknown object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private BiometricData(Asn1Sequence seq)
  {
    this.typeOfBiometricData = TypeOfBiometricData.GetInstance((object) seq[0]);
    this.hashAlgorithm = AlgorithmIdentifier.GetInstance((object) seq[1]);
    this.biometricDataHash = Asn1OctetString.GetInstance((object) seq[2]);
    if (seq.Count <= 3)
      return;
    this.sourceDataUri = DerIA5String.GetInstance((object) seq[3]);
  }

  public BiometricData(
    TypeOfBiometricData typeOfBiometricData,
    AlgorithmIdentifier hashAlgorithm,
    Asn1OctetString biometricDataHash,
    DerIA5String sourceDataUri)
  {
    this.typeOfBiometricData = typeOfBiometricData;
    this.hashAlgorithm = hashAlgorithm;
    this.biometricDataHash = biometricDataHash;
    this.sourceDataUri = sourceDataUri;
  }

  public BiometricData(
    TypeOfBiometricData typeOfBiometricData,
    AlgorithmIdentifier hashAlgorithm,
    Asn1OctetString biometricDataHash)
  {
    this.typeOfBiometricData = typeOfBiometricData;
    this.hashAlgorithm = hashAlgorithm;
    this.biometricDataHash = biometricDataHash;
    this.sourceDataUri = (DerIA5String) null;
  }

  public TypeOfBiometricData TypeOfBiometricData => this.typeOfBiometricData;

  public AlgorithmIdentifier HashAlgorithm => this.hashAlgorithm;

  public Asn1OctetString BiometricDataHash => this.biometricDataHash;

  public DerIA5String SourceDataUri => this.sourceDataUri;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(new Asn1Encodable[3]
    {
      (Asn1Encodable) this.typeOfBiometricData,
      (Asn1Encodable) this.hashAlgorithm,
      (Asn1Encodable) this.biometricDataHash
    });
    elementVector.AddOptional((Asn1Encodable) this.sourceDataUri);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
