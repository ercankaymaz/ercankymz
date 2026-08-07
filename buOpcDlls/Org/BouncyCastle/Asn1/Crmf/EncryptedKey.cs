// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.EncryptedKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Cms;

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class EncryptedKey : Asn1Encodable, IAsn1Choice
{
  private readonly EnvelopedData m_envelopedData;
  private readonly EncryptedValue m_encryptedValue;

  public static EncryptedKey GetInstance(object obj)
  {
    switch (obj)
    {
      case EncryptedKey instance:
        return instance;
      case Asn1TaggedObject asn1TaggedObject:
        return new EncryptedKey(EnvelopedData.GetInstance(asn1TaggedObject, false));
      default:
        return new EncryptedKey(EncryptedValue.GetInstance(obj));
    }
  }

  public EncryptedKey(EnvelopedData envelopedData) => this.m_envelopedData = envelopedData;

  public EncryptedKey(EncryptedValue encryptedValue) => this.m_encryptedValue = encryptedValue;

  public virtual bool IsEncryptedValue => this.m_encryptedValue != null;

  public virtual Asn1Encodable Value
  {
    get
    {
      return this.m_encryptedValue != null ? (Asn1Encodable) this.m_encryptedValue : (Asn1Encodable) this.m_envelopedData;
    }
  }

  public override Asn1Object ToAsn1Object()
  {
    return this.m_encryptedValue != null ? this.m_encryptedValue.ToAsn1Object() : (Asn1Object) new DerTaggedObject(false, 0, (Asn1Encodable) this.m_envelopedData);
  }
}
