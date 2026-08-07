// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.TimeStampedDataParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class TimeStampedDataParser
{
  private DerInteger version;
  private DerIA5String dataUri;
  private MetaData metaData;
  private Asn1OctetStringParser content;
  private Evidence temporalEvidence;
  private Asn1SequenceParser parser;

  private TimeStampedDataParser(Asn1SequenceParser parser)
  {
    this.parser = parser;
    this.version = DerInteger.GetInstance((object) parser.ReadObject());
    Asn1Object asn1Object = parser.ReadObject().ToAsn1Object();
    if (asn1Object is DerIA5String)
    {
      this.dataUri = DerIA5String.GetInstance((object) asn1Object);
      asn1Object = parser.ReadObject().ToAsn1Object();
    }
    if (asn1Object is Asn1SequenceParser)
    {
      this.metaData = MetaData.GetInstance((object) asn1Object.ToAsn1Object());
      asn1Object = parser.ReadObject().ToAsn1Object();
    }
    if (!(asn1Object is Asn1OctetStringParser))
      return;
    this.content = (Asn1OctetStringParser) asn1Object;
  }

  public static TimeStampedDataParser GetInstance(object obj)
  {
    switch (obj)
    {
      case Asn1Sequence _:
        return new TimeStampedDataParser(((Asn1Sequence) obj).Parser);
      case Asn1SequenceParser _:
        return new TimeStampedDataParser((Asn1SequenceParser) obj);
      default:
        return (TimeStampedDataParser) null;
    }
  }

  public virtual DerIA5String DataUri => this.dataUri;

  public virtual MetaData MetaData => this.metaData;

  public virtual Asn1OctetStringParser Content => this.content;

  public virtual Evidence GetTemporalEvidence()
  {
    if (this.temporalEvidence == null)
      this.temporalEvidence = Evidence.GetInstance((object) this.parser.ReadObject().ToAsn1Object());
    return this.temporalEvidence;
  }
}
