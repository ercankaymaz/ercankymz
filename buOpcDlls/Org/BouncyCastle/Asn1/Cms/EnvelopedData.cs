// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.EnvelopedData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class EnvelopedData : Asn1Encodable
{
  private DerInteger version;
  private OriginatorInfo originatorInfo;
  private Asn1Set recipientInfos;
  private EncryptedContentInfo encryptedContentInfo;
  private Asn1Set unprotectedAttrs;

  public EnvelopedData(
    OriginatorInfo originatorInfo,
    Asn1Set recipientInfos,
    EncryptedContentInfo encryptedContentInfo,
    Asn1Set unprotectedAttrs)
  {
    this.version = new DerInteger(EnvelopedData.CalculateVersion(originatorInfo, recipientInfos, unprotectedAttrs));
    this.originatorInfo = originatorInfo;
    this.recipientInfos = recipientInfos;
    this.encryptedContentInfo = encryptedContentInfo;
    this.unprotectedAttrs = unprotectedAttrs;
  }

  public EnvelopedData(
    OriginatorInfo originatorInfo,
    Asn1Set recipientInfos,
    EncryptedContentInfo encryptedContentInfo,
    Attributes unprotectedAttrs)
  {
    this.version = new DerInteger(EnvelopedData.CalculateVersion(originatorInfo, recipientInfos, Asn1Set.GetInstance((object) unprotectedAttrs)));
    this.originatorInfo = originatorInfo;
    this.recipientInfos = recipientInfos;
    this.encryptedContentInfo = encryptedContentInfo;
    this.unprotectedAttrs = Asn1Set.GetInstance((object) unprotectedAttrs);
  }

  private EnvelopedData(Asn1Sequence seq)
  {
    int num1 = 0;
    Asn1Sequence asn1Sequence1 = seq;
    num1 = 1;
    this.version = (DerInteger) asn1Sequence1[0];
    Asn1Sequence asn1Sequence2 = seq;
    int num2 = 2;
    object obj = (object) asn1Sequence2[1];
    if (obj is Asn1TaggedObject asn1TaggedObject)
    {
      this.originatorInfo = OriginatorInfo.GetInstance(asn1TaggedObject, false);
      obj = (object) seq[num2++];
    }
    this.recipientInfos = Asn1Set.GetInstance(obj);
    Asn1Sequence asn1Sequence3 = seq;
    int index1 = num2;
    int index2 = index1 + 1;
    this.encryptedContentInfo = EncryptedContentInfo.GetInstance((object) asn1Sequence3[index1]);
    if (seq.Count <= index2)
      return;
    this.unprotectedAttrs = Asn1Set.GetInstance((Asn1TaggedObject) seq[index2], false);
  }

  public static EnvelopedData GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return EnvelopedData.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static EnvelopedData GetInstance(object obj)
  {
    if (obj is EnvelopedData)
      return (EnvelopedData) obj;
    return obj == null ? (EnvelopedData) null : new EnvelopedData(Asn1Sequence.GetInstance(obj));
  }

  public DerInteger Version => this.version;

  public OriginatorInfo OriginatorInfo => this.originatorInfo;

  public Asn1Set RecipientInfos => this.recipientInfos;

  public EncryptedContentInfo EncryptedContentInfo => this.encryptedContentInfo;

  public Asn1Set UnprotectedAttrs => this.unprotectedAttrs;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.version);
    elementVector.AddOptionalTagged(false, 0, (Asn1Encodable) this.originatorInfo);
    elementVector.Add((Asn1Encodable) this.recipientInfos, (Asn1Encodable) this.encryptedContentInfo);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.unprotectedAttrs);
    return (Asn1Object) new BerSequence(elementVector);
  }

  public static int CalculateVersion(
    OriginatorInfo originatorInfo,
    Asn1Set recipientInfos,
    Asn1Set unprotectedAttrs)
  {
    if (originatorInfo != null || unprotectedAttrs != null)
      return 2;
    foreach (object recipientInfo in recipientInfos)
    {
      if (!RecipientInfo.GetInstance(recipientInfo).Version.HasValue(0))
        return 2;
    }
    return 0;
  }
}
