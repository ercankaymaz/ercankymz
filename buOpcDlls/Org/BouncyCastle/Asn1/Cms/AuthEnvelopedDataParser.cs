// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.AuthEnvelopedDataParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class AuthEnvelopedDataParser
{
  private Asn1SequenceParser seq;
  private DerInteger version;
  private IAsn1Convertible nextObject;
  private bool originatorInfoCalled;
  private bool isData;

  public AuthEnvelopedDataParser(Asn1SequenceParser seq)
  {
    this.seq = seq;
    this.version = (DerInteger) seq.ReadObject();
    if (!this.version.HasValue(0))
      throw new Asn1ParsingException("AuthEnvelopedData version number must be 0");
  }

  public DerInteger Version => this.version;

  public OriginatorInfo GetOriginatorInfo()
  {
    this.originatorInfoCalled = true;
    if (this.nextObject == null)
      this.nextObject = this.seq.ReadObject();
    if (!(this.nextObject is Asn1TaggedObjectParser nextObject) || !nextObject.HasContextTag(0))
      return (OriginatorInfo) null;
    Asn1SequenceParser baseUniversal = (Asn1SequenceParser) nextObject.ParseBaseUniversal(false, 16 /*0x10*/);
    this.nextObject = (IAsn1Convertible) null;
    return OriginatorInfo.GetInstance((object) baseUniversal.ToAsn1Object());
  }

  public Asn1SetParser GetRecipientInfos()
  {
    if (!this.originatorInfoCalled)
      this.GetOriginatorInfo();
    if (this.nextObject == null)
      this.nextObject = this.seq.ReadObject();
    Asn1SetParser nextObject = (Asn1SetParser) this.nextObject;
    this.nextObject = (IAsn1Convertible) null;
    return nextObject;
  }

  public EncryptedContentInfoParser GetAuthEncryptedContentInfo()
  {
    if (this.nextObject == null)
      this.nextObject = this.seq.ReadObject();
    if (this.nextObject == null)
      return (EncryptedContentInfoParser) null;
    Asn1SequenceParser nextObject = (Asn1SequenceParser) this.nextObject;
    this.nextObject = (IAsn1Convertible) null;
    EncryptedContentInfoParser encryptedContentInfo = new EncryptedContentInfoParser(nextObject);
    this.isData = CmsObjectIdentifiers.Data.Equals((Asn1Object) encryptedContentInfo.ContentType);
    return encryptedContentInfo;
  }

  public Asn1SetParser GetAuthAttrs()
  {
    if (this.nextObject == null)
      this.nextObject = this.seq.ReadObject();
    if (this.nextObject is Asn1TaggedObjectParser nextObject)
    {
      this.nextObject = (IAsn1Convertible) null;
      return (Asn1SetParser) Asn1Utilities.ParseContextBaseUniversal(nextObject, 1, false, 17);
    }
    if (!this.isData)
      throw new Asn1ParsingException("authAttrs must be present with non-data content");
    return (Asn1SetParser) null;
  }

  public Asn1OctetString GetMac()
  {
    if (this.nextObject == null)
      this.nextObject = this.seq.ReadObject();
    IAsn1Convertible nextObject = this.nextObject;
    this.nextObject = (IAsn1Convertible) null;
    return Asn1OctetString.GetInstance((object) nextObject.ToAsn1Object());
  }

  public Asn1SetParser GetUnauthAttrs()
  {
    if (this.nextObject == null)
      this.nextObject = this.seq.ReadObject();
    if (this.nextObject == null)
      return (Asn1SetParser) null;
    Asn1TaggedObjectParser nextObject = (Asn1TaggedObjectParser) this.nextObject;
    this.nextObject = (IAsn1Convertible) null;
    return (Asn1SetParser) Asn1Utilities.ParseContextBaseUniversal(nextObject, 2, false, 17);
  }
}
