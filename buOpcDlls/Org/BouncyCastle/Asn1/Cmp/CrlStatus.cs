// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.CrlStatus
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class CrlStatus : Asn1Encodable
{
  private readonly CrlSource m_source;
  private readonly Time m_thisUpdate;

  public static CrlStatus GetInstance(object obj)
  {
    if (obj == null)
      return (CrlStatus) null;
    return obj is CrlStatus crlStatus ? crlStatus : new CrlStatus(Asn1Sequence.GetInstance(obj));
  }

  public static CrlStatus GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return CrlStatus.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  private CrlStatus(Asn1Sequence sequence)
  {
    int count = sequence.Count;
    switch (count)
    {
      case 1:
      case 2:
        this.m_source = CrlSource.GetInstance((object) sequence[0]);
        if (sequence.Count != 2)
          break;
        this.m_thisUpdate = Time.GetInstance((object) sequence[1]);
        break;
      default:
        throw new ArgumentException("expected sequence size of 1 or 2, got " + count.ToString());
    }
  }

  public CrlStatus(CrlSource source, Time thisUpdate)
  {
    this.m_source = source;
    this.m_thisUpdate = thisUpdate;
  }

  public virtual CrlSource Source => this.m_source;

  public virtual Time ThisUpdate => this.m_thisUpdate;

  public override Asn1Object ToAsn1Object()
  {
    return this.m_thisUpdate == null ? (Asn1Object) new DerSequence((Asn1Encodable) this.m_source) : (Asn1Object) new DerSequence((Asn1Encodable) this.m_source, (Asn1Encodable) this.m_thisUpdate);
  }
}
