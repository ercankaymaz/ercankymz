using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class AddReferencesItem : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_sourceNodeId;

	private NodeId m_referenceTypeId;

	private bool m_isForward;

	private string m_targetServerUri;

	private ExpandedNodeId m_targetNodeId;

	private NodeClass m_targetNodeClass;

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

	[DataMember(Name = "TargetServerUri", IsRequired = false, Order = 4)]
	public string TargetServerUri
	{
		get
		{
			return m_targetServerUri;
		}
		set
		{
			m_targetServerUri = value;
		}
	}

	[DataMember(Name = "TargetNodeId", IsRequired = false, Order = 5)]
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

	[DataMember(Name = "TargetNodeClass", IsRequired = false, Order = 6)]
	public NodeClass TargetNodeClass
	{
		get
		{
			return m_targetNodeClass;
		}
		set
		{
			m_targetNodeClass = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.AddReferencesItem;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.AddReferencesItem_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.AddReferencesItem_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.AddReferencesItem_Encoding_DefaultJson;

	public AddReferencesItem()
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
		m_targetServerUri = null;
		m_targetNodeId = null;
		m_targetNodeClass = NodeClass.Unspecified;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("SourceNodeId", SourceNodeId);
		encoder.WriteNodeId("ReferenceTypeId", ReferenceTypeId);
		encoder.WriteBoolean("IsForward", IsForward);
		encoder.WriteString("TargetServerUri", TargetServerUri);
		encoder.WriteExpandedNodeId("TargetNodeId", TargetNodeId);
		encoder.WriteEnumerated("TargetNodeClass", TargetNodeClass);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		SourceNodeId = decoder.ReadNodeId("SourceNodeId");
		ReferenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
		IsForward = decoder.ReadBoolean("IsForward");
		TargetServerUri = decoder.ReadString("TargetServerUri");
		TargetNodeId = decoder.ReadExpandedNodeId("TargetNodeId");
		TargetNodeClass = (NodeClass)(object)decoder.ReadEnumerated("TargetNodeClass", typeof(NodeClass));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is AddReferencesItem addReferencesItem))
		{
			return false;
		}
		if (!Utils.IsEqual(m_sourceNodeId, addReferencesItem.m_sourceNodeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_referenceTypeId, addReferencesItem.m_referenceTypeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_isForward, addReferencesItem.m_isForward))
		{
			return false;
		}
		if (!Utils.IsEqual(m_targetServerUri, addReferencesItem.m_targetServerUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_targetNodeId, addReferencesItem.m_targetNodeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_targetNodeClass, addReferencesItem.m_targetNodeClass))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (AddReferencesItem)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		AddReferencesItem obj = (AddReferencesItem)base.MemberwiseClone();
		obj.m_sourceNodeId = (NodeId)Utils.Clone(m_sourceNodeId);
		obj.m_referenceTypeId = (NodeId)Utils.Clone(m_referenceTypeId);
		obj.m_isForward = (bool)Utils.Clone(m_isForward);
		obj.m_targetServerUri = (string)Utils.Clone(m_targetServerUri);
		obj.m_targetNodeId = (ExpandedNodeId)Utils.Clone(m_targetNodeId);
		obj.m_targetNodeClass = (NodeClass)Utils.Clone(m_targetNodeClass);
		return obj;
	}
}
