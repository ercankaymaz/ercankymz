// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ThreeDFrame
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
public class ThreeDFrame : Frame
{
  private ThreeDCartesianCoordinates m_cartesianCoordinates;
  private ThreeDOrientation m_orientation;

  public ThreeDFrame() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_cartesianCoordinates = new ThreeDCartesianCoordinates();
    this.m_orientation = new ThreeDOrientation();
  }

  [DataMember(Name = "CartesianCoordinates", IsRequired = false, Order = 1)]
  public ThreeDCartesianCoordinates CartesianCoordinates
  {
    get => this.m_cartesianCoordinates;
    set
    {
      this.m_cartesianCoordinates = value;
      if (value != null)
        return;
      this.m_cartesianCoordinates = new ThreeDCartesianCoordinates();
    }
  }

  [DataMember(Name = "Orientation", IsRequired = false, Order = 2)]
  public ThreeDOrientation Orientation
  {
    get => this.m_orientation;
    set
    {
      this.m_orientation = value;
      if (value != null)
        return;
      this.m_orientation = new ThreeDOrientation();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ThreeDFrame;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ThreeDFrame_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ThreeDFrame_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ThreeDFrame_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("CartesianCoordinates", (IEncodeable) this.CartesianCoordinates, typeof (ThreeDCartesianCoordinates));
    encoder.WriteEncodeable("Orientation", (IEncodeable) this.Orientation, typeof (ThreeDOrientation));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.CartesianCoordinates = (ThreeDCartesianCoordinates) decoder.ReadEncodeable("CartesianCoordinates", typeof (ThreeDCartesianCoordinates));
    this.Orientation = (ThreeDOrientation) decoder.ReadEncodeable("Orientation", typeof (ThreeDOrientation));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is ThreeDFrame threeDframe && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_cartesianCoordinates, (object) threeDframe.m_cartesianCoordinates) && Utils.IsEqual((object) this.m_orientation, (object) threeDframe.m_orientation) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (ThreeDFrame) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ThreeDFrame threeDframe = (ThreeDFrame) base.MemberwiseClone();
    threeDframe.m_cartesianCoordinates = (ThreeDCartesianCoordinates) Utils.Clone((object) this.m_cartesianCoordinates);
    threeDframe.m_orientation = (ThreeDOrientation) Utils.Clone((object) this.m_orientation);
    return (object) threeDframe;
  }
}
