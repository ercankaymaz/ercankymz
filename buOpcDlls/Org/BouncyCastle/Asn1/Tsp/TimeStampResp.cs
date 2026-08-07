// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Tsp.TimeStampResp
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.Cms;

#nullable disable
namespace Org.BouncyCastle.Asn1.Tsp;

public class TimeStampResp : Asn1Encodable
{
  private readonly PkiStatusInfo pkiStatusInfo;
  private readonly ContentInfo timeStampToken;

  public static TimeStampResp GetInstance(object obj)
  {
    if (obj is TimeStampResp)
      return (TimeStampResp) obj;
    return obj == null ? (TimeStampResp) null : new TimeStampResp(Asn1Sequence.GetInstance(obj));
  }

  private TimeStampResp(Asn1Sequence seq)
  {
    this.pkiStatusInfo = PkiStatusInfo.GetInstance((object) seq[0]);
    if (seq.Count <= 1)
      return;
    this.timeStampToken = ContentInfo.GetInstance((object) seq[1]);
  }

  public TimeStampResp(PkiStatusInfo pkiStatusInfo, ContentInfo timeStampToken)
  {
    this.pkiStatusInfo = pkiStatusInfo;
    this.timeStampToken = timeStampToken;
  }

  public PkiStatusInfo Status => this.pkiStatusInfo;

  public ContentInfo TimeStampToken => this.timeStampToken;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.pkiStatusInfo);
    elementVector.AddOptional((Asn1Encodable) this.timeStampToken);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
