// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Esf.RevocationValues
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Esf;

public class RevocationValues : Asn1Encodable
{
  private readonly Asn1Sequence m_crlVals;
  private readonly Asn1Sequence m_ocspVals;
  private readonly OtherRevVals m_otherRevVals;

  public static RevocationValues GetInstance(object obj)
  {
    if (obj == null)
      return (RevocationValues) null;
    return obj is RevocationValues revocationValues ? revocationValues : new RevocationValues(Asn1Sequence.GetInstance(obj));
  }

  private RevocationValues(Asn1Sequence seq)
  {
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    if (seq.Count > 3)
      throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    foreach (Asn1TaggedObject asn1TaggedObject in seq)
    {
      Asn1Object asn1Object = asn1TaggedObject.GetObject();
      switch (asn1TaggedObject.TagNo)
      {
        case 0:
          Asn1Sequence asn1Sequence1 = (Asn1Sequence) asn1Object;
          asn1Sequence1.MapElements<CertificateList>((Func<Asn1Encodable, CertificateList>) (element => CertificateList.GetInstance((object) element.ToAsn1Object())));
          this.m_crlVals = asn1Sequence1;
          continue;
        case 1:
          Asn1Sequence asn1Sequence2 = (Asn1Sequence) asn1Object;
          asn1Sequence2.MapElements<BasicOcspResponse>((Func<Asn1Encodable, BasicOcspResponse>) (element => BasicOcspResponse.GetInstance((object) element.ToAsn1Object())));
          this.m_ocspVals = asn1Sequence2;
          continue;
        case 2:
          this.m_otherRevVals = OtherRevVals.GetInstance((object) asn1Object);
          continue;
        default:
          throw new ArgumentException("Illegal tag in RevocationValues", nameof (seq));
      }
    }
  }

  public RevocationValues(
    CertificateList[] crlVals,
    BasicOcspResponse[] ocspVals,
    OtherRevVals otherRevVals)
  {
    if (crlVals != null)
      this.m_crlVals = (Asn1Sequence) new DerSequence((Asn1Encodable[]) crlVals);
    if (ocspVals != null)
      this.m_ocspVals = (Asn1Sequence) new DerSequence((Asn1Encodable[]) ocspVals);
    this.m_otherRevVals = otherRevVals;
  }

  public RevocationValues(
    IEnumerable<CertificateList> crlVals,
    IEnumerable<BasicOcspResponse> ocspVals,
    OtherRevVals otherRevVals)
  {
    if (crlVals != null)
      this.m_crlVals = (Asn1Sequence) new DerSequence(Asn1EncodableVector.FromEnumerable((IEnumerable<Asn1Encodable>) crlVals));
    if (ocspVals != null)
      this.m_ocspVals = (Asn1Sequence) new DerSequence(Asn1EncodableVector.FromEnumerable((IEnumerable<Asn1Encodable>) ocspVals));
    this.m_otherRevVals = otherRevVals;
  }

  public CertificateList[] GetCrlVals()
  {
    return this.m_crlVals.MapElements<CertificateList>((Func<Asn1Encodable, CertificateList>) (element => CertificateList.GetInstance((object) element.ToAsn1Object())));
  }

  public BasicOcspResponse[] GetOcspVals()
  {
    return this.m_ocspVals.MapElements<BasicOcspResponse>((Func<Asn1Encodable, BasicOcspResponse>) (element => BasicOcspResponse.GetInstance((object) element.ToAsn1Object())));
  }

  public OtherRevVals OtherRevVals => this.m_otherRevVals;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.m_crlVals);
    elementVector.AddOptionalTagged(true, 1, (Asn1Encodable) this.m_ocspVals);
    if (this.m_otherRevVals != null)
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 2, (Asn1Encodable) this.m_otherRevVals.ToAsn1Object()));
    return (Asn1Object) new DerSequence(elementVector);
  }
}
