// Decompiled with JetBrains decompiler
// Type: Opc.Ua.MonitoredItemModifyRequest
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
public class MonitoredItemModifyRequest : IEncodeable, ICloneable, IJsonEncodeable
{
  private uint m_monitoredItemId;
  private MonitoringParameters m_requestedParameters;
  private object m_handle;
  private bool m_processed;

  public MonitoredItemModifyRequest() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_monitoredItemId = 0U;
    this.m_requestedParameters = new MonitoringParameters();
  }

  [DataMember(Name = "MonitoredItemId", IsRequired = false, Order = 1)]
  public uint MonitoredItemId
  {
    get => this.m_monitoredItemId;
    set => this.m_monitoredItemId = value;
  }

  [DataMember(Name = "RequestedParameters", IsRequired = false, Order = 2)]
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

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.MonitoredItemModifyRequest;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MonitoredItemModifyRequest_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MonitoredItemModifyRequest_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MonitoredItemModifyRequest_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("MonitoredItemId", this.MonitoredItemId);
    encoder.WriteEncodeable("RequestedParameters", (IEncodeable) this.RequestedParameters, typeof (MonitoringParameters));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.MonitoredItemId = decoder.ReadUInt32("MonitoredItemId");
    this.RequestedParameters = (MonitoringParameters) decoder.ReadEncodeable("RequestedParameters", typeof (MonitoringParameters));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is MonitoredItemModifyRequest itemModifyRequest && Utils.IsEqual((object) this.m_monitoredItemId, (object) itemModifyRequest.m_monitoredItemId) && Utils.IsEqual((object) this.m_requestedParameters, (object) itemModifyRequest.m_requestedParameters);
  }

  public virtual object Clone() => (object) (MonitoredItemModifyRequest) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    MonitoredItemModifyRequest itemModifyRequest = (MonitoredItemModifyRequest) base.MemberwiseClone();
    itemModifyRequest.m_monitoredItemId = (uint) Utils.Clone((object) this.m_monitoredItemId);
    itemModifyRequest.m_requestedParameters = (MonitoringParameters) Utils.Clone((object) this.m_requestedParameters);
    return (object) itemModifyRequest;
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
