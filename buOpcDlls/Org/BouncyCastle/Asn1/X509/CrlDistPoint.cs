// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.CrlDistPoint
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Text;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class CrlDistPoint : Asn1Encodable
{
  internal readonly Asn1Sequence seq;

  public static CrlDistPoint GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return CrlDistPoint.GetInstance((object) Asn1Sequence.GetInstance(obj, explicitly));
  }

  public static CrlDistPoint GetInstance(object obj)
  {
    if (obj is CrlDistPoint)
      return (CrlDistPoint) obj;
    return obj == null ? (CrlDistPoint) null : new CrlDistPoint(Asn1Sequence.GetInstance(obj));
  }

  public static CrlDistPoint FromExtensions(X509Extensions extensions)
  {
    return CrlDistPoint.GetInstance((object) X509Extensions.GetExtensionParsedValue(extensions, X509Extensions.CrlDistributionPoints));
  }

  private CrlDistPoint(Asn1Sequence seq) => this.seq = seq;

  public CrlDistPoint(DistributionPoint[] points)
  {
    this.seq = (Asn1Sequence) new DerSequence((Asn1Encodable[]) points);
  }

  public DistributionPoint[] GetDistributionPoints()
  {
    DistributionPoint[] distributionPoints = new DistributionPoint[this.seq.Count];
    for (int index = 0; index != this.seq.Count; ++index)
      distributionPoints[index] = DistributionPoint.GetInstance((object) this.seq[index]);
    return distributionPoints;
  }

  public override Asn1Object ToAsn1Object() => (Asn1Object) this.seq;

  public override string ToString()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.AppendLine("CRLDistPoint:");
    foreach (DistributionPoint distributionPoint in this.GetDistributionPoints())
      stringBuilder.Append("    ").Append((object) distributionPoint).AppendLine();
    return stringBuilder.ToString();
  }
}
