using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class QueryFirstResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
	private ResponseHeader m_responseHeader;

	private QueryDataSetCollection m_queryDataSets;

	private byte[] m_continuationPoint;

	private ParsingResultCollection m_parsingResults;

	private DiagnosticInfoCollection m_diagnosticInfos;

	private ContentFilterResult m_filterResult;

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

	[DataMember(Name = "ContinuationPoint", IsRequired = false, Order = 3)]
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

	[DataMember(Name = "ParsingResults", IsRequired = false, Order = 4)]
	public ParsingResultCollection ParsingResults
	{
		get
		{
			return m_parsingResults;
		}
		set
		{
			m_parsingResults = value;
			if (value == null)
			{
				m_parsingResults = new ParsingResultCollection();
			}
		}
	}

	[DataMember(Name = "DiagnosticInfos", IsRequired = false, Order = 5)]
	public DiagnosticInfoCollection DiagnosticInfos
	{
		get
		{
			return m_diagnosticInfos;
		}
		set
		{
			m_diagnosticInfos = value;
			if (value == null)
			{
				m_diagnosticInfos = new DiagnosticInfoCollection();
			}
		}
	}

	[DataMember(Name = "FilterResult", IsRequired = false, Order = 6)]
	public ContentFilterResult FilterResult
	{
		get
		{
			return m_filterResult;
		}
		set
		{
			m_filterResult = value;
			if (value == null)
			{
				m_filterResult = new ContentFilterResult();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.QueryFirstResponse;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.QueryFirstResponse_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.QueryFirstResponse_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.QueryFirstResponse_Encoding_DefaultJson;

	public QueryFirstResponse()
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
		m_continuationPoint = null;
		m_parsingResults = new ParsingResultCollection();
		m_diagnosticInfos = new DiagnosticInfoCollection();
		m_filterResult = new ContentFilterResult();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("ResponseHeader", ResponseHeader, typeof(ResponseHeader));
		encoder.WriteEncodeableArray("QueryDataSets", QueryDataSets.ToArray(), typeof(QueryDataSet));
		encoder.WriteByteString("ContinuationPoint", ContinuationPoint);
		encoder.WriteEncodeableArray("ParsingResults", ParsingResults.ToArray(), typeof(ParsingResult));
		encoder.WriteDiagnosticInfoArray("DiagnosticInfos", DiagnosticInfos);
		encoder.WriteEncodeable("FilterResult", FilterResult, typeof(ContentFilterResult));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ResponseHeader = (ResponseHeader)decoder.ReadEncodeable("ResponseHeader", typeof(ResponseHeader));
		QueryDataSets = (QueryDataSet[])decoder.ReadEncodeableArray("QueryDataSets", typeof(QueryDataSet));
		ContinuationPoint = decoder.ReadByteString("ContinuationPoint");
		ParsingResults = (ParsingResult[])decoder.ReadEncodeableArray("ParsingResults", typeof(ParsingResult));
		DiagnosticInfos = decoder.ReadDiagnosticInfoArray("DiagnosticInfos");
		FilterResult = (ContentFilterResult)decoder.ReadEncodeable("FilterResult", typeof(ContentFilterResult));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is QueryFirstResponse queryFirstResponse))
		{
			return false;
		}
		if (!Utils.IsEqual(m_responseHeader, queryFirstResponse.m_responseHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_queryDataSets, queryFirstResponse.m_queryDataSets))
		{
			return false;
		}
		if (!Utils.IsEqual(m_continuationPoint, queryFirstResponse.m_continuationPoint))
		{
			return false;
		}
		if (!Utils.IsEqual(m_parsingResults, queryFirstResponse.m_parsingResults))
		{
			return false;
		}
		if (!Utils.IsEqual(m_diagnosticInfos, queryFirstResponse.m_diagnosticInfos))
		{
			return false;
		}
		if (!Utils.IsEqual(m_filterResult, queryFirstResponse.m_filterResult))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (QueryFirstResponse)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		QueryFirstResponse obj = (QueryFirstResponse)base.MemberwiseClone();
		obj.m_responseHeader = (ResponseHeader)Utils.Clone(m_responseHeader);
		obj.m_queryDataSets = (QueryDataSetCollection)Utils.Clone(m_queryDataSets);
		obj.m_continuationPoint = (byte[])Utils.Clone(m_continuationPoint);
		obj.m_parsingResults = (ParsingResultCollection)Utils.Clone(m_parsingResults);
		obj.m_diagnosticInfos = (DiagnosticInfoCollection)Utils.Clone(m_diagnosticInfos);
		obj.m_filterResult = (ContentFilterResult)Utils.Clone(m_filterResult);
		return obj;
	}
}
