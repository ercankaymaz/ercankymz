using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ReadResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
	private ResponseHeader m_responseHeader;

	private DataValueCollection m_results;

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

	[DataMember(Name = "Results", IsRequired = false, Order = 2)]
	public DataValueCollection Results
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
				m_results = new DataValueCollection();
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.ReadResponse;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ReadResponse_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ReadResponse_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ReadResponse_Encoding_DefaultJson;

	public ReadResponse()
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
		m_results = new DataValueCollection();
		m_diagnosticInfos = new DiagnosticInfoCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("ResponseHeader", ResponseHeader, typeof(ResponseHeader));
		encoder.WriteDataValueArray("Results", Results);
		encoder.WriteDiagnosticInfoArray("DiagnosticInfos", DiagnosticInfos);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ResponseHeader = (ResponseHeader)decoder.ReadEncodeable("ResponseHeader", typeof(ResponseHeader));
		Results = decoder.ReadDataValueArray("Results");
		DiagnosticInfos = decoder.ReadDiagnosticInfoArray("DiagnosticInfos");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ReadResponse readResponse))
		{
			return false;
		}
		if (!Utils.IsEqual(m_responseHeader, readResponse.m_responseHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_results, readResponse.m_results))
		{
			return false;
		}
		if (!Utils.IsEqual(m_diagnosticInfos, readResponse.m_diagnosticInfos))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ReadResponse)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ReadResponse obj = (ReadResponse)base.MemberwiseClone();
		obj.m_responseHeader = (ResponseHeader)Utils.Clone(m_responseHeader);
		obj.m_results = (DataValueCollection)Utils.Clone(m_results);
		obj.m_diagnosticInfos = (DiagnosticInfoCollection)Utils.Clone(m_diagnosticInfos);
		return obj;
	}
}
