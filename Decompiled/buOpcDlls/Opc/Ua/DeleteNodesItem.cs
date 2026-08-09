using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DeleteNodesItem : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_nodeId;

	private bool m_deleteTargetReferences;

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

	[DataMember(Name = "DeleteTargetReferences", IsRequired = false, Order = 2)]
	public bool DeleteTargetReferences
	{
		get
		{
			return m_deleteTargetReferences;
		}
		set
		{
			m_deleteTargetReferences = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.DeleteNodesItem;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.DeleteNodesItem_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.DeleteNodesItem_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.DeleteNodesItem_Encoding_DefaultJson;

	public DeleteNodesItem()
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
		m_deleteTargetReferences = true;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("NodeId", NodeId);
		encoder.WriteBoolean("DeleteTargetReferences", DeleteTargetReferences);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NodeId = decoder.ReadNodeId("NodeId");
		DeleteTargetReferences = decoder.ReadBoolean("DeleteTargetReferences");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DeleteNodesItem deleteNodesItem))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodeId, deleteNodesItem.m_nodeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_deleteTargetReferences, deleteNodesItem.m_deleteTargetReferences))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (DeleteNodesItem)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DeleteNodesItem obj = (DeleteNodesItem)base.MemberwiseClone();
		obj.m_nodeId = (NodeId)Utils.Clone(m_nodeId);
		obj.m_deleteTargetReferences = (bool)Utils.Clone(m_deleteTargetReferences);
		return obj;
	}
}
