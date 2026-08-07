// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ess.ContentHints
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ess;

public class ContentHints : Asn1Encodable
{
  private readonly DerUtf8String contentDescription;
  private readonly DerObjectIdentifier contentType;

  public static ContentHints GetInstance(object o)
  {
    switch (o)
    {
      case null:
      case ContentHints _:
        return (ContentHints) o;
      case Asn1Sequence _:
        return new ContentHints((Asn1Sequence) o);
      default:
        throw new ArgumentException($"unknown object in 'ContentHints' factory : {Platform.GetTypeName(o)}.");
    }
  }

  private ContentHints(Asn1Sequence seq)
  {
    IAsn1Convertible asn1Convertible = (IAsn1Convertible) seq[0];
    if (asn1Convertible.ToAsn1Object() is DerUtf8String)
    {
      this.contentDescription = DerUtf8String.GetInstance((object) asn1Convertible);
      this.contentType = DerObjectIdentifier.GetInstance((object) seq[1]);
    }
    else
      this.contentType = DerObjectIdentifier.GetInstance((object) seq[0]);
  }

  public ContentHints(DerObjectIdentifier contentType)
  {
    this.contentType = contentType;
    this.contentDescription = (DerUtf8String) null;
  }

  public ContentHints(DerObjectIdentifier contentType, DerUtf8String contentDescription)
  {
    this.contentType = contentType;
    this.contentDescription = contentDescription;
  }

  public DerObjectIdentifier ContentType => this.contentType;

  public DerUtf8String ContentDescription => this.contentDescription;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(2);
    elementVector.AddOptional((Asn1Encodable) this.contentDescription);
    elementVector.Add((Asn1Encodable) this.contentType);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
