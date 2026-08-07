// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.NoticeReference
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class NoticeReference : Asn1Encodable
{
  private readonly DisplayText organization;
  private readonly Asn1Sequence noticeNumbers;

  private static Asn1EncodableVector ConvertVector(IList<object> numbers)
  {
    Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector(numbers.Count);
    foreach (object number in (IEnumerable<object>) numbers)
    {
      DerInteger element;
      switch (number)
      {
        case BigInteger _:
          element = new DerInteger((BigInteger) number);
          break;
        case int num:
          element = new DerInteger(num);
          break;
        default:
          throw new ArgumentException();
      }
      asn1EncodableVector.Add((Asn1Encodable) element);
    }
    return asn1EncodableVector;
  }

  public NoticeReference(string organization, IList<object> numbers)
    : this(organization, NoticeReference.ConvertVector(numbers))
  {
  }

  public NoticeReference(string organization, Asn1EncodableVector noticeNumbers)
    : this(new DisplayText(organization), noticeNumbers)
  {
  }

  public NoticeReference(DisplayText organization, Asn1EncodableVector noticeNumbers)
  {
    this.organization = organization;
    this.noticeNumbers = (Asn1Sequence) new DerSequence(noticeNumbers);
  }

  private NoticeReference(Asn1Sequence seq)
  {
    this.organization = seq.Count == 2 ? DisplayText.GetInstance((object) seq[0]) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    this.noticeNumbers = Asn1Sequence.GetInstance((object) seq[1]);
  }

  public static NoticeReference GetInstance(object obj)
  {
    if (obj is NoticeReference)
      return (NoticeReference) obj;
    return obj == null ? (NoticeReference) null : new NoticeReference(Asn1Sequence.GetInstance(obj));
  }

  public virtual DisplayText Organization => this.organization;

  public virtual DerInteger[] GetNoticeNumbers()
  {
    return this.noticeNumbers.MapElements<DerInteger>(new Func<Asn1Encodable, DerInteger>(DerInteger.GetInstance));
  }

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.organization, (Asn1Encodable) this.noticeNumbers);
  }
}
