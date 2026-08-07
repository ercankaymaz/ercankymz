// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReadProcessedDetails
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ReadProcessedDetails : HistoryReadDetails
{
  private DateTime m_startTime;
  private DateTime m_endTime;
  private double m_processingInterval;
  private NodeIdCollection m_aggregateType;
  private AggregateConfiguration m_aggregateConfiguration;

  public ReadProcessedDetails() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_startTime = DateTime.MinValue;
    this.m_endTime = DateTime.MinValue;
    this.m_processingInterval = 0.0;
    this.m_aggregateType = new NodeIdCollection();
    this.m_aggregateConfiguration = new AggregateConfiguration();
  }

  [DataMember(Name = "StartTime", IsRequired = false, Order = 1)]
  public DateTime StartTime
  {
    get => this.m_startTime;
    set => this.m_startTime = value;
  }

  [DataMember(Name = "EndTime", IsRequired = false, Order = 2)]
  public DateTime EndTime
  {
    get => this.m_endTime;
    set => this.m_endTime = value;
  }

  [DataMember(Name = "ProcessingInterval", IsRequired = false, Order = 3)]
  public double ProcessingInterval
  {
    get => this.m_processingInterval;
    set => this.m_processingInterval = value;
  }

  [DataMember(Name = "AggregateType", IsRequired = false, Order = 4)]
  public NodeIdCollection AggregateType
  {
    get => this.m_aggregateType;
    set
    {
      this.m_aggregateType = value;
      if (value != null)
        return;
      this.m_aggregateType = new NodeIdCollection();
    }
  }

  [DataMember(Name = "AggregateConfiguration", IsRequired = false, Order = 5)]
  public AggregateConfiguration AggregateConfiguration
  {
    get => this.m_aggregateConfiguration;
    set
    {
      this.m_aggregateConfiguration = value;
      if (value != null)
        return;
      this.m_aggregateConfiguration = new AggregateConfiguration();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ReadProcessedDetails;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadProcessedDetails_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadProcessedDetails_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadProcessedDetails_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteDateTime("StartTime", this.StartTime);
    encoder.WriteDateTime("EndTime", this.EndTime);
    encoder.WriteDouble("ProcessingInterval", this.ProcessingInterval);
    encoder.WriteNodeIdArray("AggregateType", (IList<NodeId>) this.AggregateType);
    encoder.WriteEncodeable("AggregateConfiguration", (IEncodeable) this.AggregateConfiguration, typeof (AggregateConfiguration));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.StartTime = decoder.ReadDateTime("StartTime");
    this.EndTime = decoder.ReadDateTime("EndTime");
    this.ProcessingInterval = decoder.ReadDouble("ProcessingInterval");
    this.AggregateType = decoder.ReadNodeIdArray("AggregateType");
    this.AggregateConfiguration = (AggregateConfiguration) decoder.ReadEncodeable("AggregateConfiguration", typeof (AggregateConfiguration));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is ReadProcessedDetails processedDetails && base.IsEqual(encodeable) && Utils.IsEqual(this.m_startTime, processedDetails.m_startTime) && Utils.IsEqual(this.m_endTime, processedDetails.m_endTime) && Utils.IsEqual((object) this.m_processingInterval, (object) processedDetails.m_processingInterval) && Utils.IsEqual((object) this.m_aggregateType, (object) processedDetails.m_aggregateType) && Utils.IsEqual((object) this.m_aggregateConfiguration, (object) processedDetails.m_aggregateConfiguration) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (ReadProcessedDetails) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ReadProcessedDetails processedDetails = (ReadProcessedDetails) base.MemberwiseClone();
    processedDetails.m_startTime = (DateTime) Utils.Clone((object) this.m_startTime);
    processedDetails.m_endTime = (DateTime) Utils.Clone((object) this.m_endTime);
    processedDetails.m_processingInterval = (double) Utils.Clone((object) this.m_processingInterval);
    processedDetails.m_aggregateType = (NodeIdCollection) Utils.Clone((object) this.m_aggregateType);
    processedDetails.m_aggregateConfiguration = (AggregateConfiguration) Utils.Clone((object) this.m_aggregateConfiguration);
    return (object) processedDetails;
  }
}
