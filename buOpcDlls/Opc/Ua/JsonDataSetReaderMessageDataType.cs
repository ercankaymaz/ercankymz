// Decompiled with JetBrains decompiler
// Type: Opc.Ua.JsonDataSetReaderMessageDataType
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
public class JsonDataSetReaderMessageDataType : DataSetReaderMessageDataType
{
  private uint m_networkMessageContentMask;
  private uint m_dataSetMessageContentMask;

  public JsonDataSetReaderMessageDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_networkMessageContentMask = 0U;
    this.m_dataSetMessageContentMask = 0U;
  }

  [DataMember(Name = "NetworkMessageContentMask", IsRequired = false, Order = 1)]
  public uint NetworkMessageContentMask
  {
    get => this.m_networkMessageContentMask;
    set => this.m_networkMessageContentMask = value;
  }

  [DataMember(Name = "DataSetMessageContentMask", IsRequired = false, Order = 2)]
  public uint DataSetMessageContentMask
  {
    get => this.m_dataSetMessageContentMask;
    set => this.m_dataSetMessageContentMask = value;
  }

  public override ExpandedNodeId TypeId
  {
    get => (ExpandedNodeId) DataTypeIds.JsonDataSetReaderMessageDataType;
  }

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.JsonDataSetReaderMessageDataType_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.JsonDataSetReaderMessageDataType_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.JsonDataSetReaderMessageDataType_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("NetworkMessageContentMask", this.NetworkMessageContentMask);
    encoder.WriteUInt32("DataSetMessageContentMask", this.DataSetMessageContentMask);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.NetworkMessageContentMask = decoder.ReadUInt32("NetworkMessageContentMask");
    this.DataSetMessageContentMask = decoder.ReadUInt32("DataSetMessageContentMask");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is JsonDataSetReaderMessageDataType readerMessageDataType && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_networkMessageContentMask, (object) readerMessageDataType.m_networkMessageContentMask) && Utils.IsEqual((object) this.m_dataSetMessageContentMask, (object) readerMessageDataType.m_dataSetMessageContentMask) && base.IsEqual(encodeable);
  }

  public override object Clone()
  {
    return (object) (JsonDataSetReaderMessageDataType) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    JsonDataSetReaderMessageDataType readerMessageDataType = (JsonDataSetReaderMessageDataType) base.MemberwiseClone();
    readerMessageDataType.m_networkMessageContentMask = (uint) Utils.Clone((object) this.m_networkMessageContentMask);
    readerMessageDataType.m_dataSetMessageContentMask = (uint) Utils.Clone((object) this.m_dataSetMessageContentMask);
    return (object) readerMessageDataType;
  }
}
