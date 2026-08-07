// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.TimeStampedData
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class TimeStampedData : Asn1Encodable
{
  private DerInteger version;
  private DerIA5String dataUri;
  private MetaData metaData;
  private Asn1OctetString content;
  private Evidence temporalEvidence;

  public TimeStampedData(
    DerIA5String dataUri,
    MetaData metaData,
    Asn1OctetString content,
    Evidence temporalEvidence)
  {
    this.version = new DerInteger(1);
    this.dataUri = dataUri;
    this.metaData = metaData;
    this.content = content;
    this.temporalEvidence = temporalEvidence;
  }

  private TimeStampedData(Asn1Sequence seq)
  {
    this.version = DerInteger.GetInstance((object) seq[0]);
    int index = 1;
    if (seq[1] is DerIA5String derIa5String)
    {
      this.dataUri = derIa5String;
      ++index;
    }
    if (seq[index] is MetaData || seq[index] is Asn1Sequence)
      this.metaData = MetaData.GetInstance((object) seq[index++]);
    if (seq[index] is Asn1OctetString asn1OctetString)
    {
      this.content = asn1OctetString;
      ++index;
    }
    this.temporalEvidence = Evidence.GetInstance((object) seq[index]);
  }

  public static TimeStampedData GetInstance(object obj)
  {
    if (obj is TimeStampedData)
      return (TimeStampedData) obj;
    return obj != null ? new TimeStampedData(Asn1Sequence.GetInstance(obj)) : (TimeStampedData) null;
  }

  public virtual DerIA5String DataUri => this.dataUri;

  public MetaData MetaData => this.metaData;

  public Asn1OctetString Content => this.content;

  public Evidence TemporalEvidence => this.temporalEvidence;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.version);
    elementVector.AddOptional((Asn1Encodable) this.dataUri, (Asn1Encodable) this.metaData, (Asn1Encodable) this.content);
    elementVector.Add((Asn1Encodable) this.temporalEvidence);
    return (Asn1Object) new BerSequence(elementVector);
  }
}
