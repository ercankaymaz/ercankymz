// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X500.AttributeTypeAndValue
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.X500;

public class AttributeTypeAndValue : Asn1Encodable
{
  private readonly DerObjectIdentifier type;
  private readonly Asn1Encodable value;

  private AttributeTypeAndValue(Asn1Sequence seq)
  {
    this.type = (DerObjectIdentifier) seq[0];
    this.value = seq[1];
  }

  public static AttributeTypeAndValue GetInstance(object obj)
  {
    if (obj is AttributeTypeAndValue)
      return (AttributeTypeAndValue) obj;
    return obj != null ? new AttributeTypeAndValue(Asn1Sequence.GetInstance(obj)) : throw new ArgumentNullException(nameof (obj));
  }

  public AttributeTypeAndValue(DerObjectIdentifier type, Asn1Encodable value)
  {
    this.type = type;
    this.value = value;
  }

  public virtual DerObjectIdentifier Type => this.type;

  public virtual Asn1Encodable Value => this.value;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.type, this.value);
  }
}
