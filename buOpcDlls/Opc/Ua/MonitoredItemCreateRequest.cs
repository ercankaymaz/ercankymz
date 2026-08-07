// Decompiled with JetBrains decompiler
// Type: Opc.Ua.MonitoredItemCreateRequest
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
public class MonitoredItemCreateRequest : IEncodeable, ICloneable, IJsonEncodeable
{
  private ReadValueId m_itemToMonitor;
  private MonitoringMode m_monitoringMode;
  private MonitoringParameters m_requestedParameters;
  private object m_handle;
  private bool m_processed;

  public MonitoredItemCreateRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_itemToMonitor = new ReadValueId();
    this.m_monitoringMode = MonitoringMode.Disabled;
    this.m_requestedParameters = new MonitoringParameters();
  }

  [DataMember(Name = "ItemToMonitor", IsRequired = false, Order = 1)]
  public ReadValueId ItemToMonitor
  {
    get => this.m_itemToMonitor;
    set
    {
      this.m_itemToMonitor = value;
      if (value != null)
        return;
      this.m_itemToMonitor = new ReadValueId();
    }
  }

  [DataMember(Name = "MonitoringMode", IsRequired = false, Order = 2)]
  public MonitoringMode MonitoringMode
  {
    get => this.m_monitoringMode;
    set => this.m_monitoringMode = value;
  }

  [DataMember(Name = "RequestedParameters", IsRequired = false, Order = 3)]
  public MonitoringParameters RequestedParameters
  {
    get => this.m_requestedParameters;
    set
    {
      this.m_requestedParameters = value;
      if (value != null)
        return;
      this.m_requestedParameters = new MonitoringParameters();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.MonitoredItemCreateRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MonitoredItemCreateRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MonitoredItemCreateRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MonitoredItemCreateRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("ItemToMonitor", (IEncodeable) this.ItemToMonitor, typeof (ReadValueId));
    encoder.WriteEnumerated("MonitoringMode", (Enum) this.MonitoringMode);
    encoder.WriteEncodeable("RequestedParameters", (IEncodeable) this.RequestedParameters, typeof (MonitoringParameters));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ItemToMonitor = (ReadValueId) decoder.ReadEncodeable("ItemToMonitor", typeof (ReadValueId));
    this.MonitoringMode = (MonitoringMode) decoder.ReadEnumerated("MonitoringMode", typeof (MonitoringMode));
    this.RequestedParameters = (MonitoringParameters) decoder.ReadEncodeable("RequestedParameters", typeof (MonitoringParameters));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is MonitoredItemCreateRequest itemCreateRequest && Utils.IsEqual((object) this.m_itemToMonitor, (object) itemCreateRequest.m_itemToMonitor) && Utils.IsEqual((object) this.m_monitoringMode, (object) itemCreateRequest.m_monitoringMode) && Utils.IsEqual((object) this.m_requestedParameters, (object) itemCreateRequest.m_requestedParameters);
  }

  public virtual object Clone() => (object) (MonitoredItemCreateRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    MonitoredItemCreateRequest itemCreateRequest = (MonitoredItemCreateRequest) base.MemberwiseClone();
    itemCreateRequest.m_itemToMonitor = (ReadValueId) Utils.Clone((object) this.m_itemToMonitor);
    itemCreateRequest.m_monitoringMode = (MonitoringMode) Utils.Clone((object) this.m_monitoringMode);
    itemCreateRequest.m_requestedParameters = (MonitoringParameters) Utils.Clone((object) this.m_requestedParameters);
    return (object) itemCreateRequest;
  }

  public object Handle
  {
    get => this.m_handle;
    set => this.m_handle = value;
  }

  public bool Processed
  {
    get => this.m_processed;
    set => this.m_processed = value;
  }
}
