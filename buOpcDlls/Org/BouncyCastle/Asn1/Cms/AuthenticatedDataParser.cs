// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.AuthenticatedDataParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class AuthenticatedDataParser
{
  private Asn1SequenceParser seq;
  private DerInteger version;
  private IAsn1Convertible nextObject;
  private bool originatorInfoCalled;

  public AuthenticatedDataParser(Asn1SequenceParser seq)
  {
    this.seq = seq;
    this.version = (DerInteger) seq.ReadObject();
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

  public AlgorithmIdentifier GetMacAlgorithm()
  {
    if (this.nextObject == null)
      this.nextObject = this.seq.ReadObject();
    if (this.nextObject == null)
      return (AlgorithmIdentifier) null;
    Asn1SequenceParser nextObject = (Asn1SequenceParser) this.nextObject;
    this.nextObject = (IAsn1Convertible) null;
    return AlgorithmIdentifier.GetInstance((object) nextObject.ToAsn1Object());
  }

  public AlgorithmIdentifier GetDigestAlgorithm()
  {
    if (this.nextObject == null)
      this.nextObject = this.seq.ReadObject();
    if (!(this.nextObject is Asn1TaggedObjectParser))
      return (AlgorithmIdentifier) null;
    AlgorithmIdentifier instance = AlgorithmIdentifier.GetInstance((Asn1TaggedObject) this.nextObject.ToAsn1Object(), false);
    this.nextObject = (IAsn1Convertible) null;
    return instance;
  }

  public ContentInfoParser GetEnapsulatedContentInfo()
  {
    if (this.nextObject == null)
      this.nextObject = this.seq.ReadObject();
    if (this.nextObject == null)
      return (ContentInfoParser) null;
    Asn1SequenceParser nextObject = (Asn1SequenceParser) this.nextObject;
    this.nextObject = (IAsn1Convertible) null;
    return new ContentInfoParser(nextObject);
  }

  public Asn1SetParser GetAuthAttrs()
  {
    if (this.nextObject == null)
      this.nextObject = this.seq.ReadObject();
    if (!(this.nextObject is Asn1TaggedObjectParser nextObject))
      return (Asn1SetParser) null;
    this.nextObject = (IAsn1Convertible) null;
    return (Asn1SetParser) Asn1Utilities.ParseContextBaseUniversal(nextObject, 2, false, 17);
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
    Asn1TaggedObject nextObject = (Asn1TaggedObject) this.nextObject;
    this.nextObject = (IAsn1Convertible) null;
    return (Asn1SetParser) Asn1Utilities.ParseContextBaseUniversal((Asn1TaggedObjectParser) nextObject, 3, false, 17);
  }
}
