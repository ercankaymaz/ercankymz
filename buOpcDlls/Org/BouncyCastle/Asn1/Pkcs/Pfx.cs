// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Pkcs.Pfx
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Pkcs;

public class Pfx : Asn1Encodable
{
  private readonly ContentInfo contentInfo;
  private readonly MacData macData;

  public static Pfx GetInstance(object obj)
  {
    if (obj is Pfx)
      return (Pfx) obj;
    return obj == null ? (Pfx) null : new Pfx(Asn1Sequence.GetInstance(obj));
  }

  private Pfx(Asn1Sequence seq)
  {
    this.contentInfo = DerInteger.GetInstance((object) seq[0]).HasValue(3) ? ContentInfo.GetInstance((object) seq[1]) : throw new ArgumentException("wrong version for PFX PDU");
    if (seq.Count != 3)
      return;
    this.macData = MacData.GetInstance((object) seq[2]);
  }

  public Pfx(ContentInfo contentInfo, MacData macData)
  {
    this.contentInfo = contentInfo;
    this.macData = macData;
  }

  public ContentInfo AuthSafe => this.contentInfo;

  public MacData MacData => this.macData;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) new DerInteger(3), (Asn1Encodable) this.contentInfo);
    elementVector.AddOptional((Asn1Encodable) this.macData);
    return (Asn1Object) new BerSequence(elementVector);
  }
}
