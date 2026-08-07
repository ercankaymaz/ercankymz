// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cms.Ecc.MQVuserKeyingMaterial
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cms.Ecc;

public class MQVuserKeyingMaterial : Asn1Encodable
{
  private OriginatorPublicKey ephemeralPublicKey;
  private Asn1OctetString addedukm;

  public MQVuserKeyingMaterial(OriginatorPublicKey ephemeralPublicKey, Asn1OctetString addedukm)
  {
    this.ephemeralPublicKey = ephemeralPublicKey;
    this.addedukm = addedukm;
  }

  private MQVuserKeyingMaterial(Asn1Sequence seq)
  {
    this.ephemeralPublicKey = OriginatorPublicKey.GetInstance((object) seq[0]);
    if (seq.Count <= 1)
      return;
    this.addedukm = Asn1OctetString.GetInstance((Asn1TaggedObject) seq[1], true);
  }

  public static MQVuserKeyingMaterial GetInstance(Asn1TaggedObject obj, bool isExplicit)
  {
    return MQVuserKeyingMaterial.GetInstance((object) Asn1Sequence.GetInstance(obj, isExplicit));
  }

  public static MQVuserKeyingMaterial GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case MQVuserKeyingMaterial _:
        return (MQVuserKeyingMaterial) obj;
      case Asn1Sequence _:
        return new MQVuserKeyingMaterial((Asn1Sequence) obj);
      default:
        throw new ArgumentException("Invalid MQVuserKeyingMaterial: " + Platform.GetTypeName(obj));
    }
  }

  public OriginatorPublicKey EphemeralPublicKey => this.ephemeralPublicKey;

  public Asn1OctetString AddedUkm => this.addedukm;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.ephemeralPublicKey);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.addedukm);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
