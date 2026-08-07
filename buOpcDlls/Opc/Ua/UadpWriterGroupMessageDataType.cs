// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UadpWriterGroupMessageDataType
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
public class UadpWriterGroupMessageDataType : WriterGroupMessageDataType
{
  private uint m_groupVersion;
  private DataSetOrderingType m_dataSetOrdering;
  private uint m_networkMessageContentMask;
  private double m_samplingOffset;
  private DoubleCollection m_publishingOffset;

  public UadpWriterGroupMessageDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_groupVersion = 0U;
    this.m_dataSetOrdering = DataSetOrderingType.Undefined;
    this.m_networkMessageContentMask = 0U;
    this.m_samplingOffset = 0.0;
    this.m_publishingOffset = new DoubleCollection();
  }

  [DataMember(Name = "GroupVersion", IsRequired = false, Order = 1)]
  public uint GroupVersion
  {
    get => this.m_groupVersion;
    set => this.m_groupVersion = value;
  }

  [DataMember(Name = "DataSetOrdering", IsRequired = false, Order = 2)]
  public DataSetOrderingType DataSetOrdering
  {
    get => this.m_dataSetOrdering;
    set => this.m_dataSetOrdering = value;
  }

  [DataMember(Name = "NetworkMessageContentMask", IsRequired = false, Order = 3)]
  public uint NetworkMessageContentMask
  {
    get => this.m_networkMessageContentMask;
    set => this.m_networkMessageContentMask = value;
  }

  [DataMember(Name = "SamplingOffset", IsRequired = false, Order = 4)]
  public double SamplingOffset
  {
    get => this.m_samplingOffset;
    set => this.m_samplingOffset = value;
  }

  [DataMember(Name = "PublishingOffset", IsRequired = false, Order = 5)]
  public DoubleCollection PublishingOffset
  {
    get => this.m_publishingOffset;
    set
    {
      this.m_publishingOffset = value;
      if (value != null)
        return;
      this.m_publishingOffset = new DoubleCollection();
    }
  }

  public override ExpandedNodeId TypeId
  {
    get => (ExpandedNodeId) DataTypeIds.UadpWriterGroupMessageDataType;
  }

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UadpWriterGroupMessageDataType_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UadpWriterGroupMessageDataType_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UadpWriterGroupMessageDataType_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("GroupVersion", this.GroupVersion);
    encoder.WriteEnumerated("DataSetOrdering", (Enum) this.DataSetOrdering);
    encoder.WriteUInt32("NetworkMessageContentMask", this.NetworkMessageContentMask);
    encoder.WriteDouble("SamplingOffset", this.SamplingOffset);
    encoder.WriteDoubleArray("PublishingOffset", (IList<double>) this.PublishingOffset);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.GroupVersion = decoder.ReadUInt32("GroupVersion");
    this.DataSetOrdering = (DataSetOrderingType) decoder.ReadEnumerated("DataSetOrdering", typeof (DataSetOrderingType));
    this.NetworkMessageContentMask = decoder.ReadUInt32("NetworkMessageContentMask");
    this.SamplingOffset = decoder.ReadDouble("SamplingOffset");
    this.PublishingOffset = decoder.ReadDoubleArray("PublishingOffset");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is UadpWriterGroupMessageDataType groupMessageDataType && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_groupVersion, (object) groupMessageDataType.m_groupVersion) && Utils.IsEqual((object) this.m_dataSetOrdering, (object) groupMessageDataType.m_dataSetOrdering) && Utils.IsEqual((object) this.m_networkMessageContentMask, (object) groupMessageDataType.m_networkMessageContentMask) && Utils.IsEqual((object) this.m_samplingOffset, (object) groupMessageDataType.m_samplingOffset) && Utils.IsEqual((object) this.m_publishingOffset, (object) groupMessageDataType.m_publishingOffset) && base.IsEqual(encodeable);
  }

  public override object Clone()
  {
    return (object) (UadpWriterGroupMessageDataType) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    UadpWriterGroupMessageDataType groupMessageDataType = (UadpWriterGroupMessageDataType) base.MemberwiseClone();
    groupMessageDataType.m_groupVersion = (uint) Utils.Clone((object) this.m_groupVersion);
    groupMessageDataType.m_dataSetOrdering = (DataSetOrderingType) Utils.Clone((object) this.m_dataSetOrdering);
    groupMessageDataType.m_networkMessageContentMask = (uint) Utils.Clone((object) this.m_networkMessageContentMask);
    groupMessageDataType.m_samplingOffset = (double) Utils.Clone((object) this.m_samplingOffset);
    groupMessageDataType.m_publishingOffset = (DoubleCollection) Utils.Clone((object) this.m_publishingOffset);
    return (object) groupMessageDataType;
  }
}
