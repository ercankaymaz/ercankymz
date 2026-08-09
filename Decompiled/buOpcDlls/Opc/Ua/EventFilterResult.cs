using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class EventFilterResult : MonitoringFilterResult
{
	private StatusCodeCollection m_selectClauseResults;

	private DiagnosticInfoCollection m_selectClauseDiagnosticInfos;

	private ContentFilterResult m_whereClauseResult;

	[DataMember(Name = "SelectClauseResults", IsRequired = false, Order = 1)]
	public StatusCodeCollection SelectClauseResults
	{
		get
		{
			return m_selectClauseResults;
		}
		set
		{
			m_selectClauseResults = value;
			if (value == null)
			{
				m_selectClauseResults = new StatusCodeCollection();
			}
		}
	}

	[DataMember(Name = "SelectClauseDiagnosticInfos", IsRequired = false, Order = 2)]
	public DiagnosticInfoCollection SelectClauseDiagnosticInfos
	{
		get
		{
			return m_selectClauseDiagnosticInfos;
		}
		set
		{
			m_selectClauseDiagnosticInfos = value;
			if (value == null)
			{
				m_selectClauseDiagnosticInfos = new DiagnosticInfoCollection();
			}
		}
	}

	[DataMember(Name = "WhereClauseResult", IsRequired = false, Order = 3)]
	public ContentFilterResult WhereClauseResult
	{
		get
		{
			return m_whereClauseResult;
		}
		set
		{
			m_whereClauseResult = value;
			if (value == null)
			{
				m_whereClauseResult = new ContentFilterResult();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.EventFilterResult;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.EventFilterResult_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.EventFilterResult_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.EventFilterResult_Encoding_DefaultJson;

	public EventFilterResult()
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
		m_selectClauseResults = new StatusCodeCollection();
		m_selectClauseDiagnosticInfos = new DiagnosticInfoCollection();
		m_whereClauseResult = new ContentFilterResult();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteStatusCodeArray("SelectClauseResults", SelectClauseResults);
		encoder.WriteDiagnosticInfoArray("SelectClauseDiagnosticInfos", SelectClauseDiagnosticInfos);
		encoder.WriteEncodeable("WhereClauseResult", WhereClauseResult, typeof(ContentFilterResult));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		SelectClauseResults = decoder.ReadStatusCodeArray("SelectClauseResults");
		SelectClauseDiagnosticInfos = decoder.ReadDiagnosticInfoArray("SelectClauseDiagnosticInfos");
		WhereClauseResult = (ContentFilterResult)decoder.ReadEncodeable("WhereClauseResult", typeof(ContentFilterResult));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is EventFilterResult eventFilterResult))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_selectClauseResults, eventFilterResult.m_selectClauseResults))
		{
			return false;
		}
		if (!Utils.IsEqual(m_selectClauseDiagnosticInfos, eventFilterResult.m_selectClauseDiagnosticInfos))
		{
			return false;
		}
		if (!Utils.IsEqual(m_whereClauseResult, eventFilterResult.m_whereClauseResult))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (EventFilterResult)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EventFilterResult obj = (EventFilterResult)base.MemberwiseClone();
		obj.m_selectClauseResults = (StatusCodeCollection)Utils.Clone(m_selectClauseResults);
		obj.m_selectClauseDiagnosticInfos = (DiagnosticInfoCollection)Utils.Clone(m_selectClauseDiagnosticInfos);
		obj.m_whereClauseResult = (ContentFilterResult)Utils.Clone(m_whereClauseResult);
		return obj;
	}
}
