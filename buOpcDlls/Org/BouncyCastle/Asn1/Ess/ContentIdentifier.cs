// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ess.ContentIdentifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ess;

public class ContentIdentifier : Asn1Encodable
{
  private Asn1OctetString value;

  public static ContentIdentifier GetInstance(object o)
  {
    switch (o)
    {
      case null:
      case ContentIdentifier _:
        return (ContentIdentifier) o;
      case Asn1OctetString _:
        return new ContentIdentifier((Asn1OctetString) o);
      default:
        throw new ArgumentException($"unknown object in 'ContentIdentifier' factory : {Platform.GetTypeName(o)}.");
    }
  }

  public ContentIdentifier(Asn1OctetString value) => this.value = value;

  public ContentIdentifier(byte[] value)
    : this((Asn1OctetString) new DerOctetString(value))
  {
  }

  public Asn1OctetString Value => this.value;

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.value;
}
