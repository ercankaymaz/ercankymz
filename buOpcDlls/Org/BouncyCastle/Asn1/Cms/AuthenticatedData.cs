// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.AuthenticatedData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class AuthenticatedData : Asn1Encodable
{
  private DerInteger version;
  private OriginatorInfo originatorInfo;
  private Asn1Set recipientInfos;
  private AlgorithmIdentifier macAlgorithm;
  private AlgorithmIdentifier digestAlgorithm;
  private ContentInfo encapsulatedContentInfo;
  private Asn1Set authAttrs;
  private Asn1OctetString mac;
  private Asn1Set unauthAttrs;

  public AuthenticatedData(
    OriginatorInfo originatorInfo,
    Asn1Set recipientInfos,
    AlgorithmIdentifier macAlgorithm,
    AlgorithmIdentifier digestAlgorithm,
    ContentInfo encapsulatedContent,
    Asn1Set authAttrs,
    Asn1OctetString mac,
    Asn1Set unauthAttrs)
  {
    if ((digestAlgorithm != null || authAttrs != null) && (digestAlgorithm == null || authAttrs == null))
      throw new ArgumentException("digestAlgorithm and authAttrs must be set together");
    this.version = new DerInteger(AuthenticatedData.CalculateVersion(originatorInfo));
    this.originatorInfo = originatorInfo;
    this.macAlgorithm = macAlgorithm;
    this.digestAlgorithm = digestAlgorithm;
    this.recipientInfos = recipientInfos;
    this.encapsulatedContentInfo = encapsulatedContent;
    this.authAttrs = authAttrs;
    this.mac = mac;
    this.unauthAttrs = unauthAttrs;
  }

  private AuthenticatedData(Asn1Sequence seq)
  {
    int num1 = 0;
    Asn1Sequence asn1Sequence1 = seq;
    num1 = 1;
    this.version = (DerInteger) asn1Sequence1[0];
    Asn1Sequence asn1Sequence2 = seq;
    int num2 = 2;
    Asn1Encodable asn1Encodable1 = asn1Sequence2[1];
    if (asn1Encodable1 is Asn1TaggedObject asn1TaggedObject1)
    {
      this.originatorInfo = OriginatorInfo.GetInstance(asn1TaggedObject1, false);
      asn1Encodable1 = seq[num2++];
    }
    this.recipientInfos = Asn1Set.GetInstance((object) asn1Encodable1);
    Asn1Sequence asn1Sequence3 = seq;
    int index1 = num2;
    int num3 = index1 + 1;
    this.macAlgorithm = AlgorithmIdentifier.GetInstance((object) asn1Sequence3[index1]);
    Asn1Sequence asn1Sequence4 = seq;
    int index2 = num3;
    int num4 = index2 + 1;
    Asn1Encodable asn1Encodable2 = asn1Sequence4[index2];
    if (asn1Encodable2 is Asn1TaggedObject asn1TaggedObject2)
    {
      this.digestAlgorithm = AlgorithmIdentifier.GetInstance(asn1TaggedObject2, false);
      asn1Encodable2 = seq[num4++];
    }
    this.encapsulatedContentInfo = ContentInfo.GetInstance((object) asn1Encodable2);
    Asn1Sequence asn1Sequence5 = seq;
    int index3 = num4;
    int index4 = index3 + 1;
    Asn1Encodable asn1Encodable3 = asn1Sequence5[index3];
    if (asn1Encodable3 is Asn1TaggedObject taggedObject)
    {
      this.authAttrs = Asn1Set.GetInstance(taggedObject, false);
      asn1Encodable3 = seq[index4++];
    }
    this.mac = Asn1OctetString.GetInstance((object) asn1Encodable3);
    if (seq.Count <= index4)
      return;
    this.unauthAttrs = Asn1Set.GetInstance((Asn1TaggedObject) seq[index4], false);
  }

  public static AuthenticatedData GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return AuthenticatedData.GetInstance((object) Asn1Sequence.GetInstance(obj, isExplicit));
  }

  public static AuthenticatedData GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case AuthenticatedData _:
        return (AuthenticatedData) obj;
      case Asn1Sequence _:
        return new AuthenticatedData((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid AuthenticatedData: " + Platform.GetTypeName(obj));
    }
  }

  public DerInteger Version => this.version;

  public OriginatorInfo OriginatorInfo => this.originatorInfo;

  public Asn1Set RecipientInfos => this.recipientInfos;

  public AlgorithmIdentifier MacAlgorithm => this.macAlgorithm;

  public AlgorithmIdentifier DigestAlgorithm => this.digestAlgorithm;

  public ContentInfo EncapsulatedContentInfo => this.encapsulatedContentInfo;

  public Asn1Set AuthAttrs => this.authAttrs;

  public Asn1OctetString Mac => this.mac;

  public Asn1Set UnauthAttrs => this.unauthAttrs;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.version);
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.originatorInfo);
    elementVector.Add((Asn1Encodable) this.recipientInfos, (Asn1Encodable) this.macAlgorithm);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.digestAlgorithm);
    elementVector.Add((Asn1Encodable) this.encapsulatedContentInfo);
    elementVector.AddOptionalTagged(false, 2, (Asn1Encodable) this.authAttrs);
    elementVector.Add((Asn1Encodable) this.mac);
    elementVector.AddOptionalTagged(false, 3, (Asn1Encodable) this.unauthAttrs);
    return (Asn1Object) new BerSequence(elementVector);
  }

  public static int CalculateVersion(OriginatorInfo origInfo)
  {
    if (origInfo == null)
      return 0;
    int version = 0;
    foreach (object certificate in origInfo.Certificates)
    {
      if (certificate is Asn1TaggedObject)
      {
        Asn1TaggedObject asn1TaggedObject = (Asn1TaggedObject) certificate;
        if (asn1TaggedObject.TagNo == 2)
          version = 1;
        else if (asn1TaggedObject.TagNo == 3)
        {
          version = 3;
          break;
        }
      }
    }
    foreach (object crl in origInfo.Crls)
    {
      if (crl is Asn1TaggedObject && ((Asn1TaggedObject) crl).TagNo == 1)
      {
        version = 3;
        break;
      }
    }
    return version;
  }
}
