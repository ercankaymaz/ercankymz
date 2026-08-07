// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Ocsp.RevokedInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Ocsp;

public class RevokedInfo : Asn1Encodable
{
  private readonly Asn1GeneralizedTime revocationTime;
  private readonly CrlReason revocationReason;

  public static RevokedInfo GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return RevokedInfo.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static RevokedInfo GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
      case RevokedInfo _:
        return (RevokedInfo) obj;
      case Asn1Sequence _:
        return new RevokedInfo((Asn1Sequence) obj);
      default:
        throw new ArgumentException("unknown object in factory: " + Platform.GetTypeName(obj), nameof (obj));
    }
  }

  public RevokedInfo(Asn1GeneralizedTime revocationTime)
    : this(revocationTime, (CrlReason) null)
  {
  }

  public RevokedInfo(Asn1GeneralizedTime revocationTime, CrlReason revocationReason)
  {
    this.revocationTime = revocationTime != null ? revocationTime : throw new ArgumentNullException(nameof (revocationTime));
    this.revocationReason = revocationReason;
  }

  private RevokedInfo(Asn1Sequence seq)
  {
    this.revocationTime = (Asn1GeneralizedTime) seq[0];
    if (seq.Count <= 1)
      return;
    this.revocationReason = new CrlReason(DerEnumerated.GetInstance((Asn1TaggedObject) seq[1], true));
  }

  public Asn1GeneralizedTime RevocationTime => this.revocationTime;

  public CrlReason RevocationReason => this.revocationReason;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) this.revocationTime);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.revocationReason);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
