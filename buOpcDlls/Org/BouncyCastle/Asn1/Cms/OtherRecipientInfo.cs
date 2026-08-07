// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.OtherRecipientInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms;

public class OtherRecipientInfo : Asn1Encodable
{
  private readonly DerObjectIdentifier oriType;
  private readonly Asn1Encodable oriValue;

  public OtherRecipientInfo(DerObjectIdentifier oriType, Asn1Encodable oriValue)
  {
    this.oriType = oriType;
    this.oriValue = oriValue;
  }

  private OtherRecipientInfo(Asn1Sequence seq)
  {
    this.oriType = DerObjectIdentifier.GetInstance((object) seq[0]);
    this.oriValue = seq[1];
  }

  public static OtherRecipientInfo GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return OtherRecipientInfo.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static OtherRecipientInfo GetInstance(object obj)
  {
    if (obj == null)
      return (OtherRecipientInfo) null;
    return obj is OtherRecipientInfo otherRecipientInfo ? otherRecipientInfo : new OtherRecipientInfo(Asn1Sequence.GetInstance(obj));
  }

  public virtual DerObjectIdentifier OriType => this.oriType;

  public virtual Asn1Encodable OriValue => this.oriValue;

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.oriType, this.oriValue);
  }
}
