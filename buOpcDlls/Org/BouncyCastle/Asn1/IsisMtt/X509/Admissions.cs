// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.IsisMtt.X509.Admissions
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.IsisMtt.X509;

public class Admissions : Asn1Encodable
{
  private readonly GeneralName admissionAuthority;
  private readonly NamingAuthority namingAuthority;
  private readonly Asn1Sequence professionInfos;

  public static Admissions GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case Admissions _:
        return (Admissions) obj;
      case Asn1Sequence seq:
        return new Admissions(seq);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private Admissions(Asn1Sequence seq)
  {
    IEnumerator<Asn1Encodable> enumerator = seq.Count <= 3 ? seq.GetEnumerator() : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    enumerator.MoveNext();
    Asn1Encodable current = enumerator.Current;
    if (current is Asn1TaggedObject tagObj)
    {
      switch (tagObj.TagNo)
      {
        case 0:
          this.admissionAuthority = GeneralName.GetInstance(tagObj, true);
          break;
        case 1:
          this.namingAuthority = NamingAuthority.GetInstance(tagObj, true);
          break;
        default:
          throw new ArgumentException("Bad tag number: " + tagObj.TagNo.ToString());
      }
      enumerator.MoveNext();
      current = enumerator.Current;
    }
    if (current is Asn1TaggedObject asn1TaggedObject)
    {
      this.namingAuthority = asn1TaggedObject.TagNo == 1 ? NamingAuthority.GetInstance(asn1TaggedObject, true) : throw new ArgumentException("Bad tag number: " + asn1TaggedObject.TagNo.ToString());
      enumerator.MoveNext();
      current = enumerator.Current;
    }
    this.professionInfos = Asn1Sequence.GetInstance((object) current);
    if (enumerator.MoveNext())
      throw new ArgumentException("Bad object encountered: " + Platform.GetTypeName((object) enumerator.Current));
  }

  public Admissions(
    GeneralName admissionAuthority,
    NamingAuthority namingAuthority,
    ProfessionInfo[] professionInfos)
  {
    this.admissionAuthority = admissionAuthority;
    this.namingAuthority = namingAuthority;
    this.professionInfos = (Asn1Sequence) new DerSequence((Asn1Encodable[]) professionInfos);
  }

  public virtual GeneralName AdmissionAuthority => this.admissionAuthority;

  public virtual NamingAuthority NamingAuthority => this.namingAuthority;

  public ProfessionInfo[] GetProfessionInfos()
  {
    ProfessionInfo[] professionInfos = new ProfessionInfo[this.professionInfos.Count];
    int num = 0;
    foreach (Asn1Encodable professionInfo in this.professionInfos)
      professionInfos[num++] = ProfessionInfo.GetInstance((object) professionInfo);
    return professionInfos;
  }

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.admissionAuthority);
    elementVector.AddOptionalTagged(true, 1, (Asn1Encodable) this.namingAuthority);
    elementVector.Add((Asn1Encodable) this.professionInfos);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
