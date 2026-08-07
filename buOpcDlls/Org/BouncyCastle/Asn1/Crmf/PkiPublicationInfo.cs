// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Crmf.PkiPublicationInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Crmf;

public class PkiPublicationInfo : Asn1Encodable
{
  public static readonly DerInteger DontPublish = new DerInteger(0);
  public static readonly DerInteger PleasePublish = new DerInteger(1);
  private readonly DerInteger m_action;
  private readonly Asn1Sequence m_pubInfos;

  public static PkiPublicationInfo GetInstance(object obj)
  {
    if (obj is PkiPublicationInfo instance)
      return instance;
    return obj != null ? new PkiPublicationInfo(Asn1Sequence.GetInstance(obj)) : (PkiPublicationInfo) null;
  }

  private PkiPublicationInfo(Asn1Sequence seq)
  {
    this.m_action = DerInteger.GetInstance((object) seq[0]);
    if (seq.Count <= 1)
      return;
    this.m_pubInfos = Asn1Sequence.GetInstance((object) seq[1]);
  }

  public PkiPublicationInfo(BigInteger action)
    : this(new DerInteger(action))
  {
  }

  public PkiPublicationInfo(DerInteger action) => this.m_action = action;

  public PkiPublicationInfo(SinglePubInfo pubInfo)
  {
    SinglePubInfo[] pubInfos;
    if (pubInfo == null)
      pubInfos = (SinglePubInfo[]) null;
    else
      pubInfos = new SinglePubInfo[1]{ pubInfo };
    // ISSUE: explicit constructor call
    this.\u002Ector(pubInfos);
  }

  public PkiPublicationInfo(SinglePubInfo[] pubInfos)
  {
    this.m_action = PkiPublicationInfo.PleasePublish;
    if (pubInfos == null)
      return;
    this.m_pubInfos = (Asn1Sequence) new DerSequence((Asn1Encodable[]) pubInfos);
  }

  public virtual DerInteger Action => this.m_action;

  public virtual SinglePubInfo[] GetPubInfos()
  {
    return this.m_pubInfos == null ? (SinglePubInfo[]) null : this.m_pubInfos.MapElements<SinglePubInfo>(new Func<Asn1Encodable, SinglePubInfo>(SinglePubInfo.GetInstance));
  }

  public override Asn1Object ToAsn1Object()
  {
    return this.m_pubInfos == null ? (Asn1Object) new DerSequence((Asn1Encodable) this.m_action) : (Asn1Object) new DerSequence((Asn1Encodable) this.m_action, (Asn1Encodable) this.m_pubInfos);
  }
}
