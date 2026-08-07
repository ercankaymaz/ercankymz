// Decompiled with JetBrains decompiler
// Type: Opc.Ua.BrokerDataSetReaderTransportDataType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class BrokerDataSetReaderTransportDataType : DataSetReaderTransportDataType
{
  private string m_queueName;
  private string m_resourceUri;
  private string m_authenticationProfileUri;
  private BrokerTransportQualityOfService m_requestedDeliveryGuarantee;
  private string m_metaDataQueueName;

  public BrokerDataSetReaderTransportDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_queueName = (string) null;
    this.m_resourceUri = (string) null;
    this.m_authenticationProfileUri = (string) null;
    this.m_requestedDeliveryGuarantee = BrokerTransportQualityOfService.NotSpecified;
    this.m_metaDataQueueName = (string) null;
  }

  [DataMember(Name = "QueueName", IsRequired = false, Order = 1)]
  public string QueueName
  {
    get => this.m_queueName;
    set => this.m_queueName = value;
  }

  [DataMember(Name = "ResourceUri", IsRequired = false, Order = 2)]
  public string ResourceUri
  {
    get => this.m_resourceUri;
    set => this.m_resourceUri = value;
  }

  [DataMember(Name = "AuthenticationProfileUri", IsRequired = false, Order = 3)]
  public string AuthenticationProfileUri
  {
    get => this.m_authenticationProfileUri;
    set => this.m_authenticationProfileUri = value;
  }

  [DataMember(Name = "RequestedDeliveryGuarantee", IsRequired = false, Order = 4)]
  public BrokerTransportQualityOfService RequestedDeliveryGuarantee
  {
    get => this.m_requestedDeliveryGuarantee;
    set => this.m_requestedDeliveryGuarantee = value;
  }

  [DataMember(Name = "MetaDataQueueName", IsRequired = false, Order = 5)]
  public string MetaDataQueueName
  {
    get => this.m_metaDataQueueName;
    set => this.m_metaDataQueueName = value;
  }

  public override ExpandedNodeId TypeId
  {
    get => (ExpandedNodeId) DataTypeIds.BrokerDataSetReaderTransportDataType;
  }

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrokerDataSetReaderTransportDataType_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrokerDataSetReaderTransportDataType_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.BrokerDataSetReaderTransportDataType_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("QueueName", this.QueueName);
    encoder.WriteString("ResourceUri", this.ResourceUri);
    encoder.WriteString("AuthenticationProfileUri", this.AuthenticationProfileUri);
    encoder.WriteEnumerated("RequestedDeliveryGuarantee", (Enum) this.RequestedDeliveryGuarantee);
    encoder.WriteString("MetaDataQueueName", this.MetaDataQueueName);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.QueueName = decoder.ReadString("QueueName");
    this.ResourceUri = decoder.ReadString("ResourceUri");
    this.AuthenticationProfileUri = decoder.ReadString("AuthenticationProfileUri");
    this.RequestedDeliveryGuarantee = (BrokerTransportQualityOfService) decoder.ReadEnumerated("RequestedDeliveryGuarantee", typeof (BrokerTransportQualityOfService));
    this.MetaDataQueueName = decoder.ReadString("MetaDataQueueName");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is BrokerDataSetReaderTransportDataType transportDataType && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_queueName, (object) transportDataType.m_queueName) && Utils.IsEqual((object) this.m_resourceUri, (object) transportDataType.m_resourceUri) && Utils.IsEqual((object) this.m_authenticationProfileUri, (object) transportDataType.m_authenticationProfileUri) && Utils.IsEqual((object) this.m_requestedDeliveryGuarantee, (object) transportDataType.m_requestedDeliveryGuarantee) && Utils.IsEqual((object) this.m_metaDataQueueName, (object) transportDataType.m_metaDataQueueName) && base.IsEqual(encodeable);
  }

  public override object Clone()
  {
    return (object) (BrokerDataSetReaderTransportDataType) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    BrokerDataSetReaderTransportDataType transportDataType = (BrokerDataSetReaderTransportDataType) base.MemberwiseClone();
    transportDataType.m_queueName = (string) Utils.Clone((object) this.m_queueName);
    transportDataType.m_resourceUri = (string) Utils.Clone((object) this.m_resourceUri);
    transportDataType.m_authenticationProfileUri = (string) Utils.Clone((object) this.m_authenticationProfileUri);
    transportDataType.m_requestedDeliveryGuarantee = (BrokerTransportQualityOfService) Utils.Clone((object) this.m_requestedDeliveryGuarantee);
    transportDataType.m_metaDataQueueName = (string) Utils.Clone((object) this.m_metaDataQueueName);
    return (object) transportDataType;
  }
}
