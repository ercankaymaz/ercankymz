using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class StatusResult : IEncodeable, ICloneable, IJsonEncodeable
{
	private StatusCode m_statusCode;

	private DiagnosticInfo m_diagnosticInfo;

	private ServiceResult m_result;

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

	[DataMember(Name = "DiagnosticInfo", IsRequired = false, Order = 2)]
	public DiagnosticInfo DiagnosticInfo
	{
		get
		{
			return m_diagnosticInfo;
		}
		set
		{
			m_diagnosticInfo = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.StatusResult;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.StatusResult_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.StatusResult_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.StatusResult_Encoding_DefaultJson;

	public StatusResult()
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
		m_diagnosticInfo = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteStatusCode("StatusCode", StatusCode);
		encoder.WriteDiagnosticInfo("DiagnosticInfo", DiagnosticInfo);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		StatusCode = decoder.ReadStatusCode("StatusCode");
		DiagnosticInfo = decoder.ReadDiagnosticInfo("DiagnosticInfo");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is StatusResult statusResult))
		{
			return false;
		}
		if (!Utils.IsEqual(m_statusCode, statusResult.m_statusCode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_diagnosticInfo, statusResult.m_diagnosticInfo))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (StatusResult)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		StatusResult obj = (StatusResult)base.MemberwiseClone();
		obj.m_statusCode = (StatusCode)Utils.Clone(m_statusCode);
		obj.m_diagnosticInfo = (DiagnosticInfo)Utils.Clone(m_diagnosticInfo);
		return obj;
	}

	public StatusResult(ServiceResult result)
	{
		Initialize();
		m_result = result;
		if (result != null)
		{
			m_statusCode = result.StatusCode;
		}
	}

	public void ApplyDiagnosticMasks(DiagnosticsMasks diagnosticMasks, StringTable stringTable)
	{
		if (m_result != null)
		{
			m_statusCode = m_result.StatusCode;
			m_diagnosticInfo = new DiagnosticInfo(m_result, diagnosticMasks, serviceLevel: false, stringTable);
		}
	}
}
