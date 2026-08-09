using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DeleteReferencesItem : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_sourceNodeId;

	private NodeId m_referenceTypeId;

	private bool m_isForward;

	private ExpandedNodeId m_targetNodeId;

	private bool m_deleteBidirectional;

	[DataMember(Name = "SourceNodeId", IsRequired = false, Order = 1)]
	public NodeId SourceNodeId
	{
		get
		{
			return m_sourceNodeId;
		}
		set
		{
			m_sourceNodeId = value;
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

	[DataMember(Name = "TargetNodeId", IsRequired = false, Order = 4)]
	public ExpandedNodeId TargetNodeId
	{
		get
		{
			return m_targetNodeId;
		}
		set
		{
			m_targetNodeId = value;
		}
	}

	[DataMember(Name = "DeleteBidirectional", IsRequired = false, Order = 5)]
	public bool DeleteBidirectional
	{
		get
		{
			return m_deleteBidirectional;
		}
		set
		{
			m_deleteBidirectional = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.DeleteReferencesItem;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.DeleteReferencesItem_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.DeleteReferencesItem_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.DeleteReferencesItem_Encoding_DefaultJson;

	public DeleteReferencesItem()
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
		m_sourceNodeId = null;
		m_referenceTypeId = null;
		m_isForward = true;
		m_targetNodeId = null;
		m_deleteBidirectional = true;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("SourceNodeId", SourceNodeId);
		encoder.WriteNodeId("ReferenceTypeId", ReferenceTypeId);
		encoder.WriteBoolean("IsForward", IsForward);
		encoder.WriteExpandedNodeId("TargetNodeId", TargetNodeId);
		encoder.WriteBoolean("DeleteBidirectional", DeleteBidirectional);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		SourceNodeId = decoder.ReadNodeId("SourceNodeId");
		ReferenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
		IsForward = decoder.ReadBoolean("IsForward");
		TargetNodeId = decoder.ReadExpandedNodeId("TargetNodeId");
		DeleteBidirectional = decoder.ReadBoolean("DeleteBidirectional");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DeleteReferencesItem deleteReferencesItem))
		{
			return false;
		}
		if (!Utils.IsEqual(m_sourceNodeId, deleteReferencesItem.m_sourceNodeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_referenceTypeId, deleteReferencesItem.m_referenceTypeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_isForward, deleteReferencesItem.m_isForward))
		{
			return false;
		}
		if (!Utils.IsEqual(m_targetNodeId, deleteReferencesItem.m_targetNodeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_deleteBidirectional, deleteReferencesItem.m_deleteBidirectional))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (DeleteReferencesItem)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DeleteReferencesItem obj = (DeleteReferencesItem)base.MemberwiseClone();
		obj.m_sourceNodeId = (NodeId)Utils.Clone(m_sourceNodeId);
		obj.m_referenceTypeId = (NodeId)Utils.Clone(m_referenceTypeId);
		obj.m_isForward = (bool)Utils.Clone(m_isForward);
		obj.m_targetNodeId = (ExpandedNodeId)Utils.Clone(m_targetNodeId);
		obj.m_deleteBidirectional = (bool)Utils.Clone(m_deleteBidirectional);
		return obj;
	}
}
