// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.EncryptedData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class EncryptedData : Asn1Encodable
{
  private readonly DerInteger version;
  private readonly EncryptedContentInfo encryptedContentInfo;
  private readonly Asn1Set unprotectedAttrs;

  public static EncryptedData GetInstance(object obj)
  {
    switch (obj)
    {
      case EncryptedData _:
        return (EncryptedData) obj;
      case Asn1Sequence _:
        return new EncryptedData((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid EncryptedData: " + Platform.GetTypeName(obj));
    }
  }

  public EncryptedData(EncryptedContentInfo encInfo)
    : this(encInfo, (Asn1Set) null)
  {
  }

  public EncryptedData(EncryptedContentInfo encInfo, Asn1Set unprotectedAttrs)
  {
    if (encInfo == null)
      throw new ArgumentNullException(nameof (encInfo));
    this.version = new DerInteger(unprotectedAttrs == null ? 0 : 2);
    this.encryptedContentInfo = encInfo;
    this.unprotectedAttrs = unprotectedAttrs;
  }

  private EncryptedData(Asn1Sequence seq)
  {
    if (seq == null)
      throw new ArgumentNullException(nameof (seq));
    this.version = seq.Count >= 2 && seq.Count <= 3 ? DerInteger.GetInstance((object) seq[0]) : throw new ArgumentException("Bad sequence size: " + seq.Count.ToString(), nameof (seq));
    this.encryptedContentInfo = EncryptedContentInfo.GetInstance((object) seq[1]);
    if (seq.Count <= 2)
      return;
    this.unprotectedAttrs = Asn1Set.GetInstance((Asn1TaggedObject) seq[2], false);
  }

  public virtual DerInteger Version => this.version;

  public virtual EncryptedContentInfo EncryptedContentInfo => this.encryptedContentInfo;

  public virtual Asn1Set UnprotectedAttrs => this.unprotectedAttrs;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.version, (Asn1Encodable) this.encryptedContentInfo);
    if (this.unprotectedAttrs != null)
      elementVector.Add((Asn1Encodable) new BerTaggedObject(false, 1, (Asn1Encodable) this.unprotectedAttrs));
    return (Asn1Object) new BerSequence(elementVector);
  }
}
