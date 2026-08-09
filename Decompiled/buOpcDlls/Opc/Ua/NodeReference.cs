using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class NodeReference : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_nodeId;

	private NodeId m_referenceTypeId;

	private bool m_isForward;

	private NodeIdCollection m_referencedNodeIds;

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

	[DataMember(Name = "IsForward", IsRequired = false, Order = 3)]
	public bool IsForward
	{
		get
		{
			return m_isForward;
		}
		set
		{
			m_isForward = value;
		}
	}

	[DataMember(Name = "ReferencedNodeIds", IsRequired = false, Order = 4)]
	public NodeIdCollection ReferencedNodeIds
	{
		get
		{
			return m_referencedNodeIds;
		}
		set
		{
			m_referencedNodeIds = value;
			if (value == null)
			{
				m_referencedNodeIds = new NodeIdCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.NodeReference;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.NodeReference_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.NodeReference_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.NodeReference_Encoding_DefaultJson;

	public NodeReference()
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
		m_referenceTypeId = null;
		m_isForward = true;
		m_referencedNodeIds = new NodeIdCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("NodeId", NodeId);
		encoder.WriteNodeId("ReferenceTypeId", ReferenceTypeId);
		encoder.WriteBoolean("IsForward", IsForward);
		encoder.WriteNodeIdArray("ReferencedNodeIds", ReferencedNodeIds);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NodeId = decoder.ReadNodeId("NodeId");
		ReferenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
		IsForward = decoder.ReadBoolean("IsForward");
		ReferencedNodeIds = decoder.ReadNodeIdArray("ReferencedNodeIds");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is NodeReference nodeReference))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodeId, nodeReference.m_nodeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_referenceTypeId, nodeReference.m_referenceTypeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_isForward, nodeReference.m_isForward))
		{
			return false;
		}
		if (!Utils.IsEqual(m_referencedNodeIds, nodeReference.m_referencedNodeIds))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (NodeReference)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		NodeReference obj = (NodeReference)base.MemberwiseClone();
		obj.m_nodeId = (NodeId)Utils.Clone(m_nodeId);
		obj.m_referenceTypeId = (NodeId)Utils.Clone(m_referenceTypeId);
		obj.m_isForward = (bool)Utils.Clone(m_isForward);
		obj.m_referencedNodeIds = (NodeIdCollection)Utils.Clone(m_referencedNodeIds);
		return obj;
	}
}
