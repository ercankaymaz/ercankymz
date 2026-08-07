// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.OtherRevocationInfoFormat
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class OtherRevocationInfoFormat : Asn1Encodable
{
  private readonly DerObjectIdentifier otherRevInfoFormat;
  private readonly Asn1Encodable otherRevInfo;

  public OtherRevocationInfoFormat(
    DerObjectIdentifier otherRevInfoFormat,
    Asn1Encodable otherRevInfo)
  {
    this.otherRevInfoFormat = otherRevInfoFormat;
    this.otherRevInfo = otherRevInfo;
  }

  private OtherRevocationInfoFormat(Asn1Sequence seq)
  {
    this.otherRevInfoFormat = DerObjectIdentifier.GetInstance((object) seq[0]);
    this.otherRevInfo = seq[1];
  }

  public static OtherRevocationInfoFormat GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return OtherRevocationInfoFormat.GetInstance((object) Asn1Sequence.GetInstance(obj, isExplicit));
  }

  public static OtherRevocationInfoFormat GetInstance(object obj)
  {
    if (obj is OtherRevocationInfoFormat instance)
      return instance;
    return obj != null ? new OtherRevocationInfoFormat(Asn1Sequence.GetInstance(obj)) : (OtherRevocationInfoFormat) null;
  }

  public virtual DerObjectIdentifier InfoFormat => this.otherRevInfoFormat;

  public virtual Asn1Encodable Info => this.otherRevInfo;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.otherRevInfoFormat, this.otherRevInfo);
  }
}
