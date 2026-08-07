// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.CrlBag
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class CrlBag : Asn1Encodable
{
  private readonly DerObjectIdentifier m_crlID;
  private readonly Asn1Encodable m_crlValue;

  public static CrlBag GetInstance(object obj)
  {
    if (obj is CrlBag instance)
      return instance;
    return obj == null ? (CrlBag) null : new CrlBag(Asn1Sequence.GetInstance(obj));
  }

  private CrlBag(Asn1Sequence seq)
  {
    this.m_crlID = seq.Count == 2 ? DerObjectIdentifier.GetInstance((object) seq[0]) : throw new ArgumentException("Wrong number of elements in sequence", nameof (seq));
    this.m_crlValue = (Asn1Encodable) Asn1TaggedObject.GetInstance((object) seq[1]).GetObject();
  }

  public CrlBag(DerObjectIdentifier crlID, Asn1Encodable crlValue)
  {
    this.m_crlID = crlID;
    this.m_crlValue = crlValue;
  }

  public virtual DerObjectIdentifier CrlID => this.m_crlID;

  public virtual Asn1Encodable CrlValue => this.m_crlValue;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.m_crlID, (Asn1Encodable) new DerTaggedObject(0, this.m_crlValue));
  }
}
