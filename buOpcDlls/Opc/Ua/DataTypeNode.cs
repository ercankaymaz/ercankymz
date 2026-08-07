// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataTypeNode
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
public class DataTypeNode : TypeNode, IDataType, ILocalNode, INode
{
  private bool m_isAbstract;
  private ExtensionObject m_dataTypeDefinition;

  public DataTypeNode() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_isAbstract = true;
    this.m_dataTypeDefinition = (ExtensionObject) null;
  }

  [DataMember(Name = "IsAbstract", IsRequired = false, Order = 1)]
  public bool IsAbstract
  {
    get => this.m_isAbstract;
    set => this.m_isAbstract = value;
  }

  [DataMember(Name = "DataTypeDefinition", IsRequired = false, Order = 2)]
  public ExtensionObject DataTypeDefinition
  {
    get => this.m_dataTypeDefinition;
    set => this.m_dataTypeDefinition = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.DataTypeNode;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataTypeNode_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataTypeNode_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataTypeNode_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteBoolean("IsAbstract", this.IsAbstract);
    encoder.WriteExtensionObject("DataTypeDefinition", this.DataTypeDefinition);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.IsAbstract = decoder.ReadBoolean("IsAbstract");
    this.DataTypeDefinition = decoder.ReadExtensionObject("DataTypeDefinition");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is DataTypeNode dataTypeNode && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_isAbstract, (object) dataTypeNode.m_isAbstract) && Utils.IsEqual((object) this.m_dataTypeDefinition, (object) dataTypeNode.m_dataTypeDefinition) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (DataTypeNode) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DataTypeNode dataTypeNode = (DataTypeNode) base.MemberwiseClone();
    dataTypeNode.m_isAbstract = (bool) Utils.Clone((object) this.m_isAbstract);
    dataTypeNode.m_dataTypeDefinition = (ExtensionObject) Utils.Clone((object) this.m_dataTypeDefinition);
    return (object) dataTypeNode;
  }

  public DataTypeNode(ILocalNode source)
    : base(source)
  {
    this.NodeClass = NodeClass.DataType;
    if (!(source is IDataType dataType))
      return;
    this.IsAbstract = dataType.IsAbstract;
  }

  public override bool SupportsAttribute(uint attributeId)
  {
    return attributeId == 8U || attributeId == 23U || base.SupportsAttribute(attributeId);
  }

  protected override object Read(uint attributeId)
  {
    if (attributeId == 8U)
      return (object) this.m_isAbstract;
    return attributeId != 23U ? base.Read(attributeId) : (object) this.m_dataTypeDefinition;
  }

  protected override ServiceResult Write(uint attributeId, object value)
  {
    if (attributeId != 8U)
    {
      if (attributeId != 23U)
        return base.Write(attributeId, value);
      this.m_dataTypeDefinition = (ExtensionObject) value;
      return ServiceResult.Good;
    }
    this.m_isAbstract = (bool) value;
    return ServiceResult.Good;
  }
}
