using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class CancelRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private uint m_requestHandle;

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

	[DataMember(Name = "RequestHandle", IsRequired = false, Order = 2)]
	public uint RequestHandle
	{
		get
		{
			return m_requestHandle;
		}
		set
		{
			m_requestHandle = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.CancelRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.CancelRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.CancelRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.CancelRequest_Encoding_DefaultJson;

	public CancelRequest()
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
		m_requestHandle = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteUInt32("RequestHandle", RequestHandle);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		RequestHandle = decoder.ReadUInt32("RequestHandle");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is CancelRequest cancelRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, cancelRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHandle, cancelRequest.m_requestHandle))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (CancelRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		CancelRequest obj = (CancelRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_requestHandle = (uint)Utils.Clone(m_requestHandle);
		return obj;
	}
}
