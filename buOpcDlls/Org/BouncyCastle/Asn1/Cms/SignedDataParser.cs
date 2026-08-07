// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.SignedDataParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class SignedDataParser
{
  private Asn1SequenceParser _seq;
  private DerInteger _version;
  private object _nextObject;
  private bool _certsCalled;
  private bool _crlsCalled;

  public static SignedDataParser GetInstance(object o)
  {
    switch (o)
    {
      case Asn1Sequence _:
        return new SignedDataParser(((Asn1Sequence) o).Parser);
      case Asn1SequenceParser _:
        return new SignedDataParser((Asn1SequenceParser) o);
      default:
        throw new IOException("unknown object encountered: " + Platform.GetTypeName(o));
    }
  }

  public SignedDataParser(Asn1SequenceParser seq)
  {
    this._seq = seq;
    this._version = (DerInteger) seq.ReadObject();
  }

  public DerInteger Version => this._version;

  public Asn1SetParser GetDigestAlgorithms() => (Asn1SetParser) this._seq.ReadObject();

  public ContentInfoParser GetEncapContentInfo()
  {
    return new ContentInfoParser((Asn1SequenceParser) this._seq.ReadObject());
  }

  public Asn1SetParser GetCertificates()
  {
    this._certsCalled = true;
    this._nextObject = (object) this._seq.ReadObject();
    if (!(this._nextObject is Asn1TaggedObjectParser nextObject) || !nextObject.HasContextTag(0))
      return (Asn1SetParser) null;
    Asn1SetParser baseUniversal = (Asn1SetParser) nextObject.ParseBaseUniversal(false, 17);
    this._nextObject = (object) null;
    return baseUniversal;
  }

  public Asn1SetParser GetCrls()
  {
    if (!this._certsCalled)
      throw new IOException("GetCerts() has not been called.");
    this._crlsCalled = true;
    if (this._nextObject == null)
      this._nextObject = (object) this._seq.ReadObject();
    if (!(this._nextObject is Asn1TaggedObjectParser nextObject) || !nextObject.HasContextTag(1))
      return (Asn1SetParser) null;
    Asn1SetParser baseUniversal = (Asn1SetParser) nextObject.ParseBaseUniversal(false, 17);
    this._nextObject = (object) null;
    return baseUniversal;
  }

  public Asn1SetParser GetSignerInfos()
  {
    if (!this._certsCalled || !this._crlsCalled)
      throw new IOException("GetCerts() and/or GetCrls() has not been called.");
    if (this._nextObject == null)
      this._nextObject = (object) this._seq.ReadObject();
    return (Asn1SetParser) this._nextObject;
  }
}
