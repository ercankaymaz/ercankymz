using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class QueryNextRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private bool m_releaseContinuationPoint;

	private byte[] m_continuationPoint;

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

	[DataMember(Name = "ReleaseContinuationPoint", IsRequired = false, Order = 2)]
	public bool ReleaseContinuationPoint
	{
		get
		{
			return m_releaseContinuationPoint;
		}
		set
		{
			m_releaseContinuationPoint = value;
		}
	}

	[DataMember(Name = "ContinuationPoint", IsRequired = false, Order = 3)]
	public byte[] ContinuationPoint
	{
		get
		{
			return m_continuationPoint;
		}
		set
		{
			m_continuationPoint = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.QueryNextRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.QueryNextRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.QueryNextRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.QueryNextRequest_Encoding_DefaultJson;

	public QueryNextRequest()
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
		m_releaseContinuationPoint = true;
		m_continuationPoint = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteBoolean("ReleaseContinuationPoint", ReleaseContinuationPoint);
		encoder.WriteByteString("ContinuationPoint", ContinuationPoint);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		ReleaseContinuationPoint = decoder.ReadBoolean("ReleaseContinuationPoint");
		ContinuationPoint = decoder.ReadByteString("ContinuationPoint");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is QueryNextRequest queryNextRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, queryNextRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_releaseContinuationPoint, queryNextRequest.m_releaseContinuationPoint))
		{
			return false;
		}
		if (!Utils.IsEqual(m_continuationPoint, queryNextRequest.m_continuationPoint))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (QueryNextRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		QueryNextRequest obj = (QueryNextRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_releaseContinuationPoint = (bool)Utils.Clone(m_releaseContinuationPoint);
		obj.m_continuationPoint = (byte[])Utils.Clone(m_continuationPoint);
		return obj;
	}
}
