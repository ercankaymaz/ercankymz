// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UadpDataSetWriterMessageDataType
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
public class UadpDataSetWriterMessageDataType : DataSetWriterMessageDataType
{
  private uint m_dataSetMessageContentMask;
  private ushort m_configuredSize;
  private ushort m_networkMessageNumber;
  private ushort m_dataSetOffset;

  public UadpDataSetWriterMessageDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_dataSetMessageContentMask = 0U;
    this.m_configuredSize = (ushort) 0;
    this.m_networkMessageNumber = (ushort) 0;
    this.m_dataSetOffset = (ushort) 0;
  }

  [DataMember(Name = "DataSetMessageContentMask", IsRequired = false, Order = 1)]
  public uint DataSetMessageContentMask
  {
    get => this.m_dataSetMessageContentMask;
    set => this.m_dataSetMessageContentMask = value;
  }

  [DataMember(Name = "ConfiguredSize", IsRequired = false, Order = 2)]
  public ushort ConfiguredSize
  {
    get => this.m_configuredSize;
    set => this.m_configuredSize = value;
  }

  [DataMember(Name = "NetworkMessageNumber", IsRequired = false, Order = 3)]
  public ushort NetworkMessageNumber
  {
    get => this.m_networkMessageNumber;
    set => this.m_networkMessageNumber = value;
  }

  [DataMember(Name = "DataSetOffset", IsRequired = false, Order = 4)]
  public ushort DataSetOffset
  {
    get => this.m_dataSetOffset;
    set => this.m_dataSetOffset = value;
  }

  public override ExpandedNodeId TypeId
  {
    get => (ExpandedNodeId) DataTypeIds.UadpDataSetWriterMessageDataType;
  }

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UadpDataSetWriterMessageDataType_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UadpDataSetWriterMessageDataType_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UadpDataSetWriterMessageDataType_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("DataSetMessageContentMask", this.DataSetMessageContentMask);
    encoder.WriteUInt16("ConfiguredSize", this.ConfiguredSize);
    encoder.WriteUInt16("NetworkMessageNumber", this.NetworkMessageNumber);
    encoder.WriteUInt16("DataSetOffset", this.DataSetOffset);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.DataSetMessageContentMask = decoder.ReadUInt32("DataSetMessageContentMask");
    this.ConfiguredSize = decoder.ReadUInt16("ConfiguredSize");
    this.NetworkMessageNumber = decoder.ReadUInt16("NetworkMessageNumber");
    this.DataSetOffset = decoder.ReadUInt16("DataSetOffset");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is UadpDataSetWriterMessageDataType writerMessageDataType && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_dataSetMessageContentMask, (object) writerMessageDataType.m_dataSetMessageContentMask) && Utils.IsEqual((object) this.m_configuredSize, (object) writerMessageDataType.m_configuredSize) && Utils.IsEqual((object) this.m_networkMessageNumber, (object) writerMessageDataType.m_networkMessageNumber) && Utils.IsEqual((object) this.m_dataSetOffset, (object) writerMessageDataType.m_dataSetOffset) && base.IsEqual(encodeable);
  }

  public override object Clone()
  {
    return (object) (UadpDataSetWriterMessageDataType) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    UadpDataSetWriterMessageDataType writerMessageDataType = (UadpDataSetWriterMessageDataType) base.MemberwiseClone();
    writerMessageDataType.m_dataSetMessageContentMask = (uint) Utils.Clone((object) this.m_dataSetMessageContentMask);
    writerMessageDataType.m_configuredSize = (ushort) Utils.Clone((object) this.m_configuredSize);
    writerMessageDataType.m_networkMessageNumber = (ushort) Utils.Clone((object) this.m_networkMessageNumber);
    writerMessageDataType.m_dataSetOffset = (ushort) Utils.Clone((object) this.m_dataSetOffset);
    return (object) writerMessageDataType;
  }
}
