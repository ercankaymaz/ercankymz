// Decompiled with JetBrains decompiler
// Type: Opc.Ua.JsonWriterGroupMessageDataType
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
public class JsonWriterGroupMessageDataType : WriterGroupMessageDataType
{
  private uint m_networkMessageContentMask;

  public JsonWriterGroupMessageDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_networkMessageContentMask = 0U;

  [DataMember(Name = "NetworkMessageContentMask", IsRequired = false, Order = 1)]
  public uint NetworkMessageContentMask
  {
    get => this.m_networkMessageContentMask;
    set => this.m_networkMessageContentMask = value;
  }

  public override ExpandedNodeId TypeId
  {
    get => (ExpandedNodeId) DataTypeIds.JsonWriterGroupMessageDataType;
  }

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.JsonWriterGroupMessageDataType_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.JsonWriterGroupMessageDataType_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.JsonWriterGroupMessageDataType_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("NetworkMessageContentMask", this.NetworkMessageContentMask);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.NetworkMessageContentMask = decoder.ReadUInt32("NetworkMessageContentMask");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is JsonWriterGroupMessageDataType groupMessageDataType && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_networkMessageContentMask, (object) groupMessageDataType.m_networkMessageContentMask) && base.IsEqual(encodeable);
  }

  public override object Clone()
  {
    return (object) (JsonWriterGroupMessageDataType) this.MemberwiseClone();
  }

  public new object MemberwiseClone()
  {
    JsonWriterGroupMessageDataType groupMessageDataType = (JsonWriterGroupMessageDataType) base.MemberwiseClone();
    groupMessageDataType.m_networkMessageContentMask = (uint) Utils.Clone((object) this.m_networkMessageContentMask);
    return (object) groupMessageDataType;
  }
}
