using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class BrowseNextRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private bool m_releaseContinuationPoints;

	private ByteStringCollection m_continuationPoints;

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

	[DataMember(Name = "ReleaseContinuationPoints", IsRequired = false, Order = 2)]
	public bool ReleaseContinuationPoints
	{
		get
		{
			return m_releaseContinuationPoints;
		}
		set
		{
			m_releaseContinuationPoints = value;
		}
	}

	[DataMember(Name = "ContinuationPoints", IsRequired = false, Order = 3)]
	public ByteStringCollection ContinuationPoints
	{
		get
		{
			return m_continuationPoints;
		}
		set
		{
			m_continuationPoints = value;
			if (value == null)
			{
				m_continuationPoints = new ByteStringCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.BrowseNextRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.BrowseNextRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.BrowseNextRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.BrowseNextRequest_Encoding_DefaultJson;

	public BrowseNextRequest()
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
		m_releaseContinuationPoints = true;
		m_continuationPoints = new ByteStringCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteBoolean("ReleaseContinuationPoints", ReleaseContinuationPoints);
		encoder.WriteByteStringArray("ContinuationPoints", ContinuationPoints);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		ReleaseContinuationPoints = decoder.ReadBoolean("ReleaseContinuationPoints");
		ContinuationPoints = decoder.ReadByteStringArray("ContinuationPoints");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is BrowseNextRequest browseNextRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, browseNextRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_releaseContinuationPoints, browseNextRequest.m_releaseContinuationPoints))
		{
			return false;
		}
		if (!Utils.IsEqual(m_continuationPoints, browseNextRequest.m_continuationPoints))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (BrowseNextRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BrowseNextRequest obj = (BrowseNextRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_releaseContinuationPoints = (bool)Utils.Clone(m_releaseContinuationPoints);
		obj.m_continuationPoints = (ByteStringCollection)Utils.Clone(m_continuationPoints);
		return obj;
	}
}
