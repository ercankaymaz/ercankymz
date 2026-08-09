using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ActivateSessionResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
	private ResponseHeader m_responseHeader;

	private byte[] m_serverNonce;

	private StatusCodeCollection m_results;

	private DiagnosticInfoCollection m_diagnosticInfos;

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

	[DataMember(Name = "ServerNonce", IsRequired = false, Order = 2)]
	public byte[] ServerNonce
	{
		get
		{
			return m_serverNonce;
		}
		set
		{
			m_serverNonce = value;
		}
	}

	[DataMember(Name = "Results", IsRequired = false, Order = 3)]
	public StatusCodeCollection Results
	{
		get
		{
			return m_results;
		}
		set
		{
			m_results = value;
			if (value == null)
			{
				m_results = new StatusCodeCollection();
			}
		}
	}

	[DataMember(Name = "DiagnosticInfos", IsRequired = false, Order = 4)]
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.ActivateSessionResponse;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ActivateSessionResponse_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ActivateSessionResponse_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ActivateSessionResponse_Encoding_DefaultJson;

	public ActivateSessionResponse()
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
		m_serverNonce = null;
		m_results = new StatusCodeCollection();
		m_diagnosticInfos = new DiagnosticInfoCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("ResponseHeader", ResponseHeader, typeof(ResponseHeader));
		encoder.WriteByteString("ServerNonce", ServerNonce);
		encoder.WriteStatusCodeArray("Results", Results);
		encoder.WriteDiagnosticInfoArray("DiagnosticInfos", DiagnosticInfos);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ResponseHeader = (ResponseHeader)decoder.ReadEncodeable("ResponseHeader", typeof(ResponseHeader));
		ServerNonce = decoder.ReadByteString("ServerNonce");
		Results = decoder.ReadStatusCodeArray("Results");
		DiagnosticInfos = decoder.ReadDiagnosticInfoArray("DiagnosticInfos");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ActivateSessionResponse activateSessionResponse))
		{
			return false;
		}
		if (!Utils.IsEqual(m_responseHeader, activateSessionResponse.m_responseHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverNonce, activateSessionResponse.m_serverNonce))
		{
			return false;
		}
		if (!Utils.IsEqual(m_results, activateSessionResponse.m_results))
		{
			return false;
		}
		if (!Utils.IsEqual(m_diagnosticInfos, activateSessionResponse.m_diagnosticInfos))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ActivateSessionResponse)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ActivateSessionResponse obj = (ActivateSessionResponse)base.MemberwiseClone();
		obj.m_responseHeader = (ResponseHeader)Utils.Clone(m_responseHeader);
		obj.m_serverNonce = (byte[])Utils.Clone(m_serverNonce);
		obj.m_results = (StatusCodeCollection)Utils.Clone(m_results);
		obj.m_diagnosticInfos = (DiagnosticInfoCollection)Utils.Clone(m_diagnosticInfos);
		return obj;
	}
}
