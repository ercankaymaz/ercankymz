// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UadpDataSetReaderMessageDataType
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
public class UadpDataSetReaderMessageDataType : DataSetReaderMessageDataType
{
  private uint m_groupVersion;
  private ushort m_networkMessageNumber;
  private ushort m_dataSetOffset;
  private Uuid m_dataSetClassId;
  private uint m_networkMessageContentMask;
  private uint m_dataSetMessageContentMask;
  private double m_publishingInterval;
  private double m_receiveOffset;
  private double m_processingOffset;

  public UadpDataSetReaderMessageDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_groupVersion = 0U;
    this.m_networkMessageNumber = (ushort) 0;
    this.m_dataSetOffset = (ushort) 0;
    this.m_dataSetClassId = Uuid.Empty;
    this.m_networkMessageContentMask = 0U;
    this.m_dataSetMessageContentMask = 0U;
    this.m_publishingInterval = 0.0;
    this.m_receiveOffset = 0.0;
    this.m_processingOffset = 0.0;
  }

  [DataMember(Name = "GroupVersion", IsRequired = false, Order = 1)]
  public uint GroupVersion
  {
    get => this.m_groupVersion;
    set => this.m_groupVersion = value;
  }

  [DataMember(Name = "NetworkMessageNumber", IsRequired = false, Order = 2)]
  public ushort NetworkMessageNumber
  {
    get => this.m_networkMessageNumber;
    set => this.m_networkMessageNumber = value;
  }

  [DataMember(Name = "DataSetOffset", IsRequired = false, Order = 3)]
  public ushort DataSetOffset
  {
    get => this.m_dataSetOffset;
    set => this.m_dataSetOffset = value;
  }

  [DataMember(Name = "DataSetClassId", IsRequired = false, Order = 4)]
  public Uuid DataSetClassId
  {
    get => this.m_dataSetClassId;
    set => this.m_dataSetClassId = value;
  }

  [DataMember(Name = "NetworkMessageContentMask", IsRequired = false, Order = 5)]
  public uint NetworkMessageContentMask
  {
    get => this.m_networkMessageContentMask;
    set => this.m_networkMessageContentMask = value;
  }

  [DataMember(Name = "DataSetMessageContentMask", IsRequired = false, Order = 6)]
  public uint DataSetMessageContentMask
  {
    get => this.m_dataSetMessageContentMask;
    set => this.m_dataSetMessageContentMask = value;
  }

  [DataMember(Name = "PublishingInterval", IsRequired = false, Order = 7)]
  public double PublishingInterval
  {
    get => this.m_publishingInterval;
    set => this.m_publishingInterval = value;
  }

  [DataMember(Name = "ReceiveOffset", IsRequired = false, Order = 8)]
  public double ReceiveOffset
  {
    get => this.m_receiveOffset;
    set => this.m_receiveOffset = value;
  }

  [DataMember(Name = "ProcessingOffset", IsRequired = false, Order = 9)]
  public double ProcessingOffset
  {
    get => this.m_processingOffset;
    set => this.m_processingOffset = value;
  }

  public override ExpandedNodeId TypeId
  {
    get => (ExpandedNodeId) DataTypeIds.UadpDataSetReaderMessageDataType;
  }

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UadpDataSetReaderMessageDataType_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UadpDataSetReaderMessageDataType_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UadpDataSetReaderMessageDataType_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("GroupVersion", this.GroupVersion);
    encoder.WriteUInt16("NetworkMessageNumber", this.NetworkMessageNumber);
    encoder.WriteUInt16("DataSetOffset", this.DataSetOffset);
    encoder.WriteGuid("DataSetClassId", this.DataSetClassId);
    encoder.WriteUInt32("NetworkMessageContentMask", this.NetworkMessageContentMask);
    encoder.WriteUInt32("DataSetMessageContentMask", this.DataSetMessageContentMask);
    encoder.WriteDouble("PublishingInterval", this.PublishingInterval);
    encoder.WriteDouble("ReceiveOffset", this.ReceiveOffset);
    encoder.WriteDouble("ProcessingOffset", this.ProcessingOffset);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.GroupVersion = decoder.ReadUInt32("GroupVersion");
    this.NetworkMessageNumber = decoder.ReadUInt16("NetworkMessageNumber");
    this.DataSetOffset = decoder.ReadUInt16("DataSetOffset");
    this.DataSetClassId = decoder.ReadGuid("DataSetClassId");
    this.NetworkMessageContentMask = decoder.ReadUInt32("NetworkMessageContentMask");
    this.DataSetMessageContentMask = decoder.ReadUInt32("DataSetMessageContentMask");
    this.PublishingInterval = decoder.ReadDouble("PublishingInterval");
    this.ReceiveOffset = decoder.ReadDouble("ReceiveOffset");
    this.ProcessingOffset = decoder.ReadDouble("ProcessingOffset");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is UadpDataSetReaderMessageDataType readerMessageDataType && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_groupVersion, (object) readerMessageDataType.m_groupVersion) && Utils.IsEqual((object) this.m_networkMessageNumber, (object) readerMessageDataType.m_networkMessageNumber) && Utils.IsEqual((object) this.m_dataSetOffset, (object) readerMessageDataType.m_dataSetOffset) && Utils.IsEqual((object) this.m_dataSetClassId, (object) readerMessageDataType.m_dataSetClassId) && Utils.IsEqual((object) this.m_networkMessageContentMask, (object) readerMessageDataType.m_networkMessageContentMask) && Utils.IsEqual((object) this.m_dataSetMessageContentMask, (object) readerMessageDataType.m_dataSetMessageContentMask) && Utils.IsEqual((object) this.m_publishingInterval, (object) readerMessageDataType.m_publishingInterval) && Utils.IsEqual((object) this.m_receiveOffset, (object) readerMessageDataType.m_receiveOffset) && Utils.IsEqual((object) this.m_processingOffset, (object) readerMessageDataType.m_processingOffset) && base.IsEqual(encodeable);
  }

  public override object Clone()
  {
    return (object) (UadpDataSetReaderMessageDataType) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    UadpDataSetReaderMessageDataType readerMessageDataType = (UadpDataSetReaderMessageDataType) base.MemberwiseClone();
    readerMessageDataType.m_groupVersion = (uint) Utils.Clone((object) this.m_groupVersion);
    readerMessageDataType.m_networkMessageNumber = (ushort) Utils.Clone((object) this.m_networkMessageNumber);
    readerMessageDataType.m_dataSetOffset = (ushort) Utils.Clone((object) this.m_dataSetOffset);
    readerMessageDataType.m_dataSetClassId = (Uuid) Utils.Clone((object) this.m_dataSetClassId);
    readerMessageDataType.m_networkMessageContentMask = (uint) Utils.Clone((object) this.m_networkMessageContentMask);
    readerMessageDataType.m_dataSetMessageContentMask = (uint) Utils.Clone((object) this.m_dataSetMessageContentMask);
    readerMessageDataType.m_publishingInterval = (double) Utils.Clone((object) this.m_publishingInterval);
    readerMessageDataType.m_receiveOffset = (double) Utils.Clone((object) this.m_receiveOffset);
    readerMessageDataType.m_processingOffset = (double) Utils.Clone((object) this.m_processingOffset);
    return (object) readerMessageDataType;
  }
}
