// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.InfoTypeAndValue
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class InfoTypeAndValue : Asn1Encodable
{
  private readonly DerObjectIdentifier m_infoType;
  private readonly Asn1Encodable m_infoValue;

  public static InfoTypeAndValue GetInstance(object obj)
  {
    if (obj == null)
      return (InfoTypeAndValue) null;
    return obj is InfoTypeAndValue infoTypeAndValue ? infoTypeAndValue : new InfoTypeAndValue(Asn1Sequence.GetInstance(obj));
  }

  public static InfoTypeAndValue GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return InfoTypeAndValue.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private InfoTypeAndValue(Asn1Sequence seq)
  {
    this.m_infoType = DerObjectIdentifier.GetInstance((object) seq[0]);
    if (seq.Count <= 1)
      return;
    this.m_infoValue = seq[1];
  }

  public InfoTypeAndValue(DerObjectIdentifier infoType)
    : this(infoType, (Asn1Encodable) null)
  {
  }

  public InfoTypeAndValue(DerObjectIdentifier infoType, Asn1Encodable infoValue)
  {
    this.m_infoType = infoType ?? throw new ArgumentNullException(nameof (infoType));
    this.m_infoValue = infoValue;
  }

  public virtual DerObjectIdentifier InfoType => this.m_infoType;

  public virtual Asn1Encodable InfoValue => this.m_infoValue;

  public override Asn1Object ToAsn1Object()
  {
    return this.m_infoValue == null ? (Asn1Object) new DerSequence((Asn1Encodable) this.m_infoType) : (Asn1Object) new DerSequence((Asn1Encodable) this.m_infoType, this.m_infoValue);
  }
}
