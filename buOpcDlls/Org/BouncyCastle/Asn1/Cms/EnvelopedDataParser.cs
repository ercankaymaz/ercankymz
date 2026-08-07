// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.EnvelopedDataParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class EnvelopedDataParser
{
  private Asn1SequenceParser _seq;
  private DerInteger _version;
  private IAsn1Convertible _nextObject;
  private bool _originatorInfoCalled;

  public EnvelopedDataParser(Asn1SequenceParser seq)
  {
    this._seq = seq;
    this._version = (DerInteger) seq.ReadObject();
  }

  public DerInteger Version => this._version;

  public OriginatorInfo GetOriginatorInfo()
  {
    this._originatorInfoCalled = true;
    if (this._nextObject == null)
      this._nextObject = this._seq.ReadObject();
    if (!(this._nextObject is Asn1TaggedObjectParser nextObject) || !nextObject.HasContextTag(0))
      return (OriginatorInfo) null;
    Asn1SequenceParser baseUniversal = (Asn1SequenceParser) nextObject.ParseBaseUniversal(false, 16 /*0x10*/);
    this._nextObject = (IAsn1Convertible) null;
    return OriginatorInfo.GetInstance((object) baseUniversal.ToAsn1Object());
  }

  public Asn1SetParser GetRecipientInfos()
  {
    if (!this._originatorInfoCalled)
      this.GetOriginatorInfo();
    if (this._nextObject == null)
      this._nextObject = this._seq.ReadObject();
    Asn1SetParser nextObject = (Asn1SetParser) this._nextObject;
    this._nextObject = (IAsn1Convertible) null;
    return nextObject;
  }

  public EncryptedContentInfoParser GetEncryptedContentInfo()
  {
    if (this._nextObject == null)
      this._nextObject = this._seq.ReadObject();
    if (this._nextObject == null)
      return (EncryptedContentInfoParser) null;
    Asn1SequenceParser nextObject = (Asn1SequenceParser) this._nextObject;
    this._nextObject = (IAsn1Convertible) null;
    return new EncryptedContentInfoParser(nextObject);
  }

  public Asn1SetParser GetUnprotectedAttrs()
  {
    if (this._nextObject == null)
      this._nextObject = this._seq.ReadObject();
    if (this._nextObject == null)
      return (Asn1SetParser) null;
    Asn1TaggedObjectParser nextObject = (Asn1TaggedObjectParser) this._nextObject;
    this._nextObject = (IAsn1Convertible) null;
    return (Asn1SetParser) Asn1Utilities.ParseContextBaseUniversal(nextObject, 1, false, 17);
  }
}
