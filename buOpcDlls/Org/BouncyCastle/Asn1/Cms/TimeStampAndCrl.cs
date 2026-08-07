// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.TimeStampAndCrl
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class TimeStampAndCrl : Asn1Encodable
{
  private ContentInfo timeStamp;
  private CertificateList crl;

  public TimeStampAndCrl(ContentInfo timeStamp) => this.timeStamp = timeStamp;

  private TimeStampAndCrl(Asn1Sequence seq)
  {
    this.timeStamp = ContentInfo.GetInstance((object) seq[0]);
    if (seq.Count != 2)
      return;
    this.crl = CertificateList.GetInstance((object) seq[1]);
  }

  public static TimeStampAndCrl GetInstance(object obj)
  {
    if (obj is TimeStampAndCrl)
      return (TimeStampAndCrl) obj;
    return obj != null ? new TimeStampAndCrl(Asn1Sequence.GetInstance(obj)) : (TimeStampAndCrl) null;
  }

  public virtual ContentInfo TimeStampToken => this.timeStamp;

  public virtual CertificateList Crl => this.crl;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.timeStamp);
    elementVector.AddOptional((Asn1Encodable) this.crl);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
