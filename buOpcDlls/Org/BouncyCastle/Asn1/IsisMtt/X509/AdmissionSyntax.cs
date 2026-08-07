// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.IsisMtt.X509.AdmissionSyntax
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.IsisMtt.X509;

public class AdmissionSyntax : Asn1Encodable
{
  private readonly GeneralName admissionAuthority;
  private readonly Asn1Sequence contentsOfAdmissions;

  public static AdmissionSyntax GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case AdmissionSyntax _:
        return (AdmissionSyntax) obj;
      case Asn1Sequence _:
        return new AdmissionSyntax((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private AdmissionSyntax(Asn1Sequence seq)
  {
    switch (seq.Count)
    {
      case 1:
        this.contentsOfAdmissions = Asn1Sequence.GetInstance((object) seq[0]);
        break;
      case 2:
        this.admissionAuthority = GeneralName.GetInstance((object) seq[0]);
        this.contentsOfAdmissions = Asn1Sequence.GetInstance((object) seq[1]);
        break;
      default:
        throw new ArgumentException("Bad sequence size: " + seq.Count.ToString());
    }
  }

  public AdmissionSyntax(GeneralName admissionAuthority, Asn1Sequence contentsOfAdmissions)
  {
    this.admissionAuthority = admissionAuthority;
    this.contentsOfAdmissions = contentsOfAdmissions;
  }

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(2);
    elementVector.AddOptional((Asn1Encodable) this.admissionAuthority);
    elementVector.Add((Asn1Encodable) this.contentsOfAdmissions);
    return (Asn1Object) new DerSequence(elementVector);
  }

  public virtual GeneralName AdmissionAuthority => this.admissionAuthority;

  public virtual Admissions[] GetContentsOfAdmissions()
  {
    Admissions[] contentsOfAdmissions = new Admissions[this.contentsOfAdmissions.Count];
    for (int index = 0; index < this.contentsOfAdmissions.Count; ++index)
      contentsOfAdmissions[index] = Admissions.GetInstance((object) this.contentsOfAdmissions[index]);
    return contentsOfAdmissions;
  }
}
