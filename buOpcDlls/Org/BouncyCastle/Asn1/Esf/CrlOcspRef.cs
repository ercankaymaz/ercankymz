// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.CrlOcspRef
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class CrlOcspRef : Asn1Encodable
{
  private readonly CrlListID crlids;
  private readonly OcspListID ocspids;
  private readonly OtherRevRefs otherRev;

  public static CrlOcspRef GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case CrlOcspRef _:
        return (CrlOcspRef) obj;
      case Asn1Sequence _:
        return new CrlOcspRef((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Unknown object in 'CrlOcspRef' factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private CrlOcspRef(Asn1Sequence seq)
  {
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    foreach (Asn1TaggedObject asn1TaggedObject in seq)
    {
      Asn1Object asn1Object = asn1TaggedObject.GetObject();
      switch (asn1TaggedObject.TagNo)
      {
        case 0:
          this.crlids = CrlListID.GetInstance((object) asn1Object);
          continue;
        case 1:
          this.ocspids = OcspListID.GetInstance((object) asn1Object);
          continue;
        case 2:
          this.otherRev = OtherRevRefs.GetInstance((object) asn1Object);
          continue;
        default:
          throw new ArgumentException("Illegal tag in CrlOcspRef", nameof (seq));
      }
    }
  }

  public CrlOcspRef(CrlListID crlids, OcspListID ocspids, OtherRevRefs otherRev)
  {
    this.crlids = crlids;
    this.ocspids = ocspids;
    this.otherRev = otherRev;
  }

  public CrlListID CrlIDs => this.crlids;

  public OcspListID OcspIDs => this.ocspids;

  public OtherRevRefs OtherRev => this.otherRev;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
    if (this.crlids != null)
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 0, (Asn1Encodable) this.crlids.ToAsn1Object()));
    if (this.ocspids != null)
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 1, (Asn1Encodable) this.ocspids.ToAsn1Object()));
    if (this.otherRev != null)
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 2, (Asn1Encodable) this.otherRev.ToAsn1Object()));
    return (Asn1Object) new DerSequence(elementVector);
  }
}
