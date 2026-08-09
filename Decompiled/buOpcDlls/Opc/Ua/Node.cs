using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

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

	[DataMember(Name = "NodeId", IsRequired = false, Order = 1)]
	public NodeId NodeId
	{
		get
		{
			return m_nodeId;
		}
		set
		{
			m_nodeId = value;
		}
	}

	[DataMember(Name = "NodeClass", IsRequired = false, Order = 2)]
	public NodeClass NodeClass
	{
		get
		{
			return m_nodeClass;
		}
		set
		{
			m_nodeClass = value;
		}
	}

	[DataMember(Name = "BrowseName", IsRequired = false, Order = 3)]
	public QualifiedName BrowseName
	{
		get
		{
			return m_browseName;
		}
		set
		{
			m_browseName = value;
		}
	}

	[DataMember(Name = "DisplayName", IsRequired = false, Order = 4)]
	public LocalizedText DisplayName
	{
		get
		{
			return m_displayName;
		}
		set
		{
			m_displayName = value;
		}
	}

	[DataMember(Name = "Description", IsRequired = false, Order = 5)]
	public LocalizedText Description
	{
		get
		{
			return m_description;
		}
		set
		{
			m_description = value;
		}
	}

	[DataMember(Name = "WriteMask", IsRequired = false, Order = 6)]
	public uint WriteMask
	{
		get
		{
			return m_writeMask;
		}
		set
		{
			m_writeMask = value;
		}
	}

	[DataMember(Name = "UserWriteMask", IsRequired = false, Order = 7)]
	public uint UserWriteMask
	{
		get
		{
			return m_userWriteMask;
		}
		set
		{
			m_userWriteMask = value;
		}
	}

	[DataMember(Name = "RolePermissions", IsRequired = false, Order = 8)]
	public RolePermissionTypeCollection RolePermissions
	{
		get
		{
			return m_rolePermissions;
		}
		set
		{
			m_rolePermissions = value;
			if (value == null)
			{
				m_rolePermissions = new RolePermissionTypeCollection();
			}
		}
	}

	[DataMember(Name = "UserRolePermissions", IsRequired = false, Order = 9)]
	public RolePermissionTypeCollection UserRolePermissions
	{
		get
		{
			return m_userRolePermissions;
		}
		set
		{
			m_userRolePermissions = value;
			if (value == null)
			{
				m_userRolePermissions = new RolePermissionTypeCollection();
			}
		}
	}

	[DataMember(Name = "AccessRestrictions", IsRequired = false, Order = 10)]
	public ushort AccessRestrictions
	{
		get
		{
			return m_accessRestrictions;
		}
		set
		{
			m_accessRestrictions = value;
		}
	}

	[DataMember(Name = "References", IsRequired = false, Order = 11)]
	public ReferenceNodeCollection References
	{
		get
		{
			return m_references;
		}
		set
		{
			m_references = value;
			if (value == null)
			{
				m_references = new ReferenceNodeCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.Node;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.Node_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.Node_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.Node_Encoding_DefaultJson;

	public object Handle
	{
		get
		{
			return m_handle;
		}
		set
		{
			m_handle = value;
		}
	}

	ExpandedNodeId INode.NodeId => m_nodeId;

	public ExpandedNodeId TypeDefinitionId
	{
		get
		{
			if (m_referenceTable != null)
			{
				return m_referenceTable.FindTarget(ReferenceTypeIds.HasTypeDefinition, isInverse: false, includeSubtypes: false, null, 0);
			}
			return null;
		}
	}

	public object DataLock => this;

	AttributeWriteMask ILocalNode.WriteMask
	{
		get
		{
			return (AttributeWriteMask)m_writeMask;
		}
		set
		{
			m_writeMask = (uint)value;
		}
	}

	AttributeWriteMask ILocalNode.UserWriteMask
	{
		get
		{
			return (AttributeWriteMask)m_userWriteMask;
		}
		set
		{
			m_userWriteMask = (uint)value;
		}
	}

	public NodeId ModellingRule => (NodeId)ReferenceTable.FindTarget(ReferenceTypeIds.HasModellingRule, isInverse: false, includeSubtypes: false, null, 0);

	IReferenceCollection ILocalNode.References => ReferenceTable;

	public ReferenceCollection ReferenceTable
	{
		get
		{
			if (m_referenceTable == null)
			{
				m_referenceTable = new ReferenceCollection();
			}
			return m_referenceTable;
		}
	}

	public Node()
	{
		Initialize();
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
		m_nodeId = null;
		m_nodeClass = NodeClass.Unspecified;
		m_browseName = null;
		m_displayName = null;
		m_description = null;
		m_writeMask = 0u;
		m_userWriteMask = 0u;
		m_rolePermissions = new RolePermissionTypeCollection();
		m_userRolePermissions = new RolePermissionTypeCollection();
		m_accessRestrictions = 0;
		m_references = new ReferenceNodeCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("NodeId", NodeId);
		encoder.WriteEnumerated("NodeClass", NodeClass);
		encoder.WriteQualifiedName("BrowseName", BrowseName);
		encoder.WriteLocalizedText("DisplayName", DisplayName);
		encoder.WriteLocalizedText("Description", Description);
		encoder.WriteUInt32("WriteMask", WriteMask);
		encoder.WriteUInt32("UserWriteMask", UserWriteMask);
		encoder.WriteEncodeableArray("RolePermissions", RolePermissions.ToArray(), typeof(RolePermissionType));
		encoder.WriteEncodeableArray("UserRolePermissions", UserRolePermissions.ToArray(), typeof(RolePermissionType));
		encoder.WriteUInt16("AccessRestrictions", AccessRestrictions);
		encoder.WriteEncodeableArray("References", References.ToArray(), typeof(ReferenceNode));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NodeId = decoder.ReadNodeId("NodeId");
		NodeClass = (NodeClass)(object)decoder.ReadEnumerated("NodeClass", typeof(NodeClass));
		BrowseName = decoder.ReadQualifiedName("BrowseName");
		DisplayName = decoder.ReadLocalizedText("DisplayName");
		Description = decoder.ReadLocalizedText("Description");
		WriteMask = decoder.ReadUInt32("WriteMask");
		UserWriteMask = decoder.ReadUInt32("UserWriteMask");
		RolePermissions = (RolePermissionType[])decoder.ReadEncodeableArray("RolePermissions", typeof(RolePermissionType));
		UserRolePermissions = (RolePermissionType[])decoder.ReadEncodeableArray("UserRolePermissions", typeof(RolePermissionType));
		AccessRestrictions = decoder.ReadUInt16("AccessRestrictions");
		References = (ReferenceNode[])decoder.ReadEncodeableArray("References", typeof(ReferenceNode));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is Node node))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodeId, node.m_nodeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodeClass, node.m_nodeClass))
		{
			return false;
		}
		if (!Utils.IsEqual(m_browseName, node.m_browseName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_displayName, node.m_displayName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_description, node.m_description))
		{
			return false;
		}
		if (!Utils.IsEqual(m_writeMask, node.m_writeMask))
		{
			return false;
		}
		if (!Utils.IsEqual(m_userWriteMask, node.m_userWriteMask))
		{
			return false;
		}
		if (!Utils.IsEqual(m_rolePermissions, node.m_rolePermissions))
		{
			return false;
		}
		if (!Utils.IsEqual(m_userRolePermissions, node.m_userRolePermissions))
		{
			return false;
		}
		if (!Utils.IsEqual(m_accessRestrictions, node.m_accessRestrictions))
		{
			return false;
		}
		if (!Utils.IsEqual(m_references, node.m_references))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (Node)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		Node obj = (Node)base.MemberwiseClone();
		obj.m_nodeId = (NodeId)Utils.Clone(m_nodeId);
		obj.m_nodeClass = (NodeClass)Utils.Clone(m_nodeClass);
		obj.m_browseName = (QualifiedName)Utils.Clone(m_browseName);
		obj.m_displayName = (LocalizedText)Utils.Clone(m_displayName);
		obj.m_description = (LocalizedText)Utils.Clone(m_description);
		obj.m_writeMask = (uint)Utils.Clone(m_writeMask);
		obj.m_userWriteMask = (uint)Utils.Clone(m_userWriteMask);
		obj.m_rolePermissions = (RolePermissionTypeCollection)Utils.Clone(m_rolePermissions);
		obj.m_userRolePermissions = (RolePermissionTypeCollection)Utils.Clone(m_userRolePermissions);
		obj.m_accessRestrictions = (ushort)Utils.Clone(m_accessRestrictions);
		obj.m_references = (ReferenceNodeCollection)Utils.Clone(m_references);
		return obj;
	}

	public Node(ReferenceDescription reference)
	{
		Initialize();
		m_nodeId = (NodeId)reference.NodeId;
		m_nodeClass = reference.NodeClass;
		m_browseName = reference.BrowseName;
		m_displayName = reference.DisplayName;
	}

	public Node(ILocalNode source)
	{
		Initialize();
		if (source != null)
		{
			NodeId = source.NodeId;
			NodeClass = source.NodeClass;
			BrowseName = source.BrowseName;
			DisplayName = source.DisplayName;
			Description = source.Description;
			WriteMask = (uint)source.WriteMask;
			UserWriteMask = (uint)source.UserWriteMask;
		}
	}

	public static Node Copy(ILocalNode source)
	{
		if (source == null)
		{
			return null;
		}
		switch (source.NodeClass)
		{
		case NodeClass.Object:
			return new ObjectNode(source);
		case NodeClass.Variable:
			return new VariableNode(source);
		case NodeClass.ObjectType:
			return new ObjectTypeNode(source);
		case NodeClass.VariableType:
			return new VariableTypeNode(source);
		case NodeClass.DataType:
			return new DataTypeNode(source);
		case NodeClass.ReferenceType:
			return new ReferenceTypeNode(source);
		case NodeClass.Method:
			return new MethodNode(source);
		case NodeClass.View:
			return new ViewNode(source);
		default:
			if (source is IObject)
			{
				return new ObjectNode(source);
			}
			if (source is IVariable)
			{
				return new VariableNode(source);
			}
			if (source is IObjectType)
			{
				return new ObjectTypeNode(source);
			}
			if (source is IVariableType)
			{
				return new VariableTypeNode(source);
			}
			if (source is IDataType)
			{
				return new DataTypeNode(source);
			}
			if (source is IReferenceType)
			{
				return new ReferenceTypeNode(source);
			}
			if (source is IMethod)
			{
				return new MethodNode(source);
			}
			if (source is IView)
			{
				return new ViewNode(source);
			}
			return new Node(source);
		}
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			if (m_displayName != null && !string.IsNullOrEmpty(m_displayName.Text))
			{
				return m_displayName.Text;
			}
			if (!QualifiedName.IsNull(m_browseName))
			{
				return m_browseName.Name;
			}
			object[] array = new object[1];
			NodeClass nodeClass = m_nodeClass;
			array[0] = nodeClass.ToString().ToLower();
			return Utils.Format("(unknown {0})", array);
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public ILocalNode CreateCopy(NodeId nodeId)
	{
		Node node = Copy(this);
		node.NodeId = nodeId;
		return node;
	}

	public virtual bool SupportsAttribute(uint attributeId)
	{
		if (attributeId - 1 <= 6 || attributeId - 24 <= 2)
		{
			return true;
		}
		return false;
	}

	public ServiceResult Read(IOperationContext context, uint attributeId, DataValue value)
	{
		if (!SupportsAttribute(attributeId))
		{
			return 2150957056u;
		}
		value.Value = Read(attributeId);
		value.StatusCode = 0u;
		if (attributeId == 13)
		{
			value.SourceTimestamp = DateTime.UtcNow;
		}
		return ServiceResult.Good;
	}

	public ServiceResult Write(uint attributeId, DataValue value)
	{
		if (!SupportsAttribute(attributeId))
		{
			return 2150957056u;
		}
		switch (attributeId)
		{
		case 1u:
		case 2u:
			return 2151350272u;
		default:
			if (Attributes.GetDataTypeId(attributeId) != TypeInfo.GetDataTypeId(value))
			{
				return 2155085824u;
			}
			break;
		case 13u:
			break;
		}
		return Write(attributeId, value.Value);
	}

	public bool ReferenceExists(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId)
	{
		return ReferenceTable.Exists(referenceTypeId, isInverse, targetId, includeSubtypes: false, null);
	}

	public IList<IReference> Find(NodeId referenceTypeId, bool isInverse)
	{
		return ReferenceTable.Find(referenceTypeId, isInverse, includeSubtypes: false, null);
	}

	public ExpandedNodeId FindTarget(NodeId referenceTypeId, bool isInverse, int index)
	{
		return ReferenceTable.FindTarget(referenceTypeId, isInverse, includeSubtypes: false, null, index);
	}

	public ExpandedNodeId GetSuperType(ITypeTable typeTree)
	{
		if (m_referenceTable != null)
		{
			return m_referenceTable.FindTarget(ReferenceTypeIds.HasSubtype, isInverse: true, typeTree != null, typeTree, 0);
		}
		return null;
	}

	public override int GetHashCode()
	{
		HashCode hashCode = default(HashCode);
		hashCode.Add(m_nodeId);
		hashCode.Add(m_nodeClass);
		hashCode.Add(m_browseName);
		return hashCode.ToHashCode();
	}

	protected virtual object Read(uint attributeId)
	{
		return attributeId switch
		{
			1u => m_nodeId, 
			2u => m_nodeClass, 
			3u => m_browseName, 
			4u => m_displayName, 
			5u => m_description, 
			6u => m_writeMask, 
			7u => m_userWriteMask, 
			24u => m_rolePermissions, 
			25u => m_userRolePermissions, 
			26u => m_accessRestrictions, 
			_ => false, 
		};
	}

	protected virtual ServiceResult Write(uint attributeId, object value)
	{
		switch (attributeId)
		{
		case 3u:
			m_browseName = (QualifiedName)value;
			break;
		case 4u:
			m_displayName = (LocalizedText)value;
			break;
		case 5u:
			m_description = (LocalizedText)value;
			break;
		case 6u:
			m_writeMask = (uint)value;
			break;
		case 7u:
			m_userWriteMask = (uint)value;
			break;
		case 24u:
			m_rolePermissions = (RolePermissionTypeCollection)value;
			break;
		case 25u:
			m_userRolePermissions = (RolePermissionTypeCollection)value;
			break;
		case 26u:
			m_accessRestrictions = (ushort)value;
			break;
		default:
			return 2150957056u;
		}
		return ServiceResult.Good;
	}
}
