// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SamplingIntervalDiagnosticsDataType
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
public class SamplingIntervalDiagnosticsDataType : IEncodeable, ICloneable, IJsonEncodeable
{
  private double m_samplingInterval;
  private uint m_monitoredItemCount;
  private uint m_maxMonitoredItemCount;
  private uint m_disabledMonitoredItemCount;

  public SamplingIntervalDiagnosticsDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_samplingInterval = 0.0;
    this.m_monitoredItemCount = 0U;
    this.m_maxMonitoredItemCount = 0U;
    this.m_disabledMonitoredItemCount = 0U;
  }

  [DataMember(Name = "SamplingInterval", IsRequired = false, Order = 1)]
  public double SamplingInterval
  {
    get => this.m_samplingInterval;
    set => this.m_samplingInterval = value;
  }

  [DataMember(Name = "MonitoredItemCount", IsRequired = false, Order = 2)]
  public uint MonitoredItemCount
  {
    get => this.m_monitoredItemCount;
    set => this.m_monitoredItemCount = value;
  }

  [DataMember(Name = "MaxMonitoredItemCount", IsRequired = false, Order = 3)]
  public uint MaxMonitoredItemCount
  {
    get => this.m_maxMonitoredItemCount;
    set => this.m_maxMonitoredItemCount = value;
  }

  [DataMember(Name = "DisabledMonitoredItemCount", IsRequired = false, Order = 4)]
  public uint DisabledMonitoredItemCount
  {
    get => this.m_disabledMonitoredItemCount;
    set => this.m_disabledMonitoredItemCount = value;
  }

  public virtual ExpandedNodeId TypeId
  {
    get => (ExpandedNodeId) DataTypeIds.SamplingIntervalDiagnosticsDataType;
  }

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SamplingIntervalDiagnosticsDataType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SamplingIntervalDiagnosticsDataType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SamplingIntervalDiagnosticsDataType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteDouble("SamplingInterval", this.SamplingInterval);
    encoder.WriteUInt32("MonitoredItemCount", this.MonitoredItemCount);
    encoder.WriteUInt32("MaxMonitoredItemCount", this.MaxMonitoredItemCount);
    encoder.WriteUInt32("DisabledMonitoredItemCount", this.DisabledMonitoredItemCount);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.SamplingInterval = decoder.ReadDouble("SamplingInterval");
    this.MonitoredItemCount = decoder.ReadUInt32("MonitoredItemCount");
    this.MaxMonitoredItemCount = decoder.ReadUInt32("MaxMonitoredItemCount");
    this.DisabledMonitoredItemCount = decoder.ReadUInt32("DisabledMonitoredItemCount");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is SamplingIntervalDiagnosticsDataType diagnosticsDataType && Utils.IsEqual((object) this.m_samplingInterval, (object) diagnosticsDataType.m_samplingInterval) && Utils.IsEqual((object) this.m_monitoredItemCount, (object) diagnosticsDataType.m_monitoredItemCount) && Utils.IsEqual((object) this.m_maxMonitoredItemCount, (object) diagnosticsDataType.m_maxMonitoredItemCount) && Utils.IsEqual((object) this.m_disabledMonitoredItemCount, (object) diagnosticsDataType.m_disabledMonitoredItemCount);
  }

  public virtual object Clone()
  {
    return (object) (SamplingIntervalDiagnosticsDataType) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    SamplingIntervalDiagnosticsDataType diagnosticsDataType = (SamplingIntervalDiagnosticsDataType) base.MemberwiseClone();
    diagnosticsDataType.m_samplingInterval = (double) Utils.Clone((object) this.m_samplingInterval);
    diagnosticsDataType.m_monitoredItemCount = (uint) Utils.Clone((object) this.m_monitoredItemCount);
    diagnosticsDataType.m_maxMonitoredItemCount = (uint) Utils.Clone((object) this.m_maxMonitoredItemCount);
    diagnosticsDataType.m_disabledMonitoredItemCount = (uint) Utils.Clone((object) this.m_disabledMonitoredItemCount);
    return (object) diagnosticsDataType;
  }
}
