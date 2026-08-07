// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.CertificatePair
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class CertificatePair : Asn1Encodable
{
  private X509CertificateStructure forward;
  private X509CertificateStructure reverse;

  public static CertificatePair GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case CertificatePair _:
        return (CertificatePair) obj;
      case Asn1Sequence _:
        return new CertificatePair((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private CertificatePair(Asn1Sequence seq)
  {
    if (seq.Count != 1 && seq.Count != 2)
      throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    foreach (object obj in seq)
    {
      Asn1TaggedObject instance = Asn1TaggedObject.GetInstance(obj);
      if (instance.TagNo == 0)
        this.forward = X509CertificateStructure.GetInstance(instance, true);
      else
        this.reverse = instance.TagNo == 1 ? X509CertificateStructure.GetInstance(instance, true) : throw new ArgumentException("Bad tag number: " + instance.TagNo.ToString());
    }
  }

  public CertificatePair(X509CertificateStructure forward, X509CertificateStructure reverse)
  {
    this.forward = forward;
    this.reverse = reverse;
  }

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(2);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.forward);
    elementVector.AddOptionalTagged(true, 1, (Asn1Encodable) this.reverse);
    return (Asn1Object) new DerSequence(elementVector);
  }

  public X509CertificateStructure Forward => this.forward;

  public X509CertificateStructure Reverse => this.reverse;
}
