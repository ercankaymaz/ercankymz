// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.AuthEnvelopedData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class AuthEnvelopedData : Asn1Encodable
{
  private DerInteger version;
  private OriginatorInfo originatorInfo;
  private Asn1Set recipientInfos;
  private EncryptedContentInfo authEncryptedContentInfo;
  private Asn1Set authAttrs;
  private Asn1OctetString mac;
  private Asn1Set unauthAttrs;

  public AuthEnvelopedData(
    OriginatorInfo originatorInfo,
    Asn1Set recipientInfos,
    EncryptedContentInfo authEncryptedContentInfo,
    Asn1Set authAttrs,
    Asn1OctetString mac,
    Asn1Set unauthAttrs)
  {
    this.version = new DerInteger(0);
    this.originatorInfo = originatorInfo;
    this.recipientInfos = recipientInfos;
    if (this.recipientInfos.Count < 1)
      throw new ArgumentException("AuthEnvelopedData requires at least 1 RecipientInfo");
    this.authEncryptedContentInfo = authEncryptedContentInfo;
    this.authAttrs = authAttrs;
    if (!authEncryptedContentInfo.ContentType.Equals((Asn1Object) CmsObjectIdentifiers.Data) && (authAttrs == null || authAttrs.Count < 1))
      throw new ArgumentException("authAttrs must be present with non-data content");
    this.mac = mac;
    this.unauthAttrs = unauthAttrs;
  }

  private AuthEnvelopedData(Asn1Sequence seq)
  {
    int num1 = 0;
    Asn1Sequence asn1Sequence1 = seq;
    int num2 = 1;
    this.version = DerInteger.GetInstance((object) asn1Sequence1[0].ToAsn1Object());
    if (!this.version.HasValue(0))
      throw new ArgumentException("AuthEnvelopedData version number must be 0");
    Asn1Sequence asn1Sequence2 = seq;
    int index1 = num2;
    int num3 = index1 + 1;
    Asn1Object asn1Object1 = asn1Sequence2[index1].ToAsn1Object();
    if (asn1Object1 is Asn1TaggedObject asn1TaggedObject)
    {
      this.originatorInfo = OriginatorInfo.GetInstance(asn1TaggedObject, false);
      asn1Object1 = seq[num3++].ToAsn1Object();
    }
    this.recipientInfos = Asn1Set.GetInstance((object) asn1Object1);
    if (this.recipientInfos.Count < 1)
      throw new ArgumentException("AuthEnvelopedData requires at least 1 RecipientInfo");
    Asn1Sequence asn1Sequence3 = seq;
    int index2 = num3;
    int num4 = index2 + 1;
    this.authEncryptedContentInfo = EncryptedContentInfo.GetInstance((object) asn1Sequence3[index2].ToAsn1Object());
    Asn1Sequence asn1Sequence4 = seq;
    int index3 = num4;
    int num5 = index3 + 1;
    Asn1Object asn1Object2 = asn1Sequence4[index3].ToAsn1Object();
    if (asn1Object2 is Asn1TaggedObject taggedObject)
    {
      this.authAttrs = Asn1Set.GetInstance(taggedObject, false);
      asn1Object2 = seq[num5++].ToAsn1Object();
    }
    else if (!this.authEncryptedContentInfo.ContentType.Equals((Asn1Object) CmsObjectIdentifiers.Data) && (this.authAttrs == null || this.authAttrs.Count < 1))
      throw new ArgumentException("authAttrs must be present with non-data content");
    this.mac = Asn1OctetString.GetInstance((object) asn1Object2);
    if (seq.Count <= num5)
      return;
    Asn1Sequence asn1Sequence5 = seq;
    int index4 = num5;
    num1 = index4 + 1;
    this.unauthAttrs = Asn1Set.GetInstance((Asn1TaggedObject) asn1Sequence5[index4].ToAsn1Object(), false);
  }

  public static AuthEnvelopedData GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return AuthEnvelopedData.GetInstance((object) Asn1Sequence.GetInstance(obj, isExplicit));
  }

  public static AuthEnvelopedData GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case AuthEnvelopedData _:
        return (AuthEnvelopedData) obj;
      case Asn1Sequence _:
        return new AuthEnvelopedData((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid AuthEnvelopedData: " + Platform.GetTypeName(obj));
    }
  }

  public DerInteger Version => this.version;

  public OriginatorInfo OriginatorInfo => this.originatorInfo;

  public Asn1Set RecipientInfos => this.recipientInfos;

  public EncryptedContentInfo AuthEncryptedContentInfo => this.authEncryptedContentInfo;

  public Asn1Set AuthAttrs => this.authAttrs;

  public Asn1OctetString Mac => this.mac;

  public Asn1Set UnauthAttrs => this.unauthAttrs;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.version);
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.originatorInfo);
    elementVector.Add((Asn1Encodable) this.recipientInfos, (Asn1Encodable) this.authEncryptedContentInfo);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.authAttrs);
    elementVector.Add((Asn1Encodable) this.mac);
    elementVector.AddOptionalTagged(false, 2, (Asn1Encodable) this.unauthAttrs);
    return (Asn1Object) new BerSequence(elementVector);
  }
}
