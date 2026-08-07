// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.AccessDescription
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class AccessDescription : Asn1Encodable
{
  public static readonly DerObjectIdentifier IdADCAIssuers = new DerObjectIdentifier("1.3.6.1.5.5.7.48.2");
  public static readonly DerObjectIdentifier IdADOcsp = new DerObjectIdentifier("1.3.6.1.5.5.7.48.1");
  private readonly DerObjectIdentifier accessMethod;
  private readonly GeneralName accessLocation;

  public static AccessDescription GetInstance(object obj)
  {
    switch (obj)
    {
      case AccessDescription _:
        return (AccessDescription) obj;
      case Asn1Sequence _:
        return new AccessDescription((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private AccessDescription(Asn1Sequence seq)
  {
    this.accessMethod = seq.Count == 2 ? DerObjectIdentifier.GetInstance((object) seq[0]) : throw new ArgumentException("wrong number of elements in sequence");
    this.accessLocation = GeneralName.GetInstance((object) seq[1]);
  }

  public AccessDescription(DerObjectIdentifier oid, GeneralName location)
  {
    this.accessMethod = oid;
    this.accessLocation = location;
  }

  public DerObjectIdentifier AccessMethod => this.accessMethod;

  public GeneralName AccessLocation => this.accessLocation;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.accessMethod, (Asn1Encodable) this.accessLocation);
  }

  public override string ToString() => $"AccessDescription: Oid({this.accessMethod.Id})";
}
