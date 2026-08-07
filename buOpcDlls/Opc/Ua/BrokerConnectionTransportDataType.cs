// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrokerConnectionTransportDataType
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
public class BrokerConnectionTransportDataType : ConnectionTransportDataType
{
  private string m_resourceUri;
  private string m_authenticationProfileUri;

  public BrokerConnectionTransportDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_resourceUri = (string) null;
    this.m_authenticationProfileUri = (string) null;
  }

  [DataMember(Name = "ResourceUri", IsRequired = false, Order = 1)]
  public string ResourceUri
  {
    get => this.m_resourceUri;
    set => this.m_resourceUri = value;
  }

  [DataMember(Name = "AuthenticationProfileUri", IsRequired = false, Order = 2)]
  public string AuthenticationProfileUri
  {
    get => this.m_authenticationProfileUri;
    set => this.m_authenticationProfileUri = value;
  }

  public override ExpandedNodeId TypeId
  {
    get => (ExpandedNodeId) DataTypeIds.BrokerConnectionTransportDataType;
  }

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrokerConnectionTransportDataType_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrokerConnectionTransportDataType_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrokerConnectionTransportDataType_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("ResourceUri", this.ResourceUri);
    encoder.WriteString("AuthenticationProfileUri", this.AuthenticationProfileUri);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ResourceUri = decoder.ReadString("ResourceUri");
    this.AuthenticationProfileUri = decoder.ReadString("AuthenticationProfileUri");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is BrokerConnectionTransportDataType transportDataType && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_resourceUri, (object) transportDataType.m_resourceUri) && Utils.IsEqual((object) this.m_authenticationProfileUri, (object) transportDataType.m_authenticationProfileUri) && base.IsEqual(encodeable);
  }

  public override object Clone()
  {
    return (object) (BrokerConnectionTransportDataType) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    BrokerConnectionTransportDataType transportDataType = (BrokerConnectionTransportDataType) base.MemberwiseClone();
    transportDataType.m_resourceUri = (string) Utils.Clone((object) this.m_resourceUri);
    transportDataType.m_authenticationProfileUri = (string) Utils.Clone((object) this.m_authenticationProfileUri);
    return (object) transportDataType;
  }
}
