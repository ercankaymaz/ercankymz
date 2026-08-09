using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class WriteRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private WriteValueCollection m_nodesToWrite;

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

	[DataMember(Name = "NodesToWrite", IsRequired = false, Order = 2)]
	public WriteValueCollection NodesToWrite
	{
		get
		{
			return m_nodesToWrite;
		}
		set
		{
			m_nodesToWrite = value;
			if (value == null)
			{
				m_nodesToWrite = new WriteValueCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.WriteRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.WriteRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.WriteRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.WriteRequest_Encoding_DefaultJson;

	public WriteRequest()
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
		m_nodesToWrite = new WriteValueCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteEncodeableArray("NodesToWrite", NodesToWrite.ToArray(), typeof(WriteValue));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		NodesToWrite = (WriteValue[])decoder.ReadEncodeableArray("NodesToWrite", typeof(WriteValue));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is WriteRequest writeRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, writeRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodesToWrite, writeRequest.m_nodesToWrite))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (WriteRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		WriteRequest obj = (WriteRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_nodesToWrite = (WriteValueCollection)Utils.Clone(m_nodesToWrite);
		return obj;
	}
}
