// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.DistributionPoint
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Text;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class DistributionPoint : Asn1Encodable
{
  private readonly DistributionPointName m_distributionPoint;
  private readonly ReasonFlags m_reasons;
  private readonly GeneralNames m_crlIssuer;

  public static DistributionPoint GetInstance(object obj)
  {
    if (obj == null)
      return (DistributionPoint) null;
    return obj is DistributionPoint distributionPoint ? distributionPoint : new DistributionPoint(Asn1Sequence.GetInstance(obj));
  }

  public static DistributionPoint GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return DistributionPoint.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  private DistributionPoint(Asn1Sequence seq)
  {
    for (int index = 0; index != seq.Count; ++index)
    {
      Asn1TaggedObject instance = Asn1TaggedObject.GetInstance((object) seq[index]);
      switch (instance.TagNo)
      {
        case 0:
          this.m_distributionPoint = DistributionPointName.GetInstance(instance, true);
          break;
        case 1:
          this.m_reasons = new ReasonFlags(DerBitString.GetInstance(instance, false));
          break;
        case 2:
          this.m_crlIssuer = GeneralNames.GetInstance(instance, false);
          break;
      }
    }
  }

  public DistributionPoint(
    DistributionPointName distributionPointName,
    ReasonFlags reasons,
    GeneralNames crlIssuer)
  {
    this.m_distributionPoint = distributionPointName;
    this.m_reasons = reasons;
    this.m_crlIssuer = crlIssuer;
  }

  public DistributionPointName DistributionPointName => this.m_distributionPoint;

  public ReasonFlags Reasons => this.m_reasons;

  public GeneralNames CrlIssuer => this.m_crlIssuer;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(3);
    elementVector.AddOptionalTagged(true, 0, (Asn1Encodable) this.m_distributionPoint);
    elementVector.AddOptionalTagged(false, 1, (Asn1Encodable) this.m_reasons);
    elementVector.AddOptionalTagged(false, 2, (Asn1Encodable) this.m_crlIssuer);
    return (Asn1Object) new DerSequence(elementVector);
  }

  public override string ToString()
  {
    StringBuilder buf = new StringBuilder();
    buf.AppendLine("DistributionPoint: [");
    if (this.m_distributionPoint != null)
      this.AppendObject(buf, "distributionPoint", this.m_distributionPoint.ToString());
    if (this.m_reasons != null)
      this.AppendObject(buf, "reasons", this.m_reasons.ToString());
    if (this.m_crlIssuer != null)
      this.AppendObject(buf, "cRLIssuer", this.m_crlIssuer.ToString());
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
