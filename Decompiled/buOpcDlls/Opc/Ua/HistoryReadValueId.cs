using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class HistoryReadValueId : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_nodeId;

	private string m_indexRange;

	private QualifiedName m_dataEncoding;

	private byte[] m_continuationPoint;

	private object m_handle;

	private bool m_processed;

	private NumericRange m_parsedIndexRange;

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

	[DataMember(Name = "IndexRange", IsRequired = false, Order = 2)]
	public string IndexRange
	{
		get
		{
			return m_indexRange;
		}
		set
		{
			m_indexRange = value;
		}
	}

	[DataMember(Name = "DataEncoding", IsRequired = false, Order = 3)]
	public QualifiedName DataEncoding
	{
		get
		{
			return m_dataEncoding;
		}
		set
		{
			m_dataEncoding = value;
		}
	}

	[DataMember(Name = "ContinuationPoint", IsRequired = false, Order = 4)]
	public byte[] ContinuationPoint
	{
		get
		{
			return m_continuationPoint;
		}
		set
		{
			m_continuationPoint = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.HistoryReadValueId;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.HistoryReadValueId_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.HistoryReadValueId_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.HistoryReadValueId_Encoding_DefaultJson;

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

	public NumericRange ParsedIndexRange
	{
		get
		{
			return m_parsedIndexRange;
		}
		set
		{
			m_parsedIndexRange = value;
		}
	}

	public HistoryReadValueId()
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
		m_indexRange = null;
		m_dataEncoding = null;
		m_continuationPoint = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("NodeId", NodeId);
		encoder.WriteString("IndexRange", IndexRange);
		encoder.WriteQualifiedName("DataEncoding", DataEncoding);
		encoder.WriteByteString("ContinuationPoint", ContinuationPoint);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NodeId = decoder.ReadNodeId("NodeId");
		IndexRange = decoder.ReadString("IndexRange");
		DataEncoding = decoder.ReadQualifiedName("DataEncoding");
		ContinuationPoint = decoder.ReadByteString("ContinuationPoint");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is HistoryReadValueId historyReadValueId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodeId, historyReadValueId.m_nodeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_indexRange, historyReadValueId.m_indexRange))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataEncoding, historyReadValueId.m_dataEncoding))
		{
			return false;
		}
		if (!Utils.IsEqual(m_continuationPoint, historyReadValueId.m_continuationPoint))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (HistoryReadValueId)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		HistoryReadValueId obj = (HistoryReadValueId)base.MemberwiseClone();
		obj.m_nodeId = (NodeId)Utils.Clone(m_nodeId);
		obj.m_indexRange = (string)Utils.Clone(m_indexRange);
		obj.m_dataEncoding = (QualifiedName)Utils.Clone(m_dataEncoding);
		obj.m_continuationPoint = (byte[])Utils.Clone(m_continuationPoint);
		return obj;
	}

	public static ServiceResult Validate(HistoryReadValueId valueId)
	{
		if (valueId == null)
		{
			return 2152071168u;
		}
		if (NodeId.IsNull(valueId.NodeId))
		{
			return 2150825984u;
		}
		valueId.ParsedIndexRange = NumericRange.Empty;
		if (!string.IsNullOrEmpty(valueId.IndexRange))
		{
			try
			{
				valueId.ParsedIndexRange = NumericRange.Parse(valueId.IndexRange);
			}
			catch (Exception e)
			{
				return ServiceResult.Create(e, 2151022592u, string.Empty);
			}
		}
		else
		{
			valueId.ParsedIndexRange = NumericRange.Empty;
		}
		return null;
	}
}
