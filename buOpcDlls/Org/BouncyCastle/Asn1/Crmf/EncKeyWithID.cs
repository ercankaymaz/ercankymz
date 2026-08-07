// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.EncKeyWithID
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class EncKeyWithID : Asn1Encodable
{
  private readonly PrivateKeyInfo privKeyInfo;
  private readonly Asn1Encodable identifier;

  public static EncKeyWithID GetInstance(object obj)
  {
    if (obj is EncKeyWithID)
      return (EncKeyWithID) obj;
    return obj != null ? new EncKeyWithID(Asn1Sequence.GetInstance(obj)) : (EncKeyWithID) null;
  }

  private EncKeyWithID(Asn1Sequence seq)
  {
    this.privKeyInfo = PrivateKeyInfo.GetInstance((object) seq[0]);
    if (seq.Count > 1)
    {
      if (!(seq[1] is DerUtf8String))
        this.identifier = (Asn1Encodable) GeneralName.GetInstance((object) seq[1]);
      else
        this.identifier = seq[1];
    }
    else
      this.identifier = (Asn1Encodable) null;
  }

  public EncKeyWithID(PrivateKeyInfo privKeyInfo)
  {
    this.privKeyInfo = privKeyInfo;
    this.identifier = (Asn1Encodable) null;
  }

  public EncKeyWithID(PrivateKeyInfo privKeyInfo, DerUtf8String str)
  {
    this.privKeyInfo = privKeyInfo;
    this.identifier = (Asn1Encodable) str;
  }

  public EncKeyWithID(PrivateKeyInfo privKeyInfo, GeneralName generalName)
  {
    this.privKeyInfo = privKeyInfo;
    this.identifier = (Asn1Encodable) generalName;
  }

  public virtual PrivateKeyInfo PrivateKey => this.privKeyInfo;

  public virtual bool HasIdentifier => this.identifier != null;

  public virtual bool IsIdentifierUtf8String => this.identifier is DerUtf8String;

  public virtual Asn1Encodable Identifier => this.identifier;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.privKeyInfo);
    elementVector.AddOptional(this.identifier);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
