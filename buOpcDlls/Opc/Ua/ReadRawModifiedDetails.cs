// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReadRawModifiedDetails
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
public class ReadRawModifiedDetails : HistoryReadDetails
{
  private bool m_isReadModified;
  private DateTime m_startTime;
  private DateTime m_endTime;
  private uint m_numValuesPerNode;
  private bool m_returnBounds;

  public ReadRawModifiedDetails() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_isReadModified = true;
    this.m_startTime = DateTime.MinValue;
    this.m_endTime = DateTime.MinValue;
    this.m_numValuesPerNode = 0U;
    this.m_returnBounds = true;
  }

  [DataMember(Name = "IsReadModified", IsRequired = false, Order = 1)]
  public bool IsReadModified
  {
    get => this.m_isReadModified;
    set => this.m_isReadModified = value;
  }

  [DataMember(Name = "StartTime", IsRequired = false, Order = 2)]
  public DateTime StartTime
  {
    get => this.m_startTime;
    set => this.m_startTime = value;
  }

  [DataMember(Name = "EndTime", IsRequired = false, Order = 3)]
  public DateTime EndTime
  {
    get => this.m_endTime;
    set => this.m_endTime = value;
  }

  [DataMember(Name = "NumValuesPerNode", IsRequired = false, Order = 4)]
  public uint NumValuesPerNode
  {
    get => this.m_numValuesPerNode;
    set => this.m_numValuesPerNode = value;
  }

  [DataMember(Name = "ReturnBounds", IsRequired = false, Order = 5)]
  public bool ReturnBounds
  {
    get => this.m_returnBounds;
    set => this.m_returnBounds = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ReadRawModifiedDetails;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadRawModifiedDetails_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadRawModifiedDetails_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReadRawModifiedDetails_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteBoolean("IsReadModified", this.IsReadModified);
    encoder.WriteDateTime("StartTime", this.StartTime);
    encoder.WriteDateTime("EndTime", this.EndTime);
    encoder.WriteUInt32("NumValuesPerNode", this.NumValuesPerNode);
    encoder.WriteBoolean("ReturnBounds", this.ReturnBounds);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.IsReadModified = decoder.ReadBoolean("IsReadModified");
    this.StartTime = decoder.ReadDateTime("StartTime");
    this.EndTime = decoder.ReadDateTime("EndTime");
    this.NumValuesPerNode = decoder.ReadUInt32("NumValuesPerNode");
    this.ReturnBounds = decoder.ReadBoolean("ReturnBounds");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is ReadRawModifiedDetails rawModifiedDetails && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_isReadModified, (object) rawModifiedDetails.m_isReadModified) && Utils.IsEqual(this.m_startTime, rawModifiedDetails.m_startTime) && Utils.IsEqual(this.m_endTime, rawModifiedDetails.m_endTime) && Utils.IsEqual((object) this.m_numValuesPerNode, (object) rawModifiedDetails.m_numValuesPerNode) && Utils.IsEqual((object) this.m_returnBounds, (object) rawModifiedDetails.m_returnBounds) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (ReadRawModifiedDetails) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ReadRawModifiedDetails rawModifiedDetails = (ReadRawModifiedDetails) base.MemberwiseClone();
    rawModifiedDetails.m_isReadModified = (bool) Utils.Clone((object) this.m_isReadModified);
    rawModifiedDetails.m_startTime = (DateTime) Utils.Clone((object) this.m_startTime);
    rawModifiedDetails.m_endTime = (DateTime) Utils.Clone((object) this.m_endTime);
    rawModifiedDetails.m_numValuesPerNode = (uint) Utils.Clone((object) this.m_numValuesPerNode);
    rawModifiedDetails.m_returnBounds = (bool) Utils.Clone((object) this.m_returnBounds);
    return (object) rawModifiedDetails;
  }
}
