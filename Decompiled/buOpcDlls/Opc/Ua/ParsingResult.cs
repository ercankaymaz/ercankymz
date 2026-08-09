using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ParsingResult : IEncodeable, ICloneable, IJsonEncodeable
{
	private StatusCode m_statusCode;

	private StatusCodeCollection m_dataStatusCodes;

	private DiagnosticInfoCollection m_dataDiagnosticInfos;

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

	[DataMember(Name = "DataStatusCodes", IsRequired = false, Order = 2)]
	public StatusCodeCollection DataStatusCodes
	{
		get
		{
			return m_dataStatusCodes;
		}
		set
		{
			m_dataStatusCodes = value;
			if (value == null)
			{
				m_dataStatusCodes = new StatusCodeCollection();
			}
		}
	}

	[DataMember(Name = "DataDiagnosticInfos", IsRequired = false, Order = 3)]
	public DiagnosticInfoCollection DataDiagnosticInfos
	{
		get
		{
			return m_dataDiagnosticInfos;
		}
		set
		{
			m_dataDiagnosticInfos = value;
			if (value == null)
			{
				m_dataDiagnosticInfos = new DiagnosticInfoCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ParsingResult;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ParsingResult_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ParsingResult_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ParsingResult_Encoding_DefaultJson;

	public ParsingResult()
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
		m_dataStatusCodes = new StatusCodeCollection();
		m_dataDiagnosticInfos = new DiagnosticInfoCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteStatusCode("StatusCode", StatusCode);
		encoder.WriteStatusCodeArray("DataStatusCodes", DataStatusCodes);
		encoder.WriteDiagnosticInfoArray("DataDiagnosticInfos", DataDiagnosticInfos);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		StatusCode = decoder.ReadStatusCode("StatusCode");
		DataStatusCodes = decoder.ReadStatusCodeArray("DataStatusCodes");
		DataDiagnosticInfos = decoder.ReadDiagnosticInfoArray("DataDiagnosticInfos");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ParsingResult parsingResult))
		{
			return false;
		}
		if (!Utils.IsEqual(m_statusCode, parsingResult.m_statusCode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataStatusCodes, parsingResult.m_dataStatusCodes))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataDiagnosticInfos, parsingResult.m_dataDiagnosticInfos))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ParsingResult)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ParsingResult obj = (ParsingResult)base.MemberwiseClone();
		obj.m_statusCode = (StatusCode)Utils.Clone(m_statusCode);
		obj.m_dataStatusCodes = (StatusCodeCollection)Utils.Clone(m_dataStatusCodes);
		obj.m_dataDiagnosticInfos = (DiagnosticInfoCollection)Utils.Clone(m_dataDiagnosticInfos);
		return obj;
	}
}
