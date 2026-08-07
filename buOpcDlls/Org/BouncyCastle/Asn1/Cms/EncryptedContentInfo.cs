// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.EncryptedContentInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class EncryptedContentInfo : Asn1Encodable
{
  private DerObjectIdentifier contentType;
  private AlgorithmIdentifier contentEncryptionAlgorithm;
  private Asn1OctetString encryptedContent;

  public EncryptedContentInfo(
    DerObjectIdentifier contentType,
    AlgorithmIdentifier contentEncryptionAlgorithm,
    Asn1OctetString encryptedContent)
  {
    this.contentType = contentType;
    this.contentEncryptionAlgorithm = contentEncryptionAlgorithm;
    this.encryptedContent = encryptedContent;
  }

  public EncryptedContentInfo(Asn1Sequence seq)
  {
    this.contentType = (DerObjectIdentifier) seq[0];
    this.contentEncryptionAlgorithm = AlgorithmIdentifier.GetInstance((object) seq[1]);
    if (seq.Count <= 2)
      return;
    this.encryptedContent = Asn1OctetString.GetInstance((Asn1TaggedObject) seq[2], false);
  }

  public static EncryptedContentInfo GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case EncryptedContentInfo _:
        return (EncryptedContentInfo) obj;
      case Asn1Sequence _:
        return new EncryptedContentInfo((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid EncryptedContentInfo: " + Platform.GetTypeName(obj));
    }
  }

  public DerObjectIdentifier ContentType => this.contentType;

  public AlgorithmIdentifier ContentEncryptionAlgorithm => this.contentEncryptionAlgorithm;

  public Asn1OctetString EncryptedContent => this.encryptedContent;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.contentType, (Asn1Encodable) this.contentEncryptionAlgorithm);
    if (this.encryptedContent != null)
      elementVector.Add((Asn1Encodable) new BerTaggedObject(false, 0, (Asn1Encodable) this.encryptedContent));
    return (Asn1Object) new BerSequence(elementVector);
  }
}
