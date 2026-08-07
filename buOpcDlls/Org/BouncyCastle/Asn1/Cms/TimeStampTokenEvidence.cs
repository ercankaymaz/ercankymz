// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.TimeStampTokenEvidence
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class TimeStampTokenEvidence : Asn1Encodable
{
  private TimeStampAndCrl[] timeStampAndCrls;

  public TimeStampTokenEvidence(TimeStampAndCrl[] timeStampAndCrls)
  {
    this.timeStampAndCrls = timeStampAndCrls;
  }

  public TimeStampTokenEvidence(TimeStampAndCrl timeStampAndCrl)
  {
    this.timeStampAndCrls = new TimeStampAndCrl[1]
    {
      timeStampAndCrl
    };
  }

  private TimeStampTokenEvidence(Asn1Sequence seq)
  {
    this.timeStampAndCrls = new TimeStampAndCrl[seq.Count];
    int num = 0;
    foreach (Asn1Encodable asn1Encodable in seq)
      this.timeStampAndCrls[num++] = TimeStampAndCrl.GetInstance((object) asn1Encodable.ToAsn1Object());
  }

  public static TimeStampTokenEvidence GetInstance(Asn1TaggedObject tagged, bool isExplicit)
  {
    return TimeStampTokenEvidence.GetInstance((object) Asn1Sequence.GetInstance(tagged, isExplicit));
  }

  public static TimeStampTokenEvidence GetInstance(object obj)
  {
    if (obj is TimeStampTokenEvidence)
      return (TimeStampTokenEvidence) obj;
    return obj != null ? new TimeStampTokenEvidence(Asn1Sequence.GetInstance(obj)) : (TimeStampTokenEvidence) null;
  }

  public virtual TimeStampAndCrl[] ToTimeStampAndCrlArray()
  {
    return (TimeStampAndCrl[]) this.timeStampAndCrls.Clone();
  }

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable[]) this.timeStampAndCrls);
  }
}
