// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.SignedData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class SignedData : Asn1Encodable
{
  private readonly DerInteger version;
  private readonly Asn1Set digestAlgorithms;
  private readonly ContentInfo contentInfo;
  private readonly Asn1Set certificates;
  private readonly Asn1Set crls;
  private readonly Asn1Set signerInfos;

  public static SignedData GetInstance(object obj)
  {
    if (obj == null)
      return (SignedData) null;
    return obj is SignedData signedData ? signedData : new SignedData(Asn1Sequence.GetInstance(obj));
  }

  public SignedData(
    DerInteger _version,
    Asn1Set _digestAlgorithms,
    ContentInfo _contentInfo,
    Asn1Set _certificates,
    Asn1Set _crls,
    Asn1Set _signerInfos)
  {
    this.version = _version;
    this.digestAlgorithms = _digestAlgorithms;
    this.contentInfo = _contentInfo;
    this.certificates = _certificates;
    this.crls = _crls;
    this.signerInfos = _signerInfos;
  }

  private SignedData(Asn1Sequence seq)
  {
    IEnumerator<Asn1Encodable> enumerator = seq.GetEnumerator();
    enumerator.MoveNext();
    this.version = (DerInteger) enumerator.Current;
    enumerator.MoveNext();
    this.digestAlgorithms = (Asn1Set) enumerator.Current;
    enumerator.MoveNext();
    this.contentInfo = ContentInfo.GetInstance((object) enumerator.Current);
    while (enumerator.MoveNext())
    {
      Asn1Object asn1Object = enumerator.Current.ToAsn1Object();
      if (asn1Object is Asn1TaggedObject taggedObject)
      {
        switch (taggedObject.TagNo)
        {
          case 0:
            this.certificates = Asn1Set.GetInstance(taggedObject, false);
            continue;
          case 1:
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

  public ContentInfo ContentInfo => this.contentInfo;

  public Asn1Set Certificates => this.certificates;

  public Asn1Set Crls => this.crls;

  public Asn1Set SignerInfos => this.signerInfos;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(new Asn1Encodable[3]
    {
      (Asn1Encodable) this.version,
      (Asn1Encodable) this.digestAlgorithms,
      (Asn1Encodable) this.contentInfo
    });
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.certificates);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.crls);
    elementVector.Add((Asn1Encodable) this.signerInfos);
    return (Asn1Object) new BerSequence(elementVector);
  }
}
