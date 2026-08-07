// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ThreeDCartesianCoordinates
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
public class ThreeDCartesianCoordinates : CartesianCoordinates
{
  private double m_x;
  private double m_y;
  private double m_z;

  public ThreeDCartesianCoordinates() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_x = 0.0;
    this.m_y = 0.0;
    this.m_z = 0.0;
  }

  [DataMember(Name = "X", IsRequired = false, Order = 1)]
  public double X
  {
    get => this.m_x;
    set => this.m_x = value;
  }

  [DataMember(Name = "Y", IsRequired = false, Order = 2)]
  public double Y
  {
    get => this.m_y;
    set => this.m_y = value;
  }

  [DataMember(Name = "Z", IsRequired = false, Order = 3)]
  public double Z
  {
    get => this.m_z;
    set => this.m_z = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ThreeDCartesianCoordinates;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ThreeDCartesianCoordinates_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ThreeDCartesianCoordinates_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ThreeDCartesianCoordinates_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteDouble("X", this.X);
    encoder.WriteDouble("Y", this.Y);
    encoder.WriteDouble("Z", this.Z);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.X = decoder.ReadDouble("X");
    this.Y = decoder.ReadDouble("Y");
    this.Z = decoder.ReadDouble("Z");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is ThreeDCartesianCoordinates dcartesianCoordinates && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_x, (object) dcartesianCoordinates.m_x) && Utils.IsEqual((object) this.m_y, (object) dcartesianCoordinates.m_y) && Utils.IsEqual((object) this.m_z, (object) dcartesianCoordinates.m_z) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (ThreeDCartesianCoordinates) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ThreeDCartesianCoordinates dcartesianCoordinates = (ThreeDCartesianCoordinates) base.MemberwiseClone();
    dcartesianCoordinates.m_x = (double) Utils.Clone((object) this.m_x);
    dcartesianCoordinates.m_y = (double) Utils.Clone((object) this.m_y);
    dcartesianCoordinates.m_z = (double) Utils.Clone((object) this.m_z);
    return (object) dcartesianCoordinates;
  }
}
