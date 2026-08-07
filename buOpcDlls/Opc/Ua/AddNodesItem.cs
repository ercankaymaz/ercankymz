// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AddNodesItem
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class AddNodesItem : IEncodeable, ICloneable, IJsonEncodeable
{
  private ExpandedNodeId m_parentNodeId;
  private NodeId m_referenceTypeId;
  private ExpandedNodeId m_requestedNewNodeId;
  private QualifiedName m_browseName;
  private NodeClass m_nodeClass;
  private ExtensionObject m_nodeAttributes;
  private ExpandedNodeId m_typeDefinition;

  public AddNodesItem() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_parentNodeId = (ExpandedNodeId) null;
    this.m_referenceTypeId = (NodeId) null;
    this.m_requestedNewNodeId = (ExpandedNodeId) null;
    this.m_browseName = (QualifiedName) null;
    this.m_nodeClass = NodeClass.Unspecified;
    this.m_nodeAttributes = (ExtensionObject) null;
    this.m_typeDefinition = (ExpandedNodeId) null;
  }

  [DataMember(Name = "ParentNodeId", IsRequired = false, Order = 1)]
  public ExpandedNodeId ParentNodeId
  {
    get => this.m_parentNodeId;
    set => this.m_parentNodeId = value;
  }

  [DataMember(Name = "ReferenceTypeId", IsRequired = false, Order = 2)]
  public NodeId ReferenceTypeId
  {
    get => this.m_referenceTypeId;
    set => this.m_referenceTypeId = value;
  }

  [DataMember(Name = "RequestedNewNodeId", IsRequired = false, Order = 3)]
  public ExpandedNodeId RequestedNewNodeId
  {
    get => this.m_requestedNewNodeId;
    set => this.m_requestedNewNodeId = value;
  }

  [DataMember(Name = "BrowseName", IsRequired = false, Order = 4)]
  public QualifiedName BrowseName
  {
    get => this.m_browseName;
    set => this.m_browseName = value;
  }

  [DataMember(Name = "NodeClass", IsRequired = false, Order = 5)]
  public NodeClass NodeClass
  {
    get => this.m_nodeClass;
    set => this.m_nodeClass = value;
  }

  [DataMember(Name = "NodeAttributes", IsRequired = false, Order = 6)]
  public ExtensionObject NodeAttributes
  {
    get => this.m_nodeAttributes;
    set => this.m_nodeAttributes = value;
  }

  [DataMember(Name = "TypeDefinition", IsRequired = false, Order = 7)]
  public ExpandedNodeId TypeDefinition
  {
    get => this.m_typeDefinition;
    set => this.m_typeDefinition = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.AddNodesItem;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AddNodesItem_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AddNodesItem_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AddNodesItem_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteExpandedNodeId("ParentNodeId", this.ParentNodeId);
    encoder.WriteNodeId("ReferenceTypeId", this.ReferenceTypeId);
    encoder.WriteExpandedNodeId("RequestedNewNodeId", this.RequestedNewNodeId);
    encoder.WriteQualifiedName("BrowseName", this.BrowseName);
    encoder.WriteEnumerated("NodeClass", (Enum) this.NodeClass);
    encoder.WriteExtensionObject("NodeAttributes", this.NodeAttributes);
    encoder.WriteExpandedNodeId("TypeDefinition", this.TypeDefinition);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ParentNodeId = decoder.ReadExpandedNodeId("ParentNodeId");
    this.ReferenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
    this.RequestedNewNodeId = decoder.ReadExpandedNodeId("RequestedNewNodeId");
    this.BrowseName = decoder.ReadQualifiedName("BrowseName");
    this.NodeClass = (NodeClass) decoder.ReadEnumerated("NodeClass", typeof (NodeClass));
    this.NodeAttributes = decoder.ReadExtensionObject("NodeAttributes");
    this.TypeDefinition = decoder.ReadExpandedNodeId("TypeDefinition");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is AddNodesItem addNodesItem && Utils.IsEqual((object) this.m_parentNodeId, (object) addNodesItem.m_parentNodeId) && Utils.IsEqual((object) this.m_referenceTypeId, (object) addNodesItem.m_referenceTypeId) && Utils.IsEqual((object) this.m_requestedNewNodeId, (object) addNodesItem.m_requestedNewNodeId) && Utils.IsEqual((object) this.m_browseName, (object) addNodesItem.m_browseName) && Utils.IsEqual((object) this.m_nodeClass, (object) addNodesItem.m_nodeClass) && Utils.IsEqual((object) this.m_nodeAttributes, (object) addNodesItem.m_nodeAttributes) && Utils.IsEqual((object) this.m_typeDefinition, (object) addNodesItem.m_typeDefinition);
  }

  public virtual object Clone() => (object) (AddNodesItem) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    AddNodesItem addNodesItem = (AddNodesItem) base.MemberwiseClone();
    addNodesItem.m_parentNodeId = (ExpandedNodeId) Utils.Clone((object) this.m_parentNodeId);
    addNodesItem.m_referenceTypeId = (NodeId) Utils.Clone((object) this.m_referenceTypeId);
    addNodesItem.m_requestedNewNodeId = (ExpandedNodeId) Utils.Clone((object) this.m_requestedNewNodeId);
    addNodesItem.m_browseName = (QualifiedName) Utils.Clone((object) this.m_browseName);
    addNodesItem.m_nodeClass = (NodeClass) Utils.Clone((object) this.m_nodeClass);
    addNodesItem.m_nodeAttributes = (ExtensionObject) Utils.Clone((object) this.m_nodeAttributes);
    addNodesItem.m_typeDefinition = (ExpandedNodeId) Utils.Clone((object) this.m_typeDefinition);
    return (object) addNodesItem;
  }
}
