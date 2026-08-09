using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ContentFilterElementResult : IEncodeable, ICloneable, IJsonEncodeable
{
	private StatusCode m_statusCode;

	private StatusCodeCollection m_operandStatusCodes;

	private DiagnosticInfoCollection m_operandDiagnosticInfos;

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

	[DataMember(Name = "OperandStatusCodes", IsRequired = false, Order = 2)]
	public StatusCodeCollection OperandStatusCodes
	{
		get
		{
			return m_operandStatusCodes;
		}
		set
		{
			m_operandStatusCodes = value;
			if (value == null)
			{
				m_operandStatusCodes = new StatusCodeCollection();
			}
		}
	}

	[DataMember(Name = "OperandDiagnosticInfos", IsRequired = false, Order = 3)]
	public DiagnosticInfoCollection OperandDiagnosticInfos
	{
		get
		{
			return m_operandDiagnosticInfos;
		}
		set
		{
			m_operandDiagnosticInfos = value;
			if (value == null)
			{
				m_operandDiagnosticInfos = new DiagnosticInfoCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ContentFilterElementResult;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ContentFilterElementResult_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ContentFilterElementResult_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ContentFilterElementResult_Encoding_DefaultJson;

	public ContentFilterElementResult()
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
		m_operandStatusCodes = new StatusCodeCollection();
		m_operandDiagnosticInfos = new DiagnosticInfoCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteStatusCode("StatusCode", StatusCode);
		encoder.WriteStatusCodeArray("OperandStatusCodes", OperandStatusCodes);
		encoder.WriteDiagnosticInfoArray("OperandDiagnosticInfos", OperandDiagnosticInfos);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		StatusCode = decoder.ReadStatusCode("StatusCode");
		OperandStatusCodes = decoder.ReadStatusCodeArray("OperandStatusCodes");
		OperandDiagnosticInfos = decoder.ReadDiagnosticInfoArray("OperandDiagnosticInfos");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ContentFilterElementResult contentFilterElementResult))
		{
			return false;
		}
		if (!Utils.IsEqual(m_statusCode, contentFilterElementResult.m_statusCode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_operandStatusCodes, contentFilterElementResult.m_operandStatusCodes))
		{
			return false;
		}
		if (!Utils.IsEqual(m_operandDiagnosticInfos, contentFilterElementResult.m_operandDiagnosticInfos))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ContentFilterElementResult)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ContentFilterElementResult obj = (ContentFilterElementResult)base.MemberwiseClone();
		obj.m_statusCode = (StatusCode)Utils.Clone(m_statusCode);
		obj.m_operandStatusCodes = (StatusCodeCollection)Utils.Clone(m_operandStatusCodes);
		obj.m_operandDiagnosticInfos = (DiagnosticInfoCollection)Utils.Clone(m_operandDiagnosticInfos);
		return obj;
	}
}
