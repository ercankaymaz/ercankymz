using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class QueryNextResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
	private ResponseHeader m_responseHeader;

	private QueryDataSetCollection m_queryDataSets;

	private byte[] m_revisedContinuationPoint;

	[DataMember(Name = "ResponseHeader", IsRequired = false, Order = 1)]
	public ResponseHeader ResponseHeader
	{
		get
		{
			return m_responseHeader;
		}
		set
		{
			m_responseHeader = value;
			if (value == null)
			{
				m_responseHeader = new ResponseHeader();
			}
		}
	}

	[DataMember(Name = "QueryDataSets", IsRequired = false, Order = 2)]
	public QueryDataSetCollection QueryDataSets
	{
		get
		{
			return m_queryDataSets;
		}
		set
		{
			m_queryDataSets = value;
			if (value == null)
			{
				m_queryDataSets = new QueryDataSetCollection();
			}
		}
	}

	[DataMember(Name = "RevisedContinuationPoint", IsRequired = false, Order = 3)]
	public byte[] RevisedContinuationPoint
	{
		get
		{
			return m_revisedContinuationPoint;
		}
		set
		{
			m_revisedContinuationPoint = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.QueryNextResponse;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.QueryNextResponse_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.QueryNextResponse_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.QueryNextResponse_Encoding_DefaultJson;

	public QueryNextResponse()
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
		m_responseHeader = new ResponseHeader();
		m_queryDataSets = new QueryDataSetCollection();
		m_revisedContinuationPoint = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("ResponseHeader", ResponseHeader, typeof(ResponseHeader));
		encoder.WriteEncodeableArray("QueryDataSets", QueryDataSets.ToArray(), typeof(QueryDataSet));
		encoder.WriteByteString("RevisedContinuationPoint", RevisedContinuationPoint);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ResponseHeader = (ResponseHeader)decoder.ReadEncodeable("ResponseHeader", typeof(ResponseHeader));
		QueryDataSets = (QueryDataSet[])decoder.ReadEncodeableArray("QueryDataSets", typeof(QueryDataSet));
		RevisedContinuationPoint = decoder.ReadByteString("RevisedContinuationPoint");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is QueryNextResponse queryNextResponse))
		{
			return false;
		}
		if (!Utils.IsEqual(m_responseHeader, queryNextResponse.m_responseHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_queryDataSets, queryNextResponse.m_queryDataSets))
		{
			return false;
		}
		if (!Utils.IsEqual(m_revisedContinuationPoint, queryNextResponse.m_revisedContinuationPoint))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (QueryNextResponse)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		QueryNextResponse obj = (QueryNextResponse)base.MemberwiseClone();
		obj.m_responseHeader = (ResponseHeader)Utils.Clone(m_responseHeader);
		obj.m_queryDataSets = (QueryDataSetCollection)Utils.Clone(m_queryDataSets);
		obj.m_revisedContinuationPoint = (byte[])Utils.Clone(m_revisedContinuationPoint);
		return obj;
	}
}
