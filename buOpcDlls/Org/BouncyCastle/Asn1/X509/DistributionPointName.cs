// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.DistributionPointName
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class DistributionPointName : Asn1Encodable, IAsn1Choice
{
  public const int FullName = 0;
  public const int NameRelativeToCrlIssuer = 1;
  private readonly int m_type;
  private readonly Asn1Encodable m_name;

  public static DistributionPointName GetInstance(object obj)
  {
    if (obj == null)
      return (DistributionPointName) null;
    return obj is DistributionPointName distributionPointName ? distributionPointName : new DistributionPointName(Asn1TaggedObject.GetInstance(obj));
  }

  public static DistributionPointName GetInstance(Asn1TaggedObject obj, bool explicitly)
  {
    return Asn1Utilities.GetInstanceFromChoice<DistributionPointName>(obj, explicitly, new Func<object, DistributionPointName>(DistributionPointName.GetInstance));
  }

  public DistributionPointName(GeneralNames name)
    : this(0, (Asn1Encodable) name)
  {
  }

  public DistributionPointName(int type, Asn1Encodable name)
  {
    this.m_type = type;
    this.m_name = name;
  }

  [Obsolete("Use 'Type' instead")]
  public int PointType => this.m_type;

  public Asn1Encodable Name => this.m_name;

  public int Type => this.m_type;

  public DistributionPointName(Asn1TaggedObject obj)
  {
    this.m_type = obj.TagNo;
    if (this.m_type == 0)
      this.m_name = (Asn1Encodable) GeneralNames.GetInstance(obj, false);
    else
      this.m_name = (Asn1Encodable) Asn1Set.GetInstance(obj, false);
  }

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerTaggedObject(false, this.m_type, this.m_name);
  }

  public override string ToString()
  {
    StringBuilder buf = new StringBuilder();
    buf.AppendLine("DistributionPointName: [");
    if (this.m_type == 0)
      this.AppendObject(buf, "fullName", this.m_name.ToString());
    else
      this.AppendObject(buf, "nameRelativeToCRLIssuer", this.m_name.ToString());
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
