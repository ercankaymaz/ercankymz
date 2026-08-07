// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ThreeDOrientation
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ThreeDOrientation : Orientation
{
  private double m_a;
  private double m_b;
  private double m_c;

  public ThreeDOrientation() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_a = 0.0;
    this.m_b = 0.0;
    this.m_c = 0.0;
  }

  [DataMember(Name = "A", IsRequired = false, Order = 1)]
  public double A
  {
    get => this.m_a;
    set => this.m_a = value;
  }

  [DataMember(Name = "B", IsRequired = false, Order = 2)]
  public double B
  {
    get => this.m_b;
    set => this.m_b = value;
  }

  [DataMember(Name = "C", IsRequired = false, Order = 3)]
  public double C
  {
    get => this.m_c;
    set => this.m_c = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ThreeDOrientation;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ThreeDOrientation_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ThreeDOrientation_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ThreeDOrientation_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteDouble("A", this.A);
    encoder.WriteDouble("B", this.B);
    encoder.WriteDouble("C", this.C);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.A = decoder.ReadDouble("A");
    this.B = decoder.ReadDouble("B");
    this.C = decoder.ReadDouble("C");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is ThreeDOrientation threeDorientation && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_a, (object) threeDorientation.m_a) && Utils.IsEqual((object) this.m_b, (object) threeDorientation.m_b) && Utils.IsEqual((object) this.m_c, (object) threeDorientation.m_c) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (ThreeDOrientation) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ThreeDOrientation threeDorientation = (ThreeDOrientation) base.MemberwiseClone();
    threeDorientation.m_a = (double) Utils.Clone((object) this.m_a);
    threeDorientation.m_b = (double) Utils.Clone((object) this.m_b);
    threeDorientation.m_c = (double) Utils.Clone((object) this.m_c);
    return (object) threeDorientation;
  }
}
