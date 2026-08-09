using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class TranslateBrowsePathsToNodeIdsRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private BrowsePathCollection m_browsePaths;

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

	[DataMember(Name = "BrowsePaths", IsRequired = false, Order = 2)]
	public BrowsePathCollection BrowsePaths
	{
		get
		{
			return m_browsePaths;
		}
		set
		{
			m_browsePaths = value;
			if (value == null)
			{
				m_browsePaths = new BrowsePathCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.TranslateBrowsePathsToNodeIdsRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.TranslateBrowsePathsToNodeIdsRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.TranslateBrowsePathsToNodeIdsRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.TranslateBrowsePathsToNodeIdsRequest_Encoding_DefaultJson;

	public TranslateBrowsePathsToNodeIdsRequest()
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
		m_browsePaths = new BrowsePathCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteEncodeableArray("BrowsePaths", BrowsePaths.ToArray(), typeof(BrowsePath));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		BrowsePaths = (BrowsePath[])decoder.ReadEncodeableArray("BrowsePaths", typeof(BrowsePath));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is TranslateBrowsePathsToNodeIdsRequest translateBrowsePathsToNodeIdsRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, translateBrowsePathsToNodeIdsRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_browsePaths, translateBrowsePathsToNodeIdsRequest.m_browsePaths))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (TranslateBrowsePathsToNodeIdsRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		TranslateBrowsePathsToNodeIdsRequest obj = (TranslateBrowsePathsToNodeIdsRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_browsePaths = (BrowsePathCollection)Utils.Clone(m_browsePaths);
		return obj;
	}
}
