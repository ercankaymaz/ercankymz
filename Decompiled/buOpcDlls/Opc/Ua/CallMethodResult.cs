using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class CallMethodResult : IEncodeable, ICloneable, IJsonEncodeable
{
	private StatusCode m_statusCode;

	private StatusCodeCollection m_inputArgumentResults;

	private DiagnosticInfoCollection m_inputArgumentDiagnosticInfos;

	private VariantCollection m_outputArguments;

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

	[DataMember(Name = "InputArgumentResults", IsRequired = false, Order = 2)]
	public StatusCodeCollection InputArgumentResults
	{
		get
		{
			return m_inputArgumentResults;
		}
		set
		{
			m_inputArgumentResults = value;
			if (value == null)
			{
				m_inputArgumentResults = new StatusCodeCollection();
			}
		}
	}

	[DataMember(Name = "InputArgumentDiagnosticInfos", IsRequired = false, Order = 3)]
	public DiagnosticInfoCollection InputArgumentDiagnosticInfos
	{
		get
		{
			return m_inputArgumentDiagnosticInfos;
		}
		set
		{
			m_inputArgumentDiagnosticInfos = value;
			if (value == null)
			{
				m_inputArgumentDiagnosticInfos = new DiagnosticInfoCollection();
			}
		}
	}

	[DataMember(Name = "OutputArguments", IsRequired = false, Order = 4)]
	public VariantCollection OutputArguments
	{
		get
		{
			return m_outputArguments;
		}
		set
		{
			m_outputArguments = value;
			if (value == null)
			{
				m_outputArguments = new VariantCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.CallMethodResult;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.CallMethodResult_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.CallMethodResult_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.CallMethodResult_Encoding_DefaultJson;

	public CallMethodResult()
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
		m_inputArgumentResults = new StatusCodeCollection();
		m_inputArgumentDiagnosticInfos = new DiagnosticInfoCollection();
		m_outputArguments = new VariantCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteStatusCode("StatusCode", StatusCode);
		encoder.WriteStatusCodeArray("InputArgumentResults", InputArgumentResults);
		encoder.WriteDiagnosticInfoArray("InputArgumentDiagnosticInfos", InputArgumentDiagnosticInfos);
		encoder.WriteVariantArray("OutputArguments", OutputArguments);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		StatusCode = decoder.ReadStatusCode("StatusCode");
		InputArgumentResults = decoder.ReadStatusCodeArray("InputArgumentResults");
		InputArgumentDiagnosticInfos = decoder.ReadDiagnosticInfoArray("InputArgumentDiagnosticInfos");
		OutputArguments = decoder.ReadVariantArray("OutputArguments");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is CallMethodResult callMethodResult))
		{
			return false;
		}
		if (!Utils.IsEqual(m_statusCode, callMethodResult.m_statusCode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_inputArgumentResults, callMethodResult.m_inputArgumentResults))
		{
			return false;
		}
		if (!Utils.IsEqual(m_inputArgumentDiagnosticInfos, callMethodResult.m_inputArgumentDiagnosticInfos))
		{
			return false;
		}
		if (!Utils.IsEqual(m_outputArguments, callMethodResult.m_outputArguments))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (CallMethodResult)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		CallMethodResult obj = (CallMethodResult)base.MemberwiseClone();
		obj.m_statusCode = (StatusCode)Utils.Clone(m_statusCode);
		obj.m_inputArgumentResults = (StatusCodeCollection)Utils.Clone(m_inputArgumentResults);
		obj.m_inputArgumentDiagnosticInfos = (DiagnosticInfoCollection)Utils.Clone(m_inputArgumentDiagnosticInfos);
		obj.m_outputArguments = (VariantCollection)Utils.Clone(m_outputArguments);
		return obj;
	}
}
