using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

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

	[DataMember(Name = "ParentNodeId", IsRequired = false, Order = 1)]
	public ExpandedNodeId ParentNodeId
	{
		get
		{
			return m_parentNodeId;
		}
		set
		{
			m_parentNodeId = value;
		}
	}

	[DataMember(Name = "ReferenceTypeId", IsRequired = false, Order = 2)]
	public NodeId ReferenceTypeId
	{
		get
		{
			return m_referenceTypeId;
		}
		set
		{
			m_referenceTypeId = value;
		}
	}

	[DataMember(Name = "RequestedNewNodeId", IsRequired = false, Order = 3)]
	public ExpandedNodeId RequestedNewNodeId
	{
		get
		{
			return m_requestedNewNodeId;
		}
		set
		{
			m_requestedNewNodeId = value;
		}
	}

	[DataMember(Name = "BrowseName", IsRequired = false, Order = 4)]
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

	[DataMember(Name = "NodeClass", IsRequired = false, Order = 5)]
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

	[DataMember(Name = "NodeAttributes", IsRequired = false, Order = 6)]
	public ExtensionObject NodeAttributes
	{
		get
		{
			return m_nodeAttributes;
		}
		set
		{
			m_nodeAttributes = value;
		}
	}

	[DataMember(Name = "TypeDefinition", IsRequired = false, Order = 7)]
	public ExpandedNodeId TypeDefinition
	{
		get
		{
			return m_typeDefinition;
		}
		set
		{
			m_typeDefinition = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.AddNodesItem;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.AddNodesItem_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.AddNodesItem_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.AddNodesItem_Encoding_DefaultJson;

	public AddNodesItem()
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
		m_parentNodeId = null;
		m_referenceTypeId = null;
		m_requestedNewNodeId = null;
		m_browseName = null;
		m_nodeClass = NodeClass.Unspecified;
		m_nodeAttributes = null;
		m_typeDefinition = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteExpandedNodeId("ParentNodeId", ParentNodeId);
		encoder.WriteNodeId("ReferenceTypeId", ReferenceTypeId);
		encoder.WriteExpandedNodeId("RequestedNewNodeId", RequestedNewNodeId);
		encoder.WriteQualifiedName("BrowseName", BrowseName);
		encoder.WriteEnumerated("NodeClass", NodeClass);
		encoder.WriteExtensionObject("NodeAttributes", NodeAttributes);
		encoder.WriteExpandedNodeId("TypeDefinition", TypeDefinition);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ParentNodeId = decoder.ReadExpandedNodeId("ParentNodeId");
		ReferenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
		RequestedNewNodeId = decoder.ReadExpandedNodeId("RequestedNewNodeId");
		BrowseName = decoder.ReadQualifiedName("BrowseName");
		NodeClass = (NodeClass)(object)decoder.ReadEnumerated("NodeClass", typeof(NodeClass));
		NodeAttributes = decoder.ReadExtensionObject("NodeAttributes");
		TypeDefinition = decoder.ReadExpandedNodeId("TypeDefinition");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is AddNodesItem addNodesItem))
		{
			return false;
		}
		if (!Utils.IsEqual(m_parentNodeId, addNodesItem.m_parentNodeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_referenceTypeId, addNodesItem.m_referenceTypeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestedNewNodeId, addNodesItem.m_requestedNewNodeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_browseName, addNodesItem.m_browseName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodeClass, addNodesItem.m_nodeClass))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodeAttributes, addNodesItem.m_nodeAttributes))
		{
			return false;
		}
		if (!Utils.IsEqual(m_typeDefinition, addNodesItem.m_typeDefinition))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (AddNodesItem)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		AddNodesItem obj = (AddNodesItem)base.MemberwiseClone();
		obj.m_parentNodeId = (ExpandedNodeId)Utils.Clone(m_parentNodeId);
		obj.m_referenceTypeId = (NodeId)Utils.Clone(m_referenceTypeId);
		obj.m_requestedNewNodeId = (ExpandedNodeId)Utils.Clone(m_requestedNewNodeId);
		obj.m_browseName = (QualifiedName)Utils.Clone(m_browseName);
		obj.m_nodeClass = (NodeClass)Utils.Clone(m_nodeClass);
		obj.m_nodeAttributes = (ExtensionObject)Utils.Clone(m_nodeAttributes);
		obj.m_typeDefinition = (ExpandedNodeId)Utils.Clone(m_typeDefinition);
		return obj;
	}
}
