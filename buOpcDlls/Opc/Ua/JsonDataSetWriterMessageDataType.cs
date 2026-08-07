// Decompiled with JetBrains decompiler
// Type: Opc.Ua.JsonDataSetWriterMessageDataType
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
public class JsonDataSetWriterMessageDataType : DataSetWriterMessageDataType
{
  private uint m_dataSetMessageContentMask;

  public JsonDataSetWriterMessageDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_dataSetMessageContentMask = 0U;

  [DataMember(Name = "DataSetMessageContentMask", IsRequired = false, Order = 1)]
  public uint DataSetMessageContentMask
  {
    get => this.m_dataSetMessageContentMask;
    set => this.m_dataSetMessageContentMask = value;
  }

  public override ExpandedNodeId TypeId
  {
    get => (ExpandedNodeId) DataTypeIds.JsonDataSetWriterMessageDataType;
  }

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.JsonDataSetWriterMessageDataType_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.JsonDataSetWriterMessageDataType_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.JsonDataSetWriterMessageDataType_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("DataSetMessageContentMask", this.DataSetMessageContentMask);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.DataSetMessageContentMask = decoder.ReadUInt32("DataSetMessageContentMask");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is JsonDataSetWriterMessageDataType writerMessageDataType && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_dataSetMessageContentMask, (object) writerMessageDataType.m_dataSetMessageContentMask) && base.IsEqual(encodeable);
  }

  public override object Clone()
  {
    return (object) (JsonDataSetWriterMessageDataType) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    JsonDataSetWriterMessageDataType writerMessageDataType = (JsonDataSetWriterMessageDataType) base.MemberwiseClone();
    writerMessageDataType.m_dataSetMessageContentMask = (uint) Utils.Clone((object) this.m_dataSetMessageContentMask);
    return (object) writerMessageDataType;
  }
}
