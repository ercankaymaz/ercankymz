// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Smime.SmimeEncryptionKeyPreferenceAttribute
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.Asn1.Smime;

public class SmimeEncryptionKeyPreferenceAttribute : AttributeX509
{
  public SmimeEncryptionKeyPreferenceAttribute(IssuerAndSerialNumber issAndSer)
    : base(SmimeAttributes.EncrypKeyPref, (Asn1Set) new DerSet((Asn1Encodable) new DerTaggedObject(false, 0, (Asn1Encodable) issAndSer)))
  {
  }

  public SmimeEncryptionKeyPreferenceAttribute(RecipientKeyIdentifier rKeyID)
    : base(SmimeAttributes.EncrypKeyPref, (Asn1Set) new DerSet((Asn1Encodable) new DerTaggedObject(false, 1, (Asn1Encodable) rKeyID)))
  {
  }

  public SmimeEncryptionKeyPreferenceAttribute(Asn1OctetString sKeyID)
    : base(SmimeAttributes.EncrypKeyPref, (Asn1Set) new DerSet((Asn1Encodable) new DerTaggedObject(false, 2, (Asn1Encodable) sKeyID)))
  {
  }
}
