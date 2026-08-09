using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class HistoryUpdateResult : IEncodeable, ICloneable, IJsonEncodeable
{
	private StatusCode m_statusCode;

	private StatusCodeCollection m_operationResults;

	private DiagnosticInfoCollection m_diagnosticInfos;

	[DataMember(Name = "StatusCode", IsRequired = false, Order = 1)]
	public StatusCode StatusCode
	{
		get
		{
			return m_statusCode;
		}
		set
		{
			m_statusCode = value;
		}
	}

	[DataMember(Name = "OperationResults", IsRequired = false, Order = 2)]
	public StatusCodeCollection OperationResults
	{
		get
		{
			return m_operationResults;
		}
		set
		{
			m_operationResults = value;
			if (value == null)
			{
				m_operationResults = new StatusCodeCollection();
			}
		}
	}

	[DataMember(Name = "DiagnosticInfos", IsRequired = false, Order = 3)]
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.HistoryUpdateResult;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.HistoryUpdateResult_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.HistoryUpdateResult_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.HistoryUpdateResult_Encoding_DefaultJson;

	public HistoryUpdateResult()
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
		m_statusCode = 0u;
		m_operationResults = new StatusCodeCollection();
		m_diagnosticInfos = new DiagnosticInfoCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteStatusCode("StatusCode", StatusCode);
		encoder.WriteStatusCodeArray("OperationResults", OperationResults);
		encoder.WriteDiagnosticInfoArray("DiagnosticInfos", DiagnosticInfos);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		StatusCode = decoder.ReadStatusCode("StatusCode");
		OperationResults = decoder.ReadStatusCodeArray("OperationResults");
		DiagnosticInfos = decoder.ReadDiagnosticInfoArray("DiagnosticInfos");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is HistoryUpdateResult historyUpdateResult))
		{
			return false;
		}
		if (!Utils.IsEqual(m_statusCode, historyUpdateResult.m_statusCode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_operationResults, historyUpdateResult.m_operationResults))
		{
			return false;
		}
		if (!Utils.IsEqual(m_diagnosticInfos, historyUpdateResult.m_diagnosticInfos))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (HistoryUpdateResult)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		HistoryUpdateResult obj = (HistoryUpdateResult)base.MemberwiseClone();
		obj.m_statusCode = (StatusCode)Utils.Clone(m_statusCode);
		obj.m_operationResults = (StatusCodeCollection)Utils.Clone(m_operationResults);
		obj.m_diagnosticInfos = (DiagnosticInfoCollection)Utils.Clone(m_diagnosticInfos);
		return obj;
	}
}
