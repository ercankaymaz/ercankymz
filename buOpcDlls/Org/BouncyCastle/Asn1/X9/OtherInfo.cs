// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X9.OtherInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.X9;

public class OtherInfo : Asn1Encodable
{
  private KeySpecificInfo keyInfo;
  private Asn1OctetString partyAInfo;
  private Asn1OctetString suppPubInfo;

  public OtherInfo(
    KeySpecificInfo keyInfo,
    Asn1OctetString partyAInfo,
    Asn1OctetString suppPubInfo)
  {
    this.keyInfo = keyInfo;
    this.partyAInfo = partyAInfo;
    this.suppPubInfo = suppPubInfo;
  }

  public OtherInfo(Asn1Sequence seq)
  {
    IEnumerator<Asn1Encodable> enumerator = seq.GetEnumerator();
    enumerator.MoveNext();
    this.keyInfo = new KeySpecificInfo((Asn1Sequence) enumerator.Current);
    while (enumerator.MoveNext())
    {
      Asn1TaggedObject current = (Asn1TaggedObject) enumerator.Current;
      if (current.TagNo == 0)
        this.partyAInfo = (Asn1OctetString) current.GetObject();
      else if (current.TagNo == 2)
        this.suppPubInfo = (Asn1OctetString) current.GetObject();
    }
  }

  public KeySpecificInfo KeyInfo => this.keyInfo;

  public Asn1OctetString PartyAInfo => this.partyAInfo;

  public Asn1OctetString SuppPubInfo => this.suppPubInfo;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.keyInfo);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.partyAInfo);
    elementVector.Add((Asn1Encodable) new DerTaggedObject(2, (Asn1Encodable) this.suppPubInfo));
    return (Asn1Object) new DerSequence(elementVector);
  }
}
