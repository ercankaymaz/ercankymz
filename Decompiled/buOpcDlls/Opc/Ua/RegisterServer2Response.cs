using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class RegisterServer2Response : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
	private ResponseHeader m_responseHeader;

	private StatusCodeCollection m_configurationResults;

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

	[DataMember(Name = "ConfigurationResults", IsRequired = false, Order = 2)]
	public StatusCodeCollection ConfigurationResults
	{
		get
		{
			return m_configurationResults;
		}
		set
		{
			m_configurationResults = value;
			if (value == null)
			{
				m_configurationResults = new StatusCodeCollection();
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.RegisterServer2Response;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.RegisterServer2Response_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.RegisterServer2Response_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.RegisterServer2Response_Encoding_DefaultJson;

	public RegisterServer2Response()
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
		m_configurationResults = new StatusCodeCollection();
		m_diagnosticInfos = new DiagnosticInfoCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("ResponseHeader", ResponseHeader, typeof(ResponseHeader));
		encoder.WriteStatusCodeArray("ConfigurationResults", ConfigurationResults);
		encoder.WriteDiagnosticInfoArray("DiagnosticInfos", DiagnosticInfos);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ResponseHeader = (ResponseHeader)decoder.ReadEncodeable("ResponseHeader", typeof(ResponseHeader));
		ConfigurationResults = decoder.ReadStatusCodeArray("ConfigurationResults");
		DiagnosticInfos = decoder.ReadDiagnosticInfoArray("DiagnosticInfos");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is RegisterServer2Response registerServer2Response))
		{
			return false;
		}
		if (!Utils.IsEqual(m_responseHeader, registerServer2Response.m_responseHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_configurationResults, registerServer2Response.m_configurationResults))
		{
			return false;
		}
		if (!Utils.IsEqual(m_diagnosticInfos, registerServer2Response.m_diagnosticInfos))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (RegisterServer2Response)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		RegisterServer2Response obj = (RegisterServer2Response)base.MemberwiseClone();
		obj.m_responseHeader = (ResponseHeader)Utils.Clone(m_responseHeader);
		obj.m_configurationResults = (StatusCodeCollection)Utils.Clone(m_configurationResults);
		obj.m_diagnosticInfos = (DiagnosticInfoCollection)Utils.Clone(m_diagnosticInfos);
		return obj;
	}
}
