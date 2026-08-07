// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.Qualified.TypeOfBiometricData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509.Qualified;

public class TypeOfBiometricData : Asn1Encodable, IAsn1Choice
{
  public const int Picture = 0;
  public const int HandwrittenSignature = 1;
  internal Asn1Encodable obj;

  public static TypeOfBiometricData GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case TypeOfBiometricData _:
        return (TypeOfBiometricData) obj;
      case DerInteger _:
        return new TypeOfBiometricData(DerInteger.GetInstance(obj).IntValueExact);
      case DerObjectIdentifier _:
        return new TypeOfBiometricData(DerObjectIdentifier.GetInstance(obj));
      default:
        throw new ArgumentException("unknown object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public TypeOfBiometricData(int predefinedBiometricType)
  {
    this.obj = predefinedBiometricType == 0 || predefinedBiometricType == 1 ? (Asn1Encodable) new DerInteger(predefinedBiometricType) : throw new ArgumentException("unknow PredefinedBiometricType : " + predefinedBiometricType.ToString());
  }

  public TypeOfBiometricData(DerObjectIdentifier biometricDataOid)
  {
    this.obj = (Asn1Encodable) biometricDataOid;
  }

  public bool IsPredefined => this.obj is DerInteger;

  public int PredefinedBiometricType => ((DerInteger) this.obj).IntValueExact;

  public DerObjectIdentifier BiometricDataOid => (DerObjectIdentifier) this.obj;

  public override Asn1Object ToAsn1Object() => this.obj.ToAsn1Object();
}
