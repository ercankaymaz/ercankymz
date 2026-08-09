using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class HistoryUpdateRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private ExtensionObjectCollection m_historyUpdateDetails;

	[DataMember(Name = "RequestHeader", IsRequired = false, Order = 1)]
	public RequestHeader RequestHeader
	{
		get
		{
			return m_requestHeader;
		}
		set
		{
			m_requestHeader = value;
			if (value == null)
			{
				m_requestHeader = new RequestHeader();
			}
		}
	}

	[DataMember(Name = "HistoryUpdateDetails", IsRequired = false, Order = 2)]
	public ExtensionObjectCollection HistoryUpdateDetails
	{
		get
		{
			return m_historyUpdateDetails;
		}
		set
		{
			m_historyUpdateDetails = value;
			if (value == null)
			{
				m_historyUpdateDetails = new ExtensionObjectCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.HistoryUpdateRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.HistoryUpdateRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.HistoryUpdateRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.HistoryUpdateRequest_Encoding_DefaultJson;

	public HistoryUpdateRequest()
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
		m_requestHeader = new RequestHeader();
		m_historyUpdateDetails = new ExtensionObjectCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteExtensionObjectArray("HistoryUpdateDetails", HistoryUpdateDetails);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		HistoryUpdateDetails = decoder.ReadExtensionObjectArray("HistoryUpdateDetails");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is HistoryUpdateRequest historyUpdateRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, historyUpdateRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_historyUpdateDetails, historyUpdateRequest.m_historyUpdateDetails))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (HistoryUpdateRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		HistoryUpdateRequest obj = (HistoryUpdateRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_historyUpdateDetails = (ExtensionObjectCollection)Utils.Clone(m_historyUpdateDetails);
		return obj;
	}
}
