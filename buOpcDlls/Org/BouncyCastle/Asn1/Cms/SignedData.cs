// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.SignedData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class SignedData : Asn1Encodable
{
  private static readonly DerInteger Version1 = new DerInteger(1);
  private static readonly DerInteger Version3 = new DerInteger(3);
  private static readonly DerInteger Version4 = new DerInteger(4);
  private static readonly DerInteger Version5 = new DerInteger(5);
  private readonly DerInteger version;
  private readonly Asn1Set digestAlgorithms;
  private readonly ContentInfo contentInfo;
  private readonly Asn1Set certificates;
  private readonly Asn1Set crls;
  private readonly Asn1Set signerInfos;
  private readonly bool certsBer;
  private readonly bool crlsBer;

  public static SignedData GetInstance(object obj)
  {
    if (obj is SignedData instance)
      return instance;
    return obj == null ? (SignedData) null : new SignedData(Asn1Sequence.GetInstance(obj));
  }

  public SignedData(
    Asn1Set digestAlgorithms,
    ContentInfo contentInfo,
    Asn1Set certificates,
    Asn1Set crls,
    Asn1Set signerInfos)
  {
    this.version = this.CalculateVersion(contentInfo.ContentType, certificates, crls, signerInfos);
    this.digestAlgorithms = digestAlgorithms;
    this.contentInfo = contentInfo;
    this.certificates = certificates;
    this.crls = crls;
    this.signerInfos = signerInfos;
    this.crlsBer = crls is BerSet;
    this.certsBer = certificates is BerSet;
  }

  private DerInteger CalculateVersion(
    DerObjectIdentifier contentOid,
    Asn1Set certs,
    Asn1Set crls,
    Asn1Set signerInfs)
  {
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    bool flag4 = false;
    if (certs != null)
    {
      foreach (object cert in certs)
      {
        if (cert is Asn1TaggedObject)
        {
          Asn1TaggedObject asn1TaggedObject = (Asn1TaggedObject) cert;
          if (asn1TaggedObject.TagNo == 1)
            flag3 = true;
          else if (asn1TaggedObject.TagNo == 2)
            flag4 = true;
          else if (asn1TaggedObject.TagNo == 3)
          {
            flag1 = true;
            break;
          }
        }
      }
    }
    if (flag1)
      return SignedData.Version5;
    if (crls != null)
    {
      foreach (Asn1Encodable crl in crls)
      {
        if (crl is Asn1TaggedObject)
        {
          flag2 = true;
          break;
        }
      }
    }
    if (flag2)
      return SignedData.Version5;
    if (flag4)
      return SignedData.Version4;
    return !flag3 && CmsObjectIdentifiers.Data.Equals((Asn1Object) contentOid) && !this.CheckForVersion3(signerInfs) ? SignedData.Version1 : SignedData.Version3;
  }

  private bool CheckForVersion3(Asn1Set signerInfs)
  {
    foreach (object signerInf in signerInfs)
    {
      if (SignerInfo.GetInstance(signerInf).Version.HasValue(3))
        return true;
    }
    return false;
  }

  private SignedData(Asn1Sequence seq)
  {
    IEnumerator<Asn1Encodable> enumerator = seq.GetEnumerator();
    enumerator.MoveNext();
    this.version = (DerInteger) enumerator.Current;
    enumerator.MoveNext();
    this.digestAlgorithms = (Asn1Set) enumerator.Current.ToAsn1Object();
    enumerator.MoveNext();
    this.contentInfo = ContentInfo.GetInstance((object) enumerator.Current.ToAsn1Object());
    while (enumerator.MoveNext())
    {
      Asn1Object asn1Object = enumerator.Current.ToAsn1Object();
      if (asn1Object is Asn1TaggedObject taggedObject)
      {
        switch (taggedObject.TagNo)
        {
          case 0:
            this.certsBer = taggedObject is BerTaggedObject;
            this.certificates = Asn1Set.GetInstance(taggedObject, false);
            continue;
          case 1:
            this.crlsBer = taggedObject is BerTaggedObject;
            this.crls = Asn1Set.GetInstance(taggedObject, false);
            continue;
          default:
            throw new ArgumentException("unknown tag value " + taggedObject.TagNo.ToString());
        }
      }
      else
        this.signerInfos = (Asn1Set) asn1Object;
    }
  }

  public DerInteger Version => this.version;

  public Asn1Set DigestAlgorithms => this.digestAlgorithms;

  public ContentInfo EncapContentInfo => this.contentInfo;

  public Asn1Set Certificates => this.certificates;

  public Asn1Set CRLs => this.crls;

  public Asn1Set SignerInfos => this.signerInfos;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(new Asn1Encodable[3]
    {
      (Asn1Encodable) this.version,
      (Asn1Encodable) this.digestAlgorithms,
      (Asn1Encodable) this.contentInfo
    });
    if (this.certificates != null)
    {
      if (this.certsBer)
        elementVector.Add((Asn1Encodable) new BerTaggedObject(false, 0, (Asn1Encodable) this.certificates));
      else
        elementVector.Add((Asn1Encodable) new DerTaggedObject(false, 0, (Asn1Encodable) this.certificates));
    }
    if (this.crls != null)
    {
      if (this.crlsBer)
        elementVector.Add((Asn1Encodable) new BerTaggedObject(false, 1, (Asn1Encodable) this.crls));
      else
        elementVector.Add((Asn1Encodable) new DerTaggedObject(false, 1, (Asn1Encodable) this.crls));
    }
    elementVector.Add((Asn1Encodable) this.signerInfos);
    return (Asn1Object) new BerSequence(elementVector);
  }
}
