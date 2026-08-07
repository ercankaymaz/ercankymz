// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.IssuingDistributionPoint
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class IssuingDistributionPoint : Asn1Encodable
{
  private readonly DistributionPointName _distributionPoint;
  private readonly bool _onlyContainsUserCerts;
  private readonly bool _onlyContainsCACerts;
  private readonly ReasonFlags _onlySomeReasons;
  private readonly bool _indirectCRL;
  private readonly bool _onlyContainsAttributeCerts;
  private readonly Asn1Sequence seq;

  public static IssuingDistributionPoint GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return IssuingDistributionPoint.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static IssuingDistributionPoint GetInstance(object obj)
  {
    if (obj == null)
      return (IssuingDistributionPoint) null;
    return obj is IssuingDistributionPoint distributionPoint ? distributionPoint : new IssuingDistributionPoint(Asn1Sequence.GetInstance(obj));
  }

  public IssuingDistributionPoint(
    DistributionPointName distributionPoint,
    bool onlyContainsUserCerts,
    bool onlyContainsCACerts,
    ReasonFlags onlySomeReasons,
    bool indirectCRL,
    bool onlyContainsAttributeCerts)
  {
    this._distributionPoint = distributionPoint;
    this._indirectCRL = indirectCRL;
    this._onlyContainsAttributeCerts = onlyContainsAttributeCerts;
    this._onlyContainsCACerts = onlyContainsCACerts;
    this._onlyContainsUserCerts = onlyContainsUserCerts;
    this._onlySomeReasons = onlySomeReasons;
    Asn1EncodableVector elementVector = new Asn1EncodableVector(6);
    if (distributionPoint != null)
      elementVector.Add((Asn1Encodable) new DerTaggedObject(true, 0, (Asn1Encodable) distributionPoint));
    if (onlyContainsUserCerts)
      elementVector.Add((Asn1Encodable) new DerTaggedObject(false, 1, (Asn1Encodable) DerBoolean.True));
    if (onlyContainsCACerts)
      elementVector.Add((Asn1Encodable) new DerTaggedObject(false, 2, (Asn1Encodable) DerBoolean.True));
    if (onlySomeReasons != null)
      elementVector.Add((Asn1Encodable) new DerTaggedObject(false, 3, (Asn1Encodable) onlySomeReasons));
    if (indirectCRL)
      elementVector.Add((Asn1Encodable) new DerTaggedObject(false, 4, (Asn1Encodable) DerBoolean.True));
    if (onlyContainsAttributeCerts)
      elementVector.Add((Asn1Encodable) new DerTaggedObject(false, 5, (Asn1Encodable) DerBoolean.True));
    this.seq = (Asn1Sequence) new DerSequence(elementVector);
  }

  private IssuingDistributionPoint(Asn1Sequence seq)
  {
    this.seq = seq;
    for (int index = 0; index != seq.Count; ++index)
    {
      Asn1TaggedObject instance = Asn1TaggedObject.GetInstance((object) seq[index]);
      switch (instance.TagNo)
      {
        case 0:
          this._distributionPoint = DistributionPointName.GetInstance(instance, true);
          break;
        case 1:
          this._onlyContainsUserCerts = DerBoolean.GetInstance(instance, false).IsTrue;
          break;
        case 2:
          this._onlyContainsCACerts = DerBoolean.GetInstance(instance, false).IsTrue;
          break;
        case 3:
          this._onlySomeReasons = new ReasonFlags(DerBitString.GetInstance(instance, false));
          break;
        case 4:
          this._indirectCRL = DerBoolean.GetInstance(instance, false).IsTrue;
          break;
        case 5:
          this._onlyContainsAttributeCerts = DerBoolean.GetInstance(instance, false).IsTrue;
          break;
        default:
          throw new ArgumentException("unknown tag in IssuingDistributionPoint");
      }
    }
  }

  public bool OnlyContainsUserCerts => this._onlyContainsUserCerts;

  public bool OnlyContainsCACerts => this._onlyContainsCACerts;

  public bool IsIndirectCrl => this._indirectCRL;

  public bool OnlyContainsAttributeCerts => this._onlyContainsAttributeCerts;

  public DistributionPointName DistributionPoint => this._distributionPoint;

  public ReasonFlags OnlySomeReasons => this._onlySomeReasons;

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.seq;

  public override string ToString()
  {
    StringBuilder buf = new StringBuilder();
    buf.AppendLine("IssuingDistributionPoint: [");
    if (this._distributionPoint != null)
      this.AppendObject(buf, "distributionPoint", this._distributionPoint.ToString());
    if (this._onlyContainsUserCerts)
      this.AppendObject(buf, "onlyContainsUserCerts", this._onlyContainsUserCerts.ToString());
    if (this._onlyContainsCACerts)
      this.AppendObject(buf, "onlyContainsCACerts", this._onlyContainsCACerts.ToString());
    if (this._onlySomeReasons != null)
      this.AppendObject(buf, "onlySomeReasons", this._onlySomeReasons.ToString());
    if (this._onlyContainsAttributeCerts)
      this.AppendObject(buf, "onlyContainsAttributeCerts", this._onlyContainsAttributeCerts.ToString());
    if (this._indirectCRL)
      this.AppendObject(buf, "indirectCRL", this._indirectCRL.ToString());
    buf.AppendLine("]");
    return buf.ToString();
  }

  private void AppendObject(StringBuilder buf, string name, string val)
  {
    string str = "    ";
    buf.Append(str);
    buf.Append(name);
    buf.AppendLine(":");
    buf.Append(str);
    buf.Append(str);
    buf.Append(val);
    buf.AppendLine();
  }
}
