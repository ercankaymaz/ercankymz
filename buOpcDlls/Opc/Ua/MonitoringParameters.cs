// Decompiled with JetBrains decompiler
// Type: Opc.Ua.MonitoringParameters
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
public class MonitoringParameters : IEncodeable, ICloneable, IJsonEncodeable
{
  private uint m_clientHandle;
  private double m_samplingInterval;
  private ExtensionObject m_filter;
  private uint m_queueSize;
  private bool m_discardOldest;

  public MonitoringParameters() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_clientHandle = 0U;
    this.m_samplingInterval = 0.0;
    this.m_filter = (ExtensionObject) null;
    this.m_queueSize = 0U;
    this.m_discardOldest = true;
  }

  [DataMember(Name = "ClientHandle", IsRequired = false, Order = 1)]
  public uint ClientHandle
  {
    get => this.m_clientHandle;
    set => this.m_clientHandle = value;
  }

  [DataMember(Name = "SamplingInterval", IsRequired = false, Order = 2)]
  public double SamplingInterval
  {
    get => this.m_samplingInterval;
    set => this.m_samplingInterval = value;
  }

  [DataMember(Name = "Filter", IsRequired = false, Order = 3)]
  public ExtensionObject Filter
  {
    get => this.m_filter;
    set => this.m_filter = value;
  }

  [DataMember(Name = "QueueSize", IsRequired = false, Order = 4)]
  public uint QueueSize
  {
    get => this.m_queueSize;
    set => this.m_queueSize = value;
  }

  [DataMember(Name = "DiscardOldest", IsRequired = false, Order = 5)]
  public bool DiscardOldest
  {
    get => this.m_discardOldest;
    set => this.m_discardOldest = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.MonitoringParameters;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MonitoringParameters_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MonitoringParameters_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MonitoringParameters_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("ClientHandle", this.ClientHandle);
    encoder.WriteDouble("SamplingInterval", this.SamplingInterval);
    encoder.WriteExtensionObject("Filter", this.Filter);
    encoder.WriteUInt32("QueueSize", this.QueueSize);
    encoder.WriteBoolean("DiscardOldest", this.DiscardOldest);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ClientHandle = decoder.ReadUInt32("ClientHandle");
    this.SamplingInterval = decoder.ReadDouble("SamplingInterval");
    this.Filter = decoder.ReadExtensionObject("Filter");
    this.QueueSize = decoder.ReadUInt32("QueueSize");
    this.DiscardOldest = decoder.ReadBoolean("DiscardOldest");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is MonitoringParameters monitoringParameters && Utils.IsEqual((object) this.m_clientHandle, (object) monitoringParameters.m_clientHandle) && Utils.IsEqual((object) this.m_samplingInterval, (object) monitoringParameters.m_samplingInterval) && Utils.IsEqual((object) this.m_filter, (object) monitoringParameters.m_filter) && Utils.IsEqual((object) this.m_queueSize, (object) monitoringParameters.m_queueSize) && Utils.IsEqual((object) this.m_discardOldest, (object) monitoringParameters.m_discardOldest);
  }

  public virtual object Clone() => (object) (MonitoringParameters) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    MonitoringParameters monitoringParameters = (MonitoringParameters) base.MemberwiseClone();
    monitoringParameters.m_clientHandle = (uint) Utils.Clone((object) this.m_clientHandle);
    monitoringParameters.m_samplingInterval = (double) Utils.Clone((object) this.m_samplingInterval);
    monitoringParameters.m_filter = (ExtensionObject) Utils.Clone((object) this.m_filter);
    monitoringParameters.m_queueSize = (uint) Utils.Clone((object) this.m_queueSize);
    monitoringParameters.m_discardOldest = (bool) Utils.Clone((object) this.m_discardOldest);
    return (object) monitoringParameters;
  }
}
