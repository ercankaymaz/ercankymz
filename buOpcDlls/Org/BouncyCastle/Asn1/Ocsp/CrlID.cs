// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ocsp.CrlID
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ocsp;

public class CrlID : Asn1Encodable
{
  private readonly DerIA5String crlUrl;
  private readonly DerInteger crlNum;
  private readonly Asn1GeneralizedTime crlTime;

  public static CrlID GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return CrlID.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  public static CrlID GetInstance(object obj)
  {
    if (obj == null)
      return (CrlID) null;
    return obj is CrlID crlId ? crlId : new CrlID(Asn1Sequence.GetInstance(obj));
  }

  [Obsolete("Use 'GetInstance' instead")]
  public CrlID(Asn1Sequence seq)
  {
    foreach (Asn1TaggedObject taggedObject in seq)
    {
      switch (taggedObject.TagNo)
      {
        case 0:
          this.crlUrl = DerIA5String.GetInstance(taggedObject, true);
          continue;
        case 1:
          this.crlNum = DerInteger.GetInstance(taggedObject, true);
          continue;
        case 2:
          this.crlTime = Asn1GeneralizedTime.GetInstance(taggedObject, true);
          continue;
        default:
          throw new ArgumentException("unknown tag number: " + taggedObject.TagNo.ToString());
      }
    }
  }

  public DerIA5String CrlUrl => this.crlUrl;

  public DerInteger CrlNum => this.crlNum;

  public Asn1GeneralizedTime CrlTime => this.crlTime;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.crlUrl);
    elementVector.AddOptionalTagged(true, 1, (Asn1Encodable) this.crlNum);
    elementVector.AddOptionalTagged(true, 2, (Asn1Encodable) this.crlTime);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
