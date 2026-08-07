// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SimpleTypeDescription
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
public class SimpleTypeDescription : DataTypeDescription
{
  private NodeId m_baseDataType;
  private byte m_builtInType;

  public SimpleTypeDescription() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_baseDataType = (NodeId) null;
    this.m_builtInType = (byte) 0;
  }

  [DataMember(Name = "BaseDataType", IsRequired = false, Order = 1)]
  public NodeId BaseDataType
  {
    get => this.m_baseDataType;
    set => this.m_baseDataType = value;
  }

  [DataMember(Name = "BuiltInType", IsRequired = false, Order = 2)]
  public byte BuiltInType
  {
    get => this.m_builtInType;
    set => this.m_builtInType = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.SimpleTypeDescription;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SimpleTypeDescription_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SimpleTypeDescription_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SimpleTypeDescription_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("BaseDataType", this.BaseDataType);
    encoder.WriteByte("BuiltInType", this.BuiltInType);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.BaseDataType = decoder.ReadNodeId("BaseDataType");
    this.BuiltInType = decoder.ReadByte("BuiltInType");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is SimpleTypeDescription simpleTypeDescription && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_baseDataType, (object) simpleTypeDescription.m_baseDataType) && Utils.IsEqual((object) this.m_builtInType, (object) simpleTypeDescription.m_builtInType) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (SimpleTypeDescription) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    SimpleTypeDescription simpleTypeDescription = (SimpleTypeDescription) base.MemberwiseClone();
    simpleTypeDescription.m_baseDataType = (NodeId) Utils.Clone((object) this.m_baseDataType);
    simpleTypeDescription.m_builtInType = (byte) Utils.Clone((object) this.m_builtInType);
    return (object) simpleTypeDescription;
  }
}
