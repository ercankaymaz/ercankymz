// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ObjectTypeNode
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
public class ObjectTypeNode : TypeNode, IObjectType, ILocalNode, INode
{
  private bool m_isAbstract;

  public ObjectTypeNode() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_isAbstract = true;

  [DataMember(Name = "IsAbstract", IsRequired = false, Order = 1)]
  public bool IsAbstract
  {
    get => this.m_isAbstract;
    set => this.m_isAbstract = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ObjectTypeNode;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ObjectTypeNode_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ObjectTypeNode_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ObjectTypeNode_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteBoolean("IsAbstract", this.IsAbstract);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.IsAbstract = decoder.ReadBoolean("IsAbstract");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is ObjectTypeNode objectTypeNode && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_isAbstract, (object) objectTypeNode.m_isAbstract) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (ObjectTypeNode) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ObjectTypeNode objectTypeNode = (ObjectTypeNode) base.MemberwiseClone();
    objectTypeNode.m_isAbstract = (bool) Utils.Clone((object) this.m_isAbstract);
    return (object) objectTypeNode;
  }

  public ObjectTypeNode(ILocalNode source)
    : base(source)
  {
    this.NodeClass = NodeClass.ObjectType;
    if (!(source is IObjectType objectType))
      return;
    this.IsAbstract = objectType.IsAbstract;
  }

  public override bool SupportsAttribute(uint attributeId)
  {
    return attributeId == 8U || base.SupportsAttribute(attributeId);
  }

  protected override object Read(uint attributeId)
  {
    return attributeId == 8U ? (object) this.m_isAbstract : base.Read(attributeId);
  }

  protected override ServiceResult Write(uint attributeId, object value)
  {
    if (attributeId != 8U)
      return base.Write(attributeId, value);
    this.m_isAbstract = (bool) value;
    return ServiceResult.Good;
  }
}
