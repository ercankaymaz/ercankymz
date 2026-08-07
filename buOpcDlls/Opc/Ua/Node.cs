// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Node
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class Node : IEncodeable, ICloneable, IJsonEncodeable, IFormattable, ILocalNode, INode
{
  private NodeId m_nodeId;
  private NodeClass m_nodeClass;
  private QualifiedName m_browseName;
  private LocalizedText m_displayName;
  private LocalizedText m_description;
  private uint m_writeMask;
  private uint m_userWriteMask;
  private RolePermissionTypeCollection m_rolePermissions;
  private RolePermissionTypeCollection m_userRolePermissions;
  private ushort m_accessRestrictions;
  private ReferenceNodeCollection m_references;
  private object m_handle;
  private ReferenceCollection m_referenceTable;

  public Node() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_nodeId = (NodeId) null;
    this.m_nodeClass = NodeClass.Unspecified;
    this.m_browseName = (QualifiedName) null;
    this.m_displayName = (LocalizedText) null;
    this.m_description = (LocalizedText) null;
    this.m_writeMask = 0U;
    this.m_userWriteMask = 0U;
    this.m_rolePermissions = new RolePermissionTypeCollection();
    this.m_userRolePermissions = new RolePermissionTypeCollection();
    this.m_accessRestrictions = (ushort) 0;
    this.m_references = new ReferenceNodeCollection();
  }

  [DataMember(Name = "NodeId", IsRequired = false, Order = 1)]
  public NodeId NodeId
  {
    get => this.m_nodeId;
    set => this.m_nodeId = value;
  }

  [DataMember(Name = "NodeClass", IsRequired = false, Order = 2)]
  public NodeClass NodeClass
  {
    get => this.m_nodeClass;
    set => this.m_nodeClass = value;
  }

  [DataMember(Name = "BrowseName", IsRequired = false, Order = 3)]
  public QualifiedName BrowseName
  {
    get => this.m_browseName;
    set => this.m_browseName = value;
  }

  [DataMember(Name = "DisplayName", IsRequired = false, Order = 4)]
  public LocalizedText DisplayName
  {
    get => this.m_displayName;
    set => this.m_displayName = value;
  }

  [DataMember(Name = "Description", IsRequired = false, Order = 5)]
  public LocalizedText Description
  {
    get => this.m_description;
    set => this.m_description = value;
  }

  [DataMember(Name = "WriteMask", IsRequired = false, Order = 6)]
  public uint WriteMask
  {
    get => this.m_writeMask;
    set => this.m_writeMask = value;
  }

  [DataMember(Name = "UserWriteMask", IsRequired = false, Order = 7)]
  public uint UserWriteMask
  {
    get => this.m_userWriteMask;
    set => this.m_userWriteMask = value;
  }

  [DataMember(Name = "RolePermissions", IsRequired = false, Order = 8)]
  public RolePermissionTypeCollection RolePermissions
  {
    get => this.m_rolePermissions;
    set
    {
      this.m_rolePermissions = value;
      if (value != null)
        return;
      this.m_rolePermissions = new RolePermissionTypeCollection();
    }
  }

  [DataMember(Name = "UserRolePermissions", IsRequired = false, Order = 9)]
  public RolePermissionTypeCollection UserRolePermissions
  {
    get => this.m_userRolePermissions;
    set
    {
      this.m_userRolePermissions = value;
      if (value != null)
        return;
      this.m_userRolePermissions = new RolePermissionTypeCollection();
    }
  }

  [DataMember(Name = "AccessRestrictions", IsRequired = false, Order = 10)]
  public ushort AccessRestrictions
  {
    get => this.m_accessRestrictions;
    set => this.m_accessRestrictions = value;
  }

  [DataMember(Name = "References", IsRequired = false, Order = 11)]
  public ReferenceNodeCollection References
  {
    get => this.m_references;
    set
    {
      this.m_references = value;
      if (value != null)
        return;
      this.m_references = new ReferenceNodeCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.Node;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.Node_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.Node_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.Node_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("NodeId", this.NodeId);
    encoder.WriteEnumerated("NodeClass", (Enum) this.NodeClass);
    encoder.WriteQualifiedName("BrowseName", this.BrowseName);
    encoder.WriteLocalizedText("DisplayName", this.DisplayName);
    encoder.WriteLocalizedText("Description", this.Description);
    encoder.WriteUInt32("WriteMask", this.WriteMask);
    encoder.WriteUInt32("UserWriteMask", this.UserWriteMask);
    encoder.WriteEncodeableArray("RolePermissions", (IList<IEncodeable>) this.RolePermissions.ToArray(), typeof (RolePermissionType));
    encoder.WriteEncodeableArray("UserRolePermissions", (IList<IEncodeable>) this.UserRolePermissions.ToArray(), typeof (RolePermissionType));
    encoder.WriteUInt16("AccessRestrictions", this.AccessRestrictions);
    encoder.WriteEncodeableArray("References", (IList<IEncodeable>) this.References.ToArray(), typeof (ReferenceNode));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.NodeId = decoder.ReadNodeId("NodeId");
    this.NodeClass = (NodeClass) decoder.ReadEnumerated("NodeClass", typeof (NodeClass));
    this.BrowseName = decoder.ReadQualifiedName("BrowseName");
    this.DisplayName = decoder.ReadLocalizedText("DisplayName");
    this.Description = decoder.ReadLocalizedText("Description");
    this.WriteMask = decoder.ReadUInt32("WriteMask");
    this.UserWriteMask = decoder.ReadUInt32("UserWriteMask");
    this.RolePermissions = (RolePermissionTypeCollection) (RolePermissionType[]) decoder.ReadEncodeableArray("RolePermissions", typeof (RolePermissionType));
    this.UserRolePermissions = (RolePermissionTypeCollection) (RolePermissionType[]) decoder.ReadEncodeableArray("UserRolePermissions", typeof (RolePermissionType));
    this.AccessRestrictions = decoder.ReadUInt16("AccessRestrictions");
    this.References = (ReferenceNodeCollection) (ReferenceNode[]) decoder.ReadEncodeableArray("References", typeof (ReferenceNode));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is Node node && Utils.IsEqual((object) this.m_nodeId, (object) node.m_nodeId) && Utils.IsEqual((object) this.m_nodeClass, (object) node.m_nodeClass) && Utils.IsEqual((object) this.m_browseName, (object) node.m_browseName) && Utils.IsEqual((object) this.m_displayName, (object) node.m_displayName) && Utils.IsEqual((object) this.m_description, (object) node.m_description) && Utils.IsEqual((object) this.m_writeMask, (object) node.m_writeMask) && Utils.IsEqual((object) this.m_userWriteMask, (object) node.m_userWriteMask) && Utils.IsEqual((object) this.m_rolePermissions, (object) node.m_rolePermissions) && Utils.IsEqual((object) this.m_userRolePermissions, (object) node.m_userRolePermissions) && Utils.IsEqual((object) this.m_accessRestrictions, (object) node.m_accessRestrictions) && Utils.IsEqual((object) this.m_references, (object) node.m_references);
  }

  public virtual object Clone() => (object) (Node) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    Node node = (Node) base.MemberwiseClone();
    node.m_nodeId = (NodeId) Utils.Clone((object) this.m_nodeId);
    node.m_nodeClass = (NodeClass) Utils.Clone((object) this.m_nodeClass);
    node.m_browseName = (QualifiedName) Utils.Clone((object) this.m_browseName);
    node.m_displayName = (LocalizedText) Utils.Clone((object) this.m_displayName);
    node.m_description = (LocalizedText) Utils.Clone((object) this.m_description);
    node.m_writeMask = (uint) Utils.Clone((object) this.m_writeMask);
    node.m_userWriteMask = (uint) Utils.Clone((object) this.m_userWriteMask);
    node.m_rolePermissions = (RolePermissionTypeCollection) Utils.Clone((object) this.m_rolePermissions);
    node.m_userRolePermissions = (RolePermissionTypeCollection) Utils.Clone((object) this.m_userRolePermissions);
    node.m_accessRestrictions = (ushort) Utils.Clone((object) this.m_accessRestrictions);
    node.m_references = (ReferenceNodeCollection) Utils.Clone((object) this.m_references);
    return (object) node;
  }

  public Node(ReferenceDescription reference)
  {
    this.Initialize();
    this.m_nodeId = (NodeId) reference.NodeId;
    this.m_nodeClass = reference.NodeClass;
    this.m_browseName = reference.BrowseName;
    this.m_displayName = reference.DisplayName;
  }

  public Node(ILocalNode source)
  {
    this.Initialize();
    if (source == null)
      return;
    this.NodeId = source.NodeId;
    this.NodeClass = source.NodeClass;
    this.BrowseName = source.BrowseName;
    this.DisplayName = source.DisplayName;
    this.Description = source.Description;
    this.WriteMask = (uint) source.WriteMask;
    this.UserWriteMask = (uint) source.UserWriteMask;
  }

  public static Node Copy(ILocalNode source)
  {
    if (source == null)
      return (Node) null;
    switch (source.NodeClass)
    {
      case NodeClass.Object:
        return (Node) new ObjectNode(source);
      case NodeClass.Variable:
        return (Node) new VariableNode(source);
      case NodeClass.Method:
        return (Node) new MethodNode(source);
      case NodeClass.ObjectType:
        return (Node) new ObjectTypeNode(source);
      case NodeClass.VariableType:
        return (Node) new VariableTypeNode(source);
      case NodeClass.ReferenceType:
        return (Node) new ReferenceTypeNode(source);
      case NodeClass.DataType:
        return (Node) new DataTypeNode(source);
      case NodeClass.View:
        return (Node) new ViewNode(source);
      default:
        switch (source)
        {
          case IObject _:
            return (Node) new ObjectNode(source);
          case IVariable _:
            return (Node) new VariableNode(source);
          case IObjectType _:
            return (Node) new ObjectTypeNode(source);
          case IVariableType _:
            return (Node) new VariableTypeNode(source);
          case IDataType _:
            return (Node) new DataTypeNode(source);
          case IReferenceType _:
            return (Node) new ReferenceTypeNode(source);
          case IMethod _:
            return (Node) new MethodNode(source);
          case IView _:
            return (Node) new ViewNode(source);
          default:
            return new Node(source);
        }
    }
  }

  public object Handle
  {
    get => this.m_handle;
    set => this.m_handle = value;
  }

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format == null)
    {
      if (this.m_displayName != (LocalizedText) null && !string.IsNullOrEmpty(this.m_displayName.Text))
        return this.m_displayName.Text;
      if (!QualifiedName.IsNull(this.m_browseName))
        return this.m_browseName.Name;
      return Utils.Format("(unknown {0})", (object) this.m_nodeClass.ToString().ToLower());
    }
    throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
  }

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  ExpandedNodeId INode.NodeId => (ExpandedNodeId) this.m_nodeId;

  public ExpandedNodeId TypeDefinitionId
  {
    get
    {
      return this.m_referenceTable != null ? this.m_referenceTable.FindTarget(ReferenceTypeIds.HasTypeDefinition, false, false, (ITypeTable) null, 0) : (ExpandedNodeId) null;
    }
  }

  public object DataLock => (object) this;

  AttributeWriteMask ILocalNode.WriteMask
  {
    get => (AttributeWriteMask) this.m_writeMask;
    set => this.m_writeMask = (uint) value;
  }

  AttributeWriteMask ILocalNode.UserWriteMask
  {
    get => (AttributeWriteMask) this.m_userWriteMask;
    set => this.m_userWriteMask = (uint) value;
  }

  public NodeId ModellingRule
  {
    get
    {
      return (NodeId) this.ReferenceTable.FindTarget(ReferenceTypeIds.HasModellingRule, false, false, (ITypeTable) null, 0);
    }
  }

  IReferenceCollection ILocalNode.References => (IReferenceCollection) this.ReferenceTable;

  public ILocalNode CreateCopy(NodeId nodeId)
  {
    Node copy = Node.Copy((ILocalNode) this);
    copy.NodeId = nodeId;
    return (ILocalNode) copy;
  }

  public virtual bool SupportsAttribute(uint attributeId)
  {
    switch (attributeId)
    {
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
      case 7:
      case 24:
      case 25:
      case 26:
        return true;
      default:
        return false;
    }
  }

  public ServiceResult Read(IOperationContext context, uint attributeId, DataValue value)
  {
    if (!this.SupportsAttribute(attributeId))
      return (ServiceResult) 2150957056U /*0x80350000*/;
    value.Value = this.Read(attributeId);
    value.StatusCode = (StatusCode) 0U;
    if (attributeId == 13U)
      value.SourceTimestamp = DateTime.UtcNow;
    return ServiceResult.Good;
  }

  public ServiceResult Write(uint attributeId, DataValue value)
  {
    if (!this.SupportsAttribute(attributeId))
      return (ServiceResult) 2150957056U /*0x80350000*/;
    switch (attributeId)
    {
      case 1:
      case 2:
        return (ServiceResult) 2151350272U /*0x803B0000*/;
      case 13:
        return this.Write(attributeId, value.Value);
      default:
        if (Attributes.GetDataTypeId(attributeId) != (object) TypeInfo.GetDataTypeId((object) value))
          return (ServiceResult) 2155085824U /*0x80740000*/;
        goto case 13;
    }
  }

  public ReferenceCollection ReferenceTable
  {
    get
    {
      if (this.m_referenceTable == null)
        this.m_referenceTable = new ReferenceCollection();
      return this.m_referenceTable;
    }
  }

  public bool ReferenceExists(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId)
  {
    return this.ReferenceTable.Exists(referenceTypeId, isInverse, targetId, false, (ITypeTable) null);
  }

  public IList<IReference> Find(NodeId referenceTypeId, bool isInverse)
  {
    return this.ReferenceTable.Find(referenceTypeId, isInverse, false, (ITypeTable) null);
  }

  public ExpandedNodeId FindTarget(NodeId referenceTypeId, bool isInverse, int index)
  {
    return this.ReferenceTable.FindTarget(referenceTypeId, isInverse, false, (ITypeTable) null, index);
  }

  public ExpandedNodeId GetSuperType(ITypeTable typeTree)
  {
    return this.m_referenceTable != null ? this.m_referenceTable.FindTarget(ReferenceTypeIds.HasSubtype, true, typeTree != null, typeTree, 0) : (ExpandedNodeId) null;
  }

  public override int GetHashCode()
  {
    HashCode hashCode = new HashCode();
    hashCode.Add<NodeId>(this.m_nodeId);
    hashCode.Add<NodeClass>(this.m_nodeClass);
    hashCode.Add<QualifiedName>(this.m_browseName);
    return hashCode.ToHashCode();
  }

  protected virtual object Read(uint attributeId)
  {
    switch (attributeId)
    {
      case 1:
        return (object) this.m_nodeId;
      case 2:
        return (object) this.m_nodeClass;
      case 3:
        return (object) this.m_browseName;
      case 4:
        return (object) this.m_displayName;
      case 5:
        return (object) this.m_description;
      case 6:
        return (object) this.m_writeMask;
      case 7:
        return (object) this.m_userWriteMask;
      case 24:
        return (object) this.m_rolePermissions;
      case 25:
        return (object) this.m_userRolePermissions;
      case 26:
        return (object) this.m_accessRestrictions;
      default:
        return (object) false;
    }
  }

  protected virtual ServiceResult Write(uint attributeId, object value)
  {
    switch (attributeId)
    {
      case 3:
        this.m_browseName = (QualifiedName) value;
        break;
      case 4:
        this.m_displayName = (LocalizedText) value;
        break;
      case 5:
        this.m_description = (LocalizedText) value;
        break;
      case 6:
        this.m_writeMask = (uint) value;
        break;
      case 7:
        this.m_userWriteMask = (uint) value;
        break;
      case 24:
        this.m_rolePermissions = (RolePermissionTypeCollection) value;
        break;
      case 25:
        this.m_userRolePermissions = (RolePermissionTypeCollection) value;
        break;
      case 26:
        this.m_accessRestrictions = (ushort) value;
        break;
      default:
        return (ServiceResult) 2150957056U /*0x80350000*/;
    }
    return ServiceResult.Good;
  }
}
