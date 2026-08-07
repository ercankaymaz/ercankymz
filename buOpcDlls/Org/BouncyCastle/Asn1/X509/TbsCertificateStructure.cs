// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.TbsCertificateStructure
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class TbsCertificateStructure : Asn1Encodable
{
  internal Asn1Sequence seq;
  internal DerInteger version;
  internal DerInteger serialNumber;
  internal AlgorithmIdentifier signature;
  internal X509Name issuer;
  internal Time startDate;
  internal Time endDate;
  internal X509Name subject;
  internal SubjectPublicKeyInfo subjectPublicKeyInfo;
  internal DerBitString issuerUniqueID;
  internal DerBitString subjectUniqueID;
  internal X509Extensions extensions;

  public static TbsCertificateStructure GetInstance(object obj)
  {
    if (obj == null)
      return (TbsCertificateStructure) null;
    return obj is TbsCertificateStructure certificateStructure ? certificateStructure : new TbsCertificateStructure(Asn1Sequence.GetInstance(obj));
  }

  public static TbsCertificateStructure GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return TbsCertificateStructure.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  private TbsCertificateStructure(Asn1Sequence seq)
  {
    int num1 = 0;
    this.seq = seq;
    if (seq[0] is Asn1TaggedObject taggedObject)
    {
      this.version = DerInteger.GetInstance(taggedObject, true);
    }
    else
    {
      num1 = -1;
      this.version = new DerInteger(0);
    }
    bool flag1 = false;
    bool flag2 = false;
    if (this.version.HasValue(0))
      flag1 = true;
    else if (this.version.HasValue(1))
      flag2 = true;
    else if (!this.version.HasValue(2))
      throw new ArgumentException("version number not recognised");
    this.serialNumber = DerInteger.GetInstance((object) seq[num1 + 1]);
    this.signature = AlgorithmIdentifier.GetInstance((object) seq[num1 + 2]);
    this.issuer = X509Name.GetInstance((object) seq[num1 + 3]);
    Asn1Sequence asn1Sequence = (Asn1Sequence) seq[num1 + 4];
    this.startDate = Time.GetInstance((object) asn1Sequence[0]);
    this.endDate = Time.GetInstance((object) asn1Sequence[1]);
    this.subject = X509Name.GetInstance((object) seq[num1 + 5]);
    this.subjectPublicKeyInfo = SubjectPublicKeyInfo.GetInstance((object) seq[num1 + 6]);
    int num2 = seq.Count - (num1 + 6) - 1;
    if (num2 != 0 & flag1)
      throw new ArgumentException("version 1 certificate contains extra data");
    for (; num2 > 0; --num2)
    {
      Asn1TaggedObject instance = Asn1TaggedObject.GetInstance((object) seq[num1 + 6 + num2]);
      switch (instance.TagNo)
      {
        case 1:
          this.issuerUniqueID = DerBitString.GetInstance(instance, false);
          break;
        case 2:
          this.subjectUniqueID = DerBitString.GetInstance(instance, false);
          break;
        case 3:
          if (flag2)
            throw new ArgumentException("version 2 certificate cannot contain extensions");
          this.extensions = X509Extensions.GetInstance((object) Asn1Sequence.GetInstance(instance, true));
          break;
        default:
          throw new ArgumentException("Unknown tag encountered in structure: " + instance.TagNo.ToString());
      }
    }
  }

  public int Version => this.version.IntValueExact + 1;

  public DerInteger VersionNumber => this.version;

  public DerInteger SerialNumber => this.serialNumber;

  public AlgorithmIdentifier Signature => this.signature;

  public X509Name Issuer => this.issuer;

  public Time StartDate => this.startDate;

  public Time EndDate => this.endDate;

  public X509Name Subject => this.subject;

  public SubjectPublicKeyInfo SubjectPublicKeyInfo => this.subjectPublicKeyInfo;

  public DerBitString IssuerUniqueID => this.issuerUniqueID;

  public DerBitString SubjectUniqueID => this.subjectUniqueID;

  public X509Extensions Extensions => this.extensions;

  public override Asn1Object ToAsn1Object()
  {
    string environmentVariable = Platform.GetEnvironmentVariable("Org.BouncyCastle.X509.Allow_Non-DER_TBSCert");
    if (environmentVariable == null || Platform.EqualsIgnoreCase("true", environmentVariable))
      return (Asn1Object) this.seq;
    Asn1EncodableVector elementVector = new Asn1EncodableVector(8);
    if (!this.version.HasValue(0))
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 0, (Asn1Encodable) this.version));
    elementVector.Add((Asn1Encodable) this.serialNumber, (Asn1Encodable) this.signature, (Asn1Encodable) this.issuer);
    elementVector.Add((Asn1Encodable) new DerSequence((Asn1Encodable) this.startDate, (Asn1Encodable) this.endDate));
    if (this.subject != null)
      elementVector.Add((Asn1Encodable) this.subject);
    else
      elementVector.Add((Asn1Encodable) DerSequence.Empty);
    elementVector.Add((Asn1Encodable) this.subjectPublicKeyInfo);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.issuerUniqueID);
    elementVector.AddOptionalTagged(false, 2, (Asn1Encodable) this.subjectUniqueID);
    elementVector.AddOptionalTagged(true, 3, (Asn1Encodable) this.extensions);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
