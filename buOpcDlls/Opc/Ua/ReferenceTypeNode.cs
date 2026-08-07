// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReferenceTypeNode
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
public class ReferenceTypeNode : TypeNode, IReferenceType, ILocalNode, INode
{
  private bool m_isAbstract;
  private bool m_symmetric;
  private LocalizedText m_inverseName;

  public ReferenceTypeNode() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_isAbstract = true;
    this.m_symmetric = true;
    this.m_inverseName = (LocalizedText) null;
  }

  [DataMember(Name = "IsAbstract", IsRequired = false, Order = 1)]
  public bool IsAbstract
  {
    get => this.m_isAbstract;
    set => this.m_isAbstract = value;
  }

  [DataMember(Name = "Symmetric", IsRequired = false, Order = 2)]
  public bool Symmetric
  {
    get => this.m_symmetric;
    set => this.m_symmetric = value;
  }

  [DataMember(Name = "InverseName", IsRequired = false, Order = 3)]
  public LocalizedText InverseName
  {
    get => this.m_inverseName;
    set => this.m_inverseName = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ReferenceTypeNode;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReferenceTypeNode_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReferenceTypeNode_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReferenceTypeNode_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteBoolean("IsAbstract", this.IsAbstract);
    encoder.WriteBoolean("Symmetric", this.Symmetric);
    encoder.WriteLocalizedText("InverseName", this.InverseName);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.IsAbstract = decoder.ReadBoolean("IsAbstract");
    this.Symmetric = decoder.ReadBoolean("Symmetric");
    this.InverseName = decoder.ReadLocalizedText("InverseName");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is ReferenceTypeNode referenceTypeNode && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_isAbstract, (object) referenceTypeNode.m_isAbstract) && Utils.IsEqual((object) this.m_symmetric, (object) referenceTypeNode.m_symmetric) && Utils.IsEqual((object) this.m_inverseName, (object) referenceTypeNode.m_inverseName) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (ReferenceTypeNode) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ReferenceTypeNode referenceTypeNode = (ReferenceTypeNode) base.MemberwiseClone();
    referenceTypeNode.m_isAbstract = (bool) Utils.Clone((object) this.m_isAbstract);
    referenceTypeNode.m_symmetric = (bool) Utils.Clone((object) this.m_symmetric);
    referenceTypeNode.m_inverseName = (LocalizedText) Utils.Clone((object) this.m_inverseName);
    return (object) referenceTypeNode;
  }

  public ReferenceTypeNode(ILocalNode source)
    : base(source)
  {
    this.NodeClass = NodeClass.ReferenceType;
    if (!(source is IReferenceType referenceType))
      return;
    this.IsAbstract = referenceType.IsAbstract;
    this.InverseName = referenceType.InverseName;
    this.Symmetric = referenceType.Symmetric;
  }

  public override bool SupportsAttribute(uint attributeId)
  {
    switch (attributeId)
    {
      case 8:
      case 9:
      case 10:
        return true;
      default:
        return base.SupportsAttribute(attributeId);
    }
  }

  protected override object Read(uint attributeId)
  {
    switch (attributeId)
    {
      case 8:
        return (object) this.m_isAbstract;
      case 9:
        return (object) this.m_symmetric;
      case 10:
        return (object) this.m_inverseName;
      default:
        return base.Read(attributeId);
    }
  }

  protected override ServiceResult Write(uint attributeId, object value)
  {
    switch (attributeId)
    {
      case 8:
        this.m_isAbstract = (bool) value;
        return ServiceResult.Good;
      case 9:
        this.m_symmetric = (bool) value;
        return ServiceResult.Good;
      case 10:
        this.m_inverseName = (LocalizedText) value;
        return ServiceResult.Good;
      default:
        return base.Write(attributeId, value);
    }
  }
}
