// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.PkiArchiveOptions
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class PkiArchiveOptions : Asn1Encodable, IAsn1Choice
{
  public const int encryptedPrivKey = 0;
  public const int keyGenParameters = 1;
  public const int archiveRemGenPrivKey = 2;
  private readonly Asn1Encodable value;

  public static PkiArchiveOptions GetInstance(object obj)
  {
    switch (obj)
    {
      case PkiArchiveOptions _:
        return (PkiArchiveOptions) obj;
      case Asn1TaggedObject _:
        return new PkiArchiveOptions((Asn1TaggedObject) obj);
      default:
        throw new ArgumentException("Invalid object: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  private PkiArchiveOptions(Asn1TaggedObject tagged)
  {
    switch (tagged.TagNo)
    {
      case 0:
        this.value = (Asn1Encodable) EncryptedKey.GetInstance((object) tagged.GetObject());
        break;
      case 1:
        this.value = (Asn1Encodable) Asn1OctetString.GetInstance(tagged, false);
        break;
      case 2:
        this.value = (Asn1Encodable) DerBoolean.GetInstance(tagged, false);
        break;
      default:
        throw new ArgumentException("unknown tag number: " + tagged.TagNo.ToString(), nameof (tagged));
    }
  }

  public PkiArchiveOptions(EncryptedKey encKey) => this.value = (Asn1Encodable) encKey;

  public PkiArchiveOptions(Asn1OctetString keyGenParameters)
  {
    this.value = (Asn1Encodable) keyGenParameters;
  }

  public PkiArchiveOptions(bool archiveRemGenPrivKey)
  {
    this.value = (Asn1Encodable) DerBoolean.GetInstance(archiveRemGenPrivKey);
  }

  public virtual int Type
  {
    get
    {
      if (this.value is EncryptedKey)
        return 0;
      return this.value is Asn1OctetString ? 1 : 2;
    }
  }

  public virtual Asn1Encodable Value => this.value;

  public override Asn1Object ToAsn1Object()
  {
    if (this.value is EncryptedKey)
      return (Asn1Object) new DerTaggedObject(true, 0, this.value);
    return this.value is Asn1OctetString ? (Asn1Object) new DerTaggedObject(false, 1, this.value) : (Asn1Object) new DerTaggedObject(false, 2, this.value);
  }
}
