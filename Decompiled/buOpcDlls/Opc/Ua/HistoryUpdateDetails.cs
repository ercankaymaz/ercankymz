using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class HistoryUpdateDetails : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_nodeId;

	private object m_handle;

	private bool m_processed;

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

	public virtual ExpandedNodeId TypeId => DataTypeIds.HistoryUpdateDetails;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.HistoryUpdateDetails_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.HistoryUpdateDetails_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.HistoryUpdateDetails_Encoding_DefaultJson;

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

	public bool Processed
	{
		get
		{
			return m_processed;
		}
		set
		{
			m_processed = value;
		}
	}

	public HistoryUpdateDetails()
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
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("NodeId", NodeId);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NodeId = decoder.ReadNodeId("NodeId");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is HistoryUpdateDetails historyUpdateDetails))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodeId, historyUpdateDetails.m_nodeId))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (HistoryUpdateDetails)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		HistoryUpdateDetails obj = (HistoryUpdateDetails)base.MemberwiseClone();
		obj.m_nodeId = (NodeId)Utils.Clone(m_nodeId);
		return obj;
	}

	public static ServiceResult Validate(HistoryUpdateDetails valueId)
	{
		if (valueId == null)
		{
			return 2152071168u;
		}
		if (NodeId.IsNull(valueId.NodeId))
		{
			return 2150825984u;
		}
		return null;
	}
}
