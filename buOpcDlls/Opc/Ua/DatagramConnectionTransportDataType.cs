// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DatagramConnectionTransportDataType
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
public class DatagramConnectionTransportDataType : ConnectionTransportDataType
{
  private ExtensionObject m_discoveryAddress;

  public DatagramConnectionTransportDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_discoveryAddress = (ExtensionObject) null;

  [DataMember(Name = "DiscoveryAddress", IsRequired = false, Order = 1)]
  public ExtensionObject DiscoveryAddress
  {
    get => this.m_discoveryAddress;
    set => this.m_discoveryAddress = value;
  }

  public override ExpandedNodeId TypeId
  {
    get => (ExpandedNodeId) DataTypeIds.DatagramConnectionTransportDataType;
  }

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DatagramConnectionTransportDataType_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DatagramConnectionTransportDataType_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DatagramConnectionTransportDataType_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteExtensionObject("DiscoveryAddress", this.DiscoveryAddress);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.DiscoveryAddress = decoder.ReadExtensionObject("DiscoveryAddress");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is DatagramConnectionTransportDataType transportDataType && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_discoveryAddress, (object) transportDataType.m_discoveryAddress) && base.IsEqual(encodeable);
  }

  public override object Clone()
  {
    return (object) (DatagramConnectionTransportDataType) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    DatagramConnectionTransportDataType transportDataType = (DatagramConnectionTransportDataType) base.MemberwiseClone();
    transportDataType.m_discoveryAddress = (ExtensionObject) Utils.Clone((object) this.m_discoveryAddress);
    return (object) transportDataType;
  }
}
