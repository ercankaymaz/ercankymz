// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.AttCertIssuer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class AttCertIssuer : Asn1Encodable, IAsn1Choice
{
  internal readonly Asn1Encodable obj;
  internal readonly Asn1Object choiceObj;

  public static AttCertIssuer GetInstance(object obj)
  {
    switch (obj)
    {
      case AttCertIssuer _:
        return (AttCertIssuer) obj;
      case V2Form _:
        return new AttCertIssuer(V2Form.GetInstance(obj));
      case GeneralNames _:
        return new AttCertIssuer((GeneralNames) obj);
      case Asn1TaggedObject _:
        return new AttCertIssuer(V2Form.GetInstance((Asn1TaggedObject) obj, false));
      case Asn1Sequence _:
        return new AttCertIssuer(GeneralNames.GetInstance(obj));
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public static AttCertIssuer GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return AttCertIssuer.GetInstance((object) obj.GetObject());
  }

  public AttCertIssuer(GeneralNames names)
  {
    this.obj = (Asn1Encodable) names;
    this.choiceObj = this.obj.ToAsn1Object();
  }

  public AttCertIssuer(V2Form v2Form)
  {
    this.obj = (Asn1Encodable) v2Form;
    this.choiceObj = (Asn1Object) new DerTaggedObject(false, 0, this.obj);
  }

  public Asn1Encodable Issuer => this.obj;

  public override Asn1Object ToAsn1Object() => this.choiceObj;
}
