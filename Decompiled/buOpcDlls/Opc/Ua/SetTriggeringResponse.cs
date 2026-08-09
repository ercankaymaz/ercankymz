using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class SetTriggeringResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
	private ResponseHeader m_responseHeader;

	private StatusCodeCollection m_addResults;

	private DiagnosticInfoCollection m_addDiagnosticInfos;

	private StatusCodeCollection m_removeResults;

	private DiagnosticInfoCollection m_removeDiagnosticInfos;

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

	[DataMember(Name = "AddResults", IsRequired = false, Order = 2)]
	public StatusCodeCollection AddResults
	{
		get
		{
			return m_addResults;
		}
		set
		{
			m_addResults = value;
			if (value == null)
			{
				m_addResults = new StatusCodeCollection();
			}
		}
	}

	[DataMember(Name = "AddDiagnosticInfos", IsRequired = false, Order = 3)]
	public DiagnosticInfoCollection AddDiagnosticInfos
	{
		get
		{
			return m_addDiagnosticInfos;
		}
		set
		{
			m_addDiagnosticInfos = value;
			if (value == null)
			{
				m_addDiagnosticInfos = new DiagnosticInfoCollection();
			}
		}
	}

	[DataMember(Name = "RemoveResults", IsRequired = false, Order = 4)]
	public StatusCodeCollection RemoveResults
	{
		get
		{
			return m_removeResults;
		}
		set
		{
			m_removeResults = value;
			if (value == null)
			{
				m_removeResults = new StatusCodeCollection();
			}
		}
	}

	[DataMember(Name = "RemoveDiagnosticInfos", IsRequired = false, Order = 5)]
	public DiagnosticInfoCollection RemoveDiagnosticInfos
	{
		get
		{
			return m_removeDiagnosticInfos;
		}
		set
		{
			m_removeDiagnosticInfos = value;
			if (value == null)
			{
				m_removeDiagnosticInfos = new DiagnosticInfoCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.SetTriggeringResponse;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.SetTriggeringResponse_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.SetTriggeringResponse_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.SetTriggeringResponse_Encoding_DefaultJson;

	public SetTriggeringResponse()
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
		m_addResults = new StatusCodeCollection();
		m_addDiagnosticInfos = new DiagnosticInfoCollection();
		m_removeResults = new StatusCodeCollection();
		m_removeDiagnosticInfos = new DiagnosticInfoCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("ResponseHeader", ResponseHeader, typeof(ResponseHeader));
		encoder.WriteStatusCodeArray("AddResults", AddResults);
		encoder.WriteDiagnosticInfoArray("AddDiagnosticInfos", AddDiagnosticInfos);
		encoder.WriteStatusCodeArray("RemoveResults", RemoveResults);
		encoder.WriteDiagnosticInfoArray("RemoveDiagnosticInfos", RemoveDiagnosticInfos);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ResponseHeader = (ResponseHeader)decoder.ReadEncodeable("ResponseHeader", typeof(ResponseHeader));
		AddResults = decoder.ReadStatusCodeArray("AddResults");
		AddDiagnosticInfos = decoder.ReadDiagnosticInfoArray("AddDiagnosticInfos");
		RemoveResults = decoder.ReadStatusCodeArray("RemoveResults");
		RemoveDiagnosticInfos = decoder.ReadDiagnosticInfoArray("RemoveDiagnosticInfos");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is SetTriggeringResponse setTriggeringResponse))
		{
			return false;
		}
		if (!Utils.IsEqual(m_responseHeader, setTriggeringResponse.m_responseHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_addResults, setTriggeringResponse.m_addResults))
		{
			return false;
		}
		if (!Utils.IsEqual(m_addDiagnosticInfos, setTriggeringResponse.m_addDiagnosticInfos))
		{
			return false;
		}
		if (!Utils.IsEqual(m_removeResults, setTriggeringResponse.m_removeResults))
		{
			return false;
		}
		if (!Utils.IsEqual(m_removeDiagnosticInfos, setTriggeringResponse.m_removeDiagnosticInfos))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (SetTriggeringResponse)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SetTriggeringResponse obj = (SetTriggeringResponse)base.MemberwiseClone();
		obj.m_responseHeader = (ResponseHeader)Utils.Clone(m_responseHeader);
		obj.m_addResults = (StatusCodeCollection)Utils.Clone(m_addResults);
		obj.m_addDiagnosticInfos = (DiagnosticInfoCollection)Utils.Clone(m_addDiagnosticInfos);
		obj.m_removeResults = (StatusCodeCollection)Utils.Clone(m_removeResults);
		obj.m_removeDiagnosticInfos = (DiagnosticInfoCollection)Utils.Clone(m_removeDiagnosticInfos);
		return obj;
	}
}
