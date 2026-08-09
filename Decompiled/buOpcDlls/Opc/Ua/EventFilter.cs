using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class EventFilter : MonitoringFilter
{
	public class Result
	{
		private ServiceResult m_status;

		private List<ServiceResult> m_selectClauseResults;

		private ContentFilter.Result m_whereClauseResults;

		public ServiceResult Status
		{
			get
			{
				return m_status;
			}
			set
			{
				m_status = value;
			}
		}

		public List<ServiceResult> SelectClauseResults
		{
			get
			{
				if (m_selectClauseResults == null)
				{
					m_selectClauseResults = new List<ServiceResult>();
				}
				return m_selectClauseResults;
			}
		}

		public ContentFilter.Result WhereClauseResult
		{
			get
			{
				return m_whereClauseResults;
			}
			internal set
			{
				m_whereClauseResults = value;
			}
		}

		public static implicit operator Result(ServiceResult status)
		{
			return new Result
			{
				Status = status
			};
		}

		public string GetLongString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (ServiceResult selectClauseResult in SelectClauseResults)
			{
				if (ServiceResult.IsBad(selectClauseResult))
				{
					stringBuilder.AppendFormat("Select Clause Error: {0}", selectClauseResult.ToString());
					stringBuilder.AppendLine();
				}
			}
			if (ServiceResult.IsBad(WhereClauseResult.Status))
			{
				stringBuilder.AppendFormat("Where Clause Error: {0}", WhereClauseResult.Status.ToString());
				stringBuilder.AppendLine();
				foreach (ContentFilter.ElementResult elementResult in WhereClauseResult.ElementResults)
				{
					if (elementResult == null || !ServiceResult.IsBad(elementResult.Status))
					{
						continue;
					}
					stringBuilder.AppendFormat("Element Error: {0}", elementResult.Status.ToString());
					stringBuilder.AppendLine();
					foreach (ServiceResult operandResult in elementResult.OperandResults)
					{
						if (ServiceResult.IsBad(operandResult))
						{
							stringBuilder.AppendFormat("Operand Error: {0}", operandResult.ToString());
							stringBuilder.AppendLine();
						}
					}
				}
			}
			return stringBuilder.ToString();
		}

		public EventFilterResult ToEventFilterResult(DiagnosticsMasks diagnosticsMasks, StringTable stringTable)
		{
			EventFilterResult eventFilterResult = new EventFilterResult();
			if (m_selectClauseResults != null && m_selectClauseResults.Count > 0)
			{
				foreach (ServiceResult selectClauseResult in m_selectClauseResults)
				{
					if (ServiceResult.IsBad(selectClauseResult))
					{
						eventFilterResult.SelectClauseResults.Add(selectClauseResult.StatusCode);
						eventFilterResult.SelectClauseDiagnosticInfos.Add(new DiagnosticInfo(selectClauseResult, diagnosticsMasks, serviceLevel: false, stringTable));
					}
					else
					{
						eventFilterResult.SelectClauseResults.Add(0u);
						eventFilterResult.SelectClauseDiagnosticInfos.Add(null);
					}
				}
			}
			if (m_whereClauseResults != null)
			{
				eventFilterResult.WhereClauseResult = m_whereClauseResults.ToContextFilterResult(diagnosticsMasks, stringTable);
			}
			return eventFilterResult;
		}
	}

	private SimpleAttributeOperandCollection m_selectClauses;

	private ContentFilter m_whereClause;

	[DataMember(Name = "SelectClauses", IsRequired = false, Order = 1)]
	public SimpleAttributeOperandCollection SelectClauses
	{
		get
		{
			return m_selectClauses;
		}
		set
		{
			m_selectClauses = value;
			if (value == null)
			{
				m_selectClauses = new SimpleAttributeOperandCollection();
			}
		}
	}

	[DataMember(Name = "WhereClause", IsRequired = false, Order = 2)]
	public ContentFilter WhereClause
	{
		get
		{
			return m_whereClause;
		}
		set
		{
			m_whereClause = value;
			if (value == null)
			{
				m_whereClause = new ContentFilter();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.EventFilter;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.EventFilter_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.EventFilter_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.EventFilter_Encoding_DefaultJson;

	public EventFilter()
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
		m_selectClauses = new SimpleAttributeOperandCollection();
		m_whereClause = new ContentFilter();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeableArray("SelectClauses", SelectClauses.ToArray(), typeof(SimpleAttributeOperand));
		encoder.WriteEncodeable("WhereClause", WhereClause, typeof(ContentFilter));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		SelectClauses = (SimpleAttributeOperand[])decoder.ReadEncodeableArray("SelectClauses", typeof(SimpleAttributeOperand));
		WhereClause = (ContentFilter)decoder.ReadEncodeable("WhereClause", typeof(ContentFilter));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is EventFilter eventFilter))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_selectClauses, eventFilter.m_selectClauses))
		{
			return false;
		}
		if (!Utils.IsEqual(m_whereClause, eventFilter.m_whereClause))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (EventFilter)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EventFilter obj = (EventFilter)base.MemberwiseClone();
		obj.m_selectClauses = (SimpleAttributeOperandCollection)Utils.Clone(m_selectClauses);
		obj.m_whereClause = (ContentFilter)Utils.Clone(m_whereClause);
		return obj;
	}

	public void AddSelectClause(NodeId eventTypeId, QualifiedName propertyName)
	{
		SimpleAttributeOperand simpleAttributeOperand = new SimpleAttributeOperand();
		simpleAttributeOperand.TypeDefinitionId = eventTypeId;
		simpleAttributeOperand.AttributeId = 13u;
		simpleAttributeOperand.BrowsePath.Add(propertyName);
		SelectClauses.Add(simpleAttributeOperand);
	}

	public void AddSelectClause(NodeId eventTypeId, string browsePath, uint attributeId)
	{
		SimpleAttributeOperand simpleAttributeOperand = new SimpleAttributeOperand();
		simpleAttributeOperand.TypeDefinitionId = eventTypeId;
		simpleAttributeOperand.AttributeId = attributeId;
		if (!string.IsNullOrEmpty(browsePath))
		{
			simpleAttributeOperand.BrowsePath = SimpleAttributeOperand.Parse(browsePath);
		}
		SelectClauses.Add(simpleAttributeOperand);
	}

	public Result Validate(FilterContext context)
	{
		Result result = new Result();
		if (m_selectClauses == null || m_selectClauses.Count == 0)
		{
			result.Status = ServiceResult.Create(2152071168u, "EventFilter does not specify any Select Clauses.");
			return result;
		}
		if (m_whereClause == null)
		{
			result.Status = ServiceResult.Create(2152071168u, "EventFilter does not specify any Where Clauses.");
			return result;
		}
		result.Status = ServiceResult.Good;
		bool flag = false;
		foreach (SimpleAttributeOperand selectClause in m_selectClauses)
		{
			ServiceResult serviceResult = null;
			if (selectClause == null)
			{
				serviceResult = ServiceResult.Create(2152071168u, "EventFilterSelectClause cannot be null in EventFilter SelectClause.");
				result.SelectClauseResults.Add(serviceResult);
				flag = true;
				continue;
			}
			serviceResult = selectClause.Validate(context, 0);
			if (ServiceResult.IsBad(serviceResult))
			{
				result.SelectClauseResults.Add(serviceResult);
				flag = true;
			}
			else
			{
				result.SelectClauseResults.Add(null);
			}
		}
		if (flag)
		{
			result.Status = 2152136704u;
		}
		else
		{
			result.SelectClauseResults.Clear();
		}
		result.WhereClauseResult = m_whereClause.Validate(context);
		if (ServiceResult.IsBad(result.WhereClauseResult.Status))
		{
			result.Status = 2152136704u;
		}
		return result;
	}
}
